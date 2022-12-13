using UnityEngine;

namespace Db
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(PlayerConfigSettings),
        fileName = nameof(PlayerConfigSettings))]
    public class PlayerConfigSettings : ScriptableObject
    {
        [SerializeField] private int attack;
        [SerializeField] private int health;
        [SerializeField] private float attackSpeed;
        [SerializeField] private float speedMovingBullet;
        
        public int Attack => attack;
        public int Health => health;
        public float AttackSpeed => attackSpeed;
        public float SpeedMovingBullet => speedMovingBullet;
    }
}