using System;
using System.Collections;
using Systems.Factory;
using Services;
using Signals;
using UniRx;
using UnityEngine;
using Views;
using Zenject;

namespace Systems.Player
{
    public class PlayerAttackSystem : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly PlayerView _playerView;
        private readonly IEntityFactory _entityFactory;
        private readonly PlayerParametersService _playerParameters;

        private EnemyView _targetEnemy;
        private bool _isAttack;
        
        public PlayerAttackSystem(
            SignalBus signalBus,
            PlayerView playerView,
            IEntityFactory entityFactory,
            PlayerParametersService playerParametersService
        )
        {
            _signalBus = signalBus;
            _playerView = playerView;
            _entityFactory = entityFactory;
            _playerParameters = playerParametersService;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<DetectEnemySignal>(AttackEnemy);
            _signalBus.Subscribe<KillEnemySignal>(OnKillPlayer);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<DetectEnemySignal>(AttackEnemy);
            _signalBus.Unsubscribe<KillEnemySignal>(OnKillPlayer);
        }

        private void AttackEnemy(DetectEnemySignal detectEnemySignal)
        {
            _isAttack = true;
            _targetEnemy = detectEnemySignal.enemy;
            
            Observable.FromCoroutine(Attack)
                .Subscribe();
        }

        private IEnumerator Attack()
        {
            do
            {
                if (!_isAttack)
                {
                    yield break;
                }
                
                var bullet = _entityFactory.CreateForComponent<BulletView>("Bullet");
                bullet.Initialize(_targetEnemy, _playerParameters.SpeedMovingBullet, _playerParameters.AttackDamage);

                var timeReload = 0f;
                do
                {
                    if (!_isAttack)
                    {
                        yield break;
                    }
                    
                    timeReload += Time.deltaTime;
                    yield return null;
                } while ( 1f/_playerParameters.AttackSpeed >= timeReload);
                
            } while (_isAttack);

            _isAttack = false;
        }

        private void OnKillPlayer(KillEnemySignal killEnemySignal)
        {
            _isAttack = false;
        }
    }
}