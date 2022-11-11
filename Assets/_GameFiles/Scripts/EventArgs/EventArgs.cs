using TadPoleFramework.Core;
using UnityEngine;

namespace TadPoleFramework
{
    public class PlayerIsTappedEventArgs : BaseEventArgs
    {
        
    }

    public class CollectorSenderEventArgs : BaseEventArgs
    {
        public CollectorController CollectorController { get; set; }

        public CollectorSenderEventArgs(CollectorController collectorController)
        {
            CollectorController = collectorController;
        }
    }

    public class PlatformSenderEventArgs : BaseEventArgs
    {
        public PlatformController PlatformController { get; set; }
        public Color Color { get; set; }

        public PlatformSenderEventArgs(PlatformController platformController, Color color)
        {
            PlatformController = platformController;
            Color = color;
        }
    }

    public class PoolPlatformEventArgs : BaseEventArgs
    {
        
    }
}