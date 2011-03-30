namespace Lucene.Net.LukeNet
{
    partial class PluginsTabPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListBox lstPlugins;
        private System.Windows.Forms.GroupBox groupPlugin;
        private System.Windows.Forms.GroupBox groupPluginInfo;
        private System.Windows.Forms.Label lblPluginInfo;
        private System.Windows.Forms.LinkLabel linkPluginURL;
        private System.Windows.Forms.Panel panelPlugin;

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

            this.groupPlugin = new System.Windows.Forms.GroupBox();
            this.panelPlugin = new System.Windows.Forms.Panel();
            this.groupPluginInfo = new System.Windows.Forms.GroupBox();
            this.linkPluginURL = new System.Windows.Forms.LinkLabel();
            this.lblPluginInfo = new System.Windows.Forms.Label();
            this.lstPlugins = new System.Windows.Forms.ListBox();

            this.groupPlugin.SuspendLayout();
            this.groupPluginInfo.SuspendLayout();

            // 
            // groupPlugin
            // 
            this.groupPlugin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPlugin.Controls.Add(this.panelPlugin);
            this.groupPlugin.Controls.Add(this.groupPluginInfo);
            this.groupPlugin.Location = new System.Drawing.Point(128, 16);
            this.groupPlugin.Name = "groupPlugin";
            this.groupPlugin.Size = new System.Drawing.Size(616, 485);
            this.groupPlugin.TabIndex = 2;
            this.groupPlugin.TabStop = false;

            // 
            // panelPlugin
            // 
            this.panelPlugin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlugin.Location = new System.Drawing.Point(8, 64);
            this.panelPlugin.Name = "panelPlugin";
            this.panelPlugin.Size = new System.Drawing.Size(600, 413);
            this.panelPlugin.TabIndex = 1;
            // 
            // groupPluginInfo
            // 
            this.groupPluginInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPluginInfo.BackColor = System.Drawing.SystemColors.Control;
            this.groupPluginInfo.Controls.Add(this.linkPluginURL);
            this.groupPluginInfo.Controls.Add(this.lblPluginInfo);
            this.groupPluginInfo.Location = new System.Drawing.Point(8, 8);
            this.groupPluginInfo.Name = "groupPluginInfo";
            this.groupPluginInfo.Size = new System.Drawing.Size(600, 48);
            this.groupPluginInfo.TabIndex = 0;
            this.groupPluginInfo.TabStop = false;
            // 
            // linkPluginURL
            // 
            this.linkPluginURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkPluginURL.Location = new System.Drawing.Point(424, 16);
            this.linkPluginURL.Name = "linkPluginURL";
            this.linkPluginURL.Size = new System.Drawing.Size(160, 23);
            this.linkPluginURL.TabIndex = 1;
            this.linkPluginURL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkPluginURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPluginURL_LinkClicked);
            // 
            // lblPluginInfo
            // 
            this.lblPluginInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPluginInfo.Location = new System.Drawing.Point(8, 16);
            this.lblPluginInfo.Name = "lblPluginInfo";
            this.lblPluginInfo.Size = new System.Drawing.Size(408, 24);
            this.lblPluginInfo.TabIndex = 0;
            this.lblPluginInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstPlugins
            // 
            this.lstPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstPlugins.Location = new System.Drawing.Point(8, 16);
            this.lstPlugins.Name = "lstPlugins";
            this.lstPlugins.Size = new System.Drawing.Size(112, 485);
            this.lstPlugins.TabIndex = 1;
            this.lstPlugins.SelectedIndexChanged += new System.EventHandler(this.lstPlugins_SelectedIndexChanged);

            Controls.Add(this.groupPlugin);
            Controls.Add(this.lstPlugins);

        }

        #endregion
    }
}
