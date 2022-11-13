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

    public class LevelSenderEventArgs : BaseEventArgs
    {
        public LevelInfoManager Level { get; set; }

        public LevelSenderEventArgs(LevelInfoManager level)
        {
            Level = level;
        }
    }

    public class PoolPlatformEventArgs : BaseEventArgs
    {
        
    }

    public class ContinueLevelEventArgs : BaseEventArgs
    {
        
    }

    public class LevelSuccessEventArgs : BaseEventArgs
    {
        
    }

    public class SuccessButtonClickedEventArgs : BaseEventArgs
    {
        
    }

    public class LevelFailEventArgs : BaseEventArgs
    {
        
    }
    public class FailButtonClickedEventArgs : BaseEventArgs
    {
        
    }
}