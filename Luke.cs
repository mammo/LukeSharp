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

        #endregion Luke Events

        internal void ResizeLastListColumn(ListView list)
        {
            int width = list.Width;
            for (int i = 0; i < list.Columns.Count - 1; i++)
            {
                width -= list.Columns[i].Width;
            }
            list.Columns[list.Columns.Count - 1].Width = width - 4;

        }

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
                IndexWriter writer = new IndexWriter(dir, new WhitespaceAnalyzer(), IndexWriter.MaxFieldLength.UNLIMITED);
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
            string indexName = indexPath + (_readOnly ? " (R)" : "");
            statusBar.Panels[0].Text = resources.GetString("StatusIndexName") + indexName;

            List<string> fieldNames = new List<string>(indexReader.GetFieldNames(IndexReader.FieldOption.ALL));
            SetFieldNames(fieldNames);
            searchTabPage.SetFieldnames(fieldNames);

            overviewTabPage.Init(indexName);

            TermEnum termsEnum = indexReader.Terms(); //TODO: Duplicated
            int i = 0;
            while (termsEnum.Next()) i++;
            termsEnum.Close();

            documentsTabPage.Init(i, indexReader.NumDocs());

        }

        private void LukeInit(OpenIndex openIndexDlg)
        {
            indexPath = openIndexDlg.Path;
            _readOnly = openIndexDlg.ReadOnlyIndex;
            bool force = openIndexDlg.UnlockIndex;

            FSDirectory newDir = FSDirectory.Open(new DirectoryInfo(indexPath));

            if (indexPath == String.Empty || !IndexReader.IndexExists(newDir))
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
                dir = newDir;
                p.AddToMruList(indexPath);

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

            int i = 0;
            foreach (string name in names)
            {
                indexFields[i++] = name;
            }

            overviewTabPage.SetFieldNames(names);
            overviewTabPage.SetFields(indexFields);

            documentsTabPage.SetFieldNames(names);
            documentsTabPage.SetFields(indexFields);
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

        internal void Search(string query)
        {
            ShowSearchTab();
            searchTabPage.SetSearchText(query);
            searchTabPage.Search();
        }

        internal void ShowTerm(Term t)
        {
            ShowDocumentsTab();
            documentsTabPage._ShowTerm(t);
        }
    }
}

