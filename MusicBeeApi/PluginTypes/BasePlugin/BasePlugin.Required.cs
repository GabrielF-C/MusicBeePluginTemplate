using System;

namespace MusicBeeApi.PluginTypes
{
    public abstract partial class BasePlugin
    {
        protected abstract PluginInfo InitPluginInfo();

        /// <summary>
        ///     Called when ReceiveNotification() is called with type == NotificationType.PluginStartup
        /// </summary>
        protected abstract void PluginStartup();
    }
}
