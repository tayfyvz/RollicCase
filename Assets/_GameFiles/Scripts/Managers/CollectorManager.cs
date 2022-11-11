using TadPoleFramework.Core;
using UnityEngine;

namespace TadPoleFramework
{
    public class CollectorManager : BaseManager
    {
        [SerializeField] private CollectorController _collector;
        public override void Receive(BaseEventArgs baseEventArgs)
        {
            switch (baseEventArgs)
            {
                case CollectorSenderEventArgs collectorSenderEventArgs:
                    CollectorController collector = collectorSenderEventArgs.CollectorController;
                    _collector = collector;
                    break;
                case PlayerIsTappedEventArgs playerIsTappedEventArgs:
                    Debug.Log("player is tapped..start move");
                    break;
            }
        }
    }
}