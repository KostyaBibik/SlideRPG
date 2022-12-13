using Signals;
using UnityEngine;
using Views;
using Zenject;

namespace Systems.Bullet
{
    public class BulletMovingSystem : MonoBehaviour
    {
        private EnemyView _targetEnemy;
        private bool _isMoving;
        private float _speedMoving;
        private int _attackDamage;

        [Inject] private SignalBus _signalBus;

        private void Start()
        {
            _signalBus.Subscribe<KillEnemySignal>(OnKillEnemySignal);
        }

        public void Initialize(
            EnemyView targetEnemy,
            float speedMoving,
            int attackDamage
            )
        {
            _targetEnemy = targetEnemy;
            _speedMoving = speedMoving;
            _attackDamage = attackDamage;
            
            _isMoving = true;
        }

        private void Update()
        {
            if(!_isMoving && !_targetEnemy)
                return;

            var bulletTransform = transform;
            var bulletPos = bulletTransform.position;
            var direction = (_targetEnemy.transform.position - bulletPos).normalized;
            bulletPos += direction * (_speedMoving * Time.deltaTime);
            bulletTransform.position = bulletPos;

            if (Vector3.Distance(bulletPos, _targetEnemy.transform.position) < .2f)
            {
                _targetEnemy.ApplyDamage(_attackDamage);
                
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<KillEnemySignal>(OnKillEnemySignal);
        }

        private void OnKillEnemySignal(KillEnemySignal killEnemySignal)
        {
            Destroy(gameObject);
        }
    }
}