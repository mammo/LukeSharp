using System.Windows.Forms;
namespace Lucene.Net.LukeNet
{
    partial class DocumentsTabPage 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private System.Windows.Forms.Button btnTermVector;
        private System.Windows.Forms.ColumnHeader columnHeaderField;
        private System.Windows.Forms.ColumnHeader columnHeaderIndexed;
        private System.Windows.Forms.ColumnHeader columnHeaderToken;
        private System.Windows.Forms.ColumnHeader columnHeaderStored;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.Button buttonCopySelected;
        private System.Windows.Forms.Button buttonCopyAll;
        private System.Windows.Forms.Button buttonDeleteAllDocs;
        private System.Windows.Forms.Label labelCopy;
        private System.Windows.Forms.Button btnReconstruct;
        private System.Windows.Forms.Label labelInfoDocNumTitle;
        private System.Windows.Forms.Label labelInfoDocNum;
        private System.Windows.Forms.ColumnHeader columnHeaderTV;
        private System.Windows.Forms.ColumnHeader columnHeaderBoost;

        private System.Windows.Forms.Label labelDocTermFreq;
        private System.Windows.Forms.Label labelOf;
        private System.Windows.Forms.Label labelDoc;
        private System.Windows.Forms.Label labelTermDocFreq;
        private System.Windows.Forms.Label labelTerm;
        private System.Windows.Forms.Label labelBrowseHint;
        private System.Windows.Forms.Label labelZeroDoc;
        private System.Windows.Forms.Label labelBrowseDoc;
        private System.Windows.Forms.Label labelDocNum;
        private System.Windows.Forms.Label labelDocMax;
        private System.Windows.Forms.Label labelTermFreq;
        private System.Windows.Forms.Label labelLegend;
        private System.Windows.Forms.ListView listDocFields;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.btnTermVector = new System.Windows.Forms.Button();
            this.buttonCopyAll = new System.Windows.Forms.Button();
            this.buttonCopySelected = new System.Windows.Forms.Button();
            this.buttonDeleteAllDocs = new System.Windows.Forms.Button();
            this.buttonShowAllDocs = new System.Windows.Forms.Button();
            this.btnReconstruct = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();

            this.labelInfoDocNum = new System.Windows.Forms.Label();
            this.labelInfoDocNumTitle = new System.Windows.Forms.Label();
            this.labelCopy = new System.Windows.Forms.Label();

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
            this.labelIndDocs = new System.Windows.Forms.Label();
            this.buttonNextDoc = new System.Windows.Forms.Button();
            this.textDocNum = new System.Windows.Forms.TextBox();
            this.buttonPrevDoc = new System.Windows.Forms.Button();
            this.labelZeroDoc = new System.Windows.Forms.Label();
            this.labelBrowseDoc = new System.Windows.Forms.Label();
            this.labelLegend = new System.Windows.Forms.Label();
            this.listDocFields = new System.Windows.Forms.ListView();


            this.groupDocNumber.SuspendLayout();
            this.groupTerm.SuspendLayout();

