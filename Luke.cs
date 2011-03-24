using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Resources;
using System.Reflection;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;

using Lucene.Net.Analysis; 
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Store;

using Lucene.Net.LukeNet.Plugins;
using System.Collections.Generic;

namespace Lucene.Net.LukeNet
{
	/// <summary>
	/// This class allows you to browse a <a href="jakarta.apache.org/lucene">Lucene</a>
	/// index in several ways - by document, by term, by query, and by most frequent terms.
	/// </summary>
	public partial class Luke : System.Windows.Forms.Form
	{
		
		#region Fields
		private string lukeURL = "http://www.getopt.org/luke";

		private Progress progressDlg;
		private Query query;
		private int[] searchedDocIds;
		private string indexPath;
		private Preferences p;
		private ArrayList plugins = new ArrayList();
		private Document document;
		private Term term;
		private TermDocs termDocs;
		private bool readOnly;
		private FSDirectory dir;
		//private IndexSearcher searcher;
		private IndexReader indexReader;
		//private Hashtable fieldNames;
		private Analyzer stdAnalyzer = new StandardAnalyzer();
		private Analyzer analyzer;
		private QueryParser queryParser;
		private String[] indexFields;
		private bool useCompound;
		private int numTerms;
		private SortedList analyzers = new SortedList(); // Name -> Type
		private Type[] defaultAnalyzers = 
			{
//				typeof(Lucene.Net.Analysis.De.GermanAnalyzer),
//				typeof(Lucene.Net.Analysis.Ru.RussianAnalyzer),
				typeof(Lucene.Net.Analysis.SimpleAnalyzer),
				typeof(Lucene.Net.Analysis.Standard.StandardAnalyzer),
				typeof(Lucene.Net.Analysis.StopAnalyzer),
				typeof(Lucene.Net.Analysis.WhitespaceAnalyzer)
			};
		private System.Windows.Forms.ColumnHeader columnHeaderBoost;
		private System.Windows.Forms.TextBox textParsed;
				
		private ResourceManager resources = new ResourceManager
			(
				typeof(Luke).Namespace + ".Messages",
				Assembly.GetAssembly(typeof(Luke))
			);		    
		#endregion Fields
		
		#region Constructors
		public Luke()
		{
			InitializeComponent();

			p = new Preferences();
			p.Load();

			for(int i = 0; i <= 999999; i++)
				domainTerms.Items.Add(i);
			
			domainTerms.SelectedIndex = 50;
			
			SetOverviewContextMenuItems();
		}
		#endregion Constructors
		
		#region Cleanup 
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			
			if (indexReader != null) 
				try 
				{
					indexReader.Close();
				} 
				catch(Exception) {};
				
			if (dir != null) 
				try 
				{
					dir.Close();
				} 
				catch(Exception) {};

			if (p != null)
				try
				{ p.Save();}
				catch(Exception){}
			
