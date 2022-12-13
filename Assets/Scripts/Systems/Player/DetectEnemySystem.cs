using System;
using System.Collections.Generic;
using System.Linq;
using Signals;
using UnityEngine;
using Views;
using Zenject;

namespace Systems.Player
{
    public class DetectEnemySystem : ITickable, IInitializable, IDisposable
    {
        private readonly PlayerView _playerView;
        private readonly SignalBus _signalBus;
        private readonly int _enemyLayer;
        private readonly List<Transform> _detectedEnemies = new List<Transform>();
        
        private const int maxColliders = 10;
        
        public DetectEnemySystem(
            PlayerView playerView,
            SignalBus signalBus            
        )
        {
            _playerView = playerView;
            _signalBus = signalBus;
            
            _enemyLayer = LayerMask.GetMask("Enemy");
        }
        
        public void Tick()
        {
            var hitColliders = new Collider[maxColliders];
            if (Physics.OverlapSphereNonAlloc(_playerView.transform.position, 5f, hitColliders, _enemyLayer) > 0)
            {
                if (_detectedEnemies.Any(detectedEnemy => detectedEnemy == hitColliders[0].transform))
                {
                    return;
                }
                
                _signalBus.Fire(new DetectEnemySignal
                {
                    enemy = hitColliders[0].GetComponent<EnemyView>()
                }
                );
                
                _detectedEnemies.Add(hitColliders[0].transform);
            }
        }

        public void Initialize()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}