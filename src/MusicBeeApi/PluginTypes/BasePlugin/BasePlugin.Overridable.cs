using System;

namespace MusicBeeApi.PluginTypes
{
    public abstract partial class BasePlugin
    {
        /// <param name="panelHandle">
        ///     panelHandle will only be set if you set PluginInfo.ConfigurationPanelHeight to a non-zero value
        ///     keep in mind the panel width is scaled according to the font the user has selected
        ///     if PluginInfo.ConfigurationPanelHeight is set to 0, you can display your own popup window    
        /// </param>
        /// <example>
        ///     public bool Configure(IntPtr panelHandle) 
        ///     {
        ///         // save any persistent settings in a sub-folder of this path
        ///         string dataPath = Api.Setting_GetPersistentStoragePath();
        ///         if (panelHandle != IntPtr.Zero)
        ///         {
        ///             Panel configPanel = (Panel)Panel.FromHandle(panelHandle);
        ///             Label prompt = new Label();
        ///             prompt.AutoSize = true;
        ///             prompt.Location = new Point(0, 0);
        ///             prompt.Text = "prompt:";
        ///             TextBox textBox = new TextBox();
        ///             textBox.Bounds = new Rectangle(60, 0, 100, textBox.Height);
        ///             configPanel.Controls.AddRange(new Control[] { prompt, textBox });
        ///         }
        ///         return false;
        ///     }
        /// </example>
        public virtual bool Configure(IntPtr panelHandle)
        {
            return false;
        }

        /// <summary>
        ///     called by MusicBee when the user clicks Apply or Save in the MusicBee Preferences screen.
        ///     its up to you to figure out whether anything has changed and needs updating
        /// </summary>
        public virtual void SaveSettings()
        {
        }

        /// <summary>
        ///     MusicBee is closing the plugin (plugin is being disabled by user or MusicBee is shutting down)
        /// </summary>
        public virtual void Close(PluginCloseReason reason)
        {
        }

        /// <summary>
        ///     Uninstall this plugin - clean up any persisted files
        /// </summary>
        public virtual void Uninstall()
        {
        }

        /// <summary>
        ///     return an array of lyric or artwork provider names this plugin supports
        ///     the providers will be iterated through one by one and passed to the RetrieveLyrics/ RetrieveArtwork function in order set by the user in the MusicBee Tags(2) preferences screen until a match is found
        /// </summary>
        public virtual string[] GetProviders()
        {
            return null;
        }

        /// <summary>
        ///     return lyrics for the requested artist/title from the requested provider
        ///     only required if PluginType = LyricsRetrieval
        ///     return null if no lyrics are found
        /// </summary>
        public virtual string RetrieveLyrics(string sourceFileUrl, string artist, string trackTitle, string album, bool synchronisedPreferred, string provider)
        {
            return null;
        }

        /// <summary>
        ///     return Base64 string representation of the artwork binary data from the requested provider
        ///     only required if PluginType = ArtworkRetrieval
        ///     return null if no artwork is found
        /// </summary>
        public string RetrieveArtwork(string sourceFileUrl, string albumArtist, string album, string provider)
        {
            //Return Convert.ToBase64String(artworkBinaryData)
            return null;
        }
    }
}
