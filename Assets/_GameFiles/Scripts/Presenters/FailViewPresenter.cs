using TadPoleFramework.Core;
using TadPoleFramework.UI;

namespace TadPoleFramework
{
    public class FailViewPresenter : BasePresenter
    {
        public override void Receive(BaseEventArgs baseEventArgs)
        {
            
        }

        public void OnFailButtonClicked()
        {
            BroadcastUpward(new FailButtonClickedEventArgs());
        }
    }
}