using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

using Lucene.Net.LukeNet.Plugins;
using Lucene.Net.Index;

namespace Lucene.Net.LukeNet
{
    [System.ComponentModel.ToolboxItem(true)]
    //[Designer(typeof(System.Windows.Forms.Design.ScrollableControlDesigner))]
    public partial class PluginsTabPage : TabPage
    {

        private List<LukePlugin> plugins = new List<LukePlugin>();

        public Lucene.Net.Store.Directory Directory { get; set; }
        public IndexReader IndexReader { get; set; }
        
        public PluginsTabPage()
        {
            InitializeComponent();
        }

        private void lstPlugins_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadPluginTab((LukePlugin)plugins[lstPlugins.SelectedIndex]);
        }

        private void linkPluginURL_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            linkPluginURL.Links[linkPluginURL.Links.IndexOf(e.Link)].Visited = true;
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        public void LoadPlugins()
        {
            List<Type> pluginTypes = new List<Type>();
            // try to find all plugins
            try
            {
                Type[] types =
                    Lucene.Net.LukeNet.ClassFinder.ClassFinder.GetInstantiableSubtypes(typeof(LukePlugin));
                foreach (Type type in types)
                {
                    pluginTypes.Add(type);
                }
            }
            catch (Exception) { }

            // load plugins declared in the ".plugins" file
            try
            {
                StreamReader reader = new StreamReader(".plugins");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("#")) continue;
                    if (line.Trim().Equals("")) continue;

                    Type t = Type.GetType(line, false);
                    if (t.IsSubclassOf(typeof(LukePlugin)) && !pluginTypes.Contains(t))
                    {
                        pluginTypes.Add(t);
                    }
                }
            }
            catch (IOException)
            { }

            foreach (Type pluginType in pluginTypes)
            {
                try
                {
                    LukePlugin plugin = (LukePlugin)pluginType.GetConstructor(new Type[] { }).Invoke(new Object[] { });
                    plugins.Add(plugin);
                }
                catch (Exception)
                { }
            }
            if (plugins.Count == 0) return;
            InitPlugins();
        }

        private void InitPlugins()
        {
            ClearPluginsUI();

            foreach (LukePlugin plugin in plugins)
            {
                plugin.SetDirectory(Directory);
                plugin.SetIndexReader(IndexReader);
                try
                {
                    plugin.Init();
                    plugin.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                }
                catch (Exception e)
                {
                    plugins.Remove(plugin);
                    ((Luke)Parent.Parent).ShowStatus("PLUGIN ERROR: " + e.Message);
                    MessageBox.Show("PLUGIN ERROR: " + e.Message);
                }
                lstPlugins.Items.Add(plugin.GetPluginName());
            }

            if (lstPlugins.Items.Count > 0)
            {
                lstPlugins.SelectedIndex = 0;
            }
        }

        private void ClearPluginsUI()
        {
            lstPlugins.Items.Clear();
            panelPlugin.Controls.Clear();
            lblPluginInfo.Text = "";
            linkPluginURL.Text = "";
            linkPluginURL.Links.Clear();

        }

        private void LoadPluginTab(LukePlugin plugin)
        {
            lblPluginInfo.Text = plugin.GetPluginInfo();
            linkPluginURL.Text = plugin.GetPluginHome();
            linkPluginURL.Links.Clear();
            linkPluginURL.Links.Add(0, linkPluginURL.Text.Length, linkPluginURL.Text);

            plugin.Size = panelPlugin.Size;
            panelPlugin.Controls.Clear();
            panelPlugin.Controls.Add(plugin);
        }

    }
}
