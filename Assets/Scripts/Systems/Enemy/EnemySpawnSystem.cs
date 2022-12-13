using System;
using Systems.Factory;
using Db;
using Helper;
using Services;
using Signals;
using Views;
using Zenject;

namespace Systems.Enemy
{
    public class EnemySpawnSystem : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly IEntityFactory _entityFactory;
        private readonly EnemyService _enemyService;
        private readonly SceneHolder _sceneHolder;
        private readonly EnemyParametersService _parametersService;

        public EnemySpawnSystem(
            SignalBus signalBus,
            IEntityFactory entityFactory,
            EnemyService enemyService,
            EnemyParametersService parametersService,
            SceneHolder sceneHolder
        )
        {
            _signalBus = signalBus;
            _entityFactory = entityFactory;
            _enemyService = enemyService;
            _parametersService = parametersService;
            _sceneHolder = sceneHolder;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<SpawnEnemySignal>(SpawnEnemy);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SpawnEnemySignal>(SpawnEnemy);
        }
        
        private void SpawnEnemy(SpawnEnemySignal spawnSignal)
        {
            var enemy = _entityFactory.CreateForComponent<EnemyView>("Enemy");
            enemy.transform.position = _sceneHolder.SpawnPosEnemy;
            enemy.Initialize(
                _parametersService.Health,
                _parametersService.AttackDamage,
                _parametersService.AttackSpeed
                );
            _enemyService.AddEnemyToService(enemy);
        }
    }
}