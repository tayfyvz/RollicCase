using TadPoleFramework;
using TadPoleFramework.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TadPoleFramework
{
    public class GameView : BaseView
    {
        [SerializeField] private Button _button;
        protected override void Initialize()
        {
            _button.onClick.AddListener((_presenter as GameViewPresenter).buttonclicked);
        }

    }
}