using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Specialized;

using Lucene.Net.Analysis;

using Lucene.Net.LukeNet.ClassFinder;

namespace Lucene.Net.LukeNet.Plugins
{
	/// <summary>
	/// Summary description for AnalyzerToolPlugin.
	/// </summary>
	public class AnalyzerToolPlugin : LukePlugin
	{
		private System.Windows.Forms.Label lblAnalyzers;
		private System.Windows.Forms.ComboBox cmbAnalyzers;
		private System.Windows.Forms.TextBox txtText;
		private System.Windows.Forms.Button btnAnalyze;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Label lblTokens;
		private System.Windows.Forms.ListBox lstResults;
		private System.Windows.Forms.Button btnHighlight;
		private System.Windows.Forms.Label lblError;
		private System.Windows.Forms.Label lblOriginal;
		private System.Windows.Forms.TextBox txtOutput;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label lblText;

		private ArrayList tokens = new ArrayList();
		private SortedList analyzers = new SortedList(); // Name -> Type
		private Type[] defaultAnalyzers = 
			{
//				typeof(Lucene.Net.Analysis.De.GermanAnalyzer),
//				typeof(Lucene.Net.Analysis.Ru.RussianAnalyzer),
				typeof(SimpleAnalyzer),
				typeof(Lucene.Net.Analysis.Standard.StandardAnalyzer),
				typeof(StopAnalyzer),
				typeof(WhitespaceAnalyzer)
			};

		public AnalyzerToolPlugin()
		{
			InitializeComponent();
		}

		public override String GetPluginName() 
		{
			return "AnalyzerTool";
		}
    
		public override String GetPluginInfo() 
		{
			return "Tool for analyzing analyzers";
		}
    
