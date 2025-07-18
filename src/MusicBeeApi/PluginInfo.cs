using System.Runtime.InteropServices;

namespace MusicBeeApi
{
    [StructLayout(LayoutKind.Sequential)]
    public class PluginInfo
    {
        public short PluginInfoVersion;
        public PluginType Type = PluginType.General;
        public string Name = "MyPlugin";
        public string Description = "";
        public string Author = "";
        /// <summary>the name of a Plugin Storage device or panel header for a dockable panel</summary>
        public string TargetApplication = "";
        /// <summary>your plugin major version</summary>
        public short VersionMajor = 1;
        /// <summary>your plugin minor version</summary>
        public short VersionMinor = 0;
        /// <summary>your plugin revision version</summary>
        public short Revision = 0;
        public short MinInterfaceVersion;
        public short MinApiRevision;
        public ReceiveNotificationFlags ReceiveNotifications = ReceiveNotificationFlags.StartupOnly;
        /// <summary>height in pixels that musicbee should reserve in a panel for config settings. When set, a handle to an empty panel will be passed to the Configure function</summary>
        public int ConfigurationPanelHeight = 0;
    }
}
