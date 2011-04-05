using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Lucene.Net.Index;
using Lucene.Net.Search;
using System.Windows.Forms;
using Lucene.Net.Documents;
using System.Collections;
using System.Globalization;

namespace Lucene.Net.LukeNet
{
    public partial class DocumentsTabPage : TabPage
    {
        private Document document;
        private Term term;
        private TermDocs termDocs;
        private String[] _indexFields;
        private Progress progressDlg;
        private int _numTerms;

        private Luke _luke;

        public DocumentsTabPage(Luke luke)
        {
            _luke = luke;
            InitializeComponent();
            SetDocumentsContextMenuItems();
        }

        public DocumentsTabPage(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void SetDocumentsContextMenuItems()
        {
            contextMenu.MenuItems.Clear();

            contextMenuItemShowTV = new MenuItem(_luke.resources.GetString("MenuShowTV"));
            contextMenuItemShowTV.Click += new EventHandler(contextMenuItemShowTV_Click);
            contextMenu.MenuItems.Add(contextMenuItemShowTV);
        }

        private void contextMenuItemShowTV_Click(object sender, System.EventArgs e)
        {
            ShowTV();
        }

        private void textDocNum_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar((int)Keys.Enter))
                _ShowDoc(0);
        }
        #region Buttons
        private void btnTermVector_Click(object sender, System.EventArgs e)
        {
            ShowTV();
        }