            // 
            // btnTermVector
            // 
            this.btnTermVector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTermVector.Location = new System.Drawing.Point(8, 466);
            this.btnTermVector.Name = "btnTermVector";
            this.btnTermVector.Size = new System.Drawing.Size(128, 23);
            this.btnTermVector.TabIndex = 3;
            this.btnTermVector.Text = "Field\'s Term &Vector";
            this._luke.toolTip.SetToolTip(this.btnTermVector, "Show Term Vector of selected field");
            this.btnTermVector.Click += new System.EventHandler(this.btnTermVector_Click);
            // 
            // buttonCopyAll
            // 
            this.buttonCopyAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyAll.Location = new System.Drawing.Point(623, 466);
            this.buttonCopyAll.Name = "buttonCopyAll";
            this.buttonCopyAll.Size = new System.Drawing.Size(120, 23);
            this.buttonCopyAll.TabIndex = 5;
            this.buttonCopyAll.Text = "C&omplete Document";
            this._luke.toolTip.SetToolTip(this.buttonCopyAll, "Copy all fields to Clipboard");
            this.buttonCopyAll.Click += new System.EventHandler(this.buttonCopyAll_Click);
            // 
            // buttonCopySelected
            // 
            this.buttonCopySelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopySelected.Location = new System.Drawing.Point(499, 466);
            this.buttonCopySelected.Name = "buttonCopySelected";
            this.buttonCopySelected.Size = new System.Drawing.Size(120, 23);
            this.buttonCopySelected.TabIndex = 4;
            this.buttonCopySelected.Text = "Se&lected Fields";
            this._luke.toolTip.SetToolTip(this.buttonCopySelected, "Copy selected fields to Clipboard");
            this.buttonCopySelected.Click += new System.EventHandler(this.buttonCopySelected_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.ImageIndex = 3;
            this.buttonDelete.ImageList = this._luke.imageList;
            this.buttonDelete.Location = new System.Drawing.Point(128, 104);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(72, 23);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "&Delete";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._luke.toolTip.SetToolTip(this.buttonDelete, "Delete this document (NO WARNING)");
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonDeleteAllDocs
            // 
            this.buttonDeleteAllDocs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteAllDocs.ImageIndex = 3;
            this.buttonDeleteAllDocs.ImageList = this._luke.imageList;
            this.buttonDeleteAllDocs.Location = new System.Drawing.Point(123, 106);
            this.buttonDeleteAllDocs.Name = "buttonDeleteAllDocs";
            this.buttonDeleteAllDocs.Size = new System.Drawing.Size(112, 23);
            this.buttonDeleteAllDocs.TabIndex = 11;
            this.buttonDeleteAllDocs.Text = "Delete &All Docs";
            this.buttonDeleteAllDocs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._luke.toolTip.SetToolTip(this.buttonDeleteAllDocs, "Delete all docs with this term (NO WARNING!)");
            this.buttonDeleteAllDocs.Click += new System.EventHandler(this.buttonDeleteAllDocs_Click);
            // 
            // buttonShowAllDocs
            // 
            this.buttonShowAllDocs.Location = new System.Drawing.Point(8, 106);
            this.buttonShowAllDocs.Name = "buttonShowAllDocs";
            this.buttonShowAllDocs.Size = new System.Drawing.Size(112, 23);
            this.buttonShowAllDocs.TabIndex = 10;
            this.buttonShowAllDocs.Text = "&Show All Docs";
            this._luke.toolTip.SetToolTip(this.buttonShowAllDocs, "Show all docs with this term");
            this.buttonShowAllDocs.Click += new System.EventHandler(this.buttonShowAllDocs_Click);
            // 
            // btnReconstruct
            // 
            this.btnReconstruct.Location = new System.Drawing.Point(8, 104);
            this.btnReconstruct.Name = "btnReconstruct";
            this.btnReconstruct.Size = new System.Drawing.Size(112, 23);
            this.btnReconstruct.TabIndex = 6;
            this.btnReconstruct.Text = "&Reconstruct && Edit";
            this._luke.toolTip.SetToolTip(this.btnReconstruct, "Reconstruct all field contents &amp; edit doc");
            this.btnReconstruct.Click += new System.EventHandler(this.btnReconstruct_Click);
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
            // labelTermFreq
            // 
            this.labelTermFreq.AutoSize = true;
            this.labelTermFreq.Location = new System.Drawing.Point(360, 111);
            this.labelTermFreq.Name = "labelTermFreq";
            this.labelTermFreq.Size = new System.Drawing.Size(13, 13);
            this.labelTermFreq.TabIndex = 17;
            this.labelTermFreq.Text = "?";
            // 
            // labelDocTermFreq
            // 
            this.labelDocTermFreq.AutoSize = true;
            this.labelDocTermFreq.Location = new System.Drawing.Point(248, 111);
            this.labelDocTermFreq.Name = "labelDocTermFreq";
            this.labelDocTermFreq.Size = new System.Drawing.Size(106, 13);
            this.labelDocTermFreq.TabIndex = 16;
            this.labelDocTermFreq.Text = "Term freq in this doc:";
            // 
            // labelDocMax
            // 
            this.labelDocMax.AutoSize = true;
            this.labelDocMax.Location = new System.Drawing.Point(360, 85);
            this.labelDocMax.Name = "labelDocMax";
            this.labelDocMax.Size = new System.Drawing.Size(13, 13);
            this.labelDocMax.TabIndex = 15;
            this.labelDocMax.Text = "?";
            // 
            // labelOf
            // 
            this.labelOf.AutoSize = true;
            this.labelOf.Location = new System.Drawing.Point(336, 85);
            this.labelOf.Name = "labelOf";
            this.labelOf.Size = new System.Drawing.Size(16, 13);
            this.labelOf.TabIndex = 14;
            this.labelOf.Text = "of";
            // 
            // labelDocNum
            // 
            this.labelDocNum.AutoSize = true;
            this.labelDocNum.Location = new System.Drawing.Point(320, 85);
            this.labelDocNum.Name = "labelDocNum";
            this.labelDocNum.Size = new System.Drawing.Size(13, 13);
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
            this.labelDocFreq.Size = new System.Drawing.Size(13, 13);
            this.labelDocFreq.TabIndex = 7;
            this.labelDocFreq.Text = "?";
            // 
            // labelTermDocFreq
            // 
            this.labelTermDocFreq.AutoSize = true;
            this.labelTermDocFreq.Location = new System.Drawing.Point(8, 64);
            this.labelTermDocFreq.Name = "labelTermDocFreq";
            this.labelTermDocFreq.Size = new System.Drawing.Size(105, 13);
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
            this.textTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTerm_KeyPress);
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
            this.labelInfoDocNumTitle.Size = new System.Drawing.Size(37, 13);
            this.labelInfoDocNumTitle.TabIndex = 7;
            this.labelInfoDocNumTitle.Text = "Doc #";
            // 
            // buttonFirstTerm
            // 
            this.buttonFirstTerm.Location = new System.Drawing.Point(8, 32);
            this.buttonFirstTerm.Name = "buttonFirstTerm";
            this.buttonFirstTerm.Size = new System.Drawing.Size(75, 23);
            this.buttonFirstTerm.TabIndex = 1;
            this.buttonFirstTerm.Text = "F&irst Term";
            this.buttonFirstTerm.Click += new System.EventHandler(this.buttonFirstTerm_Click);
            // 
            // labelBrowseHint
            // 
            this.labelBrowseHint.AutoSize = true;
            this.labelBrowseHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBrowseHint.Location = new System.Drawing.Point(8, 16);
            this.labelBrowseHint.Name = "labelBrowseHint";
            this.labelBrowseHint.Size = new System.Drawing.Size(278, 12);
            this.labelBrowseHint.TabIndex = 0;
            this.labelBrowseHint.Text = "(Hint: enter a substring and press Next to start at the nearest term).";
            // 
            // labelIndDocs
            // 
            this.labelIndDocs.AutoSize = true;
            this.labelIndDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIndDocs.Location = new System.Drawing.Point(178, 37);
            this.labelIndDocs.Name = "labelIndDocs";
            this.labelIndDocs.Size = new System.Drawing.Size(14, 13);
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
            this.labelZeroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelZeroDoc.Location = new System.Drawing.Point(56, 37);
            this.labelZeroDoc.Name = "labelZeroDoc";
            this.labelZeroDoc.Size = new System.Drawing.Size(14, 13);
            this.labelZeroDoc.TabIndex = 1;
            this.labelZeroDoc.Text = "0";
            // 
            // labelBrowseDoc
            // 
            this.labelBrowseDoc.AutoSize = true;
            this.labelBrowseDoc.Location = new System.Drawing.Point(8, 37);
            this.labelBrowseDoc.Name = "labelBrowseDoc";
            this.labelBrowseDoc.Size = new System.Drawing.Size(43, 13);
            this.labelBrowseDoc.TabIndex = 0;
            this.labelBrowseDoc.Text = "Doc. #:";

