using TadPoleFramework.Core;
using TadPoleFramework.UI;

namespace TadPoleFramework
{
    public class SuccessViewPresenter : BasePresenter
    {
        public override void Receive(BaseEventArgs baseEventArgs)
        {
            
        }

        public void OnSuccessButtonClicked()
        {
            BroadcastUpward(new SuccessButtonClickedEventArgs());
        }
    }
}