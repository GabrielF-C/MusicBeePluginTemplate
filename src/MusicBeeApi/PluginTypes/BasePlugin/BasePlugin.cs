using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicBeeApi.PluginTypes
{
    public abstract partial class BasePlugin
    {
        public const short PluginInfoVersion = 1;
        public const short MinInterfaceVersion = 41;
        public const short MinApiRevision = 53;

        protected MusicBeeApiInterface Api;
        protected PluginInfo PluginInfo = new PluginInfo();

        private Dictionary<NotificationType, List<NotificationObserver>> NotificationObservers { get; } = new Dictionary<NotificationType, List<NotificationObserver>>();

        public PluginInfo Initialise(IntPtr apiInterfacePtr)
        {
            Api = new MusicBeeApiInterface();
            Api.Initialise(apiInterfacePtr);

            PluginInfo = InitPluginInfo();
            PluginInfo.PluginInfoVersion = PluginInfoVersion;
            PluginInfo.MinInterfaceVersion = MinInterfaceVersion;
            PluginInfo.MinApiRevision = MinApiRevision;

            return PluginInfo;
        }

        #region Notifications
        /// <summary>
        ///     receive event notifications from MusicBee
        ///     you need to set PluginInfo.ReceiveNotificationFlags = PlayerEvents to receive all notifications, and not just the startup event
        /// </summary>
        /// <example>
        ///     public virtual void ReceiveNotification(string sourceFileUrl, NotificationType type)
        ///     {
        ///         // perform some action depending on the notification type
        ///         switch (type)
        ///         {
        ///             case NotificationType.PluginStartup:
        ///                 // perform startup initialisation
        ///                 switch (Api.Player_GetPlayState())
        ///                 {
        ///                     case PlayState.Playing:
        ///                     case PlayState.Paused:
        ///                         // ...
        ///                         break;
        ///                 }
        ///                 break;
        ///             case NotificationType.TrackChanged:
        ///                 string artist = Api.NowPlaying_GetFileTag(MetaDataType.Artist);
        ///                 // ...
        ///                 break;
        ///         }
        ///     }
        /// </example>
        public void ReceiveNotification(string sourceFileUrl, NotificationType type)
        {
            if (type == NotificationType.PluginStartup)
            {
                PluginStartup();
            }
            NotifyAll(sourceFileUrl, type);
        }

        protected void Subscribe(NotificationType type, NotificationObserver observer)
        {
            if (!NotificationObservers.TryGetValue(type, out var observers))
            {
                observers = new List<NotificationObserver>();
                NotificationObservers.Add(type, observers);
            }
            observers.Add(observer);
        }

        protected void Unsubscribe(NotificationType type, NotificationObserver observer)
        {
            if (NotificationObservers.ContainsKey(type));
            {
                NotificationObservers.Where(x => x.Key == type).Single().Value.Remove(observer);
            }
        }

        private void NotifyAll(string sourceFileUrl, NotificationType type)
        {
            foreach (var observer in NotificationObservers.Values.SelectMany(x => x))
            {
                observer.Invoke(sourceFileUrl, type);
            }
        }

        protected delegate void NotificationObserver(string sourceFileUrl, NotificationType type);
        #endregion
    };
}
