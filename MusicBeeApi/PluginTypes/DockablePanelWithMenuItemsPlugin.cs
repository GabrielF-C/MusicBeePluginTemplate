using System.Collections.Generic;
using System.Windows.Forms;

namespace MusicBeeApi.PluginTypes
{
    public abstract class DockablePanelWithMenuItemsPlugin : DockablePanelPlugin
    {
        /// <summary>
        ///     presence of this function indicates to MusicBee that the dockable panel passed to OnDockablePanelCreated will show menu items when the panel header is clicked
        ///     return the list of ToolStripMenuItems that will be displayed
        /// </summary>
        /// <example>
        ///     public List<ToolStripItem> GetHeaderMenuItems()
        ///     {
        ///         List<ToolStripItem> list = new List<ToolStripItem>();
        ///         list.Add(new ToolStripMenuItem("A menu item"));
        ///         return list;
        ///     }
        /// </example>
        public abstract List<ToolStripItem> GetHeaderMenuItems();
    }
}
