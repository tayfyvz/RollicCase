using System.ComponentModel;
using TadPoleFramework;
using TadPoleFramework.Core;
using TadPoleFramework.UI;
using UnityEngine;


public class UIManager : BaseUIManager
{
    [SerializeField] private GameViewPresenter gameViewPresenter;
    [SerializeField] private TapToStartViewPresenter tapToStartViewPresenter;
    
    private GameModel gameModel;
    public override void Receive(BaseEventArgs baseEventArgs)
    {
        switch (baseEventArgs)
        {
            case PlayerIsTappedEventArgs playerIsTappedEventArgs:
                tapToStartViewPresenter.HideView();
                gameViewPresenter.ShowView();
                Broadcast(playerIsTappedEventArgs);
                break;
            case PoolPlatformEventArgs poolPlatformEventArgs:
                Broadcast(poolPlatformEventArgs);
                break;
        }
    }
    protected override void Awake()
    {
        base.Awake();
        gameViewPresenter.InjectManager(this);
        tapToStartViewPresenter.InjectManager(this);
    }

    protected override void Start()
    {
        base.Start();
        tapToStartViewPresenter.ShowView();
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