using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucene.Net.LukeNet
{
    public partial class Luke
    {
        #region Private UI Controls
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemSeparator;
        private System.Windows.Forms.MenuItem menuItemTools;
        private System.Windows.Forms.MenuItem menuItemHelp;
        private System.Windows.Forms.MenuItem menuItemAbout;
        private System.Windows.Forms.StatusBarPanel statusBarPanelIndex;
        private System.Windows.Forms.StatusBarPanel statusBarPanelMessage;
        private System.Windows.Forms.StatusBarPanel statusBarPanelLogo;
        private System.Windows.Forms.ColumnHeader columnHeaderNo;
        private System.Windows.Forms.ColumnHeader columnHeaderTopTermRank;
        private System.Windows.Forms.ColumnHeader columnHeaderTopTermField;
        private System.Windows.Forms.ColumnHeader columnHeaderTopTermText;
        private System.Windows.Forms.ColumnHeader columnHeaderFieldName;
        private System.Windows.Forms.Label labelTopTerms;
        private System.Windows.Forms.Label labelNumOfTerms;
        private System.Windows.Forms.Label labelSelectHint;
        private System.Windows.Forms.Label labelSelectHelp;
        private System.Windows.Forms.Label labelLastMod;
        private System.Windows.Forms.Label labelNumTerms;
        private System.Windows.Forms.Label labelNumDocs;
        private System.Windows.Forms.Label labelNumFields;
        private System.Windows.Forms.Label labelIndexName;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.StatusBar statusBar;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabOverview;
        internal SearchTabPage searchTabPage;

        private System.Windows.Forms.Button buttonTopTerms;
        private System.Windows.Forms.Label separatorOverview;
        private System.Windows.Forms.Label labelDeletionsTitle;
        private System.Windows.Forms.Label labelDeletions;
        private System.Windows.Forms.Label labelVersionTitle;
        
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelMod;
        private System.Windows.Forms.Label labelTerms;
        private System.Windows.Forms.Label labelDocs;
        private System.Windows.Forms.Label labelFields;
        private System.Windows.Forms.Label labelListFields;
        private System.Windows.Forms.DomainUpDown domainTerms;
        private System.Windows.Forms.ListView listTerms;
        private System.Windows.Forms.ListView listFields;
        internal System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem contextMenuItemBrowse;
        private System.Windows.Forms.MenuItem contextMenuItemShowAll;
        private System.Windows.Forms.MenuItem contextMenuItemShowTV;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemOptimize;
        private System.Windows.Forms.MenuItem menuItemOpenIndex;
        private System.Windows.Forms.MenuItem menuItemUndelete;
        private System.Windows.Forms.MenuItem menuItemCompound;
        private System.Windows.Forms.MenuItem menuItem2;

        private System.Windows.Forms.Label labelVersion;

        internal System.Windows.Forms.ToolTip toolTip;
        internal System.Windows.Forms.ImageList imageList;

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
            this.contextMenu = new System.Windows.Forms.ContextMenu();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabOverview = new System.Windows.Forms.TabPage();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelVersionTitle = new System.Windows.Forms.Label();
            this.labelDeletions = new System.Windows.Forms.Label();
            this.labelDeletionsTitle = new System.Windows.Forms.Label();
            this.listFields = new System.Windows.Forms.ListView();
            this.columnHeaderFieldName = new System.Windows.Forms.ColumnHeader();
            this.listTerms = new System.Windows.Forms.ListView();
            this.columnHeaderNo = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTopTermRank = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTopTermField = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTopTermText = new System.Windows.Forms.ColumnHeader();
            this.labelTopTerms = new System.Windows.Forms.Label();
            this.domainTerms = new System.Windows.Forms.DomainUpDown();
            this.labelNumOfTerms = new System.Windows.Forms.Label();
            this.buttonTopTerms = new System.Windows.Forms.Button();
            this.labelListFields = new System.Windows.Forms.Label();
            this.labelSelectHint = new System.Windows.Forms.Label();
            this.labelSelectHelp = new System.Windows.Forms.Label();
            this.separatorOverview = new System.Windows.Forms.Label();
            this.labelFields = new System.Windows.Forms.Label();
            this.labelDocs = new System.Windows.Forms.Label();
            this.labelTerms = new System.Windows.Forms.Label();
            this.labelMod = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelLastMod = new System.Windows.Forms.Label();
            this.labelNumTerms = new System.Windows.Forms.Label();
            this.labelNumDocs = new System.Windows.Forms.Label();
            this.labelNumFields = new System.Windows.Forms.Label();
            this.labelIndexName = new System.Windows.Forms.Label();
            this.searchTabPage = new Lucene.Net.LukeNet.SearchTabPage(this);
            this.tabFiles = new Lucene.Net.LukeNet.FilesTabPage(this.components);
            this.pluginsTabPage = new Lucene.Net.LukeNet.PluginsTabPage(this);
            this.documentsTabPage = new LukeNet.DocumentsTabPage(this);

            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelLogo)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabOverview.SuspendLayout();
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
            this.tabControl.Controls.Add(this.tabOverview);
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
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabOverview
            // 
            this.tabOverview.Controls.Add(this.labelVersion);
            this.tabOverview.Controls.Add(this.labelVersionTitle);
            this.tabOverview.Controls.Add(this.labelDeletions);
            this.tabOverview.Controls.Add(this.labelDeletionsTitle);
            this.tabOverview.Controls.Add(this.listFields);
            this.tabOverview.Controls.Add(this.listTerms);
            this.tabOverview.Controls.Add(this.labelTopTerms);
            this.tabOverview.Controls.Add(this.domainTerms);
            this.tabOverview.Controls.Add(this.labelNumOfTerms);
            this.tabOverview.Controls.Add(this.buttonTopTerms);
            this.tabOverview.Controls.Add(this.labelListFields);
            this.tabOverview.Controls.Add(this.labelSelectHint);
            this.tabOverview.Controls.Add(this.labelSelectHelp);
            this.tabOverview.Controls.Add(this.separatorOverview);
            this.tabOverview.Controls.Add(this.labelFields);
            this.tabOverview.Controls.Add(this.labelDocs);
            this.tabOverview.Controls.Add(this.labelTerms);
            this.tabOverview.Controls.Add(this.labelMod);
            this.tabOverview.Controls.Add(this.labelName);
            this.tabOverview.Controls.Add(this.labelLastMod);
            this.tabOverview.Controls.Add(this.labelNumTerms);
            this.tabOverview.Controls.Add(this.labelNumDocs);
            this.tabOverview.Controls.Add(this.labelNumFields);
            this.tabOverview.Controls.Add(this.labelIndexName);
            this.tabOverview.ImageIndex = 0;
            this.tabOverview.Location = new System.Drawing.Point(4, 23);
            this.tabOverview.Name = "tabOverview";
            this.tabOverview.Size = new System.Drawing.Size(752, 498);
            this.tabOverview.TabIndex = 0;
            this.tabOverview.Text = "Overview";
            this.tabOverview.Resize += new System.EventHandler(this.tabOverview_Resize);
            // 
            // labelVersion
            // 
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVersion.Location = new System.Drawing.Point(128, 88);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(496, 16);
            this.labelVersion.TabIndex = 23;
            this.labelVersion.Text = "?";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersionTitle
            // 
            this.labelVersionTitle.AutoSize = true;
            this.labelVersionTitle.Location = new System.Drawing.Point(51, 88);
            this.labelVersionTitle.Name = "labelVersionTitle";
            this.labelVersionTitle.Size = new System.Drawing.Size(73, 13);
            this.labelVersionTitle.TabIndex = 22;
            this.labelVersionTitle.Text = "Index version:";
            this.labelVersionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDeletions
            // 
            this.labelDeletions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDeletions.Location = new System.Drawing.Point(128, 72);
            this.labelDeletions.Name = "labelDeletions";
            this.labelDeletions.Size = new System.Drawing.Size(496, 16);
            this.labelDeletions.TabIndex = 21;
            this.labelDeletions.Text = "?";
            this.labelDeletions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDeletionsTitle
            // 
            this.labelDeletionsTitle.AutoSize = true;
            this.labelDeletionsTitle.Location = new System.Drawing.Point(50, 72);
            this.labelDeletionsTitle.Name = "labelDeletionsTitle";
            this.labelDeletionsTitle.Size = new System.Drawing.Size(74, 13);
            this.labelDeletionsTitle.TabIndex = 20;
            this.labelDeletionsTitle.Text = "Has deletions:";
            this.labelDeletionsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listFields
            // 
            this.listFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listFields.CheckBoxes = true;
            this.listFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFieldName});
            this.listFields.FullRowSelect = true;
            this.listFields.GridLines = true;
            this.listFields.HideSelection = false;
            this.listFields.Location = new System.Drawing.Point(8, 184);
            this.listFields.MultiSelect = false;
            this.listFields.Name = "listFields";
            this.listFields.Size = new System.Drawing.Size(88, 306);
            this.listFields.TabIndex = 14;
            this.listFields.UseCompatibleStateImageBehavior = false;
            this.listFields.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderFieldName
            // 
            this.columnHeaderFieldName.Text = "Name";
            this.columnHeaderFieldName.Width = 84;
            // 
            // listTerms
            // 
            this.listTerms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listTerms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNo,
            this.columnHeaderTopTermRank,
            this.columnHeaderTopTermField,
            this.columnHeaderTopTermText});
            this.listTerms.ContextMenu = this.contextMenu;
            this.listTerms.FullRowSelect = true;
            this.listTerms.GridLines = true;
            this.listTerms.Location = new System.Drawing.Point(224, 184);
            this.listTerms.MultiSelect = false;
            this.listTerms.Name = "listTerms";
            this.listTerms.Size = new System.Drawing.Size(520, 306);
            this.listTerms.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listTerms.TabIndex = 19;
            this.listTerms.UseCompatibleStateImageBehavior = false;
            this.listTerms.View = System.Windows.Forms.View.Details;
            this.listTerms.DoubleClick += new System.EventHandler(this.listTerms_DoubleClick);
            this.listTerms.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listTerms_ColumnClick);
            // 
            // columnHeaderNo
            // 
            this.columnHeaderNo.Text = "¹";
            this.columnHeaderNo.Width = 40;
            // 
            // columnHeaderTopTermRank
            // 
            this.columnHeaderTopTermRank.Text = "Rank";
            this.columnHeaderTopTermRank.Width = 50;
            // 
            // columnHeaderTopTermField
            // 
            this.columnHeaderTopTermField.Text = "Field";
            this.columnHeaderTopTermField.Width = 120;
            // 
            // columnHeaderTopTermText
            // 
            this.columnHeaderTopTermText.Text = "Text";
            this.columnHeaderTopTermText.Width = 306;
            // 
            // labelTopTerms
            // 
            this.labelTopTerms.AutoSize = true;
            this.labelTopTerms.Location = new System.Drawing.Point(224, 168);
            this.labelTopTerms.Name = "labelTopTerms";
            this.labelTopTerms.Size = new System.Drawing.Size(232, 13);
            this.labelTopTerms.TabIndex = 18;
            this.labelTopTerms.Text = "&Top ranking terms. (Right-click for more options)";
            // 
            // domainTerms
            // 
            this.domainTerms.Location = new System.Drawing.Point(128, 272);
            this.domainTerms.Name = "domainTerms";
            this.domainTerms.Size = new System.Drawing.Size(56, 20);
            this.domainTerms.TabIndex = 17;
            this.domainTerms.TextChanged += new System.EventHandler(this.domainTerms_TextChanged);
            // 
            // labelNumOfTerms
            // 
            this.labelNumOfTerms.AutoSize = true;
            this.labelNumOfTerms.Location = new System.Drawing.Point(104, 256);
            this.labelNumOfTerms.Name = "labelNumOfTerms";
            this.labelNumOfTerms.Size = new System.Drawing.Size(105, 13);
            this.labelNumOfTerms.TabIndex = 16;
            this.labelNumOfTerms.Text = "&Number of top terms:";
            // 
            // buttonTopTerms
            // 
            this.buttonTopTerms.Location = new System.Drawing.Point(104, 224);
            this.buttonTopTerms.Name = "buttonTopTerms";
            this.buttonTopTerms.Size = new System.Drawing.Size(112, 23);
            this.buttonTopTerms.TabIndex = 15;
            this.buttonTopTerms.Text = "&Show top terms ->";
            this.buttonTopTerms.Click += new System.EventHandler(this.buttonTopTerms_Click);
            // 
            // labelListFields
            // 
            this.labelListFields.AutoSize = true;
            this.labelListFields.Location = new System.Drawing.Point(8, 168);
            this.labelListFields.Name = "labelListFields";
            this.labelListFields.Size = new System.Drawing.Size(83, 13);
            this.labelListFields.TabIndex = 13;
            this.labelListFields.Text = "&Available Fields:";
            // 
            // labelSelectHint
            // 
            this.labelSelectHint.AutoSize = true;
            this.labelSelectHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSelectHint.Location = new System.Drawing.Point(8, 152);
            this.labelSelectHint.Name = "labelSelectHint";
            this.labelSelectHint.Size = new System.Drawing.Size(370, 12);
            this.labelSelectHint.TabIndex = 12;
            this.labelSelectHint.Text = "Hint: use Shift-Click to select ranges, or Ctrl-Click to select multiple fields (" +
                "or unselect all).";
            // 
            // labelSelectHelp
            // 
            this.labelSelectHelp.AutoSize = true;
            this.labelSelectHelp.Location = new System.Drawing.Point(8, 136);
            this.labelSelectHelp.Name = "labelSelectHelp";
            this.labelSelectHelp.Size = new System.Drawing.Size(528, 13);
            this.labelSelectHelp.TabIndex = 11;
            this.labelSelectHelp.Text = "Select fields from the list below, and press button to view top terms in these fi" +
                "elds. No selection means all fields.";
            // 
            // separatorOverview
            // 
            this.separatorOverview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorOverview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separatorOverview.Location = new System.Drawing.Point(8, 128);
            this.separatorOverview.Name = "separatorOverview";
            this.separatorOverview.Size = new System.Drawing.Size(736, 3);
            this.separatorOverview.TabIndex = 10;
            // 
            // labelFields
            // 
            this.labelFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFields.Location = new System.Drawing.Point(128, 24);
            this.labelFields.Name = "labelFields";
            this.labelFields.Size = new System.Drawing.Size(496, 16);
            this.labelFields.TabIndex = 9;
            this.labelFields.Text = "?";
            this.labelFields.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDocs
            // 
            this.labelDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDocs.Location = new System.Drawing.Point(128, 40);
            this.labelDocs.Name = "labelDocs";
            this.labelDocs.Size = new System.Drawing.Size(496, 16);
            this.labelDocs.TabIndex = 8;
            this.labelDocs.Text = "?";
            this.labelDocs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTerms
            // 
            this.labelTerms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTerms.Location = new System.Drawing.Point(128, 56);
            this.labelTerms.Name = "labelTerms";
            this.labelTerms.Size = new System.Drawing.Size(496, 16);
            this.labelTerms.TabIndex = 7;
            this.labelTerms.Text = "?";
            this.labelTerms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMod
            // 
            this.labelMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMod.Location = new System.Drawing.Point(128, 104);
            this.labelMod.Name = "labelMod";
            this.labelMod.Size = new System.Drawing.Size(496, 16);
            this.labelMod.TabIndex = 6;
            this.labelMod.Text = "?";
            this.labelMod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(128, 8);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(496, 16);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "?";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLastMod
            // 
            this.labelLastMod.AutoSize = true;
            this.labelLastMod.Location = new System.Drawing.Point(51, 104);
            this.labelLastMod.Name = "labelLastMod";
            this.labelLastMod.Size = new System.Drawing.Size(72, 13);
            this.labelLastMod.TabIndex = 4;
            this.labelLastMod.Text = "Last modified:";
            this.labelLastMod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNumTerms
            // 
            this.labelNumTerms.AutoSize = true;
            this.labelNumTerms.Location = new System.Drawing.Point(35, 56);
            this.labelNumTerms.Name = "labelNumTerms";
            this.labelNumTerms.Size = new System.Drawing.Size(87, 13);
            this.labelNumTerms.TabIndex = 3;
            this.labelNumTerms.Text = "Number of terms:";
            this.labelNumTerms.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNumDocs
            // 
            this.labelNumDocs.AutoSize = true;
            this.labelNumDocs.Location = new System.Drawing.Point(8, 40);
            this.labelNumDocs.Name = "labelNumDocs";
            this.labelNumDocs.Size = new System.Drawing.Size(114, 13);
            this.labelNumDocs.TabIndex = 2;
            this.labelNumDocs.Text = "Number of documents:";
            this.labelNumDocs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNumFields
            // 
            this.labelNumFields.AutoSize = true;
            this.labelNumFields.Location = new System.Drawing.Point(36, 24);
            this.labelNumFields.Name = "labelNumFields";
            this.labelNumFields.Size = new System.Drawing.Size(86, 13);
            this.labelNumFields.TabIndex = 1;
            this.labelNumFields.Text = "Number of fields:";
            this.labelNumFields.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelIndexName
            // 
            this.labelIndexName.AutoSize = true;
            this.labelIndexName.Location = new System.Drawing.Point(60, 8);
            this.labelIndexName.Name = "labelIndexName";
            this.labelIndexName.Size = new System.Drawing.Size(65, 13);
            this.labelIndexName.TabIndex = 0;
            this.labelIndexName.Text = "Index name:";
            this.labelIndexName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.tabOverview.ResumeLayout(false);
            this.tabOverview.PerformLayout();
            this.documentsTabPage.ResumeLayout(false);
            this.documentsTabPage.PerformLayout();
            this.searchTabPage.ResumeLayout(false);
            this.searchTabPage.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

    }
}
