using System.Collections.Generic;
using System.ComponentModel;
using TadPoleFramework;
using TadPoleFramework.Core;
using UnityEngine;
namespace TadPoleFramework
{
    public class LevelManager : BaseManager
    {
        [Header("Collector Settings")]
        [SerializeField] private CollectorController collector;

        [Header("Platform Settings")] 
        [SerializeField] private PlatformController platform;
        [SerializeField] private Color color;
        
        private GameModel _gameModel;
        public override void Receive(BaseEventArgs baseEventArgs)
        {
            switch (baseEventArgs)
            {
                case PlayerIsTappedEventArgs playerIsTappedEventArgs:
                    Debug.Log("player is tapped..start move");
                    break;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            CreateCollector();
            SendPlatform();
        }

        private void CreateCollector()
        {
            CollectorController cc = Instantiate(collector, Vector3.zero, Quaternion.identity);
            Broadcast(new CollectorSenderEventArgs(cc));
        }

        private void SendPlatform()
        {
            Broadcast(new PlatformSenderEventArgs(platform, color));
        }
        public void InjectModel(GameModel gameModel)
        {
            _gameModel = gameModel;
            _gameModel.PropertyChanged += GameMOdelProperetyChangedHandler;
        }
        private void GameMOdelProperetyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_gameModel.Level))
            {
                
            }
        }
    }
}