		public override String GetPluginHome() 
		{
			return "";
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.lblAnalyzers = new System.Windows.Forms.Label();
			this.cmbAnalyzers = new System.Windows.Forms.ComboBox();
			this.lblText = new System.Windows.Forms.Label();
			this.txtText = new System.Windows.Forms.TextBox();
			this.btnAnalyze = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.btnHighlight = new System.Windows.Forms.Button();
			this.lblTokens = new System.Windows.Forms.Label();
			this.lstResults = new System.Windows.Forms.ListBox();
			this.lblError = new System.Windows.Forms.Label();
			this.lblOriginal = new System.Windows.Forms.Label();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblAnalyzers
			// 
			this.lblAnalyzers.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblAnalyzers.Location = new System.Drawing.Point(8, 8);
			this.lblAnalyzers.Name = "lblAnalyzers";
			this.lblAnalyzers.Size = new System.Drawing.Size(584, 16);
			this.lblAnalyzers.TabIndex = 0;
			this.lblAnalyzers.Text = "&Available analyzers:";
			// 
			// cmbAnalyzers
			// 
			this.cmbAnalyzers.Location = new System.Drawing.Point(8, 24);
			this.cmbAnalyzers.Name = "cmbAnalyzers";
			this.cmbAnalyzers.Size = new System.Drawing.Size(288, 21);
			this.cmbAnalyzers.TabIndex = 1;
			// 
			// lblText
			// 
			this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblText.Location = new System.Drawing.Point(8, 48);
			this.lblText.Name = "lblText";
			this.lblText.Size = new System.Drawing.Size(576, 16);
			this.lblText.TabIndex = 2;
			this.lblText.Text = "Te&xt to be analyzed:";
			// 
			// txtText
			// 
			this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.txtText.Location = new System.Drawing.Point(8, 64);
			this.txtText.Multiline = true;
			this.txtText.Name = "txtText";
			this.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtText.Size = new System.Drawing.Size(584, 88);
			this.txtText.TabIndex = 3;
			this.txtText.Text = @"Welcome to the analysis viewer. This tool is used to demonstrate how different analyzers process text into tokens. You can edit this text to try different input such as numbers like 23231.23 or characters (mharwood@apache.org). Once happy, select an Analyzer from the list of analyzers found on the current classpath and then hit the Analyze button. The tokens produced are shown below and the hilite button can be used to show where each token was found in the original text.";
			// 
			// btnAnalyze
			// 
			this.btnAnalyze.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnAnalyze.Location = new System.Drawing.Point(512, 160);
			this.btnAnalyze.Name = "btnAnalyze";
			this.btnAnalyze.TabIndex = 4;
			this.btnAnalyze.Text = "A&nalyze";
			this.toolTip.SetToolTip(this.btnAnalyze, "Save changes to this record");
			this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
			// 
			// btnHighlight
			// 
			this.btnHighlight.Location = new System.Drawing.Point(136, 200);
			this.btnHighlight.Name = "btnHighlight";
			this.btnHighlight.TabIndex = 7;
			this.btnHighlight.Text = "&Highlight";
			this.toolTip.SetToolTip(this.btnHighlight, "Highlight this token in the original text");
			this.btnHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
			// 
			// lblTokens
			// 
			this.lblTokens.Location = new System.Drawing.Point(8, 184);
			this.lblTokens.Name = "lblTokens";
			this.lblTokens.Size = new System.Drawing.Size(112, 16);
			this.lblTokens.TabIndex = 5;
			this.lblTokens.Text = "Token&s found";
			// 
			// lstResults
			// 
			this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left);
			this.lstResults.Location = new System.Drawing.Point(8, 200);
			this.lstResults.Name = "lstResults";
			this.lstResults.Size = new System.Drawing.Size(120, 160);
			this.lstResults.TabIndex = 6;
			// 
			// lblError
			// 
			this.lblError.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblError.ForeColor = System.Drawing.Color.Red;
			this.lblError.Location = new System.Drawing.Point(8, 376);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(584, 16);
			this.lblError.TabIndex = 8;
			// 
			// lblOriginal
			// 
			this.lblOriginal.Location = new System.Drawing.Point(224, 184);
			this.lblOriginal.Name = "lblOriginal";
			this.lblOriginal.Size = new System.Drawing.Size(112, 16);
			this.lblOriginal.TabIndex = 9;
			this.lblOriginal.Text = "&Original text:";
			// 
			// txtOutput
			// 
			this.txtOutput.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.txtOutput.BackColor = System.Drawing.SystemColors.Window;
			this.txtOutput.Enabled = false;
			this.txtOutput.HideSelection = false;
			this.txtOutput.Location = new System.Drawing.Point(224, 200);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOutput.Size = new System.Drawing.Size(368, 160);
			this.txtOutput.TabIndex = 10;
			this.txtOutput.Text = "";
			// 
			// AnalyzerToolPlugin
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtOutput,
																		  this.lblOriginal,
																		  this.lblError,
																		  this.btnHighlight,
																		  this.lstResults,
																		  this.lblTokens,
																		  this.btnAnalyze,
																		  this.txtText,
																		  this.lblText,
																		  this.cmbAnalyzers,
																		  this.lblAnalyzers});
			this.Name = "AnalyzerToolPlugin";
			this.Size = new System.Drawing.Size(600, 400);
			this.ResumeLayout(false);

		}
    
		public override bool Init()
		{
			// load analyzers
			try 
			{
				Type[] analyzerTypes =
					LukeNet.ClassFinder.ClassFinder.GetInstantiableSubtypes(typeof(Analyzer));
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
			catch(Exception){}

			cmbAnalyzers.BeginUpdate();
			cmbAnalyzers.Items.Clear();

			string[] aNames = new String[analyzers.Count];
			analyzers.Keys.CopyTo(aNames, 0);
			cmbAnalyzers.Items.AddRange(aNames);
			cmbAnalyzers.EndUpdate();

			return true;
		}

		private void ShowError(String message) 
		{
			lblError.Text = message;
		}

		private void btnHighlight_Click(object sender, System.EventArgs e)
		{
			if (lstResults.SelectedItem == null) return;
			if (tokens.Count < lstResults.Items.Count) return;
			
			Token t = (Token)tokens[lstResults.SelectedIndex];
			int start = t.StartOffset();
			int end = t.EndOffset();
			txtOutput.Select(start, end - start);
		}

		private void btnAnalyze_Click(object sender, System.EventArgs e)
		{
			ShowError("");
			try 
			{
				if (cmbAnalyzers.SelectedItem == null) return;

				Analyzer analyzer = null;
				try
				{
					// Trying to create type from executing assembly
					Type analyzerType = (Type)analyzers[cmbAnalyzers.SelectedItem];
				
					if (null == analyzerType)
					{
						// Trying to create type from Lucene.Net assembly
						Assembly a = Assembly.GetAssembly(typeof(Lucene.Net.Analysis.Analyzer));
						analyzerType  = a.GetType((string)cmbAnalyzers.SelectedItem);
					}

					// Trying to create with default constructor
					analyzer = (Analyzer) Activator.CreateInstance(analyzerType);
				}
				catch(Exception)
				{}

				if (null == analyzer) 
				{
					ShowError("Couldn't instantiate analyzer - public zero-argument constructor required");
					return;
				}

				txtOutput.Text = txtText.Text;

				lstResults.BeginUpdate();
				try
				{
					TokenStream ts = analyzer.TokenStream(null, new StringReader(txtText.Text));
					Token token = ts.Next();

					lstResults.Items.Clear();
					tokens.Clear();

					while (token != null) 
					{
						lstResults.Items.Add(token.TermText());
						tokens.Add(token);
						token = ts.Next();
					}
				}
				finally
				{
					lstResults.EndUpdate();
				}
			} 
			catch (Exception exc) 
			{
				ShowError("Error analyzing: " + exc.Message);
			}
		}
	}
}
