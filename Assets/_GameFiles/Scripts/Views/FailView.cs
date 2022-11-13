using TadPoleFramework.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TadPoleFramework
{
    public class FailView : BaseView
    {
        [SerializeField] private Button failButton;
        protected override void Initialize()
        {
            failButton.onClick.AddListener((_presenter as FailViewPresenter).OnFailButtonClicked);
        }
    }
}