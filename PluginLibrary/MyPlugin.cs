
namespace PluginExample
{
    [PluginAttribute(PluginType.Library)]
    public partial class MyPlugin : IPlugin
    {
        private string _pluginName = "MyPlugin";

        //one and only public property from the interface
        public string PluginName
        {
            get
            {
                return _pluginName;
            }
            set
            {
                _pluginName = value;
            }
        }
    }
}
