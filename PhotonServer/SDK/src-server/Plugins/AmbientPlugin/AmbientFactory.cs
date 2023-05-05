using System.Collections.Generic;
using Photon.Hive.Plugin;
using Photon.Hive.Plugin.WebHooks;

namespace AmbientPlugin
{
    public class AmbientFactory : IPluginFactory
    {
        public IGamePlugin Create(IPluginHost gameHost, string pluginName, Dictionary<string, string> config, out string errorMsg)
        {
            WebHooksPlugin plugin = new WebHooksPlugin();
            
            if (plugin.SetupInstance(gameHost, config, out errorMsg))
            {
                return plugin;
            }
            return null;
        }
    }
}