            // 
            // labelCopy
            // 
            this.labelCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCopy.AutoSize = true;
            this.labelCopy.Location = new System.Drawing.Point(379, 471);
            this.labelCopy.Name = "labelCopy";
            this.labelCopy.Size = new System.Drawing.Size(113, 13);
            this.labelCopy.TabIndex = 6;
            this.labelCopy.Text = "Copy text to Clipboard:";
            // 
            // labelLegend
            // 
            this.labelLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLegend.AutoSize = true;
            this.labelLegend.Location = new System.Drawing.Point(424, 152);
            this.labelLegend.Name = "labelLegend";
            this.labelLegend.Size = new System.Drawing.Size(304, 13);
            this.labelLegend.TabIndex = 3;
            this.labelLegend.Text = "Legend: I - Indexed; T - Tokenized; S - Stored, V - Term Vector";
            // 
            // listDocFields
            // 
            this.listDocFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listDocFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderField,
            this.columnHeaderIndexed,
            this.columnHeaderToken,
            this.columnHeaderStored,
            this.columnHeaderTV,
            this.columnHeaderBoost,
            this.columnHeaderValue});
            this.listDocFields.ContextMenu = _luke.contextMenu;
            this.listDocFields.FullRowSelect = true;
            this.listDocFields.GridLines = true;
            this.listDocFields.Location = new System.Drawing.Point(8, 168);
            this.listDocFields.MultiSelect = false;
            this.listDocFields.Name = "listDocFields";
            this.listDocFields.Size = new System.Drawing.Size(736, 290);
            this.listDocFields.TabIndex = 2;
            this.listDocFields.UseCompatibleStateImageBehavior = false;
            this.listDocFields.View = System.Windows.Forms.View.Details;
            this.listDocFields.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listDocFields_ColumnClick);
            // 
            // groupTerm
            // 
            this.groupTerm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupTerm.Controls.Add(this.labelTermFreq);
            this.groupTerm.Controls.Add(this.labelDocTermFreq);
            this.groupTerm.Controls.Add(this.labelDocMax);
            this.groupTerm.Controls.Add(this.labelOf);
            this.groupTerm.Controls.Add(this.labelDocNum);
            this.groupTerm.Controls.Add(this.labelDoc);
            this.groupTerm.Controls.Add(this.buttonDeleteAllDocs);
            this.groupTerm.Controls.Add(this.buttonShowAllDocs);
            this.groupTerm.Controls.Add(this.buttonShowNextDoc);
            this.groupTerm.Controls.Add(this.buttonShowFirstDoc);
            this.groupTerm.Controls.Add(this.labelDocFreq);
            this.groupTerm.Controls.Add(this.labelTermDocFreq);
            this.groupTerm.Controls.Add(this.buttonNextTerm);
            this.groupTerm.Controls.Add(this.textTerm);
            this.groupTerm.Controls.Add(this.comboTerms);
            this.groupTerm.Controls.Add(this.labelTerm);
            this.groupTerm.Controls.Add(this.buttonFirstTerm);
            this.groupTerm.Controls.Add(this.labelBrowseHint);
            this.groupTerm.Location = new System.Drawing.Point(224, 8);
            this.groupTerm.Name = "groupTerm";
            this.groupTerm.Size = new System.Drawing.Size(520, 136);
            this.groupTerm.TabIndex = 1;
            this.groupTerm.TabStop = false;
            this.groupTerm.Text = "Browse by term";
            // 
            // groupDocNumber
            // 
            this.groupDocNumber.Controls.Add(this.btnReconstruct);
            this.groupDocNumber.Controls.Add(this.buttonDelete);
            this.groupDocNumber.Controls.Add(this.labelIndDocs);
            this.groupDocNumber.Controls.Add(this.buttonNextDoc);
            this.groupDocNumber.Controls.Add(this.textDocNum);
            this.groupDocNumber.Controls.Add(this.buttonPrevDoc);
            this.groupDocNumber.Controls.Add(this.labelZeroDoc);
            this.groupDocNumber.Controls.Add(this.labelBrowseDoc);
            this.groupDocNumber.Location = new System.Drawing.Point(8, 8);
            this.groupDocNumber.Name = "groupDocNumber";
            this.groupDocNumber.Size = new System.Drawing.Size(208, 136);
            this.groupDocNumber.TabIndex = 0;
            this.groupDocNumber.TabStop = false;
            this.groupDocNumber.Text = "Browse by doc. number";


            this.Controls.Add(this.btnTermVector);
            this.Controls.Add(this.labelInfoDocNum);
            this.Controls.Add(this.labelInfoDocNumTitle);
            this.Controls.Add(this.labelCopy);
            this.Controls.Add(this.buttonCopyAll);
            this.Controls.Add(this.buttonCopySelected);
            this.Controls.Add(this.labelLegend);
            this.Controls.Add(this.listDocFields);
            this.Controls.Add(this.groupTerm);
            this.Controls.Add(this.groupDocNumber);


            this.groupDocNumber.ResumeLayout(false);
            this.groupDocNumber.PerformLayout();

            this.groupTerm.ResumeLayout(false);
            this.groupTerm.PerformLayout();

        }

        #endregion
    }
}
