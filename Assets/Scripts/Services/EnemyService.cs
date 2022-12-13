using System.Collections.Generic;
using Views;

namespace Services
{
    public class EnemyService
    {
        private readonly List<EnemyView> _enemies = new List<EnemyView>();
        public EnemyView[] Enemies => _enemies.ToArray();
        
        public void AddEnemyToService(EnemyView enemy)
        {
            _enemies.Add(enemy);
        }

        public void RemoveEnemyFromService(EnemyView enemyView)
        {
            if (_enemies.Contains(enemyView))
            {
                _enemies.Remove(enemyView);
            }
        }
    }
}