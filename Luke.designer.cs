using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucene.Net.LukeNet
{
    public partial class Luke
    {
        #region Private UI Controls
        private System.ComponentModel.IContainer components;

        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemTools;
        private System.Windows.Forms.MenuItem menuItemHelp;

        private System.Windows.Forms.MenuItem menuItemOpenIndex;
        private System.Windows.Forms.MenuItem menuItemSeparator;
        private System.Windows.Forms.MenuItem menuItemExit;

        private System.Windows.Forms.MenuItem menuItemOptimize;
        private System.Windows.Forms.MenuItem menuItemUndelete;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItemCompound;

        private System.Windows.Forms.MenuItem menuItemAbout;

        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.TabControl tabControl;

        private System.Windows.Forms.StatusBarPanel statusBarPanelIndex;
        private System.Windows.Forms.StatusBarPanel statusBarPanelMessage;
        private System.Windows.Forms.StatusBarPanel statusBarPanelLogo;

        internal System.Windows.Forms.ToolTip toolTip;
        internal System.Windows.Forms.ImageList imageList;

        private LukeNet.OverviewTabPage overviewTabPage;
        internal LukeNet.SearchTabPage searchTabPage;
        private LukeNet.DocumentsTabPage documentsTabPage;
        private LukeNet.FilesTabPage tabFiles;
        private LukeNet.PluginsTabPage pluginsTabPage;

        #endregion Private UI Controls

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Luke));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemOpenIndex = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemTools = new System.Windows.Forms.MenuItem();
            this.menuItemUndelete = new System.Windows.Forms.MenuItem();
            this.menuItemOptimize = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemCompound = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanelIndex = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelMessage = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelLogo = new System.Windows.Forms.StatusBarPanel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.overviewTabPage = new Lucene.Net.LukeNet.OverviewTabPage(this);
            this.searchTabPage = new Lucene.Net.LukeNet.SearchTabPage(this);
            this.tabFiles = new Lucene.Net.LukeNet.FilesTabPage(this.components);
            this.pluginsTabPage = new Lucene.Net.LukeNet.PluginsTabPage(this);
            this.documentsTabPage = new LukeNet.DocumentsTabPage(this);

            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelLogo)).BeginInit();
            this.tabControl.SuspendLayout();
            this.overviewTabPage.SuspendLayout();
            this.documentsTabPage.SuspendLayout();
            this.searchTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemTools,
            this.menuItemHelp});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOpenIndex,
            this.menuItemSeparator,
            this.menuItemExit});
            this.menuItemFile.Text = "&File";
            // 
            // menuItemOpenIndex
            // 
            this.menuItemOpenIndex.Index = 0;
            this.menuItemOpenIndex.Text = "&Open Lucene Index";
            this.menuItemOpenIndex.Click += new System.EventHandler(this.OnOpenIndex);
            // 
            // menuItemSeparator
            // 
            this.menuItemSeparator.Index = 1;
            this.menuItemSeparator.Text = "-";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 2;
            this.menuItemExit.Text = "&Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemTools
            // 
            this.menuItemTools.Index = 1;
            this.menuItemTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemUndelete,
            this.menuItemOptimize,
            this.menuItem2,
            this.menuItemCompound});
            this.menuItemTools.Text = "&Tools";
            // 
            // menuItemUndelete
            // 
            this.menuItemUndelete.Index = 0;
            this.menuItemUndelete.Text = "&Undelete All";
            this.menuItemUndelete.Click += new System.EventHandler(this.menuItemUndelete_Click);
            // 
            // menuItemOptimize
            // 
            this.menuItemOptimize.Index = 1;
            this.menuItemOptimize.Text = "&Optimize Index";
            this.menuItemOptimize.Click += new System.EventHandler(this.menuItemOptimize_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "-";
            // 
            // menuItemCompound
            // 
            this.menuItemCompound.Checked = true;
            this.menuItemCompound.Index = 3;
            this.menuItemCompound.Text = "Use &Compound Files";
            this.menuItemCompound.Click += new System.EventHandler(this.menuItemCompound_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Index = 2;
            this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemAbout});
            this.menuItemHelp.Text = "&Help";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 0;
            this.menuItemAbout.Text = "&About...";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 532);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanelIndex,
            this.statusBarPanelMessage,
            this.statusBarPanelLogo});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(760, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 0;
            this.statusBar.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.statusBar_PanelClick);
            // 
            // statusBarPanelIndex
            // 
            this.statusBarPanelIndex.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanelIndex.Name = "statusBarPanelIndex";
            this.statusBarPanelIndex.Text = "Index name: ?";
            this.statusBarPanelIndex.Width = 86;
            // 
            // statusBarPanelMessage
            // 
            this.statusBarPanelMessage.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanelMessage.MinWidth = 150;
            this.statusBarPanelMessage.Name = "statusBarPanelMessage";
            this.statusBarPanelMessage.Width = 643;
            // 
            // statusBarPanelLogo
            // 
            this.statusBarPanelLogo.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusBarPanelLogo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanelLogo.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanelLogo.Icon")));
            this.statusBarPanelLogo.MinWidth = 5;
            this.statusBarPanelLogo.Name = "statusBarPanelLogo";
            this.statusBarPanelLogo.ToolTipText = "Go to Luke homepage";
            this.statusBarPanelLogo.Width = 31;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.overviewTabPage);
            this.tabControl.Controls.Add(this.documentsTabPage);
            this.tabControl.Controls.Add(this.searchTabPage);
            this.tabControl.Controls.Add(this.tabFiles);
            this.tabControl.Controls.Add(this.pluginsTabPage);
            this.tabControl.ImageList = this.imageList;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(760, 525);
            this.tabControl.TabIndex = 0;
            // 
            // tabOverview
            // 
            this.overviewTabPage.ImageIndex = 0;
            this.overviewTabPage.Location = new System.Drawing.Point(4, 23);
            this.overviewTabPage.Name = "tabOverview";
            this.overviewTabPage.Size = new System.Drawing.Size(752, 498);
            this.overviewTabPage.TabIndex = 0;
            this.overviewTabPage.Text = "Overview";
            this.overviewTabPage.Resize += new System.EventHandler(this.overviewTabPage.OnResize);
            // 
            // documentsTabPage
            // 
            this.documentsTabPage.ImageIndex = 1;
            this.documentsTabPage.Location = new System.Drawing.Point(4, 23);
            this.documentsTabPage.Name = "documentsTabPage";
            this.documentsTabPage.Size = new System.Drawing.Size(752, 498);
            this.documentsTabPage.TabIndex = 1;
            this.documentsTabPage.Text = "Documents";
            this.documentsTabPage.Resize += new System.EventHandler(this.documentsTabPage.OnResize);
            // 
            // searchTabPage
            // 
            this.searchTabPage.ImageIndex = 2;
            this.searchTabPage.Location = new System.Drawing.Point(4, 23);
            this.searchTabPage.Name = "tabSearch";
            this.searchTabPage.Size = new System.Drawing.Size(752, 498);
            this.searchTabPage.TabIndex = 2;
            this.searchTabPage.Text = "Search";
            // 
            // tabFiles
            // 
            this.tabFiles.ImageIndex = 4;
            this.tabFiles.Location = new System.Drawing.Point(4, 23);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Size = new System.Drawing.Size(752, 498);
            this.tabFiles.TabIndex = 3;
            this.tabFiles.Text = "Files";
            // 
            // pluginsTabPage
            // 
            this.pluginsTabPage.ImageIndex = 5;
            this.pluginsTabPage.Location = new System.Drawing.Point(4, 23);
            this.pluginsTabPage.Name = "pluginsTabPage";
            this.pluginsTabPage.Size = new System.Drawing.Size(752, 498);
            this.pluginsTabPage.TabIndex = 4;
            this.pluginsTabPage.Text = "Plugins";
            // 
            // Luke
            // 
            this.ClientSize = new System.Drawing.Size(760, 554);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(768, 592);
            this.Name = "Luke";
            this.Text = " Luke - Lucene Index Toolbox, v 0.5 (2004-06-25)";
            this.Load += new System.EventHandler(this.Luke_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelLogo)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.overviewTabPage.ResumeLayout(false);
            this.overviewTabPage.PerformLayout();
            this.documentsTabPage.ResumeLayout(false);
            this.documentsTabPage.PerformLayout();
            this.searchTabPage.ResumeLayout(false);
            this.searchTabPage.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

    }
}
