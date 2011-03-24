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
        private System.Windows.Forms.Label labelTopTerms;
        private System.Windows.Forms.Label labelNumOfTerms;
        private System.Windows.Forms.Label labelSelectHint;
        private System.Windows.Forms.Label labelSelectHelp;
        private System.Windows.Forms.Label labelLastMod;
        private System.Windows.Forms.Label labelNumTerms;
        private System.Windows.Forms.Label labelNumDocs;
        private System.Windows.Forms.Label labelNumFields;
        private System.Windows.Forms.Label labelIndexName;
        private System.Windows.Forms.Label labelLegend;
        private System.Windows.Forms.Label labelDocTermFreq;
        private System.Windows.Forms.Label labelOf;
        private System.Windows.Forms.Label labelDoc;
        private System.Windows.Forms.Label labelTermDocFreq;
        private System.Windows.Forms.Label labelTerm;
        private System.Windows.Forms.Label labelBrowseHint;
        private System.Windows.Forms.Label labelZeroDoc;
        private System.Windows.Forms.Label labelBrowseDoc;
        private System.Windows.Forms.Label labelSearchResult;
        private System.Windows.Forms.Label labelSearchDocs;
        private System.Windows.Forms.ColumnHeader columnHeaderFieldName;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemOptimize;
        private System.Windows.Forms.Button buttonTopTerms;
        private System.Windows.Forms.Label labelDocNum;
        private System.Windows.Forms.Label labelDocMax;
        private System.Windows.Forms.Label labelTermFreq;
        private System.Windows.Forms.Label labelSearchRes;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.StatusBar statusBar;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabOverview;
        private System.Windows.Forms.TabPage tabDocuments;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelMod;
        private System.Windows.Forms.Label labelTerms;
        private System.Windows.Forms.Label labelDocs;
        private System.Windows.Forms.Label labelFields;
        private System.Windows.Forms.Label labelListFields;
        private System.Windows.Forms.DomainUpDown domainTerms;
        private System.Windows.Forms.ListView listTerms;
        private System.Windows.Forms.ListView listFields;
        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem contextMenuItemBrowse;
        private System.Windows.Forms.MenuItem contextMenuItemShowAll;
        private System.Windows.Forms.MenuItem contextMenuItemShowTV;
        private System.Windows.Forms.GroupBox groupDocNumber;
        private System.Windows.Forms.GroupBox groupTerm;
        private System.Windows.Forms.Button buttonPrevDoc;
        private System.Windows.Forms.TextBox textDocNum;
        private System.Windows.Forms.Button buttonNextDoc;
        private System.Windows.Forms.Label labelIndDocs;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonFirstTerm;
        private System.Windows.Forms.ComboBox comboTerms;
        private System.Windows.Forms.TextBox textTerm;
        private System.Windows.Forms.Button buttonNextTerm;
        private System.Windows.Forms.Label labelDocFreq;
        private System.Windows.Forms.Button buttonShowFirstDoc;
        private System.Windows.Forms.Button buttonShowNextDoc;
        private System.Windows.Forms.Button buttonShowAllDocs;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ColumnHeader columnHeaderField;
        private System.Windows.Forms.ColumnHeader columnHeaderIndexed;
        private System.Windows.Forms.ColumnHeader columnHeaderToken;
        private System.Windows.Forms.ColumnHeader columnHeaderStored;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.Button buttonCopySelected;
        private System.Windows.Forms.Button buttonCopyAll;
        private System.Windows.Forms.Button buttonDeleteAllDocs;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView listDocFields;
        private System.Windows.Forms.Label labelCopy;
        private System.Windows.Forms.Label separatorOverview;
        private System.Windows.Forms.ColumnHeader columnHeaderRank;
        private System.Windows.Forms.ColumnHeader columnHeaderDocId;
        private System.Windows.Forms.ListView listSearch;
        private System.Windows.Forms.Button buttonSearchDelete;
        private System.Windows.Forms.MenuItem menuItemOpenIndex;
        private System.Windows.Forms.MenuItem menuItemUndelete;
        private System.Windows.Forms.MenuItem menuItemCompound;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Label labelDeletionsTitle;
        private System.Windows.Forms.Label labelDeletions;
        private System.Windows.Forms.Label labelVersionTitle;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button btnReconstruct;
        private System.Windows.Forms.Label labelInfoDocNumTitle;
        private System.Windows.Forms.Label labelInfoDocNum;
        private System.Windows.Forms.ColumnHeader columnHeaderTV;
        private System.Windows.Forms.Button btnTermVector;
        private System.Windows.Forms.Button btnExplain;
        private System.Windows.Forms.GroupBox groupSearchOptions;
        private System.Windows.Forms.Button btnUpdateParsedQuery;
        private System.Windows.Forms.Label labelParsedQuery;
        private System.Windows.Forms.ComboBox comboFields;
        private System.Windows.Forms.Label labelDefaultField;
        private System.Windows.Forms.ComboBox comboAnalyzer;
        private System.Windows.Forms.Label labelAnalyzer;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Label labelSearchExpr;
        private System.Windows.Forms.TabPage tabFiles;
        private System.Windows.Forms.Label labelIndexSize;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.ListView listIndexFiles;
        private System.Windows.Forms.ColumnHeader columnFilename;
        private System.Windows.Forms.ColumnHeader columnSize;
        private System.Windows.Forms.ColumnHeader columnUnit;
        private System.Windows.Forms.TabPage tabPlugins;
        private System.Windows.Forms.ListBox lstPlugins;
        private System.Windows.Forms.GroupBox groupPlugin;
        private System.Windows.Forms.GroupBox groupPluginInfo;
        private System.Windows.Forms.Label lblPluginInfo;
        private System.Windows.Forms.LinkLabel linkPluginURL;
        private System.Windows.Forms.Panel panelPlugin;
        #endregion Private UI Controls

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Luke));
            this.mainMenu = new System.Windows.Forms.MainMenu();
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
            this.contextMenu = new System.Windows.Forms.ContextMenu();
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
            this.tabDocuments = new System.Windows.Forms.TabPage();
            this.btnTermVector = new System.Windows.Forms.Button();
            this.labelInfoDocNum = new System.Windows.Forms.Label();
            this.labelInfoDocNumTitle = new System.Windows.Forms.Label();
            this.labelCopy = new System.Windows.Forms.Label();
            this.buttonCopyAll = new System.Windows.Forms.Button();
            this.buttonCopySelected = new System.Windows.Forms.Button();
            this.labelLegend = new System.Windows.Forms.Label();
            this.listDocFields = new System.Windows.Forms.ListView();
            this.columnHeaderField = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderIndexed = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderToken = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderStored = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTV = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderBoost = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderValue = new System.Windows.Forms.ColumnHeader();
            this.groupTerm = new System.Windows.Forms.GroupBox();
            this.labelTermFreq = new System.Windows.Forms.Label();
            this.labelDocTermFreq = new System.Windows.Forms.Label();
            this.labelDocMax = new System.Windows.Forms.Label();
            this.labelOf = new System.Windows.Forms.Label();
            this.labelDocNum = new System.Windows.Forms.Label();
            this.labelDoc = new System.Windows.Forms.Label();
            this.buttonDeleteAllDocs = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.buttonShowAllDocs = new System.Windows.Forms.Button();
            this.buttonShowNextDoc = new System.Windows.Forms.Button();
            this.buttonShowFirstDoc = new System.Windows.Forms.Button();
            this.labelDocFreq = new System.Windows.Forms.Label();
            this.labelTermDocFreq = new System.Windows.Forms.Label();
            this.buttonNextTerm = new System.Windows.Forms.Button();
            this.textTerm = new System.Windows.Forms.TextBox();
            this.comboTerms = new System.Windows.Forms.ComboBox();
            this.labelTerm = new System.Windows.Forms.Label();
            this.buttonFirstTerm = new System.Windows.Forms.Button();
            this.labelBrowseHint = new System.Windows.Forms.Label();
            this.groupDocNumber = new System.Windows.Forms.GroupBox();
            this.btnReconstruct = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelIndDocs = new System.Windows.Forms.Label();
            this.buttonNextDoc = new System.Windows.Forms.Button();
            this.textDocNum = new System.Windows.Forms.TextBox();
            this.buttonPrevDoc = new System.Windows.Forms.Button();
            this.labelZeroDoc = new System.Windows.Forms.Label();
            this.labelBrowseDoc = new System.Windows.Forms.Label();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.groupSearchOptions = new System.Windows.Forms.GroupBox();
            this.btnUpdateParsedQuery = new System.Windows.Forms.Button();
            this.textParsed = new System.Windows.Forms.TextBox();
            this.labelParsedQuery = new System.Windows.Forms.Label();
            this.comboFields = new System.Windows.Forms.ComboBox();
            this.labelDefaultField = new System.Windows.Forms.Label();
            this.comboAnalyzer = new System.Windows.Forms.ComboBox();
            this.labelAnalyzer = new System.Windows.Forms.Label();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.labelSearchExpr = new System.Windows.Forms.Label();
            this.btnExplain = new System.Windows.Forms.Button();
            this.labelSearchResult = new System.Windows.Forms.Label();
            this.labelSearchDocs = new System.Windows.Forms.Label();
            this.labelSearchRes = new System.Windows.Forms.Label();
            this.listSearch = new System.Windows.Forms.ListView();
            this.columnHeaderRank = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDocId = new System.Windows.Forms.ColumnHeader();
            this.buttonSearchDelete = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.tabFiles = new System.Windows.Forms.TabPage();
            this.listIndexFiles = new System.Windows.Forms.ListView();
            this.columnFilename = new System.Windows.Forms.ColumnHeader();
            this.columnSize = new System.Windows.Forms.ColumnHeader();
            this.columnUnit = new System.Windows.Forms.ColumnHeader();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.labelIndexSize = new System.Windows.Forms.Label();
            this.tabPlugins = new System.Windows.Forms.TabPage();
            this.groupPlugin = new System.Windows.Forms.GroupBox();
            this.panelPlugin = new System.Windows.Forms.Panel();
            this.groupPluginInfo = new System.Windows.Forms.GroupBox();
            this.linkPluginURL = new System.Windows.Forms.LinkLabel();
            this.lblPluginInfo = new System.Windows.Forms.Label();
            this.lstPlugins = new System.Windows.Forms.ListBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelLogo)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabOverview.SuspendLayout();
            this.tabDocuments.SuspendLayout();
            this.groupTerm.SuspendLayout();
            this.groupDocNumber.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.groupSearchOptions.SuspendLayout();
            this.tabFiles.SuspendLayout();
            this.tabPlugins.SuspendLayout();
            this.groupPlugin.SuspendLayout();
            this.groupPluginInfo.SuspendLayout();
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
            this.statusBar.Location = new System.Drawing.Point(0, 543);
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
            this.statusBarPanelIndex.Text = "Index name: ?";
            this.statusBarPanelIndex.Width = 86;
            // 
            // statusBarPanelMessage
            // 
            this.statusBarPanelMessage.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanelMessage.MinWidth = 150;
            this.statusBarPanelMessage.Width = 643;
            // 
            // statusBarPanelLogo
            // 
            this.statusBarPanelLogo.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusBarPanelLogo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanelLogo.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanelLogo.Icon")));
            this.statusBarPanelLogo.MinWidth = 5;
            this.statusBarPanelLogo.ToolTipText = "Go to Luke homepage";
            this.statusBarPanelLogo.Width = 31;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
            this.tabControl.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.tabOverview,
																					 this.tabDocuments,
																					 this.tabSearch,
																					 this.tabFiles,
																					 this.tabPlugins});
            this.tabControl.ImageList = this.imageList;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(760, 536);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabOverview
            // 
            this.tabOverview.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.labelVersion,
																					  this.labelVersionTitle,
																					  this.labelDeletions,
																					  this.labelDeletionsTitle,
																					  this.listFields,
																					  this.listTerms,
																					  this.labelTopTerms,
																					  this.domainTerms,
																					  this.labelNumOfTerms,
																					  this.buttonTopTerms,
																					  this.labelListFields,
																					  this.labelSelectHint,
																					  this.labelSelectHelp,
																					  this.separatorOverview,
																					  this.labelFields,
																					  this.labelDocs,
																					  this.labelTerms,
																					  this.labelMod,
																					  this.labelName,
																					  this.labelLastMod,
																					  this.labelNumTerms,
																					  this.labelNumDocs,
																					  this.labelNumFields,
																					  this.labelIndexName});
            this.tabOverview.ImageIndex = 0;
            this.tabOverview.Location = new System.Drawing.Point(4, 23);
            this.tabOverview.Name = "tabOverview";
            this.tabOverview.Size = new System.Drawing.Size(752, 509);
            this.tabOverview.TabIndex = 0;
            this.tabOverview.Text = "Overview";
            this.tabOverview.Resize += new System.EventHandler(this.tabOverview_Resize);
            // 
            // labelVersion
            // 
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
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
            this.labelVersionTitle.Size = new System.Drawing.Size(75, 13);
            this.labelVersionTitle.TabIndex = 22;
            this.labelVersionTitle.Text = "Index version:";
            this.labelVersionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDeletions
            // 
            this.labelDeletions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
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
            this.labelDeletionsTitle.Size = new System.Drawing.Size(76, 13);
            this.labelDeletionsTitle.TabIndex = 20;
            this.labelDeletionsTitle.Text = "Has deletions:";
            this.labelDeletionsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listFields
            // 
            this.listFields.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left);
            this.listFields.CheckBoxes = true;
            this.listFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.columnHeaderFieldName});
            this.listFields.FullRowSelect = true;
            this.listFields.GridLines = true;
            this.listFields.HideSelection = false;
            this.listFields.Location = new System.Drawing.Point(8, 184);
            this.listFields.MultiSelect = false;
            this.listFields.Name = "listFields";
            this.listFields.Size = new System.Drawing.Size(88, 317);
            this.listFields.TabIndex = 14;
            this.listFields.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderFieldName
            // 
            this.columnHeaderFieldName.Text = "Name";
            this.columnHeaderFieldName.Width = 84;
            // 
            // listTerms
            // 
            this.listTerms.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
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
            this.listTerms.Size = new System.Drawing.Size(520, 317);
            this.listTerms.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listTerms.TabIndex = 19;
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
            this.labelTopTerms.Size = new System.Drawing.Size(246, 13);
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
            this.labelNumOfTerms.Size = new System.Drawing.Size(110, 13);
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
            this.labelListFields.Size = new System.Drawing.Size(87, 13);
            this.labelListFields.TabIndex = 13;
            this.labelListFields.Text = "&Available Fields:";
            // 
            // labelSelectHint
            // 
            this.labelSelectHint.AutoSize = true;
            this.labelSelectHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.labelSelectHint.Location = new System.Drawing.Point(8, 152);
            this.labelSelectHint.Name = "labelSelectHint";
            this.labelSelectHint.Size = new System.Drawing.Size(370, 11);
            this.labelSelectHint.TabIndex = 12;
            this.labelSelectHint.Text = "Hint: use Shift-Click to select ranges, or Ctrl-Click to select multiple fields (" +
                "or unselect all).";
            // 
            // labelSelectHelp
            // 
            this.labelSelectHelp.AutoSize = true;
            this.labelSelectHelp.Location = new System.Drawing.Point(8, 136);
            this.labelSelectHelp.Name = "labelSelectHelp";
            this.labelSelectHelp.Size = new System.Drawing.Size(563, 13);
            this.labelSelectHelp.TabIndex = 11;
            this.labelSelectHelp.Text = "Select fields from the list below, and press button to view top terms in these fi" +
                "elds. No selection means all fields.";
            // 
            // separatorOverview
            // 
            this.separatorOverview.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
            this.separatorOverview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separatorOverview.Location = new System.Drawing.Point(8, 128);
            this.separatorOverview.Name = "separatorOverview";
            this.separatorOverview.Size = new System.Drawing.Size(736, 3);
            this.separatorOverview.TabIndex = 10;
            // 
            // labelFields
            // 
            this.labelFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.labelFields.Location = new System.Drawing.Point(128, 24);
            this.labelFields.Name = "labelFields";
            this.labelFields.Size = new System.Drawing.Size(496, 16);
            this.labelFields.TabIndex = 9;
            this.labelFields.Text = "?";
            this.labelFields.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDocs
            // 
            this.labelDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.labelDocs.Location = new System.Drawing.Point(128, 40);
            this.labelDocs.Name = "labelDocs";
            this.labelDocs.Size = new System.Drawing.Size(496, 16);
            this.labelDocs.TabIndex = 8;
            this.labelDocs.Text = "?";
            this.labelDocs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTerms
            // 
            this.labelTerms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.labelTerms.Location = new System.Drawing.Point(128, 56);
            this.labelTerms.Name = "labelTerms";
            this.labelTerms.Size = new System.Drawing.Size(496, 16);
            this.labelTerms.TabIndex = 7;
            this.labelTerms.Text = "?";
            this.labelTerms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMod
            // 
            this.labelMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.labelMod.Location = new System.Drawing.Point(128, 104);
            this.labelMod.Name = "labelMod";
            this.labelMod.Size = new System.Drawing.Size(496, 16);
            this.labelMod.TabIndex = 6;
            this.labelMod.Text = "?";
            this.labelMod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
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
            this.labelLastMod.Size = new System.Drawing.Size(75, 13);
            this.labelLastMod.TabIndex = 4;
            this.labelLastMod.Text = "Last modified:";
            this.labelLastMod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNumTerms
            // 
            this.labelNumTerms.AutoSize = true;
            this.labelNumTerms.Location = new System.Drawing.Point(35, 56);
            this.labelNumTerms.Name = "labelNumTerms";
            this.labelNumTerms.Size = new System.Drawing.Size(91, 13);
            this.labelNumTerms.TabIndex = 3;
            this.labelNumTerms.Text = "Number of terms:";
            this.labelNumTerms.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNumDocs
            // 
            this.labelNumDocs.AutoSize = true;
            this.labelNumDocs.Location = new System.Drawing.Point(8, 40);
            this.labelNumDocs.Name = "labelNumDocs";
            this.labelNumDocs.Size = new System.Drawing.Size(118, 13);
            this.labelNumDocs.TabIndex = 2;
            this.labelNumDocs.Text = "Number of documents:";
            this.labelNumDocs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNumFields
            // 
            this.labelNumFields.AutoSize = true;
            this.labelNumFields.Location = new System.Drawing.Point(36, 24);
            this.labelNumFields.Name = "labelNumFields";
            this.labelNumFields.Size = new System.Drawing.Size(90, 13);
            this.labelNumFields.TabIndex = 1;
            this.labelNumFields.Text = "Number of fields:";
            this.labelNumFields.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelIndexName
            // 
            this.labelIndexName.AutoSize = true;
            this.labelIndexName.Location = new System.Drawing.Point(60, 8);
            this.labelIndexName.Name = "labelIndexName";
            this.labelIndexName.Size = new System.Drawing.Size(66, 13);
            this.labelIndexName.TabIndex = 0;
            this.labelIndexName.Text = "Index name:";
            this.labelIndexName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabDocuments
            // 
            this.tabDocuments.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.btnTermVector,
																					   this.labelInfoDocNum,
																					   this.labelInfoDocNumTitle,
																					   this.labelCopy,
																					   this.buttonCopyAll,
																					   this.buttonCopySelected,
																					   this.labelLegend,
																					   this.listDocFields,
																					   this.groupTerm,
																					   this.groupDocNumber});
            this.tabDocuments.ImageIndex = 1;
            this.tabDocuments.Location = new System.Drawing.Point(4, 23);
            this.tabDocuments.Name = "tabDocuments";
            this.tabDocuments.Size = new System.Drawing.Size(752, 509);
            this.tabDocuments.TabIndex = 1;
            this.tabDocuments.Text = "Documents";
            this.tabDocuments.Resize += new System.EventHandler(this.tabDocuments_Resize);
            // 
            // btnTermVector
            // 
            this.btnTermVector.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.btnTermVector.Location = new System.Drawing.Point(8, 477);
            this.btnTermVector.Name = "btnTermVector";
            this.btnTermVector.Size = new System.Drawing.Size(128, 23);
            this.btnTermVector.TabIndex = 3;
            this.btnTermVector.Text = "Field\'s Term &Vector";
            this.toolTip.SetToolTip(this.btnTermVector, "Show Term Vector of selected field");
            this.btnTermVector.Click += new System.EventHandler(this.btnTermVector_Click);
            // 
            // labelInfoDocNum
            // 
            this.labelInfoDocNum.Location = new System.Drawing.Point(56, 152);
            this.labelInfoDocNum.Name = "labelInfoDocNum";
            this.labelInfoDocNum.Size = new System.Drawing.Size(336, 13);
            this.labelInfoDocNum.TabIndex = 8;
            // 
            // labelInfoDocNumTitle
            // 
            this.labelInfoDocNumTitle.AutoSize = true;
            this.labelInfoDocNumTitle.Location = new System.Drawing.Point(16, 152);
            this.labelInfoDocNumTitle.Name = "labelInfoDocNumTitle";
            this.labelInfoDocNumTitle.Size = new System.Drawing.Size(34, 13);
            this.labelInfoDocNumTitle.TabIndex = 7;
            this.labelInfoDocNumTitle.Text = "Doc #";
            // 
            // labelCopy
            // 
            this.labelCopy.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.labelCopy.AutoSize = true;
            this.labelCopy.Location = new System.Drawing.Point(379, 482);
            this.labelCopy.Name = "labelCopy";
            this.labelCopy.Size = new System.Drawing.Size(119, 13);
            this.labelCopy.TabIndex = 6;
            this.labelCopy.Text = "Copy text to Clipboard:";
            // 
            // buttonCopyAll
            // 
            this.buttonCopyAll.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.buttonCopyAll.Location = new System.Drawing.Point(623, 477);
            this.buttonCopyAll.Name = "buttonCopyAll";
            this.buttonCopyAll.Size = new System.Drawing.Size(120, 23);
            this.buttonCopyAll.TabIndex = 5;
            this.buttonCopyAll.Text = "C&omplete Document";
            this.toolTip.SetToolTip(this.buttonCopyAll, "Copy all fields to Clipboard");
            this.buttonCopyAll.Click += new System.EventHandler(this.buttonCopyAll_Click);
            // 
            // buttonCopySelected
            // 
            this.buttonCopySelected.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.buttonCopySelected.Location = new System.Drawing.Point(499, 477);
            this.buttonCopySelected.Name = "buttonCopySelected";
            this.buttonCopySelected.Size = new System.Drawing.Size(120, 23);
            this.buttonCopySelected.TabIndex = 4;
            this.buttonCopySelected.Text = "Se&lected Fields";
            this.toolTip.SetToolTip(this.buttonCopySelected, "Copy selected fields to Clipboard");
            this.buttonCopySelected.Click += new System.EventHandler(this.buttonCopySelected_Click);
            // 
            // labelLegend
            // 
            this.labelLegend.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.labelLegend.AutoSize = true;
            this.labelLegend.Location = new System.Drawing.Point(424, 152);
            this.labelLegend.Name = "labelLegend";
            this.labelLegend.Size = new System.Drawing.Size(319, 13);
            this.labelLegend.TabIndex = 3;
            this.labelLegend.Text = "Legend: I - Indexed; T - Tokenized; S - Stored, V - Term Vector";
            // 
            // listDocFields
            // 
            this.listDocFields.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
            this.listDocFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.columnHeaderField,
																							this.columnHeaderIndexed,
																							this.columnHeaderToken,
																							this.columnHeaderStored,
																							this.columnHeaderTV,
																							this.columnHeaderBoost,
																							this.columnHeaderValue});
            this.listDocFields.ContextMenu = this.contextMenu;
            this.listDocFields.FullRowSelect = true;
            this.listDocFields.GridLines = true;
            this.listDocFields.Location = new System.Drawing.Point(8, 168);
            this.listDocFields.MultiSelect = false;
            this.listDocFields.Name = "listDocFields";
            this.listDocFields.Size = new System.Drawing.Size(736, 301);
            this.listDocFields.TabIndex = 2;
            this.listDocFields.View = System.Windows.Forms.View.Details;
            this.listDocFields.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listDocFields_ColumnClick);
            // 
            // columnHeaderField
            // 
            this.columnHeaderField.Text = "Field";
            this.columnHeaderField.Width = 80;
            // 
            // columnHeaderIndexed
            // 
            this.columnHeaderIndexed.Text = " I";
            this.columnHeaderIndexed.Width = 20;
            // 
            // columnHeaderToken
            // 
            this.columnHeaderToken.Text = "T";
            this.columnHeaderToken.Width = 20;
            // 
            // columnHeaderStored
            // 
            this.columnHeaderStored.Text = "S";
            this.columnHeaderStored.Width = 20;
            // 
            // columnHeaderTV
            // 
            this.columnHeaderTV.Text = "V";
            this.columnHeaderTV.Width = 20;
            // 
            // columnHeaderBoost
            // 
            this.columnHeaderBoost.Text = "Boost";
            this.columnHeaderBoost.Width = 40;
            // 
            // columnHeaderValue
            // 
            this.columnHeaderValue.Text = "String Value";
            this.columnHeaderValue.Width = 532;
            // 
            // groupTerm
            // 
            this.groupTerm.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
            this.groupTerm.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.labelTermFreq,
																					this.labelDocTermFreq,
																					this.labelDocMax,
																					this.labelOf,
																					this.labelDocNum,
																					this.labelDoc,
																					this.buttonDeleteAllDocs,
																					this.buttonShowAllDocs,
																					this.buttonShowNextDoc,
																					this.buttonShowFirstDoc,
																					this.labelDocFreq,
																					this.labelTermDocFreq,
																					this.buttonNextTerm,
																					this.textTerm,
																					this.comboTerms,
																					this.labelTerm,
																					this.buttonFirstTerm,
																					this.labelBrowseHint});
            this.groupTerm.Location = new System.Drawing.Point(224, 8);
            this.groupTerm.Name = "groupTerm";
            this.groupTerm.Size = new System.Drawing.Size(520, 136);
            this.groupTerm.TabIndex = 1;
            this.groupTerm.TabStop = false;
            this.groupTerm.Text = "Browse by term";
            // 
            // labelTermFreq
            // 
            this.labelTermFreq.AutoSize = true;
            this.labelTermFreq.Location = new System.Drawing.Point(360, 111);
            this.labelTermFreq.Name = "labelTermFreq";
            this.labelTermFreq.Size = new System.Drawing.Size(10, 13);
            this.labelTermFreq.TabIndex = 17;
            this.labelTermFreq.Text = "?";
            // 
            // labelDocTermFreq
            // 
            this.labelDocTermFreq.AutoSize = true;
            this.labelDocTermFreq.Location = new System.Drawing.Point(248, 111);
            this.labelDocTermFreq.Name = "labelDocTermFreq";
            this.labelDocTermFreq.Size = new System.Drawing.Size(110, 13);
            this.labelDocTermFreq.TabIndex = 16;
            this.labelDocTermFreq.Text = "Term freq in this doc:";
            // 
            // labelDocMax
            // 
            this.labelDocMax.AutoSize = true;
            this.labelDocMax.Location = new System.Drawing.Point(360, 85);
            this.labelDocMax.Name = "labelDocMax";
            this.labelDocMax.Size = new System.Drawing.Size(10, 13);
            this.labelDocMax.TabIndex = 15;
            this.labelDocMax.Text = "?";
            // 
            // labelOf
            // 
            this.labelOf.AutoSize = true;
            this.labelOf.Location = new System.Drawing.Point(336, 85);
            this.labelOf.Name = "labelOf";
            this.labelOf.Size = new System.Drawing.Size(14, 13);
            this.labelOf.TabIndex = 14;
            this.labelOf.Text = "of";
            // 
            // labelDocNum
            // 
            this.labelDocNum.AutoSize = true;
            this.labelDocNum.Location = new System.Drawing.Point(320, 85);
            this.labelDocNum.Name = "labelDocNum";
            this.labelDocNum.Size = new System.Drawing.Size(10, 13);
            this.labelDocNum.TabIndex = 13;
            this.labelDocNum.Text = "?";
            // 
            // labelDoc
            // 
            this.labelDoc.AutoSize = true;
            this.labelDoc.Location = new System.Drawing.Point(248, 85);
            this.labelDoc.Name = "labelDoc";
            this.labelDoc.Size = new System.Drawing.Size(59, 13);
            this.labelDoc.TabIndex = 12;
            this.labelDoc.Text = "Document:";
            // 
            // buttonDeleteAllDocs
            // 
            this.buttonDeleteAllDocs.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonDeleteAllDocs.Image")));
            this.buttonDeleteAllDocs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteAllDocs.ImageIndex = 3;
            this.buttonDeleteAllDocs.ImageList = this.imageList;
            this.buttonDeleteAllDocs.Location = new System.Drawing.Point(123, 106);
            this.buttonDeleteAllDocs.Name = "buttonDeleteAllDocs";
            this.buttonDeleteAllDocs.Size = new System.Drawing.Size(112, 23);
            this.buttonDeleteAllDocs.TabIndex = 11;
            this.buttonDeleteAllDocs.Text = "Delete &All Docs";
            this.buttonDeleteAllDocs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.buttonDeleteAllDocs, "Delete all docs with this term (NO WARNING!)");
            this.buttonDeleteAllDocs.Click += new System.EventHandler(this.buttonDeleteAllDocs_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // buttonShowAllDocs
            // 
            this.buttonShowAllDocs.Location = new System.Drawing.Point(8, 106);
            this.buttonShowAllDocs.Name = "buttonShowAllDocs";
            this.buttonShowAllDocs.Size = new System.Drawing.Size(112, 23);
            this.buttonShowAllDocs.TabIndex = 10;
            this.buttonShowAllDocs.Text = "&Show All Docs";
            this.toolTip.SetToolTip(this.buttonShowAllDocs, "Show all docs with this term");
            this.buttonShowAllDocs.Click += new System.EventHandler(this.buttonShowAllDocs_Click);
            // 
            // buttonShowNextDoc
            // 
            this.buttonShowNextDoc.Location = new System.Drawing.Point(123, 80);
            this.buttonShowNextDoc.Name = "buttonShowNextDoc";
            this.buttonShowNextDoc.Size = new System.Drawing.Size(112, 23);
            this.buttonShowNextDoc.TabIndex = 9;
            this.buttonShowNextDoc.Text = "N&ext Doc ->";
            this.buttonShowNextDoc.Click += new System.EventHandler(this.buttonShowNextDoc_Click);
            // 
            // buttonShowFirstDoc
            // 
            this.buttonShowFirstDoc.Location = new System.Drawing.Point(8, 80);
            this.buttonShowFirstDoc.Name = "buttonShowFirstDoc";
            this.buttonShowFirstDoc.Size = new System.Drawing.Size(112, 23);
            this.buttonShowFirstDoc.TabIndex = 8;
            this.buttonShowFirstDoc.Text = "Fi&rst Doc";
            this.buttonShowFirstDoc.Click += new System.EventHandler(this.buttonShowFirstDoc_Click);
            // 
            // labelDocFreq
            // 
            this.labelDocFreq.AutoSize = true;
            this.labelDocFreq.Location = new System.Drawing.Point(112, 64);
            this.labelDocFreq.Name = "labelDocFreq";
            this.labelDocFreq.Size = new System.Drawing.Size(10, 13);
            this.labelDocFreq.TabIndex = 7;
            this.labelDocFreq.Text = "?";
            // 
            // labelTermDocFreq
            // 
            this.labelTermDocFreq.AutoSize = true;
            this.labelTermDocFreq.Location = new System.Drawing.Point(8, 64);
            this.labelTermDocFreq.Name = "labelTermDocFreq";
            this.labelTermDocFreq.Size = new System.Drawing.Size(109, 13);
            this.labelTermDocFreq.TabIndex = 6;
            this.labelTermDocFreq.Text = "Doc freq of this term:";
            // 
            // buttonNextTerm
            // 
            this.buttonNextTerm.Location = new System.Drawing.Point(284, 32);
            this.buttonNextTerm.Name = "buttonNextTerm";
            this.buttonNextTerm.Size = new System.Drawing.Size(80, 23);
            this.buttonNextTerm.TabIndex = 5;
            this.buttonNextTerm.Text = "&Next Term ->";
            this.buttonNextTerm.Click += new System.EventHandler(this.buttonNextTerm_Click);
            // 
            // textTerm
            // 
            this.textTerm.Location = new System.Drawing.Point(194, 33);
            this.textTerm.Name = "textTerm";
            this.textTerm.Size = new System.Drawing.Size(88, 20);
            this.textTerm.TabIndex = 4;
            this.textTerm.Text = "";
            this.textTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTerm_KeyPress);
            // 
            // comboTerms
            // 
            this.comboTerms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTerms.Location = new System.Drawing.Point(120, 33);
            this.comboTerms.Name = "comboTerms";
            this.comboTerms.Size = new System.Drawing.Size(72, 21);
            this.comboTerms.TabIndex = 3;
            // 
            // labelTerm
            // 
            this.labelTerm.AutoSize = true;
            this.labelTerm.Location = new System.Drawing.Point(88, 37);
            this.labelTerm.Name = "labelTerm";
            this.labelTerm.Size = new System.Drawing.Size(34, 13);
            this.labelTerm.TabIndex = 2;
            this.labelTerm.Text = "T&erm:";
            // 
            // buttonFirstTerm
            // 
            this.buttonFirstTerm.Location = new System.Drawing.Point(8, 32);
            this.buttonFirstTerm.Name = "buttonFirstTerm";
            this.buttonFirstTerm.TabIndex = 1;
            this.buttonFirstTerm.Text = "F&irst Term";
            this.buttonFirstTerm.Click += new System.EventHandler(this.buttonFirstTerm_Click);
            // 
            // labelBrowseHint
            // 
            this.labelBrowseHint.AutoSize = true;
            this.labelBrowseHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.labelBrowseHint.Location = new System.Drawing.Point(8, 16);
            this.labelBrowseHint.Name = "labelBrowseHint";
            this.labelBrowseHint.Size = new System.Drawing.Size(278, 11);
            this.labelBrowseHint.TabIndex = 0;
            this.labelBrowseHint.Text = "(Hint: enter a substring and press Next to start at the nearest term).";
            // 
            // groupDocNumber
            // 
            this.groupDocNumber.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.btnReconstruct,
																						 this.buttonDelete,
																						 this.labelIndDocs,
																						 this.buttonNextDoc,
																						 this.textDocNum,
																						 this.buttonPrevDoc,
																						 this.labelZeroDoc,
																						 this.labelBrowseDoc});
            this.groupDocNumber.Location = new System.Drawing.Point(8, 8);
            this.groupDocNumber.Name = "groupDocNumber";
            this.groupDocNumber.Size = new System.Drawing.Size(208, 136);
            this.groupDocNumber.TabIndex = 0;
            this.groupDocNumber.TabStop = false;
            this.groupDocNumber.Text = "Browse by doc. number";
            // 
            // btnReconstruct
            // 
            this.btnReconstruct.Location = new System.Drawing.Point(8, 104);
            this.btnReconstruct.Name = "btnReconstruct";
            this.btnReconstruct.Size = new System.Drawing.Size(112, 23);
            this.btnReconstruct.TabIndex = 6;
            this.btnReconstruct.Text = "&Reconstruct && Edit";
            this.toolTip.SetToolTip(this.btnReconstruct, "Reconstruct all field contents &amp; edit doc");
            this.btnReconstruct.Click += new System.EventHandler(this.btnReconstruct_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonDelete.Image")));
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.ImageIndex = 3;
            this.buttonDelete.ImageList = this.imageList;
            this.buttonDelete.Location = new System.Drawing.Point(128, 104);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(72, 23);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "&Delete";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.buttonDelete, "Delete this document (NO WARNING)");
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelIndDocs
            // 
            this.labelIndDocs.AutoSize = true;
            this.labelIndDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.labelIndDocs.Location = new System.Drawing.Point(178, 37);
            this.labelIndDocs.Name = "labelIndDocs";
            this.labelIndDocs.Size = new System.Drawing.Size(11, 13);
            this.labelIndDocs.TabIndex = 5;
            this.labelIndDocs.Text = "?";
            // 
            // buttonNextDoc
            // 
            this.buttonNextDoc.Location = new System.Drawing.Point(148, 32);
            this.buttonNextDoc.Name = "buttonNextDoc";
            this.buttonNextDoc.Size = new System.Drawing.Size(24, 23);
            this.buttonNextDoc.TabIndex = 4;
            this.buttonNextDoc.Text = "->";
            this.buttonNextDoc.Click += new System.EventHandler(this.buttonNextDoc_Click);
            // 
            // textDocNum
            // 
            this.textDocNum.Location = new System.Drawing.Point(98, 33);
            this.textDocNum.Name = "textDocNum";
            this.textDocNum.Size = new System.Drawing.Size(48, 20);
            this.textDocNum.TabIndex = 3;
            this.textDocNum.Text = "";
            this.textDocNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDocNum_KeyPress);
            // 
            // buttonPrevDoc
            // 
            this.buttonPrevDoc.Location = new System.Drawing.Point(72, 32);
            this.buttonPrevDoc.Name = "buttonPrevDoc";
            this.buttonPrevDoc.Size = new System.Drawing.Size(24, 23);
            this.buttonPrevDoc.TabIndex = 2;
            this.buttonPrevDoc.Text = "<-";
            this.buttonPrevDoc.Click += new System.EventHandler(this.buttonPrevDoc_Click);
            // 
            // labelZeroDoc
            // 
            this.labelZeroDoc.AutoSize = true;
            this.labelZeroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.labelZeroDoc.Location = new System.Drawing.Point(56, 37);
            this.labelZeroDoc.Name = "labelZeroDoc";
            this.labelZeroDoc.Size = new System.Drawing.Size(11, 13);
            this.labelZeroDoc.TabIndex = 1;
            this.labelZeroDoc.Text = "0";
            // 
            // labelBrowseDoc
            // 
            this.labelBrowseDoc.AutoSize = true;
            this.labelBrowseDoc.Location = new System.Drawing.Point(8, 37);
            this.labelBrowseDoc.Name = "labelBrowseDoc";
            this.labelBrowseDoc.Size = new System.Drawing.Size(40, 13);
            this.labelBrowseDoc.TabIndex = 0;
            this.labelBrowseDoc.Text = "Doc. #:";
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.groupSearchOptions,
																					this.btnExplain,
																					this.labelSearchResult,
																					this.labelSearchDocs,
																					this.labelSearchRes,
																					this.listSearch,
																					this.buttonSearchDelete,
																					this.buttonSearch});
            this.tabSearch.ImageIndex = 2;
            this.tabSearch.Location = new System.Drawing.Point(4, 23);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new System.Drawing.Size(752, 509);
            this.tabSearch.TabIndex = 2;
            this.tabSearch.Text = "Search";
            // 
            // groupSearchOptions
            // 
            this.groupSearchOptions.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
            this.groupSearchOptions.Controls.AddRange(new System.Windows.Forms.Control[] {
																							 this.btnUpdateParsedQuery,
																							 this.textParsed,
																							 this.labelParsedQuery,
																							 this.comboFields,
																							 this.labelDefaultField,
																							 this.comboAnalyzer,
																							 this.labelAnalyzer,
																							 this.textSearch,
																							 this.labelSearchExpr});
            this.groupSearchOptions.Location = new System.Drawing.Point(8, 8);
            this.groupSearchOptions.Name = "groupSearchOptions";
            this.groupSearchOptions.Size = new System.Drawing.Size(624, 200);
            this.groupSearchOptions.TabIndex = 0;
            this.groupSearchOptions.TabStop = false;
            this.groupSearchOptions.Text = "Search expression";
            // 
            // btnUpdateParsedQuery
            // 
            this.btnUpdateParsedQuery.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.btnUpdateParsedQuery.Location = new System.Drawing.Point(533, 169);
            this.btnUpdateParsedQuery.Name = "btnUpdateParsedQuery";
            this.btnUpdateParsedQuery.TabIndex = 8;
            this.btnUpdateParsedQuery.Text = "&Update";
            this.btnUpdateParsedQuery.Click += new System.EventHandler(this.btnUpdateParsedQuery_Click);
            // 
            // textParsed
            // 
            this.textParsed.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
            this.textParsed.Location = new System.Drawing.Point(320, 97);
            this.textParsed.Multiline = true;
            this.textParsed.Name = "textParsed";
            this.textParsed.Size = new System.Drawing.Size(288, 64);
            this.textParsed.TabIndex = 7;
            this.textParsed.Text = "";
            // 
            // labelParsedQuery
            // 
            this.labelParsedQuery.AutoSize = true;
            this.labelParsedQuery.Location = new System.Drawing.Point(320, 81);
            this.labelParsedQuery.Name = "labelParsedQuery";
            this.labelParsedQuery.TabIndex = 6;
            this.labelParsedQuery.Text = "&Parsed query view:";
            // 
            // comboFields
            // 
            this.comboFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFields.Location = new System.Drawing.Point(96, 49);
            this.comboFields.Name = "comboFields";
            this.comboFields.Size = new System.Drawing.Size(104, 21);
            this.comboFields.TabIndex = 3;
            // 
            // labelDefaultField
            // 
            this.labelDefaultField.AutoSize = true;
            this.labelDefaultField.Location = new System.Drawing.Point(16, 53);
            this.labelDefaultField.Name = "labelDefaultField";
            this.labelDefaultField.Size = new System.Drawing.Size(67, 13);
            this.labelDefaultField.TabIndex = 2;
            this.labelDefaultField.Text = "&Default field:";
            // 
            // comboAnalyzer
            // 
            this.comboAnalyzer.Location = new System.Drawing.Point(96, 25);
            this.comboAnalyzer.Name = "comboAnalyzer";
            this.comboAnalyzer.Size = new System.Drawing.Size(256, 21);
            this.comboAnalyzer.TabIndex = 1;
            this.toolTip.SetToolTip(this.comboAnalyzer, "Analyzer to use for query parsing");
            // 
            // labelAnalyzer
            // 
            this.labelAnalyzer.AutoSize = true;
            this.labelAnalyzer.Location = new System.Drawing.Point(16, 29);
            this.labelAnalyzer.Name = "labelAnalyzer";
            this.labelAnalyzer.Size = new System.Drawing.Size(51, 13);
            this.labelAnalyzer.TabIndex = 0;
            this.labelAnalyzer.Text = "&Analyzer:";
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(16, 97);
            this.textSearch.Multiline = true;
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(288, 64);
            this.textSearch.TabIndex = 5;
            this.textSearch.Text = "";
            // 
            // labelSearchExpr
            // 
            this.labelSearchExpr.AutoSize = true;
            this.labelSearchExpr.Location = new System.Drawing.Point(16, 81);
            this.labelSearchExpr.Name = "labelSearchExpr";
            this.labelSearchExpr.Size = new System.Drawing.Size(101, 13);
            this.labelSearchExpr.TabIndex = 4;
            this.labelSearchExpr.Text = "S&earch expression:";
            // 
            // btnExplain
            // 
            this.btnExplain.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.btnExplain.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnExplain.Image")));
            this.btnExplain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExplain.ImageIndex = 0;
            this.btnExplain.ImageList = this.imageList;
            this.btnExplain.Location = new System.Drawing.Point(592, 477);
            this.btnExplain.Name = "btnExplain";
            this.btnExplain.TabIndex = 3;
            this.btnExplain.Text = "E&xplain";
            this.btnExplain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExplain.Click += new System.EventHandler(this.btnExplain_Click);
            // 
            // labelSearchResult
            // 
            this.labelSearchResult.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.labelSearchResult.AutoSize = true;
            this.labelSearchResult.Location = new System.Drawing.Point(8, 482);
            this.labelSearchResult.Name = "labelSearchResult";
            this.labelSearchResult.Size = new System.Drawing.Size(78, 13);
            this.labelSearchResult.TabIndex = 8;
            this.labelSearchResult.Text = "Search Result:";
            // 
            // labelSearchDocs
            // 
            this.labelSearchDocs.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.labelSearchDocs.AutoSize = true;
            this.labelSearchDocs.Location = new System.Drawing.Point(128, 482);
            this.labelSearchDocs.Name = "labelSearchDocs";
            this.labelSearchDocs.Size = new System.Drawing.Size(38, 13);
            this.labelSearchDocs.TabIndex = 10;
            this.labelSearchDocs.Text = "Doc(s)";
            // 
            // labelSearchRes
            // 
            this.labelSearchRes.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.labelSearchRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.labelSearchRes.Location = new System.Drawing.Point(88, 482);
            this.labelSearchRes.Name = "labelSearchRes";
            this.labelSearchRes.Size = new System.Drawing.Size(32, 13);
            this.labelSearchRes.TabIndex = 9;
            this.labelSearchRes.Text = "0";
            this.labelSearchRes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listSearch
            // 
            this.listSearch.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
            this.listSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.columnHeaderRank,
																						 this.columnHeaderDocId});
            this.listSearch.FullRowSelect = true;
            this.listSearch.GridLines = true;
            this.listSearch.Location = new System.Drawing.Point(8, 216);
            this.listSearch.MultiSelect = false;
            this.listSearch.Name = "listSearch";
            this.listSearch.Size = new System.Drawing.Size(736, 253);
            this.listSearch.TabIndex = 2;
            this.toolTip.SetToolTip(this.listSearch, "Double-click on results to display all document fields");
            this.listSearch.View = System.Windows.Forms.View.Details;
            this.listSearch.DoubleClick += new System.EventHandler(this.listSearch_DoubleClick);
            this.listSearch.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listSearch_ColumnClick);
            // 
            // columnHeaderRank
            // 
            this.columnHeaderRank.Text = "Rank %";
            this.columnHeaderRank.Width = 50;
            // 
            // columnHeaderDocId
            // 
            this.columnHeaderDocId.Text = "Doc. Id";
            // 
            // buttonSearchDelete
            // 
            this.buttonSearchDelete.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.buttonSearchDelete.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonSearchDelete.Image")));
            this.buttonSearchDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearchDelete.ImageIndex = 3;
            this.buttonSearchDelete.ImageList = this.imageList;
            this.buttonSearchDelete.Location = new System.Drawing.Point(672, 477);
            this.buttonSearchDelete.Name = "buttonSearchDelete";
            this.buttonSearchDelete.Size = new System.Drawing.Size(72, 23);
            this.buttonSearchDelete.TabIndex = 4;
            this.buttonSearchDelete.Text = "D&elete";
            this.buttonSearchDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.buttonSearchDelete, "Delete selected docs");
            this.buttonSearchDelete.Click += new System.EventHandler(this.buttonSearchDelete_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.buttonSearch.Location = new System.Drawing.Point(640, 16);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(104, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "&Search";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.listIndexFiles,
																				   this.lblFileSize,
																				   this.labelIndexSize});
            this.tabFiles.ImageIndex = 4;
            this.tabFiles.Location = new System.Drawing.Point(4, 23);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Size = new System.Drawing.Size(752, 509);
            this.tabFiles.TabIndex = 3;
            this.tabFiles.Text = "Files";
            // 
            // listIndexFiles
            // 
            this.listIndexFiles.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
            this.listIndexFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.columnFilename,
																							 this.columnSize,
																							 this.columnUnit});
            this.listIndexFiles.FullRowSelect = true;
            this.listIndexFiles.GridLines = true;
            this.listIndexFiles.Location = new System.Drawing.Point(8, 32);
            this.listIndexFiles.MultiSelect = false;
            this.listIndexFiles.Name = "listIndexFiles";
            this.listIndexFiles.Size = new System.Drawing.Size(736, 469);
            this.listIndexFiles.TabIndex = 2;
            this.listIndexFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnFilename
            // 
            this.columnFilename.Text = "Filename";
            this.columnFilename.Width = 300;
            // 
            // columnSize
            // 
            this.columnSize.Text = "Size";
            this.columnSize.Width = 100;
            // 
            // columnUnit
            // 
            this.columnUnit.Text = "";
            // 
            // lblFileSize
            // 
            this.lblFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.lblFileSize.Location = new System.Drawing.Point(96, 8);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(88, 13);
            this.lblFileSize.TabIndex = 1;
            this.lblFileSize.Text = "?";
            // 
            // labelIndexSize
            // 
            this.labelIndexSize.AutoSize = true;
            this.labelIndexSize.Location = new System.Drawing.Point(8, 8);
            this.labelIndexSize.Name = "labelIndexSize";
            this.labelIndexSize.Size = new System.Drawing.Size(88, 13);
            this.labelIndexSize.TabIndex = 0;
            this.labelIndexSize.Text = "Total Index Size:";
            // 
            // tabPlugins
            // 
            this.tabPlugins.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.groupPlugin,
																					 this.lstPlugins});
            this.tabPlugins.ImageIndex = 5;
            this.tabPlugins.Location = new System.Drawing.Point(4, 23);
            this.tabPlugins.Name = "tabPlugins";
            this.tabPlugins.Size = new System.Drawing.Size(752, 509);
            this.tabPlugins.TabIndex = 4;
            this.tabPlugins.Text = "Plugins";
            // 
            // groupPlugin
            // 
            this.groupPlugin.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
            this.groupPlugin.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.panelPlugin,
																					  this.groupPluginInfo});
            this.groupPlugin.Location = new System.Drawing.Point(128, 16);
            this.groupPlugin.Name = "groupPlugin";
            this.groupPlugin.Size = new System.Drawing.Size(616, 485);
            this.groupPlugin.TabIndex = 2;
            this.groupPlugin.TabStop = false;
            // 
            // panelPlugin
            // 
            this.panelPlugin.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
            this.panelPlugin.Location = new System.Drawing.Point(8, 64);
            this.panelPlugin.Name = "panelPlugin";
            this.panelPlugin.Size = new System.Drawing.Size(600, 413);
            this.panelPlugin.TabIndex = 1;
            // 
            // groupPluginInfo
            // 
            this.groupPluginInfo.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
            this.groupPluginInfo.BackColor = System.Drawing.SystemColors.Control;
            this.groupPluginInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
																						  this.linkPluginURL,
																						  this.lblPluginInfo});
            this.groupPluginInfo.Location = new System.Drawing.Point(8, 8);
            this.groupPluginInfo.Name = "groupPluginInfo";
            this.groupPluginInfo.Size = new System.Drawing.Size(600, 48);
            this.groupPluginInfo.TabIndex = 0;
            this.groupPluginInfo.TabStop = false;
            // 
            // linkPluginURL
            // 
            this.linkPluginURL.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.linkPluginURL.Location = new System.Drawing.Point(424, 16);
            this.linkPluginURL.Name = "linkPluginURL";
            this.linkPluginURL.Size = new System.Drawing.Size(160, 23);
            this.linkPluginURL.TabIndex = 1;
            this.linkPluginURL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkPluginURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPluginURL_LinkClicked);
            // 
            // lblPluginInfo
            // 
            this.lblPluginInfo.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
            this.lblPluginInfo.Location = new System.Drawing.Point(8, 16);
            this.lblPluginInfo.Name = "lblPluginInfo";
            this.lblPluginInfo.Size = new System.Drawing.Size(408, 24);
            this.lblPluginInfo.TabIndex = 0;
            this.lblPluginInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstPlugins
            // 
            this.lstPlugins.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left);
            this.lstPlugins.Location = new System.Drawing.Point(8, 16);
            this.lstPlugins.Name = "lstPlugins";
            this.lstPlugins.Size = new System.Drawing.Size(112, 485);
            this.lstPlugins.TabIndex = 1;
            this.lstPlugins.SelectedIndexChanged += new System.EventHandler(this.lstPlugins_SelectedIndexChanged);
            // 
            // Luke
            // 
            this.ClientSize = new System.Drawing.Size(760, 565);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tabControl,
																		  this.statusBar});
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
            this.tabDocuments.ResumeLayout(false);
            this.groupTerm.ResumeLayout(false);
            this.groupDocNumber.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.groupSearchOptions.ResumeLayout(false);
            this.tabFiles.ResumeLayout(false);
            this.tabPlugins.ResumeLayout(false);
            this.groupPlugin.ResumeLayout(false);
            this.groupPluginInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

    }
}
