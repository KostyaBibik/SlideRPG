using Db;
using Services;
using UnityEngine;
using Views;
using Zenject;

namespace Systems.Enemy
{
    public class EnemyMovingSystem : ITickable
    {
        private readonly PlayerView _playerView;
        private readonly EnemyService _enemyService;
        private readonly float _speedMoving;
        
        public EnemyMovingSystem(
            PlayerView playerView,
            EnemyService enemyService,
            EnemyConfigSettings configSettings
        )
        {
            _playerView = playerView;
            _enemyService = enemyService;
            _speedMoving = configSettings.SpeedMoving;
        }

        public void Tick()
        {
            var enemies = _enemyService.Enemies;
            foreach (var enemy in enemies)
            {
                var enemyTransform = enemy.transform;
                var enemyPos = enemyTransform.position;
                var directionToPlayer = (_playerView.transform.position - enemyPos).normalized;
                enemyPos += directionToPlayer * (Time.deltaTime * _speedMoving);
                enemyTransform.position = enemyPos;
            }
        }
    }
}