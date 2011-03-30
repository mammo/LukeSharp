using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lucene.Net.Store;

namespace Lucene.Net.LukeNet
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class FilesTabPage : TabPage
    {
        public FilesTabPage()
        {
            InitializeComponent();
        }

        public FilesTabPage(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ShowFiles(FSDirectory dir)
        {
            String[] files = dir.ListAll();

            listIndexFiles.Items.Clear();

            foreach (string file in files)
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

        public static long CalcTotalFileSize(FSDirectory dir)
        {
            long totalFileSize = 0;
            foreach (string file in dir.ListAll())
            {
                totalFileSize += dir.FileLength(file);
                //				FileInfo fi = new FileInfo(file);
                //				totalFileSize += fi.Length;
            }

            return totalFileSize;
        }

        public static String NormalizeUnit(long len)
        {
            if (len == 1)
            {
                return "Byte";
            }
            else if (len < 1024)
            {
                return "Bytes";
            }
            else if (len < 51200000)
            {
                return "Kb";
            }
            else
            {
                return "Mb";
            }
        }

        public static String NormalizeSize(long len)
        {
            if (len < 1024)
            {
                return len.ToString();
            }
            else if (len < 51200000)
            {
                return ((long)(len / 1024)).ToString();
            }
            else
            {
                return ((long)(len / 102400)).ToString();
            }
        }

    }
}
