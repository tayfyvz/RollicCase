using System.ComponentModel;
using TadPoleFramework;
using TadPoleFramework.Core;
using TadPoleFramework.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : BaseUIManager
{
    [SerializeField] private GameViewPresenter gameViewPresenter;
    [SerializeField] private TapToStartViewPresenter tapToStartViewPresenter;
    [SerializeField] private SuccessViewPresenter successViewPresenter;
    [SerializeField] private FailViewPresenter failViewPresenter;
    
    
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
            case LevelSuccessEventArgs levelSuccessEventArgs:
                gameViewPresenter.HideView();
                successViewPresenter.ShowView();
                break;
            case LevelFailEventArgs levelFailEventArgs:
                gameViewPresenter.HideView();
                failViewPresenter.ShowView();
                break;
            case SuccessButtonClickedEventArgs successButtonClickedEventArgs:
                gameModel.Level++;
                RestartScene();
                break;
            case FailButtonClickedEventArgs failButtonClickedEventArgs:
                RestartScene();
                break;
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
    }

    protected override void Awake()
    {
        base.Awake();
        gameViewPresenter.InjectManager(this);
        
        tapToStartViewPresenter.InjectManager(this);
        successViewPresenter.InjectManager(this);
        failViewPresenter.InjectManager(this);
    }

    protected override void Start()
    {
        base.Start();
        tapToStartViewPresenter.ShowView();
        gameViewPresenter.ChangeLevelText(gameModel.Level);
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