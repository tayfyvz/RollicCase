using System.Collections.Generic;
using TadPoleFramework.Core;
using UnityEngine;

namespace TadPoleFramework
{
    public class PlatformManager : BaseManager
    {
        private Queue<Platform> _platformQueue = new Queue<Platform>();

        private LevelInfoManager _levelInfoManager;

        private Vector3 _nextSpawnPoints;
        private Vector3 _lastPos;

        public override void Receive(BaseEventArgs baseEventArgs)
        {
            switch (baseEventArgs)
            {
                case LevelSenderEventArgs levelSenderEventArgs:
                    _levelInfoManager = levelSenderEventArgs.Level;
                    CreatePlatforms(_levelInfoManager.stages);
                    break;
                case PoolPlatformEventArgs poolPlatformEventArgs:
                    ContinuePlatform();
                    break;
            }
        }
        
        private void CreatePlatforms(List<GameObject> stages)
        {
            for (int i = 0; i < stages.Count; i++)
            {
                ListenPlatform(stages[i]);
            }
        }

        private void ListenPlatform(GameObject platform)
        {
            platform.GetComponent<Stage>().ballCollecterPlatform.OnContinueLevelEvent += OnContinueLevelEventHandler;
            platform.GetComponent<Stage>().ballCollecterPlatform.OnFailLevelEvent += OnFailLevelEventHandler;
        }

        private void OnFailLevelEventHandler()
        {
            BroadcastUpward(new LevelFailEventArgs());
        }

        private void OnContinueLevelEventHandler()
        {
            Broadcast(new ContinueLevelEventArgs());
        }

        private void ContinuePlatform()
        {
            // PlatformController pc = _platformQueue.Dequeue();
            // SpawnPlatform(pc);
            // _platformQueue.Enqueue(pc);
        }
    }
}