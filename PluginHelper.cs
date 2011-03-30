using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using Lucene.Net.LukeNet.Plugins;

namespace Lucene.Net.LukeNet
{
    public class PluginHelper
    {
        private List<LukePlugin> plugins = new List<LukePlugin>();

        private void LoadPlugins()
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
            //InitPlugins();
        }

    }
}
