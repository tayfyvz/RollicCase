using System.Collections.Generic;
using TadPoleFramework.Core;
using UnityEngine;

namespace TadPoleFramework
{
    public class PlatformManager : BaseManager
    {
        [SerializeField] private int maxPlatform;
        
        private Queue<PlatformController> _platformQueue = new Queue<PlatformController>();
        
        private PlatformController _platformController;
        private Color _color;
        
        private Vector3 _nextSpawnPoints;
        private Vector3 _lastPos;

        public override void Receive(BaseEventArgs baseEventArgs)
        {
            switch (baseEventArgs)
            {
                case PlatformSenderEventArgs platformSenderEventArgs:
                    _platformController = platformSenderEventArgs.PlatformController;
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
            
            for (int i = 0; i < maxPlatform; i++)
            {
                PlatformController platform = Instantiate(_platformController, transform.position, Quaternion.identity, transform);
                _platformQueue.Enqueue(platform);
                SpawnPlatform(platform);
            }
        }

        private void SpawnPlatform(PlatformController platformController)
        {
            platformController.transform.position = _nextSpawnPoints;
            _nextSpawnPoints = platformController.nextSpawnPoint.position;
            platformController.meshRenderer.material.SetColor( "_BaseColor", _color);
        }
        private void ContinuePlatform()
        {
            PlatformController pc = _platformQueue.Dequeue();
            SpawnPlatform(pc);
            _platformQueue.Enqueue(pc);
        }
    }
}