        private void textTerm_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar((int)Keys.Enter))
            {
                if (_luke.IndexReader == null)
                {
                    _luke.ShowStatus(_luke.resources.GetString("NoIndex"));
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
                    _luke.ShowStatus(exc.Message);
                }
            }
        }

        private void listDocFields_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            listDocFields.ListViewItemSorter = new ListViewItemComparer(e.Column);
            listDocFields.Sort();
        }

        private void buttonFirstTerm_Click(object sender, System.EventArgs e)
        {
            if (_luke.IndexReader == null)
            {
                _luke.ShowStatus(_luke.resources.GetString("NoIndex"));
                return;
            }
            try
            {
                TermEnum te = _luke.IndexReader.Terms();
                te.Next();
                Term t = te.Term();
                _ShowTerm(t);
            }
            catch (Exception exc)
            {
                _luke.ShowStatus(exc.Message);
            }
        }

        private void buttonPrevDoc_Click(object sender, System.EventArgs e)
        {
            _luke.ShowStatus("");
            _ShowDoc(-1);
        }

        private void buttonNextDoc_Click(object sender, System.EventArgs e)
        {
            _luke.ShowStatus("");
            _ShowDoc(+1);
        }

        private void buttonNextTerm_Click(object sender, System.EventArgs e)
        {
            if (_luke.IndexReader == null)
            {
                _luke.ShowStatus(_luke.resources.GetString("NoIndex"));
                return;
            }
            try
            {
                String text = textTerm.Text;
                String field = comboTerms.Text;

                TermEnum te;

                if (text == null || text == string.Empty)
                    te = _luke.IndexReader.Terms();
                else
                    te = _luke.IndexReader.Terms(new Term(field, text));

                te.Next();
                Term t = te.Term();

                _ShowTerm(t);
            }
            catch (Exception exc)
            {
                _luke.ShowStatus(exc.Message);
            }
        }

        private void buttonDelete_Click(object sender, System.EventArgs e)
        {
            int docid = 0;
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
                docid = Int32.Parse(textDocNum.Text);

                _ShowDoc(+1);
                _luke.IndexReader.DeleteDocument(docid);
                _luke.InitOverview();
            }
            catch (Exception exc)
            {
                _luke.ShowStatus(exc.Message);
            }
        }

        private void buttonShowFirstDoc_Click(object sender, System.EventArgs e)
        {
            if (term == null) return;
            if (_luke.IndexReader == null)
            {
                _luke.ShowStatus(_luke.resources.GetString("NoIndex"));
                return;
            }
            try
            {
                termDocs = _luke.IndexReader.TermDocs(term);
                termDocs.Next();
                labelDocNum.Text = "1";

                _ShowTermDoc(termDocs);
            }
            catch (Exception exc)
            {
                _luke.ShowStatus(exc.Message);
            }
        }

        private void buttonShowNextDoc_Click(object sender, System.EventArgs e)
        {
            if (term == null) return;

            if (_luke.IndexReader == null)
            {
                _luke.ShowStatus(_luke.resources.GetString("NoIndex"));
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
                catch (Exception) { };

                labelDocNum.Text = (cnt + 1).ToString();

                _ShowTermDoc(termDocs);
            }
            catch (Exception exc)
            {
                _luke.ShowStatus(exc.Message);
            }
        }

        private void buttonShowAllDocs_Click(object sender, System.EventArgs e)
        {
            if (term == null) return;
            if (_luke.IndexReader == null)
            {
                _luke.ShowStatus(_luke.resources.GetString("NoIndex"));
                return;
            }

            _luke.ShowSearchTab();

            Query q = new TermQuery(term);

            IndexSearcher searcher = null;
            try
            {
                searcher = new IndexSearcher(_luke.Directory, true);
                _luke.searchTabPage._Search(q, searcher);
            }
            catch (Exception exc)
            {
                _luke.ErrorMessage(exc.Message);
            }
            finally
            {
                if (searcher != null) try { searcher.Close(); }
                    catch (Exception) { };
            }
        }

        private void buttonDeleteAllDocs_Click(object sender, System.EventArgs e)
        {
            if (term == null) return;

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
                buttonShowNextDoc_Click(sender, e);
                _luke.IndexReader.DeleteDocuments(term);
            }
            catch (Exception exc)
            {
                _luke.ShowStatus(exc.Message);
            }
            finally
            {
                listDocFields.BeginUpdate();
                listDocFields.Items.Clear();
                listDocFields.EndUpdate();
            }
            _luke.InitOverview();
        }
        #endregion //Buttons

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
            foreach (ListViewItem item in listDocFields.SelectedItems)
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
                catch (Exception) { }

                Field field = Legacy.CreateField(item.SubItems[0].Text.Trim().Substring(1, item.SubItems[0].Text.Trim().Length - 2),
                    item.SubItems[item.SubItems.Count - 1].Text,
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

            foreach (ListViewItem item in listDocFields.Items)
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
                catch (Exception) { }

                if (!index && !token && !store && !tvf &&
                    item.SubItems[item.SubItems.Count - 1].Text == _luke.resources.GetString("FieldNotAvailable"))
                    continue;

                if (i++ > 0) copyText.Append(Environment.NewLine);

                Field field = Legacy.CreateField(item.SubItems[0].Text.Trim().Substring(1, item.SubItems[0].Text.Trim().Length - 2),
                    item.SubItems[item.SubItems.Count - 1].Text,
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

        #region Document reconstruction
        private void btnReconstruct_Click(object sender, System.EventArgs e)
        {
            progressDlg = new Progress();
            progressDlg.Message = _luke.resources.GetString("CollectingTerms");

            int docNum = 0;
            try
            {
                docNum = Int32.Parse(textDocNum.Text);
            }
            catch (Exception)
            {
                _luke.ShowStatus(_luke.resources.GetString("DocNotSelected"));
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

            EditDocument editDocDlg = new EditDocument(_luke, docNum, document, doc);
            editDocDlg.ShowDialog();
            if (editDocDlg.DialogResult == DialogResult.OK)
            {
                _luke.InitOverview();
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
                BeginInvoke(endReconstruct, new object[] { target });
            }
        }
        delegate void ReconstructDelegate(int docNum, Document document, Hashtable doc);
        void BeginAsyncReconstruction(int docNum, Document document, Hashtable doc)
        {
            // get stored fields
            ArrayList sf = new ArrayList();
            for (int i = 0; i < _indexFields.Length; i++)
            {
                Field[] f = document.GetFields(_indexFields[i]);
                if (f == null || f.Length == 0 || !f[0].IsStored()) continue;
                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < f.Length; k++)
                {
                    if (k > 0) sb.Append('\n');
                    sb.Append(f[k].StringValue());
                }
                Field field = Legacy.CreateField(_indexFields[i], sb.ToString(), f[0].IsStored(), f[0].IsIndexed(), f[0].IsTokenized(), f[0].IsTermVectorStored());
                field.SetBoost(f[0].GetBoost());
                doc[_indexFields[i]] = field;
                sf.Add(_indexFields[i]);
            }
            String term = null;
            GrowableStringArray terms = null;
            try
            {
                int i = 0;
                int delta = (int)Math.Ceiling(((double)_numTerms / 100));

                TermEnum te = _luke.IndexReader.Terms();
                TermPositions tp = _luke.IndexReader.TermPositions();
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
                _luke.ShowStatus(exc.Message);
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
                BeginInvoke(showProgress, new object[] { val });
            }
        }
        #endregion Document reconstruction

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
            catch (Exception e)
            {
                _luke.ShowStatus(e.Message);
            }
        }
        internal void _ShowDocFields(int docid, Document doc)
        {
            textDocNum.Text = docid.ToString();
            labelInfoDocNum.Text = docid.ToString();

            listDocFields.BeginUpdate();
            listDocFields.Items.Clear();

            document = doc;

            try
            {
                if (doc == null) return;
                for (int i = 0; i < _indexFields.Length; i++)
                {
                    Field[] fields = doc.GetFields(_indexFields[i]);
                    if (fields == null)
                    {
                        AddFieldRow(_indexFields[i], null);
                        continue;
                    }
                    for (int j = 0; j < fields.Length; j++)
                    {
                        AddFieldRow(_indexFields[i], fields[j]);
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
                item.SubItems.Add(_luke.resources.GetString("FieldNotAvailable"));
            }

            listDocFields.Items.Add(item);
        }

        internal void _ShowTerm(Term t)
        {
            if (t == null)
            {
                _luke.ShowStatus(_luke.resources.GetString("NoTerms"));
                return;
            }
            if (_luke.IndexReader == null)
            {
                _luke.ShowStatus(_luke.resources.GetString("NoIndex"));
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
                int freq = _luke.IndexReader.DocFreq(t);
                labelDocFreq.Text = freq.ToString();
                labelDocMax.Text = freq.ToString();
            }
            catch (Exception e)
            {
                _luke.ShowStatus(e.Message);
                labelDocFreq.Text = "?";
            }
        }

        private void _ShowTermDoc(TermDocs td)
        {
            if (_luke.IndexReader == null)
            {
                _luke.ShowStatus(_luke.resources.GetString("NoIndex"));
                return;
            }
            try
            {
                Document doc = _luke.IndexReader.Document(td.Doc());

                labelDocNum.Text = td.Doc().ToString();
                labelTermFreq.Text = td.Freq().ToString();

                _ShowDocFields(td.Doc(), doc);
            }
            catch (Exception e)
            {
                _luke.ShowStatus(e.Message);
            }
        }

        internal void ShowTV()
        {
            if (listDocFields.SelectedItems.Count == 0) return;
            if (_luke.IndexReader == null)
            {
                _luke.ShowStatus(_luke.resources.GetString("NoIndex"));
                return;
            }

            int docId;
            try
            {
                docId = Int32.Parse(textDocNum.Text);
            }
            catch (Exception)
            {
                _luke.ShowStatus(_luke.resources.GetString("DocNotSelected"));
                return;
            }

            try
            {

                string fieldName = listDocFields.SelectedItems[0].SubItems[0].Text;
                fieldName = fieldName.Substring(1, fieldName.Length - 2);
                TermFreqVector tfv = _luke.IndexReader.GetTermFreqVector(docId, fieldName);
                if (tfv == null)
                {
                    _luke.ShowStatus(_luke.resources.GetString("NoTV"));
                    return;
                }

                TermVector tvDialog = new TermVector(fieldName, tfv);
                tvDialog.ShowDialog(this);
            }
            catch (Exception exc)
            {
                _luke.ShowStatus(exc.Message);
            }
        }

        private Document CreateDocument(int iNum)
        {
            if (_luke.IndexReader == null)
            {
                _luke.ShowStatus(_luke.resources.GetString("NoIndex"));
                return null;
            }

            if (iNum < 0 || iNum >= _luke.IndexReader.NumDocs())
            {
                _luke.ShowStatus(_luke.resources.GetString("DocNumberRange"));
                return null;
            }

            if (!_luke.IndexReader.IsDeleted(iNum))
                return _luke.IndexReader.Document(iNum);
            else
            {
                _luke.ShowStatus(_luke.resources.GetString("DocDeleted"));
                return null;
            }
        }

        public void OnResize(object sender, System.EventArgs e)
        {
            _luke.ResizeLastListColumn(listDocFields);
        }

        internal void SetFieldNames(List<string> names)
        {
            comboTerms.Items.Clear();
            comboTerms.Items.AddRange(names.ToArray());
            comboTerms.SelectedIndex = 0;
        }

        internal void SetFields(string[] indexFields)
        {
            _indexFields = indexFields;
        }

        internal void Init(int termsNumber, int documentsNumber)
        {
            _numTerms = termsNumber;
            labelIndDocs.Text = (documentsNumber - 1).ToString();
        }
    }
}
