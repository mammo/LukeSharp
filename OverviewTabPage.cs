using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lucene.Net.Index;

namespace Lucene.Net.LukeNet
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class OverviewTabPage : TabPage
    {
        private int numTerms;
        private string[] _indexFields;
        private Luke _luke;

        public OverviewTabPage(Luke luke)
        {
            _luke = luke;
            InitializeComponent();
            for (int i = 0; i <= 999999; i++)
                domainTerms.Items.Add(i);

            domainTerms.SelectedIndex = 50;
            SetOverviewContextMenuItems();
        }

        public OverviewTabPage(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        #region Properties
        private string IndexName
        {
            set
            {
                labelName.Text = value;
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

        private int DocumentsNumber
        {
            set
            {
                labelDocs.Text = value.ToString();
            }
        }

        #endregion

        private void SetOverviewContextMenuItems()
        {
            contextMenu.MenuItems.Clear();

            contextMenuItemBrowse = new MenuItem(_luke.resources.GetString("MenuBrowse"));
            contextMenuItemBrowse.Click += new EventHandler(contextMenuItemBrowse_Click);
            contextMenu.MenuItems.Add(contextMenuItemBrowse);

            contextMenuItemShowAll = new MenuItem(_luke.resources.GetString("MenuShowAll"));
            contextMenuItemShowAll.Click += new EventHandler(contextMenuItemShowAll_Click);
            contextMenu.MenuItems.Add(contextMenuItemShowAll);
        }

        public void OnResize(object sender, System.EventArgs e)
        {
            _luke.ResizeLastListColumn(listTerms);
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

            _luke.Search(t.Field() + ":" + t.Text());
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

            _luke.ShowTerm(t);
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

        private void buttonTopTerms_Click(object sender, System.EventArgs e)
        {
            _luke.ShowStatus("");
            ShowTopTerms();
        }

        internal void ShowTopTerms()
        {
            int nDoc = (int)domainTerms.SelectedItem;
            ListView.CheckedListViewItemCollection fields = listFields.CheckedItems;

            String[] selectedFields;
            if (fields == null || fields.Count == 0)
            {
                selectedFields = _indexFields;
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
                TermInfo[] termInfos = HighFreqTerms.GetHighFreqTerms(_luke.Directory, null, nDoc, selectedFields);

                listTerms.BeginUpdate();
                listTerms.Items.Clear();

                if (termInfos == null || termInfos.Length == 0)
                {
                    ListViewItem noResults = new ListViewItem();
                    noResults.SubItems.AddRange(new String[] { "", "", _luke.resources.GetString("NoResults") });
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
                _luke.ErrorMessage(e.Message);
            }
            finally
            {
                listTerms.EndUpdate();
            }
        }

        internal void Init()
        {
            TermEnum termsEnum = _luke.IndexReader.Terms(); //TODO: Duplicated
            int i = 0;
            while (termsEnum.Next()) i++;
            termsEnum.Close();
            TermsNumber = i;
            IndexVersion = IndexReader.GetCurrentVersion(_luke.Directory).ToString();
            HasDeletions = _luke.IndexReader.HasDeletions().ToString();
            DocumentsNumber = _luke.IndexReader.NumDocs();

            LastModified = IndexReader.LastModified(_luke.Directory);

            ShowTopTerms();

        }


        internal void SetFields(string[] indexFields)
        {
            _indexFields = indexFields;
        }

        internal void SetFieldNames(List<string> names)
        {
            listFields.BeginUpdate();
            listFields.Items.Clear();

            foreach (string name in names)
            {
                listFields.Items.Add(new ListViewItem("<" + name + ">"));
            }

            listFields.EndUpdate();

            labelFields.Text = names.Count.ToString();
        }
    }
}
