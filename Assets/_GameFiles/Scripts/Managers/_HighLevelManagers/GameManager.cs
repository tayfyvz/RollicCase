using System.ComponentModel;
using TadPoleFramework.Core;
using TadPoleFramework.Game;
using UnityEngine;


namespace TadPoleFramework
{
    public class GameManager : BaseGameManager
    {
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private CollectorManager collectorManager;
        [SerializeField] private PlatformManager platformManager;
        
        private GameModel gameModel;
        public override void Receive(BaseEventArgs baseEventArgs)
        {
            switch (baseEventArgs)
            {
                case PlayerIsTappedEventArgs playerIsTappedEventArgs:
                    BroadcastDownward(playerIsTappedEventArgs);
                    break;
                case PoolPlatformEventArgs poolPlatformEventArgs:
                    BroadcastDownward(poolPlatformEventArgs);
                    break;
                case LevelSuccessEventArgs levelSuccessEventArgs:
                    Broadcast(levelSuccessEventArgs);
                    break;
                case LevelFailEventArgs levelFailEventArgs:
                    Broadcast(levelFailEventArgs);
                    break;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            IMediator mediator = new BaseMediator();
            levelManager.InjectMediator(mediator);
            levelManager.InjectManager(this);
            levelManager.InjectModel(gameModel);
            
            collectorManager.InjectMediator(mediator);
            collectorManager.InjectManager(this);
            
            platformManager.InjectMediator(mediator);
            platformManager.InjectManager(this);
        }

        public void InjectModel(GameModel gameModel)
        {
            this.gameModel = gameModel;
            this.gameModel.PropertyChanged += GameMOdelProperetyChangedHandler;
        }

        private void GameMOdelProperetyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(gameModel.InstantScore))
            {
                
            }
        }
    }
}