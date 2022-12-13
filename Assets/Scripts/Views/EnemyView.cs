using Systems.Enemy;
using Signals;
using UnityEngine;
using Zenject;

namespace Views
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private EnemyAttackSystem attackSystem;
        
        [Inject] private readonly SignalBus _signalBus;
        
        private int _health;

        public void Initialize(
            int health,
            int attackDamage,
            float attackSpeed
        )
        {
            _health = health;
            attackSystem.Initialize(attackDamage, attackSpeed);
        }
        
        public void ApplyDamage(int damageValue)
        {
            _health -= damageValue;
            
            if(_health <= 0)
            {
                _signalBus.Fire(new KillEnemySignal()
                    {
                        EnemyView = this
                    }
                );
            }
        }
    }
}