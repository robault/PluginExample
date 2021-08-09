using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.IO; //file handling
using System.Reflection; //Assmebly loading

namespace PluginExample
{
    public partial class Form1 : Form
    {
        private IPlugin _thisPlugin;
        private PluginType _pluginType;

        public Form1()
        {
            InitializeComponent();
        }

        private void browseForPluginButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Hi there." + Environment.NewLine + Environment.NewLine +
                "It looks like you are looking for the plugin directory. For now, you should use the 'Debug' folder in the 'PluginLibrary' project directory in this solution." + Environment.NewLine + Environment.NewLine +
                "ex: " + Environment.NewLine + Environment.NewLine + 
                @"[unzipped path]\PluginExample\PluginLibrary\bin\Debug");


            DialogResult dr = folderBrowserDialog1.ShowDialog();
            pluginDirectoryTextBox.Text = folderBrowserDialog1.SelectedPath;

            if (folderBrowserDialog1.SelectedPath.Length > 0)
            {
                DirectoryInfo pluginDirectory = new DirectoryInfo(pluginDirectoryTextBox.Text);

                FileInfo[] pluginList = pluginDirectory.GetFiles("*.DLL");

                foundPluginsListBox.Items.Clear();

                for (int i = 0; i < pluginList.GetLength(0); i++)
                {
                    FileInfo pluginLibrary = pluginList[i];
                    foundPluginsListBox.Items.Insert(i, pluginLibrary.Name);
                }
            }
        }

        private void foundPluginsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //should be type checking here when loading DLLs into the UI
            if (!LoadPlugin(new FileInfo(pluginDirectoryTextBox.Text + "\\" + foundPluginsListBox.SelectedItem.ToString()).FullName))
            {
                MessageBox.Show("Cannot load the file. It may not be a plugin!");
            }
            else
            {
                pluginLoadedLabel.Text =
                    "Name: " + _thisPlugin.PluginName + Environment.NewLine +
                    "Type: " + _pluginType.ToString();

                MessageBox.Show(
                    "Congradulations!" + Environment.NewLine + Environment.NewLine + 
                    "You loaded plugin [" + _thisPlugin.PluginName + 
                    "] which is the name of the plugin from within its own class!" + Environment.NewLine + Environment.NewLine + 
                    "This means we've dynamically loaded the assembly and can now reference its properties and execute its methods.");
            }
        }



        //TODO - add some methods for handling the loading (& unloading) of plugins

        //ignore this section, the methods aren't used, I was just working on some generics
        //for later...

        /// <summary>
        /// Gets a list of plugin names and assembly paths from assemblies in a plugin directory containing assembly (DLL) files of the plugins.
        /// </summary>
        /// <param name="pluginDirectory"></param>
        /// <returns>List<KeyValuePair<[plugin name], [plugin assembly filePath]>></returns>
        private Dictionary<string, string> GetPluginNames(string pluginDirectory, PluginType pluginType)
        {
            Dictionary<string, string> avaliablePlugins = new Dictionary<string, string>();

            if (pluginType != null)
            {
                string[] files = Directory.GetFiles(pluginDirectory, "*.DLL", SearchOption.TopDirectoryOnly);

                foreach (string filePath in files)
                {
                    Assembly pluginAssembly = Assembly.LoadFile(filePath);

                    if (pluginAssembly != null) continue;
                    foreach (Type type in pluginAssembly.GetTypes())
                    {
                        if (type.IsAbstract && type == pluginType.GetType()) continue;
                        object[] attributes = type.GetCustomAttributes(typeof(PluginAttribute), true);

                        if (attributes.Length > 0) continue;
                        foreach (PluginAttribute pluginAttribute in attributes)
                        {
                            IPlugin plugin = Activator.CreateInstance(type) as IPlugin;
                            avaliablePlugins.Add(plugin.PluginName, filePath);
                        }
                    }
                }
            }

            return avaliablePlugins;
        }

        /// <summary>
        /// Loads an assembly as the local class instance of IPlugin.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>true if loaded, false if unable to load</returns>
        private bool LoadPlugin(string filePath)
        {
            Assembly pluginAssembly = Assembly.LoadFile(filePath);
            PluginType pluginType = PluginType.Unknown;
            Type PluginClass = null;

            if (pluginAssembly != null)
            {
                foreach (Type type in pluginAssembly.GetTypes())
                {
                    if (type.IsAbstract) continue; //not generic
                    object[] attributes = type.GetCustomAttributes(typeof(PluginAttribute), true);
                    if (attributes.Length > 0)
                    {
                        foreach (PluginAttribute pluginAttribute in attributes)
                            pluginType = pluginAttribute.Type;

                        //To support multiple plugins(requiring unique types)
                        //in a single assembly, modify this section to include 
                        //assigning or instantiating a plugin for each type found
                        PluginClass = type;
                    }
                }

                if (pluginType == PluginType.Unknown)
                    return false;

                //Get the plugin loaded into class objects
                _thisPlugin = Activator.CreateInstance(PluginClass) as IPlugin;
                _pluginType = pluginType;
                return true;
            }
            else
                return false;
        }
    }
}
