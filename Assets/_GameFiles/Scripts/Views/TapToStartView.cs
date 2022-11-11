using TadPoleFramework.UI;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace TadPoleFramework
{
    public class TapToStartView : BaseView
    {
        [SerializeField] private Button tapToStartButton;
        protected override void Initialize()
        {
            tapToStartButton.onClick.AddListener((_presenter as TapToStartViewPresenter).PlayerIsTapped);
        }
    }
}