using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cinemachine;
using TadPoleFramework;
using TadPoleFramework.Core;
using UnityEngine;
namespace TadPoleFramework
{
    public class LevelManager : BaseManager
    {
        [SerializeField] private LevelInfoManager[] levelPrefabs;
        private int currentLevelIndex;
        private int nextLevelIndex;
        
        [SerializeField] private CinemachineVirtualCamera cam;

        [Header("Collector Settings")]
        [SerializeField] private CollectorController collector;

        [Header("Platform Settings")] 
        [SerializeField] private List<Platform> platforms = new List<Platform>();
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

        public static event Action levelLoadedEvent;
        public static LevelManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
            //ResetNextLevelIndex();
            LoadCurrentLevel();
            CreateCollector();
        }
        private void LoadCurrentLevel()
    {
            currentLevelIndex = _gameModel.Level;
            nextLevelIndex = PlayerPrefs.GetInt("NextLevelIndex", 0);
            int isLevelsSelected = PlayerPrefs.GetInt("IsLevelsSelected", 1); //1 mean selected 0 mean not selected

            if (currentLevelIndex < levelPrefabs.Length - 1) //get both from levels
            {
                nextLevelIndex = currentLevelIndex + 1;
                PlayerPrefs.SetInt("NextLevelIndex", nextLevelIndex);
            }
            else if (currentLevelIndex == levelPrefabs.Length - 1) //get next level random 
            {
                if (isLevelsSelected == 0)//-1 means we can pick random and assign it
                {
                    nextLevelIndex = currentLevelIndex;
                    while (currentLevelIndex == nextLevelIndex)
                    {
                        nextLevelIndex = UnityEngine.Random.Range(0, levelPrefabs.Length);
                    }
                    PlayerPrefs.SetInt("NextLevelIndex", nextLevelIndex);

                    PlayerPrefs.SetInt("IsLevelsSelected", 1);
                }
            }
            else // get current from last random and next from random
            {
                if (isLevelsSelected == 0)
                {

                    int lastLevelIndex = PlayerPrefs.GetInt("NextLevelIndex", 0);
                    currentLevelIndex = lastLevelIndex;

                    nextLevelIndex = currentLevelIndex;
                    while (currentLevelIndex == nextLevelIndex)
                    {
                        nextLevelIndex = UnityEngine.Random.Range(0, levelPrefabs.Length);
                    }

                    PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex);
                    PlayerPrefs.SetInt("NextLevelIndex", nextLevelIndex);

                    PlayerPrefs.SetInt("IsLevelsSelected", 1);
                }
                else
                {

                    currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 0);
                    nextLevelIndex = PlayerPrefs.GetInt("NextLevelIndex", 0);
                }
            }
            
            LevelInfoManager currentLevel = Instantiate(levelPrefabs[currentLevelIndex], transform.position,
                Quaternion.identity, transform);

            Vector3 nextLevelSpawnPos = new Vector3(transform.position.x, transform.position.y,
                transform.position.z + GetCurrentLevelLength(currentLevel));
            LevelInfoManager nextLevel = Instantiate(levelPrefabs[nextLevelIndex], nextLevelSpawnPos,
                Quaternion.identity, transform);

            Broadcast(new LevelSenderEventArgs(currentLevel));
            levelLoadedEvent?.Invoke();
            }
        public float GetCurrentLevelLength(LevelInfoManager curLevelObj)
        {
            float curLevelLength = 0f;
            LevelInfoManager levelInfoManager = curLevelObj.gameObject.GetComponent<LevelInfoManager>();
            curLevelLength = levelInfoManager.GetLevelLength() + 10;
            return curLevelLength;
        }
        private void CreateCollector()
        {
            CollectorController cc = Instantiate(collector, Vector3.zero, Quaternion.identity);
            cam.Follow = cc.transform;
            Broadcast(new CollectorSenderEventArgs(cc));
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