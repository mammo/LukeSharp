using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lucene.Net.LukeNet
{
    public partial class OpenIndex : System.Windows.Forms.Form
    {
        private Preferences _preferences;

        public bool ReadOnlyIndex
        {
            get
            { return checkRO.Checked; }
            set
            { checkRO.Checked = value; }
        }

        public bool UnlockIndex
        {
            get
            { return checkUnlock.Checked; }
            set
            { checkUnlock.Checked = value; }
        }

        public String Path
        {
            get
            { return textPath.Text.Trim(); }
        }

        public OpenIndex(Preferences p)
        {
            InitializeComponent();

            _preferences = p;

            foreach (string path in _preferences.MruList)
            {
                textPath.Items.Add(path);
            }
            if (_preferences.MruList.Count > 0)
            {
                folderBrowser.SelectedPath = _preferences.MruList[0];
            }
        }

        private void buttonBrowse_Click(object sender, System.EventArgs e)
        {
            if (folderBrowser.ShowDialog(this) == DialogResult.OK)
                textPath.Text = folderBrowser.SelectedPath;
        }

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
            base.Dispose(disposing);
        }

    }
}
