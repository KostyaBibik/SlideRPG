using UnityEngine;
using Views;
using Zenject;

namespace Systems.Enemy
{
    public class EnemyAttackSystem : MonoBehaviour
    {
        [Inject] private PlayerView _playerView;

        private int _damageValue;
        private float _attackSpeed;
        private float _timeWaiting;
        private bool _isReload;
        
        public void Initialize(
            int damageValue,
            float attackSpeed
        )
        {
            _damageValue = damageValue;
            _attackSpeed = attackSpeed;
        }
        
        private void Update()
        {
            if (_isReload)
            {
                _timeWaiting += Time.deltaTime;
                if (_timeWaiting >= 1/_attackSpeed)
                {
                    _isReload = false;
                }
            }
            else if (Vector3.Distance(transform.position, _playerView.transform.position) < .2f)
            {
                _playerView.ApplyDamage(_damageValue);
                _timeWaiting = 0;
                _isReload = true;
            }
        }
    }
}