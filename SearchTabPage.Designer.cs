namespace Lucene.Net.LukeNet
{
    partial class SearchTabPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListView listSearch;
        private System.Windows.Forms.ColumnHeader columnHeaderRank;
        private System.Windows.Forms.ColumnHeader columnHeaderDocId;
        private System.Windows.Forms.Button buttonSearchDelete;

        private System.Windows.Forms.Label labelSearchResult;
        private System.Windows.Forms.Label labelSearchDocs;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelSearchRes;

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

        private System.Windows.Forms.TextBox textParsed;

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

            this.groupSearchOptions = new System.Windows.Forms.GroupBox();
            this.btnUpdateParsedQuery = new System.Windows.Forms.Button();
            this.textParsed = new System.Windows.Forms.TextBox();
            this.labelParsedQuery = new System.Windows.Forms.Label();
            this.comboFields = new System.Windows.Forms.ComboBox();
            this.labelDefaultField = new System.Windows.Forms.Label();
            this.labelAnalyzer = new System.Windows.Forms.Label();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.labelSearchExpr = new System.Windows.Forms.Label();
            this.btnExplain = new System.Windows.Forms.Button();
            this.labelSearchResult = new System.Windows.Forms.Label();
            this.labelSearchDocs = new System.Windows.Forms.Label();
            this.labelSearchRes = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();

            this.comboAnalyzer = new System.Windows.Forms.ComboBox();
            this.listSearch = new System.Windows.Forms.ListView();
            this.columnHeaderRank = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDocId = new System.Windows.Forms.ColumnHeader();
            this.buttonSearchDelete = new System.Windows.Forms.Button();

            this.groupSearchOptions.SuspendLayout();

            // 
            // listSearch
            // 
            this.listSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderRank,
            this.columnHeaderDocId});
            this.listSearch.FullRowSelect = true;
            this.listSearch.GridLines = true;
            this.listSearch.Location = new System.Drawing.Point(8, 216);
            this.listSearch.MultiSelect = false;
            this.listSearch.Name = "listSearch";
            this.listSearch.Size = new System.Drawing.Size(736, 242);
            this.listSearch.TabIndex = 2;
            _luke.toolTip.SetToolTip(this.listSearch, "Double-click on results to display all document fields");
            this.listSearch.UseCompatibleStateImageBehavior = false;
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
            this.buttonSearchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearchDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearchDelete.ImageIndex = 3;
            this.buttonSearchDelete.ImageList = _luke.imageList;
            this.buttonSearchDelete.Location = new System.Drawing.Point(672, 466);
            this.buttonSearchDelete.Name = "buttonSearchDelete";
            this.buttonSearchDelete.Size = new System.Drawing.Size(72, 23);
            this.buttonSearchDelete.TabIndex = 4;
            this.buttonSearchDelete.Text = "D&elete";
            this.buttonSearchDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            _luke.toolTip.SetToolTip(this.buttonSearchDelete, "Delete selected docs");
            this.buttonSearchDelete.Click += new System.EventHandler(this.buttonSearchDelete_Click);
            // 
            // groupSearchOptions
            // 
            this.groupSearchOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSearchOptions.Controls.Add(this.btnUpdateParsedQuery);
            this.groupSearchOptions.Controls.Add(this.textParsed);
            this.groupSearchOptions.Controls.Add(this.labelParsedQuery);
            this.groupSearchOptions.Controls.Add(this.comboFields);
            this.groupSearchOptions.Controls.Add(this.labelDefaultField);
            this.groupSearchOptions.Controls.Add(this.comboAnalyzer);
            this.groupSearchOptions.Controls.Add(this.labelAnalyzer);
            this.groupSearchOptions.Controls.Add(this.textSearch);
            this.groupSearchOptions.Controls.Add(this.labelSearchExpr);
            this.groupSearchOptions.Location = new System.Drawing.Point(8, 8);
            this.groupSearchOptions.Name = "groupSearchOptions";
            this.groupSearchOptions.Size = new System.Drawing.Size(624, 200);
            this.groupSearchOptions.TabIndex = 0;
            this.groupSearchOptions.TabStop = false;
            this.groupSearchOptions.Text = "Search expression";
            // 
            // btnUpdateParsedQuery
            // 
            this.btnUpdateParsedQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateParsedQuery.Location = new System.Drawing.Point(533, 169);
            this.btnUpdateParsedQuery.Name = "btnUpdateParsedQuery";
            this.btnUpdateParsedQuery.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateParsedQuery.TabIndex = 8;
            this.btnUpdateParsedQuery.Text = "&Update";
            this.btnUpdateParsedQuery.Click += new System.EventHandler(this.btnUpdateParsedQuery_Click);
            // 
            // textParsed
            // 
            this.textParsed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textParsed.Location = new System.Drawing.Point(320, 97);
            this.textParsed.Multiline = true;
            this.textParsed.Name = "textParsed";
            this.textParsed.Size = new System.Drawing.Size(288, 64);
            this.textParsed.TabIndex = 7;
            // 
            // labelParsedQuery
            // 
            this.labelParsedQuery.AutoSize = true;
            this.labelParsedQuery.Location = new System.Drawing.Point(320, 81);
            this.labelParsedQuery.Name = "labelParsedQuery";
            this.labelParsedQuery.Size = new System.Drawing.Size(97, 13);
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
            this.labelDefaultField.Size = new System.Drawing.Size(66, 13);
            this.labelDefaultField.TabIndex = 2;
            this.labelDefaultField.Text = "&Default field:";
            // 
            // labelAnalyzer
            // 
            this.labelAnalyzer.AutoSize = true;
            this.labelAnalyzer.Location = new System.Drawing.Point(16, 29);
            this.labelAnalyzer.Name = "labelAnalyzer";
            this.labelAnalyzer.Size = new System.Drawing.Size(50, 13);
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
            // 
            // labelSearchExpr
            // 
            this.labelSearchExpr.AutoSize = true;
            this.labelSearchExpr.Location = new System.Drawing.Point(16, 81);
            this.labelSearchExpr.Name = "labelSearchExpr";
            this.labelSearchExpr.Size = new System.Drawing.Size(97, 13);
            this.labelSearchExpr.TabIndex = 4;
            this.labelSearchExpr.Text = "S&earch expression:";
            // 
            // btnExplain
            // 
            this.btnExplain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExplain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExplain.ImageIndex = 0;
            this.btnExplain.ImageList = _luke.imageList;
            this.btnExplain.Location = new System.Drawing.Point(592, 466);
            this.btnExplain.Name = "btnExplain";
            this.btnExplain.Size = new System.Drawing.Size(75, 23);
            this.btnExplain.TabIndex = 3;
            this.btnExplain.Text = "E&xplain";
            this.btnExplain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExplain.Click += new System.EventHandler(this.btnExplain_Click);
            // 
            // labelSearchResult
            // 
            this.labelSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSearchResult.AutoSize = true;
            this.labelSearchResult.Location = new System.Drawing.Point(8, 471);
            this.labelSearchResult.Name = "labelSearchResult";
            this.labelSearchResult.Size = new System.Drawing.Size(77, 13);
            this.labelSearchResult.TabIndex = 8;
            this.labelSearchResult.Text = "Search Result:";
            // 
            // labelSearchDocs
            // 
            this.labelSearchDocs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSearchDocs.AutoSize = true;
            this.labelSearchDocs.Location = new System.Drawing.Point(128, 471);
            this.labelSearchDocs.Name = "labelSearchDocs";
            this.labelSearchDocs.Size = new System.Drawing.Size(38, 13);
            this.labelSearchDocs.TabIndex = 10;
            this.labelSearchDocs.Text = "Doc(s)";
            // 
            // labelSearchRes
            // 
            this.labelSearchRes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSearchRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSearchRes.Location = new System.Drawing.Point(88, 471);
            this.labelSearchRes.Name = "labelSearchRes";
            this.labelSearchRes.Size = new System.Drawing.Size(32, 13);
            this.labelSearchRes.TabIndex = 9;
            this.labelSearchRes.Text = "0";
            this.labelSearchRes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Location = new System.Drawing.Point(640, 16);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(104, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "&Search";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboAnalyzer
            // 
            this.comboAnalyzer.Location = new System.Drawing.Point(96, 25);
            this.comboAnalyzer.Name = "comboAnalyzer";
            this.comboAnalyzer.Size = new System.Drawing.Size(256, 21);
            this.comboAnalyzer.TabIndex = 1;
            _luke.toolTip.SetToolTip(this.comboAnalyzer, "Analyzer to use for query parsing");


            Controls.Add(this.groupSearchOptions);
            Controls.Add(this.btnExplain);
            Controls.Add(this.labelSearchResult);
            Controls.Add(this.labelSearchDocs);
            Controls.Add(this.labelSearchRes);
            Controls.Add(this.listSearch);
            Controls.Add(this.buttonSearchDelete);
            Controls.Add(this.buttonSearch);

            this.groupSearchOptions.ResumeLayout(false);
            this.groupSearchOptions.PerformLayout();
        }

        #endregion
    }
}
