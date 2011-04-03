using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lucene.Net.Documents;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;

namespace Lucene.Net.LukeNet
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class SearchTabPage : TabPage
    {

        private Luke _luke;
        private Query query;
        private QueryParser queryParser;
        private Analyzer analyzer;
        private Analyzer stdAnalyzer = new StandardAnalyzer(Luke.LUCENE_VERSION);
        private int[] searchedDocIds;
        private string[] _indexFields;

        public SearchTabPage(Luke luke) 
        {
            _luke = luke;
            InitializeComponent();
        }

        public SearchTabPage(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void listSearch_DoubleClick(object sender, System.EventArgs e)
        {
            if (_luke.IndexReader == null)
            {
                _luke.ShowStatus(_luke.resources.GetString("NoIndex"));
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

                doc = _luke.IndexReader.Document(docId);
            }
            catch (Exception exc)
            {
                _luke.ShowStatus(exc.Message);
                return;
            }

            _luke._ShowDocFields(docId, doc);

            _luke.ShowDocumentsTab();
        }

        private void listSearch_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            listSearch.ListViewItemSorter = new ListViewItemComparer(e.Column);
            listSearch.Sort();
        }

        private void buttonSearch_Click(object sender, System.EventArgs e)
        {
            Search();
        }

        private void buttonSearchDelete_Click(object sender, System.EventArgs e)
        {
            if (_luke.IndexReader == null)
            {
                _luke.ShowStatus(_luke.resources.GetString("NoIndex"));
                return;
            }
            if (_luke.ReadOnly)
            {
                _luke.ShowStatus(_luke.resources.GetString("Readonly"));
                return;
            }

            try
            {
                foreach (ListViewItem item in listSearch.SelectedItems)
                {
                    int docId = Int32.Parse(item.SubItems[1].Text);
                    _luke.IndexReader.DeleteDocument(docId);
                    listSearch.Items.Remove(item);
                }
            }
            catch (Exception exc)
            {
                _luke.ShowStatus(exc.Message);
            }
            _luke.InitOverview();
        }

        private void btnExplain_Click(object sender, System.EventArgs e)
        {
            if (listSearch.SelectedItems.Count == 0) return;
            if (searchedDocIds == null || searchedDocIds.Length < listSearch.Items.Count) return;

            if (_luke.IndexReader == null)
            {
                _luke.ShowStatus(_luke.resources.GetString("NoIndex"));
                return;
            }

            if (query == null) return;

            IndexSearcher searcher = null;
            try
            {
                searcher = new IndexSearcher(_luke.Directory, true);
                Lucene.Net.Search.Explanation expl = searcher.Explain(query, searchedDocIds[listSearch.SelectedIndices[0]]);
                ExplanationDialog explDialog = new ExplanationDialog(expl);
                explDialog.ShowDialog(this);
            }
            catch (Exception exc)
            {
                _luke.ErrorMessage(exc.Message);
            }
            finally
            {
                searcher.Close();
            }
        }
        private void btnUpdateParsedQuery_Click(object sender, System.EventArgs e)
        {
            string analyzerName = Analyzing.GetAnalyzerName((string)comboAnalyzer.SelectedItem);
            comboAnalyzer.SelectedItem = analyzerName;
            QueryParser qp = CreateQueryParser(analyzerName);
            String queryS = textSearch.Text;

            if (queryS.Trim() == "")
            {
                textParsed.Enabled = false;
                textParsed.Text = _luke.resources.GetString("EmptyQuery");
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

        internal void Search()
        {
            if (_luke.IndexReader == null)
            {
                _luke.ShowStatus(_luke.resources.GetString("NoIndex"));
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            string analyzerName = Analyzing.GetAnalyzerName((string)comboAnalyzer.SelectedItem);
            comboAnalyzer.SelectedItem = analyzerName;
            queryParser = CreateQueryParser(analyzerName);

            string queryString = textSearch.Text;
            if (queryString == string.Empty)
            {
                _luke.ShowStatus(_luke.resources.GetString("EmptyQuery"));
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
                searcher = new IndexSearcher(_luke.Directory, true);

                textParsed.Text = q.ToString();
                _Search(q, searcher);
            }
            catch (Exception e)
            {
                _luke.ErrorMessage(e.Message);
            }
            finally
            {
                if (searcher != null) try { searcher.Close(); }
                    catch (Exception) { };
            }

            Cursor.Current = Cursors.Default;
        }

        internal void _Search(Query q, IndexSearcher searcher)
        {
            textParsed.Text = q.ToString();
            DateTime start = DateTime.Now;
            Hits hits = searcher.Search(q);
            _luke.ShowStatus(((TimeSpan)(DateTime.Now - start)).TotalMilliseconds.ToString() + " ms");

            listSearch.BeginUpdate();
            listSearch.Items.Clear();

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
                    noResults.SubItems.AddRange(new String[] { "", _luke.resources.GetString("NoResults") });
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

                    for (int j = 0; j < _indexFields.Length; j++)
                    {
                        item.SubItems.Add(doc.Get(_indexFields[j]));
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

        private QueryParser CreateQueryParser(string analyzerName)
        {
            analyzer = Analyzing.GetAnalyzerForName(analyzerName);
            if (null == analyzer)
            {
                _luke.ErrorMessage(string.Format(_luke.resources.GetString("AnalyzerNotFound"), analyzerName));
                analyzer = stdAnalyzer;
            }

            string defField = (string)comboFields.SelectedItem;
            if (defField == null || defField == string.Empty)
            {
                defField = _indexFields[0];
                comboFields.SelectedItem = analyzerName;
            }

            return new QueryParser(Luke.LUCENE_VERSION, defField, analyzer);
        }

        internal void PopulateAnalyzers(ComboBox cbAnalyzers)
        {
            cbAnalyzers.BeginUpdate();
            cbAnalyzers.Items.Clear();
            cbAnalyzers.Items.AddRange(Analyzing.GetAnalyzerNames().ToArray());
            cbAnalyzers.EndUpdate();
        }

        internal void Init()
        {
            _luke.PopulateAnalyzers(comboAnalyzer);
        }

        internal void UpdateListSearch(string[] indexFields)
        {
            _indexFields = indexFields;

            listSearch.BeginUpdate();

            while (listSearch.Columns.Count > 2)
            {
                listSearch.Columns.RemoveAt(2);
            }

            foreach (string field in indexFields)
            {
                listSearch.Columns.Add(field, 200, HorizontalAlignment.Left);
            }
            listSearch.EndUpdate();

        }

        internal void SetFieldnames(List<string> fieldNames)
        {
            comboFields.Items.Clear();
            comboFields.Items.AddRange(fieldNames.ToArray());
            comboFields.SelectedIndex = 0;
        }

        internal void SetSearchText(string text)
        {
            textSearch.Text = text;
        }
    }
}
