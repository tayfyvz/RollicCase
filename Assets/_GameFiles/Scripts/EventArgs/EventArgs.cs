using System.Collections.Generic;
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
        public List<Platform> Platforms { get; set; }
        public Color Color { get; set; }

        public PlatformSenderEventArgs(List<Platform> platforms, Color color)
        {
            Platforms = platforms;
            Color = color;
        }
    }

    public class PoolPlatformEventArgs : BaseEventArgs
    {
        
    }

    public class ContinueLevelEventArgs : BaseEventArgs
    {
        
    }
}