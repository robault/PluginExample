using System;

namespace PluginExample //changed namespace
{
    //plugin interface
    public interface IPlugin
    {
        //dull? perhaps...
        string PluginName { get; set; }
    }

    //type definition
    public enum PluginType
    {
        Library,
        Custom,
        Unknown
    };

    //attribute definition
    [AttributeUsage(System.AttributeTargets.Class)]
    public sealed class PluginAttribute : Attribute
    {
        private PluginType _type;

        //constructor (sets the type from the Attribute class decorator of the MyPlugin class)
        public PluginAttribute(PluginType type) { _type = type; }
 
	    public PluginType Type { get { return _type; } }
    }
}
