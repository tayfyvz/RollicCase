using TadPoleFramework.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TadPoleFramework
{
    public class SuccessView : BaseView
    {
        [SerializeField] private Button successButton;
        protected override void Initialize()
        {
            successButton.onClick.AddListener((_presenter as SuccessViewPresenter).OnSuccessButtonClicked);
        }
    }
}