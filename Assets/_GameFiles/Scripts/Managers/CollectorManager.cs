using TadPoleFramework.Core;
using UnityEngine;

namespace TadPoleFramework
{
    public class CollectorManager : BaseManager
    {
        [SerializeField] private CollectorController _collector;
        [SerializeField] private int speed;
        public override void Receive(BaseEventArgs baseEventArgs)
        {
            switch (baseEventArgs)
            {
                case CollectorSenderEventArgs collectorSenderEventArgs:
                    CollectorController collector = collectorSenderEventArgs.CollectorController;
                    _collector = collector;
                    _collector.transform.position = new Vector3(0, .65f, 0);
                    // _collector.speed = speed;
                    break;
                case PlayerIsTappedEventArgs playerIsTappedEventArgs:
                    Debug.Log("player is tapped..start move");
                    _collector.EnableMovement();
                    break;
                case ContinueLevelEventArgs continueLevelEventArgs:
                    _collector.EnableMovement();
                    break;
            }
        }
    }
}