using UnityEngine;

namespace Db
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(EnemyConfigSettings),
        fileName = nameof(EnemyConfigSettings))]
    public class EnemyConfigSettings : ScriptableObject
    {
        [SerializeField] private float speedMoving;
        [SerializeField] private int attack;
        [SerializeField] private int health;
        [SerializeField] private float attackSpeed;
        [SerializeField] private int raiseHealth;
        [SerializeField] private int raiseAttackDamage;
        
        public float SpeedMoving => speedMoving;
        public int Attack => attack;
        public int Health => health;
        public float AttackSpeed => attackSpeed;
        public int RaiseHealth => raiseHealth;
        public int RaiseAttackDamage => raiseAttackDamage;
    }
}