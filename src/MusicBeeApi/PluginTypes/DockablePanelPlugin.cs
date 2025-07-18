using System.Windows.Forms;

namespace MusicBeeApi.PluginTypes
{
    public abstract class DockablePanelPlugin : BasePlugin
    {
        /// <summary>
        ///     presence of this function indicates to MusicBee that this plugin has a dockable panel. MusicBee will create the control and pass it as the panel parameter
        ///     you can add your own controls to the panel if needed
        ///     you can control the scrollable area of the panel using the Api.MB_SetPanelScrollableArea function
        ///     to set a MusicBee header for the panel, set PluginInfo.TargetApplication in the Initialise function above to the panel header text
        /// </summary>
        /// <example>
        ///     public int OnDockablePanelCreated(Control panel)
        ///     {
        ///         //    return the height of the panel and perform any initialisation here
        ///         //    MusicBee will call panel.Dispose() when the user removes this panel from the layout configuration
        ///         //    < 0 indicates to MusicBee this control is resizable and should be sized to fill the panel it is docked to in MusicBee
        ///         //    = 0 indicates to MusicBee this control resizeable
        ///         //    > 0 indicates to MusicBee the fixed height for the control.Note it is recommended you scale the height for high DPI screens(create a graphics object and get the DpiY value)
        ///         float dpiScaling = 0;
        ///         using (Graphics g = panel.CreateGraphics())
        ///         {
        ///             dpiScaling = g.DpiY / 96f;
        ///         }
        ///         panel.Paint += (object sender, PaintEventArgs e) =>        
        ///         {
        ///             e.Graphics.Clear(Color.Red);
        ///             TextRenderer.DrawText(e.Graphics, "hello", SystemFonts.CaptionFont, new Point(10, 10), Color.Blue);
        ///         };
        ///         return Convert.ToInt32(100 * dpiScaling);
        ///     }
        ///     
        /// </example>
        public abstract int OnDockablePanelCreated(Control panel);
    }
}
