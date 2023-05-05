using Photon.Hive.Plugin;

namespace AmbientPlugin
{
    public class AmbientPlugin : PluginBase
    {
        public override string Name
        {
            get { return "AmbientPlugin"; }
        }

        public override void OnCreateGame(ICreateGameCallInfo info)
        {
            this.PluginHost.LogInfo(string.Format("OnCreateGame {0} by user {1}", info.Request.GameId, info.UserId));
            info.Continue(); // same as base.OnCreateGame(info);
        }

    }
}