			base.Dispose( disposing );
		}
		#endregion Cleanup 

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Luke());
		}


		#region Luke Events	
		private void Luke_Load(object sender, System.EventArgs e)
		{
			OpenIndex openIndexDlg = new OpenIndex(p);
			if (openIndexDlg.ShowDialog(this) == DialogResult.OK)
				LukeInit(openIndexDlg);
			else Close();
		}
		
		private void statusBar_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
		{
			if (e.StatusBarPanel == statusBarPanelLogo)
				System.Diagnostics.Process.Start(lukeURL);
		}

		private void domainTerms_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				domainTerms.SelectedIndex = Convert.ToInt32(domainTerms.Text);
			}
			catch(FormatException)
			{}
		}

		private void textTerm_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar((int) Keys.Enter))
			{
				if (indexReader == null) 
				{
					ShowStatus(resources.GetString("NoIndex"));
					return;
				}

				try 
				{
					String text = textTerm.Text;
					String field = comboTerms.Text;
            
					if (text == null || text == string.Empty) 
						return;

					Term t = new Term(field, text);
					_ShowTerm(t);
				} 
				catch (Exception exc) 
				{
					ShowStatus(exc.Message);
				}
			}
		}

		private void textDocNum_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar((int) Keys.Enter))
				_ShowDoc(0);
		}

		private void listSearch_DoubleClick(object sender, System.EventArgs e)
		{
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}

			if (listSearch.SelectedItems == null ||
				listSearch.SelectedItems.Count == 0) 
				return;

			Document doc;
			int docId;
			try
			{
				docId = Int32.Parse(listSearch.SelectedItems[0].SubItems[1].Text);

				doc = indexReader.Document(docId);
			} 
			catch (Exception exc) 
			{
				ShowStatus(exc.Message);
				return;
			}

			_ShowDocFields(docId, doc);
			
			tabControl.SelectedTab = tabDocuments;
		}

		private void listTerms_DoubleClick(object sender, System.EventArgs e)
		{
			contextMenuItemBrowse_Click(sender, e);
		}

		private void listTerms_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			listTerms.ListViewItemSorter = new ListViewItemComparer(e.Column);
			listTerms.Sort();
		}
		private void listSearch_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			listSearch.ListViewItemSorter = new ListViewItemComparer(e.Column);
			listSearch.Sort();
		}
		private void listDocFields_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			listDocFields.ListViewItemSorter = new ListViewItemComparer(e.Column);
			listDocFields.Sort();
		}

		private void tabControl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (tabControl.SelectedTab == tabOverview)
				SetOverviewContextMenuItems();
			else if (tabControl.SelectedTab == tabDocuments)
				SetDocumentsContextMenuItems();
		}
		#endregion Luke Events
		
		#region Resizing
		private void tabDocuments_Resize(object sender, System.EventArgs e)
		{
			ResizeLastListColumn(listDocFields);
		}

		private void tabOverview_Resize(object sender, System.EventArgs e)
		{
			ResizeLastListColumn(listTerms);
		}

		private void ResizeLastListColumn(ListView list)
		{
			int width = list.Width;
			for (int i = 0; i < list.Columns.Count - 1; i++)
			{
				width -= list.Columns[i].Width;
			}
			list.Columns[list.Columns.Count - 1].Width = width - 4;
		
		}
		#endregion Resizing
		
		#region Buttons
		private void buttonPrevDoc_Click(object sender, System.EventArgs e)
		{
			ShowStatus("");
			_ShowDoc(-1);
		}

		private void buttonNextDoc_Click(object sender, System.EventArgs e)
		{
			ShowStatus("");
			_ShowDoc(+1);
		}

		private void buttonTopTerms_Click(object sender, System.EventArgs e)
		{
			ShowStatus("");
			ShowTopTerms();
		}		

		private void buttonFirstTerm_Click(object sender, System.EventArgs e)
		{
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}
			try 
			{
				TermEnum te = indexReader.Terms();
				te.Next();
				Term t = te.Term();
				_ShowTerm(t);
			} 
			catch (Exception exc) 
			{
				ShowStatus(exc.Message);
			}
		}

		private void buttonNextTerm_Click(object sender, System.EventArgs e)
		{
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}
			try 
			{
				String text = textTerm.Text;
				String field = comboTerms.Text;

				TermEnum te;

				if (text == null || text == string.Empty) 
					te = indexReader.Terms();
				else 
					te = indexReader.Terms(new Term(field, text));

				te.Next();
				Term t = te.Term();

				_ShowTerm(t);
			}
			catch (Exception exc) 
			{
				ShowStatus(exc.Message);
			}
		}

		private void buttonDelete_Click(object sender, System.EventArgs e)
		{
			int docid = 0;
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}
			if (readOnly) 
			{
				ShowStatus(resources.GetString("Readonly"));
				return;
			}
			try 
			{
				docid = Int32.Parse(textDocNum.Text);
				
				_ShowDoc(+1);
				indexReader.DeleteDocument(docid);
				InitOverview();
			} 
			catch (Exception exc) 
			{
				ShowStatus(exc.Message);
			}
		}

		private void buttonShowFirstDoc_Click(object sender, System.EventArgs e)
		{
			if (term == null) return;
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}
			try 
			{
				termDocs = indexReader.TermDocs(term);
				termDocs.Next();
				labelDocNum.Text = "1";

				_ShowTermDoc(termDocs);
			} 
			catch (Exception exc) 
			{
				ShowStatus(exc.Message);
			}
		}

		private void buttonShowNextDoc_Click(object sender, System.EventArgs e)
		{
			if (term == null) return;
			
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}
			try 
			{
				if (termDocs == null) 
				{
					buttonShowFirstDoc_Click(sender, e);
					return;
				}
				
				if (!termDocs.Next()) return;
				
				int cnt = 1;
				try 
				{
					cnt = Int32.Parse(labelDocNum.Text);
				} 
				catch(Exception) {};
				
				labelDocNum.Text = (cnt + 1).ToString();
				
				_ShowTermDoc(termDocs);
			} 
			catch (Exception exc) 
			{
				ShowStatus(exc.Message);
			}
		}

		private void buttonShowAllDocs_Click(object sender, System.EventArgs e)
		{
			if (term == null) return;
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}
			
			tabControl.SelectedTab = tabSearch;

			textSearch.Text = term.Field() + ":" + term.Text();

			Query q = new TermQuery(term);
			textParsed.Text = q.ToString();

			IndexSearcher searcher = null;
			try 
			{
				searcher = new IndexSearcher(dir);

				listSearch.BeginUpdate();
				listSearch.Items.Clear();
				listSearch.EndUpdate();
				
				_Search(q, searcher);
			} 
			catch (Exception exc) 
			{
				ErrorMessage(exc.Message);
			} 
			finally 
			{
				if (searcher != null) try {searcher.Close();} 
								catch (Exception) {};
			}
		}

		private void buttonDeleteAllDocs_Click(object sender, System.EventArgs e)
		{
			if (term == null) return;
			
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}
			
			if (readOnly) 
			{
				ShowStatus(resources.GetString("Readonly"));
				return;
			}
			try 
			{
				buttonShowNextDoc_Click(sender, e);
				indexReader.DeleteDocuments(term);
			} 
			catch (Exception exc) 
			{
				ShowStatus(exc.Message);
			}
			finally
			{
				listDocFields.BeginUpdate();
				listDocFields.Items.Clear();
				listDocFields.EndUpdate();
			}
			InitOverview();
		}

		private void buttonSearch_Click(object sender, System.EventArgs e)
		{
			Search();
		}

		private void buttonSearchDelete_Click(object sender, System.EventArgs e)
		{
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}
			if (readOnly) 
			{
				ShowStatus(resources.GetString("Readonly"));
				return;
			}
			
			try
			{
				foreach(ListViewItem item in listSearch.SelectedItems)
				{
					int docId = Int32.Parse(item.SubItems[1].Text);
					indexReader.DeleteDocument(docId);
					listSearch.Items.Remove(item);
				}
			}
			catch(Exception exc)
			{
				ShowStatus(exc.Message);
			}
			InitOverview();
		}

		private void btnExplain_Click(object sender, System.EventArgs e)
		{
			if (listSearch.SelectedItems.Count == 0) return;
			if (searchedDocIds == null || searchedDocIds.Length < listSearch.Items.Count) return;

			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}

			if (query == null) return;

			IndexSearcher searcher = null;
			try 
			{
				searcher = new IndexSearcher(dir);
				Lucene.Net.Search.Explanation expl = searcher.Explain(query, searchedDocIds[listSearch.SelectedIndices[0]]);
				ExplanationDialog explDialog = new ExplanationDialog(expl);
				explDialog.ShowDialog(this);
			} 
			catch (Exception exc) 
			{
				ErrorMessage(exc.Message);
			}
			finally
			{
				searcher.Close();
			}
		}
		private void btnUpdateParsedQuery_Click(object sender, System.EventArgs e)
		{
			QueryParser qp = CreateQueryParser();
			String queryS = textSearch.Text;

			if (queryS.Trim() == "")
			{
				textParsed.Enabled = false;
				textParsed.Text = resources.GetString("EmptyQuery");
				return;
			}
			textParsed.Enabled = true;

			try 
			{
				Query q = qp.Parse(queryS);
				textParsed.Text = q.ToString();
			} 
			catch (Exception exc) 
			{
				textParsed.Text = exc.Message;
			}
		}
		private void btnTermVector_Click(object sender, System.EventArgs e)
		{
			ShowTV();		
		}

		#endregion Buttons

		#region Clipboard
		private void buttonCopySelected_Click(object sender, System.EventArgs e)
		{
			if (listDocFields.SelectedItems == null || 
				listDocFields.SelectedItems.Count == 0)
				return;

			if (document == null) return;

			StringBuilder copyText = new StringBuilder();
			
			bool store = false, 
				index = false, 
				token = false,
				tvf = false;
			float boost;

			int i = 0;
			foreach(ListViewItem item in listDocFields.SelectedItems)
			{
				boost = 0;
				if (i++ > 0) copyText.Append(Environment.NewLine);
				
				if (item.SubItems[1].Text == "+")
					index = true;
				else
					index = false;
				if (item.SubItems[2].Text == "+")
					token = true;
				else
					token = false;
				if (item.SubItems[3].Text == "+")
					store = true;
				else
					store = false;
				if (item.SubItems[4].Text == "+")
					tvf = true;
				else
					tvf = false;
				try
				{
					boost = Single.Parse(item.SubItems[5].Text, NumberFormatInfo.InvariantInfo);
				}
				catch(Exception){}
					
				Field field = Legacy.CreateField(item.SubItems[0].Text.Trim().Substring(1, item.SubItems[0].Text.Trim().Length - 2), 
					item.SubItems[item.SubItems.Count-1].Text,
					store,
					index,
					token,
					tvf);
				field.SetBoost(boost);
										
				copyText.Append(field.ToString());
        
			}
        
			Clipboard.SetDataObject(copyText.ToString());
		}

		private void buttonCopyAll_Click(object sender, System.EventArgs e)
		{
			if (document == null) return;
			
			StringBuilder copyText = new StringBuilder();
			int i = 0;
			bool store = false, 
				index = false, 
				token = false,
				tvf = false;
			float boost;
			
			foreach(ListViewItem item in listDocFields.Items)
			{
				boost = 0;

				if (item.SubItems[1].Text == "+")
					index = true;
				else
					index = false;
				if (item.SubItems[2].Text == "+")
					token = true;
				else
					token = false;
				if (item.SubItems[3].Text == "+")
					store = true;
				else
					store = false;
				if (item.SubItems[4].Text == "+")
					tvf = true;
				else
					tvf = false;
				try
				{
					boost = Single.Parse(item.SubItems[5].Text, NumberFormatInfo.InvariantInfo);
				}
				catch(Exception){}
	
				if (!index && ! token && !store && ! tvf &&
					item.SubItems[item.SubItems.Count-1].Text == resources.GetString("FieldNotAvailable"))
					continue;

				if (i++ > 0) copyText.Append(Environment.NewLine);

				Field field = Legacy.CreateField(item.SubItems[0].Text.Trim().Substring(1, item.SubItems[0].Text.Trim().Length - 2), 
					item.SubItems[item.SubItems.Count-1].Text,
					store,
					index,
					token,
					tvf);
				field.SetBoost(boost);
										
				copyText.Append(field.ToString());

			}

			Clipboard.SetDataObject(copyText.ToString());
		}

		#endregion Clipboard

		#region Menu Events
		private void menuItemExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void menuItemOptimize_Click(object sender, System.EventArgs e)
		{
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}
			if (readOnly) 
			{
				ShowStatus(resources.GetString("Readonly"));
				return;
			}
			
			try 
			{
				indexReader.Close();
				IndexWriter writer = new IndexWriter(dir, 
					new WhitespaceAnalyzer(), 
					false);
				writer.SetUseCompoundFile(useCompound);
				long startSize = CalcTotalFileSize(dir);
				DateTime startTime = DateTime.Now;
				writer.Optimize();
				DateTime endTime = DateTime.Now;
				long endSize = CalcTotalFileSize(dir);
				long deltaSize = startSize - endSize;
				String sign = deltaSize < 0 ? " Increased " : " Reduced ";
				String sizeMsg = sign + NormalizeSize(Math.Abs(deltaSize)) + NormalizeUnit(Math.Abs(deltaSize));
				String timeMsg = ((TimeSpan)(endTime - startTime)).TotalMilliseconds + " ms";
				ShowStatus(sizeMsg + " in " + timeMsg);
				ShowFiles(dir);
				writer.Close();
				indexReader = IndexReader.Open(dir);
				
				InitOverview();
			} 
			catch (Exception exc) 
			{
				ShowStatus(exc.Message);
			}		
		}

		private void menuItemAbout_Click(object sender, System.EventArgs e)
		{
			About a = new About();
			a.ShowDialog(this);
		}

		private void OnOpenIndex(object sender, System.EventArgs e)
		{
			OpenIndex openIndexDlg = new OpenIndex(p);
			if (openIndexDlg.ShowDialog(this) == DialogResult.OK)
				LukeInit(openIndexDlg);
		}

		private void contextMenuItemShowAll_Click(object sender, System.EventArgs e)
		{
			if (listTerms.SelectedItems == null) return;

			ListViewItem selItem = listTerms.SelectedItems[0];
			if (selItem == null) return;

			string field = selItem.SubItems[2].Text.Trim().Substring(1, selItem.SubItems[2].Text.Trim().Length - 2);
			string text = selItem.SubItems[3].Text;
			
			if(field == null || text == null)
				return;
			
			Term t = new Term(field, text);

			tabControl.SelectedTab = tabSearch;
			
			textSearch.Text = t.Field() + ":" + t.Text();
			Search();
		}

		private void contextMenuItemBrowse_Click(object sender, System.EventArgs e)
		{
			if (listTerms.SelectedItems == null) return;

			ListViewItem selItem = listTerms.SelectedItems[0];
			if (selItem == null) return;
			
			string field = selItem.SubItems[2].Text.Trim().Substring(1, selItem.SubItems[2].Text.Trim().Length - 2);
			string text = selItem.SubItems[3].Text;
			
			if(field == null || text == null)
				return;
			
			Term t = new Term(field, text);
			
			tabControl.SelectedTab = tabDocuments;
			_ShowTerm(t);
		}

		private void contextMenuItemShowTV_Click(object sender, System.EventArgs e)
		{
			ShowTV();
		}

		private void menuItemCompound_Click(object sender, System.EventArgs e)
		{
			menuItemCompound.Checked = !menuItemCompound.Checked;
			useCompound = menuItemCompound.Checked;
			p.UseCompound = useCompound;		
		}

		private void menuItemUndelete_Click(object sender, System.EventArgs e)
		{
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}
			if (readOnly) 
			{
				ShowStatus(resources.GetString("Readonly"));
				return;
			}
			try 
			{
				indexReader.UndeleteAll();
				InitOverview();
			} 
			catch (Exception exc) 
			{
				ErrorMessage(exc.Message);
			}
		}

		#endregion Menu Events
		
		#region Properties
		public IndexReader IndexReader
		{
			get
			{ return indexReader; }
			set
			{ indexReader = value; }
		}

		private string IndexName
		{
			set
			{ 
				labelName.Text = value; 
				statusBar.Panels[0].Text = resources.GetString("StatusIndexName") + value;
			}
		}
		private string IndexVersion
		{
			set
			{ 
				labelVersion.Text = value; 
			}
		}
		private string HasDeletions
		{
			set
			{ 
				labelDeletions.Text = value; 
			}
		}
		
		private int DocumentsNumber
		{
			set
			{
				labelDocs.Text = value.ToString();
				labelIndDocs.Text = (value-1).ToString();
			}
		}
		
		private int TermsNumber
		{
			set
			{
				numTerms = value;
				labelTerms.Text = value.ToString(); 
			}
		}
		
		private long LastModified
		{
			set
			{
				labelMod.Text = new DateTime(value * TimeSpan.TicksPerMillisecond).AddYears(1969).ToLocalTime().ToString(); 
			}
		}
		#endregion Properties
		
		#region Private Methods
		private void ShowTV()
		{
			if (listDocFields.SelectedItems.Count == 0) return;
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}

			int docId;
			try
			{
				docId = Int32.Parse(textDocNum.Text);
			}
			catch(Exception)
			{
				ShowStatus(resources.GetString("DocNotSelected"));
				return;
			}

			try 
			{

				string fieldName = listDocFields.SelectedItems[0].SubItems[0].Text;
				fieldName = fieldName.Substring(1, fieldName.Length-2);
				TermFreqVector tfv = indexReader.GetTermFreqVector(docId, fieldName);
				if (tfv == null) 
				{
					ShowStatus(resources.GetString("NoTV"));
					return;
				}

				TermVector tvDialog = new TermVector(fieldName, tfv);
				tvDialog.ShowDialog(this);
			} 
			catch (Exception exc) 
			{
				ShowStatus(exc.Message);
			}
		}
		internal void PopulateAnalyzers(ComboBox cbAnalyzers) 
		{
			cbAnalyzers.BeginUpdate();
			cbAnalyzers.Items.Clear();

			string[] aNames = new String[analyzers.Count];
			analyzers.Keys.CopyTo(aNames, 0);
			cbAnalyzers.Items.AddRange(aNames);
			cbAnalyzers.EndUpdate();
		}
    
		public IDictionary GetAnalyzers() 
		{
			return analyzers;
		}
    
		internal void InitOverview()
		{
			// populate analyzers
			PopulateAnalyzers(comboAnalyzer);

			IndexName = indexPath + (readOnly ? " (R)" : "");
				
			DocumentsNumber = indexReader.NumDocs();
				
			SetFieldNames(indexReader.GetFieldNames(IndexReader.FieldOption.ALL));
									
			TermEnum termsEnum = indexReader.Terms();
			int i = 0;
			while (termsEnum.Next()) i++;
			termsEnum.Close();
				
			TermsNumber = i;
			IndexVersion = IndexReader.GetCurrentVersion(dir).ToString();
			HasDeletions = indexReader.HasDeletions().ToString();

			LastModified = IndexReader.LastModified(dir);

			ShowTopTerms();
		}
   		private void SetOverviewContextMenuItems()
		{
			contextMenu.MenuItems.Clear();

			contextMenuItemBrowse = new MenuItem(resources.GetString("MenuBrowse"));
			contextMenuItemBrowse.Click += new EventHandler(contextMenuItemBrowse_Click);
			contextMenu.MenuItems.Add(contextMenuItemBrowse);
			
			contextMenuItemShowAll = new MenuItem(resources.GetString("MenuShowAll"));
			contextMenuItemShowAll.Click += new EventHandler(contextMenuItemShowAll_Click);
			contextMenu.MenuItems.Add(contextMenuItemShowAll);		
		}

		private void SetDocumentsContextMenuItems()
		{
			contextMenu.MenuItems.Clear();

			contextMenuItemShowTV = new MenuItem(resources.GetString("MenuShowTV"));
			contextMenuItemShowTV.Click += new EventHandler(contextMenuItemShowTV_Click);
			contextMenu.MenuItems.Add(contextMenuItemShowTV);			
		}

		private void LukeInit(OpenIndex openIndexDlg)
		{		
			indexPath = openIndexDlg.Path;
			readOnly = openIndexDlg.ReadOnlyIndex;
			bool force = openIndexDlg.UnlockIndex;
			
			if (indexPath == String.Empty || 
				!IndexReader.IndexExists(indexPath)) 
			{
				ErrorMessage(resources.GetString("InvalidPath"));  
				return;
			}	
			
			if (dir != null) 
			{
				try 
				{
					if (indexReader != null) 
						indexReader.Close();
				} 
				catch(Exception) {};
				try 
				{
					dir.Close();
				} 
				catch(Exception) {};
			}
			
			try 
			{
				p.AddToMruList(indexPath);

				dir = FSDirectory.GetDirectory(indexPath, false);
				if (IndexReader.IsLocked(dir)) 
				{
					if (readOnly) 
					{
						ShowStatus(resources.GetString("IndexLockedRo"));
						dir.Close();
						return;
					}
					if (force) 
					{
						IndexReader.Unlock(dir);
					} 
					else 
					{
						ShowStatus(resources.GetString("IndexLocked"));
						dir.Close();
						return;
					}
				}

				// files tab
				ShowFiles(dir);

				indexReader = IndexReader.Open(dir);

				menuItemCompound.Checked = p.UseCompound;

				// load analyzers
				try 
				{
					
					Type[] analyzerTypes=null;
					try {
						analyzerTypes = Lucene.Net.LukeNet.ClassFinder.ClassFinder.GetInstantiableSubtypes(typeof(Lucene.Net.Analysis.Analyzer));
					}
					catch(Exception) {}

					if (analyzerTypes == null || analyzerTypes.Length == 0)
					{
						// using default
						foreach (Type t in defaultAnalyzers)
							analyzers[t.FullName] = t;
					}
					else
					{
						foreach (Type aType in analyzerTypes)
							analyzers[aType.FullName] = aType;
					}
				}
				catch(Exception e){
					ErrorMessage(e.Message);
				}

				// plugins tab
				LoadPlugins();
				InitPlugins();

				// overview tab
				InitOverview();
				
				// search tab
				// Remove columns
				listSearch.BeginUpdate();

				while(listSearch.Columns.Count > 2)
				{
					listSearch.Columns.RemoveAt(2);
				}
				
				foreach (string field in indexFields) 
				{
					listSearch.Columns.Add(field, 200, HorizontalAlignment.Left);
				}
				listSearch.EndUpdate();
				
				ShowStatus(resources.GetString("IndexOpened"));
			} 
			catch (Exception e) 
			{
				ErrorMessage(e.Message);
			}			
		}

		internal void ErrorMessage(string msg)
		{
			MessageBox.Show(this,
							msg,
							resources.GetString("Error"),
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);
		}

		delegate void ShowStatusDelegate(string message);
		/// <summary>
		/// Updates status. Possibly async
		/// </summary>
		internal void ShowStatus(string message)
		{
			if (!statusBar.InvokeRequired)
				statusBar.Panels[1].Text = message;
			else
			{
				// Show status asynchronously
				ShowStatusDelegate showStatus = new ShowStatusDelegate(ShowStatus);
				BeginInvoke(showStatus, new object[] {message});
			}
		}
		
		private void SetFieldNames(ICollection<string> names)
		{
			indexFields = new String[names.Count];
			labelFields.Text = names.Count.ToString();

			int i = 0;
				
			listFields.BeginUpdate();
			listFields.Items.Clear();
			comboFields.Items.Clear();
			comboTerms.Items.Clear();
			
            foreach(string name in names)
            {
                // skip empty field
                    listFields.Items.Add(new ListViewItem("<" + name + ">"));
                    comboFields.Items.Add(name);
                    comboTerms.Items.Add(name);
                    indexFields[i++] = name;
            }

			listFields.EndUpdate();
			comboFields.SelectedIndex = 0;
			comboTerms.SelectedIndex = 0;		
		}
		
		private void Search()
		{
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}

			Cursor.Current = Cursors.WaitCursor;
			
			queryParser = CreateQueryParser();
			
			
			string queryString = textSearch.Text;
			if (queryString == string.Empty) 
			{
				ShowStatus(resources.GetString("EmptyQuery"));
				return;
			}
				
			IndexSearcher searcher = null;

			listSearch.BeginUpdate();
			listSearch.Items.Clear();
			
			listSearch.EndUpdate();
			try
			{
				Query q = queryParser.Parse(queryString);

				if (searcher != null) searcher.Close();
				searcher = new IndexSearcher(dir);

				textParsed.Text =  q.ToString();
				_Search(q, searcher);
			} 
			catch (Exception e) 
			{
				ErrorMessage(e.Message);
			} 
			finally 
			{
				if (searcher != null) try {searcher.Close();} 
									  catch (Exception) {};
			}

			Cursor.Current = Cursors.Default;
		}

		private void _Search(Query q, IndexSearcher searcher)
		{
			DateTime start = DateTime.Now;
			Hits hits = searcher.Search(q);
			ShowStatus(((TimeSpan)(DateTime.Now - start)).TotalMilliseconds.ToString() + " ms");

			listSearch.BeginUpdate();
	
			try
			{
				if (hits == null || hits.Length() == 0) 
				{
					if (listSearch.Columns.Count < 3)
					{
						int width = listSearch.Width -
							listSearch.Columns[0].Width -
							listSearch.Columns[1].Width;
						listSearch.Columns.Add("", width, HorizontalAlignment.Left);
					}
					
					ListViewItem noResults = new ListViewItem();
					noResults.SubItems.AddRange(new String[]{"", resources.GetString("NoResults")});
					listSearch.Items.Add(noResults);

					labelSearchRes.Text = "0";
					return;
				}
				
				labelSearchRes.Text = hits.Length().ToString();
				
				searchedDocIds = new int[hits.Length()];

				for (int i = 0; i < hits.Length(); i++) 
				{
					ListViewItem item = new ListViewItem((Math.Round((double)1000 * hits.Score(i), 1) / 10).ToString());
					item.SubItems.Add(hits.Id(i).ToString());
				
					Document doc = hits.Doc(i);
					searchedDocIds[i] = hits.Id(i);
									
					for (int j = 0; j < indexFields.Length; j++) 
					{
						item.SubItems.Add(doc.Get(indexFields[j]));
					}
					
					listSearch.Items.Add(item);
				}
				query = q;
			}
			finally
			{
				listSearch.EndUpdate();
			}
		}

		private void ShowTopTerms() 
		{
			int nDoc = (int) domainTerms.SelectedItem;
			ListView.CheckedListViewItemCollection fields = listFields.CheckedItems;
			
			String[] selectedFields;
			if (fields == null || fields.Count == 0) 
			{
				selectedFields = indexFields;
			} 
			else 
			{
				selectedFields = new String[fields.Count];
				int i = 0;
				foreach (ListViewItem item in fields) 
				{
					// item.Text without "<", ">"
					selectedFields[i++] = item.Text.Substring(1, item.Text.Length - 2);
				}
			}

			try 
			{
				TermInfo[] termInfos = HighFreqTerms.GetHighFreqTerms(dir, null, nDoc, selectedFields);

				listTerms.BeginUpdate();
				listTerms.Items.Clear();
				
				if (termInfos == null || termInfos.Length == 0) 
				{
					ListViewItem noResults = new ListViewItem();
					noResults.SubItems.AddRange(new String[]{"", "", resources.GetString("NoResults")});
					listTerms.Items.Add(noResults);
					return;
				} 

				for (int i = 0; i < termInfos.Length; i++) 
				{
					ListViewItem item = new ListViewItem((i+1).ToString());
					item.SubItems.AddRange(
						new String[]{
							termInfos[i].DocFreq.ToString(), 
							" <" + termInfos[i].Term.Field() + "> ", 
							termInfos[i].Term.Text()});

					listTerms.Items.Add(item);
				}
			} 
			catch(Exception e) 
			{
				ErrorMessage(e.Message);
			}
			finally
			{
				listTerms.EndUpdate();
			}
		}

		private Document CreateDocument(int iNum)
		{
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return null;
			}
			
			if (iNum < 0 || iNum >= indexReader.NumDocs()) 
			{
				ShowStatus(resources.GetString("DocNumberRange"));
				return null;
			}

			if (!indexReader.IsDeleted(iNum)) 
				return indexReader.Document(iNum);
			else 
			{
				ShowStatus(resources.GetString("DocDeleted"));
				return null;
			}
		}
		private void _ShowDoc(int incr)
		{
			string num = textDocNum.Text;
			
			if (num == string.Empty) num = (-incr).ToString();
			
			try 
			{
				int iNum = Int32.Parse(num);
				iNum += incr;
				Document doc = CreateDocument(iNum);
				
				_ShowDocFields(iNum, doc);
			} 
			catch(Exception e) 
			{
				ShowStatus(e.Message);
			}		
		}
		private void _ShowDocFields(int docid, Document doc)
		{
			textDocNum.Text = docid.ToString();
			labelInfoDocNum.Text = docid.ToString();
			
			listDocFields.BeginUpdate();
			listDocFields.Items.Clear();
			
			document = doc;
			
			try
			{
				if (doc == null) return;
				for (int i = 0; i < indexFields.Length; i++) 
				{
					Field[] fields = doc.GetFields(indexFields[i]);
					if (fields == null) 
					{
						AddFieldRow(indexFields[i], null);
						continue;
					}
					for (int j = 0; j < fields.Length; j++) 
					{
						AddFieldRow(indexFields[i], fields[j]);
					}
				}
			}
			finally
			{
				listDocFields.EndUpdate();
			}
		}

		private void AddFieldRow(string fieldName, Field f)
		{
			string feature;
			ListViewItem item = new ListViewItem("<" + fieldName + ">");

			if (f != null && f.IsIndexed()) feature = "+";
			else feature = " ";
			item.SubItems.Add(feature);
					
			if (f != null && f.IsTokenized()) feature = "+";
			else feature = " ";
			item.SubItems.Add(feature);

			if (f != null && f.IsStored()) feature = "+";
			else feature = " ";		
			item.SubItems.Add(feature);

			if (f != null && f.IsTermVectorStored()) feature = "+";
			else feature = " ";		
			item.SubItems.Add(feature);

			if (f != null)
                item.SubItems.Add(f.GetBoost().ToString("0.0####"));
			else item.SubItems.Add("");

			if (f != null)
				item.SubItems.Add(f.StringValue());
			else 
			{
				item.SubItems.Add(resources.GetString("FieldNotAvailable"));
			}
			
			listDocFields.Items.Add(item);
		}

		private void _ShowTerm(Term t) 
		{    
			if (t == null) 
			{
				ShowStatus(resources.GetString("NoTerms"));
				return;            
			}
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}
			
			termDocs = null;
			this.term = t;
			comboTerms.SelectedItem = t.Field();
			textTerm.Text = t.Text();
			
			labelDocNum.Text = "?";
			labelTermFreq.Text = "?";

			try 
			{
				int freq = indexReader.DocFreq(t);
				labelDocFreq.Text = freq.ToString();
				labelDocMax.Text = freq.ToString();
			} 
			catch (Exception e) 
			{
				ShowStatus(e.Message);
				labelDocFreq.Text = "?";
			}
		}

		private void _ShowTermDoc(TermDocs td)
		{
			if (indexReader == null) 
			{
				ShowStatus(resources.GetString("NoIndex"));
				return;
			}
			try 
			{
				Document doc = indexReader.Document(td.Doc());
				
				labelDocNum.Text = td.Doc().ToString();
				labelTermFreq.Text = td.Freq().ToString();

				_ShowDocFields(td.Doc(), doc);                
			} 
			catch (Exception e) 
			{
				ShowStatus(e.Message);
			}
		}
		public Analyzer AnalyzerForName(string analyzerName)
		{
			try
			{
				// Trying to create type from executing assembly
				Type analyzerType = (Type)analyzers[analyzerName];
				
				if (null == analyzerType)
				{
					// Trying to create type from Lucene.Net assembly
					Assembly a = Assembly.GetAssembly(typeof(Lucene.Net.Analysis.Analyzer));
					analyzerType  = a.GetType(analyzerName);
				}

				// Trying to create with default constructor
				return (Analyzer) Activator.CreateInstance(analyzerType);
			}
			catch(Exception)
			{return null; }
		}

		private QueryParser CreateQueryParser()
		{
			string analyzerName = (string) comboAnalyzer.SelectedItem;
			if (null == analyzerName || analyzerName == string.Empty) 
			{
				analyzerName = "Lucene.Net.Luca.Analysis.Standard.StandardAnalyzer";
				comboAnalyzer.SelectedItem = analyzerName;
			}
			
			analyzer = AnalyzerForName(analyzerName);
			if (null == analyzer)
			{
				ErrorMessage(string.Format(resources.GetString("AnalyzerNotFound"), analyzerName));
				analyzer = stdAnalyzer;
			}

			string defField = (string) comboFields.SelectedItem;
			if (defField == null || defField == string.Empty) 
			{
				defField = indexFields[0];
				comboFields.SelectedItem = analyzerName;
			}
			
			return  new QueryParser(defField, analyzer);
		}
		#endregion Private Methods

		#region Plugins
		private void LoadPlugins() 
		{
			Hashtable pluginTypes = new Hashtable();
			// try to find all plugins
			try 
			{
				Type[] types =
					Lucene.Net.LukeNet.ClassFinder.ClassFinder.GetInstantiableSubtypes(typeof(Lucene.Net.LukeNet.Plugins.LukePlugin));
				foreach(Type type in types)
				{
					pluginTypes.Add(type, null);
				}
			} 
			catch (Exception) {}

			// load plugins declared in the ".plugins" file
			try 
			{
				StreamReader reader = new StreamReader(".plugins");
				string line;
				while ((line = reader.ReadLine()) != null) 
				{
					if (line.StartsWith("#")) continue;
					if (line.Trim().Equals("")) continue;

					Type t = Type.GetType(line, false);
					if (t.IsSubclassOf(typeof(LukePlugin)) && !pluginTypes.Contains(t)) 
					{
						pluginTypes.Add(t, null);
					}
				}
			} 
			catch (IOException) 
			{}

			foreach (Type pluginType in pluginTypes.Keys) 
			{
				try 
				{
					LukePlugin plugin = (LukePlugin)pluginType.GetConstructor(new Type[]{}).Invoke(new Object[]{});
					plugins.Add(plugin);
				} 
				catch (Exception) 
				{}
			}
			if (plugins.Count == 0) return;
			InitPlugins();
		}
    
		internal void InitPlugins() 
		{
			ClearePluginsUI();

			foreach (LukePlugin plugin in plugins) 
			{
				plugin.SetDirectory(dir);
				plugin.SetIndexReader(indexReader);
				try 
				{
					plugin.Init();
					plugin.Anchor = AnchorStyles.Bottom|AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right;
				} 
				catch (Exception e) 
				{
					plugins.Remove(plugin);
					ShowStatus("PLUGIN ERROR: " + e.Message);
				}
				lstPlugins.Items.Add(plugin.GetPluginName());
			}

			if (lstPlugins.Items.Count > 0)
			{
				lstPlugins.SelectedIndex = 0;
			}
		}

		private void ClearePluginsUI()
		{
			lstPlugins.Items.Clear();
			panelPlugin.Controls.Clear();
			lblPluginInfo.Text = "";
			linkPluginURL.Text = "";
			linkPluginURL.Links.Clear();

		}

		public void LoadPluginTab(LukePlugin plugin) 
		{
			lblPluginInfo.Text = plugin.GetPluginInfo();
			linkPluginURL.Text = plugin.GetPluginHome();
			linkPluginURL.Links.Clear();
			linkPluginURL.Links.Add(0, linkPluginURL.Text.Length, linkPluginURL.Text);

			plugin.Size = panelPlugin.Size;
			panelPlugin.Controls.Clear();
			panelPlugin.Controls.Add(plugin);
		}
		private void lstPlugins_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadPluginTab((LukePlugin)plugins[lstPlugins.SelectedIndex]);
		}

		private void linkPluginURL_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			linkPluginURL.Links[linkPluginURL.Links.IndexOf(e.Link)].Visited = true;
			System.Diagnostics.Process.Start(e.Link.LinkData.ToString());		
		}
		#endregion Plugins

		#region Files
		public void ShowFiles(FSDirectory dir)
		{
			String[] files = dir.List();

			listIndexFiles.Items.Clear();

			foreach(string file in files) 
			{
//				FileInfo fi = new FileInfo(file);

				ListViewItem row = new ListViewItem(
					new string[]
					{
						file, //fi.Name,
						NormalizeSize(dir.FileLength(file)),
						NormalizeUnit(dir.FileLength(file))
					});
				listIndexFiles.Items.Add(row);
			}

			long totalFileSize = CalcTotalFileSize(dir);
			lblFileSize.Text = NormalizeSize(totalFileSize) + NormalizeUnit(totalFileSize);
		}

		private long CalcTotalFileSize(FSDirectory dir)
		{
			long totalFileSize = 0;
			foreach(string file in dir.List()) 
			{
				totalFileSize += dir.FileLength(file);
//				FileInfo fi = new FileInfo(file);
//				totalFileSize += fi.Length;
			}

			return totalFileSize;
		}

		private String NormalizeUnit(long len) 
		{
			if(len == 1) 
			{
				return "Byte";
			} 
			else if(len < 1024) 
			{
				return "Bytes";			
			} 
			else if(len < 51200000) 
			{
				return "Kb";
			} 
			else 
			{
				return "Mb";
			}
		}

		private String NormalizeSize(long len) 
		{
			if(len < 1024) 
			{
				return len.ToString();			
			} 
			else if(len < 51200000) 
			{
				return ((long)(len / 1024)).ToString();
			} 
			else 
			{
				return ((long)(len / 102400)).ToString();
			}
		}
		#endregion Files

		#region Document reconstruction
		private void btnReconstruct_Click(object sender, System.EventArgs e)
		{
			progressDlg = new Progress();
			progressDlg.Message = resources.GetString("CollectingTerms");

			int docNum = 0;
			try
			{
				docNum = Int32.Parse(textDocNum.Text);
			}
			catch(Exception)
			{
				ShowStatus(resources.GetString("DocNotSelected"));
				return;
			}

			Document document = CreateDocument(docNum);
			if (document == null)
				return;

			Hashtable doc = new Hashtable();

			this.Cursor = Cursors.WaitCursor;

			// async call to reconstruction
			ReconstructDelegate reconstruct = new ReconstructDelegate(BeginAsyncReconstruction);
			reconstruct.BeginInvoke(docNum, document, doc, new AsyncCallback(EndAsyncReconstruction), null);

			progressDlg.ShowDialog(this);
			this.Cursor = Cursors.Default;

			EditDocument editDocDlg = new EditDocument(this, docNum, document, doc);
			editDocDlg.ShowDialog();
			if (editDocDlg.DialogResult == DialogResult.OK)
			{
				InitOverview();
				InitPlugins();
			}
		}

		void EndAsyncReconstruction(IAsyncResult target)
		{
			if (!progressDlg.InvokeRequired)
				progressDlg.Close();
			else
			{
				// Show status asynchronously
				AsyncCallback endReconstruct = new AsyncCallback(EndAsyncReconstruction);
				BeginInvoke(endReconstruct, new object[] {target});
			}
		}
		delegate void ReconstructDelegate(int docNum, Document document, Hashtable doc);
		void BeginAsyncReconstruction(int docNum, Document document, Hashtable doc)
		{
			// get stored fields
			ArrayList sf = new ArrayList();
			for (int i = 0; i < indexFields.Length; i++) 
			{
				Field[] f = document.GetFields(indexFields[i]);
				if (f == null || !f[0].IsStored()) continue;
				StringBuilder sb = new StringBuilder();
				for (int k = 0; k < f.Length; k++) 
				{
					if (k > 0) sb.Append('\n');
					sb.Append(f[k].StringValue());
				}
				Field field = Legacy.CreateField(indexFields[i], sb.ToString(), f[0].IsStored(), f[0].IsIndexed(), f[0].IsTokenized(), f[0].IsTermVectorStored());
				field.SetBoost(f[0].GetBoost());
				doc[indexFields[i]] = field;
				sf.Add(indexFields[i]);
			}
			String term = null;
			GrowableStringArray terms = null;
			try 
			{
				int i = 0;
				int delta = (int)Math.Ceiling(((double)numTerms / 100));
			
				TermEnum te = indexReader.Terms();
				TermPositions tp = indexReader.TermPositions();
				while (te.Next()) 
				{
					if ((i++ % delta) == 0) 
					{
						// update UI - async
						UpdateProgress(i / delta);
					}

					// skip stored fields
					if (sf.Contains(te.Term().Field())) continue;
					tp.Seek(te.Term());
					if (!tp.SkipTo(docNum) || tp.Doc() != docNum) 
					{
						// this term is not found in the doc
						continue;
					}
					term = te.Term().Text();
					terms = (GrowableStringArray)doc[te.Term().Field()];
					if (terms == null) 
					{
						terms = new GrowableStringArray();
						doc[te.Term().Field()] = terms;
					}
					for (int k = 0; k < tp.Freq(); k++) 
					{
						int pos = tp.NextPosition();
						terms.Set(pos, term);
					}
				}
			} 
			catch (Exception exc) 
			{
				// Update UI - async
				ShowStatus(exc.Message);
			}
		}

		delegate void UpdateProgressDelegate(int val);
		/// <summary>
		/// Updates status. Possibly async
		/// </summary>
		private void UpdateProgress(int val)
		{
			if (!progressDlg.InvokeRequired)
				progressDlg.Value = val;
			else
			{
				// Show status asynchronously
				UpdateProgressDelegate showProgress = new UpdateProgressDelegate(UpdateProgress);
				BeginInvoke(showProgress, new object[] {val});
			}
		}
		#endregion Document reconstruction

		#region class ListViewItemComparer
		internal class ListViewItemComparer : IComparer 
		{
			private int col;
			public ListViewItemComparer() 
			{
				col=0;
			}
			public ListViewItemComparer(int column) 
			{
				col=column;
			}
			public int Compare(object x, object y) 
			{
				ListViewItem itemX = x as ListViewItem;
				ListViewItem itemY = y as ListViewItem;
				
				Debug.Assert(itemX != null && itemY != null);

				// First two columns - numbers
				if (col == 0 || col  == 1)
				{
					try
					{
						return Int32.Parse(itemX.SubItems[col].Text) -
							   Int32.Parse(itemY.SubItems[col].Text);
					}
					catch (Exception)
					{}
				}
				
				return String.Compare(itemX.SubItems[col].Text, 
									  itemY.SubItems[col].Text);
			}
		}
		#endregion class ListViewItemComparer
		
	}

	#region class GrowableStringArray
	class GrowableStringArray 
	{
		public int INITIAL_SIZE = 20;
		private int size = 0;
		private String[] array = null;
    
		public int Size() 
		{
			return size;
		}
    
		public void Set(int index, String val) 
		{
			if (array == null) array = new String[INITIAL_SIZE];
			if (array.Length < index + 1) 
			{
				String[] newArray = new String[index + INITIAL_SIZE];
				array.CopyTo(newArray, 0);
				array = newArray;
			}
			if (index > size - 1) size = index + 1;
			array[index] = val;
		}
    
		public String Get(int index) 
		{
			return array[index];
		}
	}
	#endregion class GrowableStringArray
}

