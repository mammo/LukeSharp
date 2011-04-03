using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Resources;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
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

namespace Lucene.Net.LukeNet
{
    /// <summary>
    /// This class allows you to browse a <a href="jakarta.apache.org/lucene">Lucene</a>
    /// index in several ways - by document, by term, by query, and by most frequent terms.
    /// </summary>
    public partial class Luke : System.Windows.Forms.Form
    {

        #region Fields
        public static readonly Lucene.Net.Util.Version LUCENE_VERSION = Lucene.Net.Util.Version.LUCENE_29;
        private string lukeURL = "http://www.getopt.org/luke";

        private string indexPath;
        private Preferences p;
        private bool _readOnly;
        private FSDirectory dir;
        private IndexReader indexReader;
        private String[] indexFields;
        private bool useCompound;
        private int numTerms;

        internal ResourceManager resources = new ResourceManager
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

            for (int i = 0; i <= 999999; i++)
                domainTerms.Items.Add(i);

            domainTerms.SelectedIndex = 50;

            SetOverviewContextMenuItems();
        }
        #endregion Constructors

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
            catch (FormatException)
            { }
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

        private void tabControl_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (tabControl.SelectedTab == tabOverview)
                SetOverviewContextMenuItems();
            else if (tabControl.SelectedTab == documentsTabPage)
                SetDocumentsContextMenuItems();
        }
        #endregion Luke Events

        #region Resizing

        private void tabOverview_Resize(object sender, System.EventArgs e)
        {
            ResizeLastListColumn(listTerms);
        }

        internal void ResizeLastListColumn(ListView list)
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

        private void buttonTopTerms_Click(object sender, System.EventArgs e)
        {
            ShowStatus("");
            ShowTopTerms();
        }

        #endregion Buttons

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
            if (_readOnly)
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
                long startSize = FilesTabPage.CalcTotalFileSize(dir);
                DateTime startTime = DateTime.Now;
                writer.Optimize();
                DateTime endTime = DateTime.Now;
                long endSize = FilesTabPage.CalcTotalFileSize(dir);
                long deltaSize = startSize - endSize;
                String sign = deltaSize < 0 ? " Increased " : " Reduced ";
                String sizeMsg = sign + FilesTabPage.NormalizeSize(Math.Abs(deltaSize)) + FilesTabPage.NormalizeUnit(Math.Abs(deltaSize));
                String timeMsg = ((TimeSpan)(endTime - startTime)).TotalMilliseconds + " ms";
                ShowStatus(sizeMsg + " in " + timeMsg);
                tabFiles.ShowFiles(dir);
                writer.Close();
                indexReader = IndexReader.Open(dir, true);

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

            if (field == null || text == null)
                return;

            Term t = new Term(field, text);

            tabControl.SelectedTab = searchTabPage;

            searchTabPage.SetSearchText(t.Field() + ":" + t.Text());
            searchTabPage.Search();
        }

        private void contextMenuItemBrowse_Click(object sender, System.EventArgs e)
        {
            if (listTerms.SelectedItems == null) return;

            ListViewItem selItem = listTerms.SelectedItems[0];
            if (selItem == null) return;

            string field = selItem.SubItems[2].Text.Trim().Substring(1, selItem.SubItems[2].Text.Trim().Length - 2);
            string text = selItem.SubItems[3].Text;

            if (field == null || text == null)
                return;

            Term t = new Term(field, text);

            tabControl.SelectedTab = documentsTabPage;
            documentsTabPage._ShowTerm(t);
        }

        private void contextMenuItemShowTV_Click(object sender, System.EventArgs e)
        {
            documentsTabPage.ShowTV();
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
            if (_readOnly)
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
        public bool ReadOnly
        {
            get { return _readOnly; }
        }

        public Lucene.Net.Store.Directory Directory
        {
            get
            {
                return dir;
            }
        }

        public IndexReader IndexReader
        {
            get
            {
                return indexReader;
            }
            set
            {
                indexReader = value;
            }
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
        internal void PopulateAnalyzers(ComboBox cbAnalyzers)
        {
            cbAnalyzers.BeginUpdate();
            cbAnalyzers.Items.Clear();
            cbAnalyzers.Items.AddRange(Analyzing.GetAnalyzerNames().ToArray());
            cbAnalyzers.EndUpdate();
        }

        internal void InitOverview()
        {
            // populate analyzers

            searchTabPage.Init();

            IndexName = indexPath + (_readOnly ? " (R)" : "");

            DocumentsNumber = indexReader.NumDocs();

            List<string> fieldNames = new List<string>(indexReader.GetFieldNames(IndexReader.FieldOption.ALL));
            SetFieldNames(fieldNames);
            searchTabPage.SetFieldnames(fieldNames);

            TermEnum termsEnum = indexReader.Terms();
            int i = 0;
            while (termsEnum.Next()) i++;
            termsEnum.Close();

            TermsNumber = i;
            IndexVersion = IndexReader.GetCurrentVersion(dir).ToString();
            HasDeletions = indexReader.HasDeletions().ToString();

            LastModified = IndexReader.LastModified(dir);

            documentsTabPage.Init(i, indexReader.NumDocs());

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
            _readOnly = openIndexDlg.ReadOnlyIndex;
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
                catch (Exception) { };
                try
                {
                    dir.Close();
                }
                catch (Exception) { };
            }

            try
            {
                p.AddToMruList(indexPath);

                dir = FSDirectory.GetDirectory(indexPath, false);
                if (IndexWriter.IsLocked(dir))
                {
                    if (_readOnly)
                    {
                        ShowStatus(resources.GetString("IndexLockedRo"));
                        dir.Close();
                        return;
                    }
                    if (force)
                    {
                        IndexWriter.Unlock(dir);
                    }
                    else
                    {
                        ShowStatus(resources.GetString("IndexLocked"));
                        dir.Close();
                        return;
                    }
                }

                // files tab
                tabFiles.ShowFiles(dir);

                indexReader = IndexReader.Open(dir, true);

                menuItemCompound.Checked = p.UseCompound;

                // plugins tab
                pluginsTabPage.LoadPlugins();

                // overview tab
                InitOverview();

                searchTabPage.UpdateListSearch(indexFields);

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
                BeginInvoke(showStatus, new object[] { message });
            }
        }

        private void SetFieldNames(List<string> names)
        {
            indexFields = new String[names.Count];
            labelFields.Text = names.Count.ToString();

            int i = 0;

            listFields.BeginUpdate();
            listFields.Items.Clear();

            foreach (string name in names)
            {
                listFields.Items.Add(new ListViewItem("<" + name + ">"));
                indexFields[i++] = name;
            }

            listFields.EndUpdate();

            documentsTabPage.SetFieldNames(names);
            documentsTabPage.SetFields(indexFields);
        }

        private void ShowTopTerms()
        {
            int nDoc = (int)domainTerms.SelectedItem;
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
                    noResults.SubItems.AddRange(new String[] { "", "", resources.GetString("NoResults") });
                    listTerms.Items.Add(noResults);
                    return;
                }

                for (int i = 0; i < termInfos.Length; i++)
                {
                    ListViewItem item = new ListViewItem((i + 1).ToString());
                    item.SubItems.AddRange(
                        new String[]{
							termInfos[i].DocFreq.ToString(), 
							" <" + termInfos[i].Term.Field() + "> ", 
							termInfos[i].Term.Text()});

                    listTerms.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                ErrorMessage(e.Message);
            }
            finally
            {
                listTerms.EndUpdate();
            }
        }


        #endregion Private Methods


        #region Cleanup
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
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
                catch (Exception) { };

            if (dir != null)
                try
                {
                    dir.Close();
                }
                catch (Exception) { };

            if (p != null)
                try
                { p.Save(); }
                catch (Exception) { }

            base.Dispose(disposing);
        }
        #endregion Cleanup


        internal void ShowDocumentsTab()
        {
            tabControl.SelectedTab = documentsTabPage;
        }

        internal void ShowSearchTab()
        {
            tabControl.SelectedTab = searchTabPage;
        }

        internal void _ShowDocFields(int docId, Document doc)
        {
            documentsTabPage._ShowDocFields(docId, doc);
        }
    }
}

