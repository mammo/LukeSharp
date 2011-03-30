namespace Lucene.Net.LukeNet
{
    partial class FilesTabPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelIndexSize;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.ListView listIndexFiles;
        private System.Windows.Forms.ColumnHeader columnFilename;
        private System.Windows.Forms.ColumnHeader columnSize;
        private System.Windows.Forms.ColumnHeader columnUnit;

        
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
            this.listIndexFiles = new System.Windows.Forms.ListView();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.labelIndexSize = new System.Windows.Forms.Label();
            this.columnFilename = new System.Windows.Forms.ColumnHeader();
            this.columnSize = new System.Windows.Forms.ColumnHeader();
            this.columnUnit = new System.Windows.Forms.ColumnHeader();

            // 
            // listIndexFiles
            // 
            this.listIndexFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.listIndexFiles.UseCompatibleStateImageBehavior = false;
            this.listIndexFiles.View = System.Windows.Forms.View.Details;
            // 
            // lblFileSize
            // 
            this.lblFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.labelIndexSize.Size = new System.Drawing.Size(86, 13);
            this.labelIndexSize.TabIndex = 0;
            this.labelIndexSize.Text = "Total Index Size:";
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
            // tabFiles
            // 
            this.Controls.Add(this.listIndexFiles);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.labelIndexSize);

        }

        #endregion
    }
}
