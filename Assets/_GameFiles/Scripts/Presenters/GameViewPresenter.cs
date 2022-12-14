using System.Collections;
using TadPoleFramework.Core;
using TadPoleFramework.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TadPoleFramework
{
    public class GameViewPresenter : BasePresenter
    {
        public override void Receive(BaseEventArgs baseEventArgs)
        {
            switch (baseEventArgs)
            {

            }
        }

        public void ChangeLevelText(int gameModelLevel)
        {
            (view as GameView).ChangeLevelText(gameModelLevel+1);
        }
    }
}