using Photon.Hive.Plugin;

namespace TestPlugins
{
    abstract class TestPluginBase : PluginBase
    {
        public override string Name
        {
            get { return this.GetType().Name; }
        }

        public override void OnCreateGame(ICreateGameCallInfo info)
        {
            this.PluginHost.LogInfo(string.Format("OnCreateGame {0} by user {1}", info.Request.GameId, info.UserId));
            info.Continue(); // same as base.OnCreateGame(info);
        }

    }
}