using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Lucene.Net.LukeNet
{

    internal class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            ListViewItem itemX = x as ListViewItem;
            ListViewItem itemY = y as ListViewItem;

            // First two columns - numbers
            if (col == 0 || col == 1)
            {
                try
                {
                    return Int32.Parse(itemX.SubItems[col].Text) -
                           Int32.Parse(itemY.SubItems[col].Text);
                }
                catch (Exception)
                { }
            }

            return String.Compare(itemX.SubItems[col].Text,
                                  itemY.SubItems[col].Text);
        }
    }
}
