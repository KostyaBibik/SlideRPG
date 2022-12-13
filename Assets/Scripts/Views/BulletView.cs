using Systems.Bullet;
using UnityEngine;

namespace Views
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private BulletMovingSystem _movingSystem;

        public void Initialize(
            EnemyView targetEnemy,
            float speedMoving,
            int attackDamage
            )
        {
            _movingSystem.Initialize(targetEnemy, speedMoving, attackDamage);
        }
    }
}