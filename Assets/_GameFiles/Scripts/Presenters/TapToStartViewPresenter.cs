using TadPoleFramework.Core;
using TadPoleFramework.UI;

namespace TadPoleFramework
{
    public class TapToStartViewPresenter : BasePresenter
    {
        public override void Receive(BaseEventArgs baseEventArgs)
        {
            
        }

        public void PlayerIsTapped()
        {
            BroadcastUpward(new PlayerIsTappedEventArgs());
        }
    }
}