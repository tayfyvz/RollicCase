using TadPoleFramework;
using TadPoleFramework.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TadPoleFramework
{
    public class GameView : BaseView
    {
        [SerializeField] private TextMeshProUGUI levelText;
        protected override void Initialize()
        {
           
        }

        public void ChangeLevelText(int level)
        {
            levelText.text = "Level " + level;
        }

    }
}