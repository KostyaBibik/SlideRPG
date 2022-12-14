using UnityEngine;

namespace Db
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(ProgressConfigSettings),
        fileName = nameof(ProgressConfigSettings))]
    public class ProgressConfigSettings : ScriptableObject
    {
        [Header("Raise values on boost")]
        [SerializeField] private int playerAttack;
        [SerializeField] private int playerHealth;
        [SerializeField, Range(0f, .1f)] private float playerAttackSpeed;
        [Header("Soft")]
        [SerializeField] private int softValueOnKillEnemy;
        
        public int PlayerAttack => playerAttack;
        public int PlayerHealth => playerHealth;
        public float PlayerAttackSpeed => playerAttackSpeed;
        public int SoftValueOnKillEnemy => softValueOnKillEnemy;
    }
}