using System.Collections.Generic;
using TadPoleFramework.Core;
using UnityEngine;

namespace TadPoleFramework
{
    public class PlatformManager : BaseManager
    {
        private Queue<Platform> _platformQueue = new Queue<Platform>();

        private List<Platform> _platforms = new List<Platform>();
        private Color _color;
        
        private Vector3 _nextSpawnPoints;
        private Vector3 _lastPos;

        public override void Receive(BaseEventArgs baseEventArgs)
        {
            switch (baseEventArgs)
            {
                case PlatformSenderEventArgs platformSenderEventArgs:
                    _platforms = platformSenderEventArgs.Platforms;
                    _color = platformSenderEventArgs.Color;
                    CreatePlatforms();
                    break;
                case PoolPlatformEventArgs poolPlatformEventArgs:
                    ContinuePlatform();
                    break;
            }
        }
        
        private void CreatePlatforms()
        {
            _nextSpawnPoints = new Vector3(0, 0, -10);
            
            for (int i = 0; i < _platforms.Count; i++)
            {
                Platform platform = Instantiate(_platforms[i], transform.position, Quaternion.identity, transform);
                _platformQueue.Enqueue(platform);
                SpawnPlatform(platform);
            }
        }

        private void SpawnPlatform(Platform platform)
        {
            platform.transform.position = _nextSpawnPoints;
            _nextSpawnPoints = platform.nextSpawnPoint.position;
            if (platform.isInteractable)
            {
                platform.GetComponent<GateController>().OnCollectorEnterEvent += OnCollectorEnterEventHandler;
            }
            
            platform.meshRenderer.material.SetColor( "_BaseColor", _color);
            
        }

        private void OnCollectorEnterEventHandler()
        {
            
        }

        private void ContinuePlatform()
        {
            // PlatformController pc = _platformQueue.Dequeue();
            // SpawnPlatform(pc);
            // _platformQueue.Enqueue(pc);
        }
    }
}