using System;
using Db;
using Signals;
using Zenject;

namespace Services
{
    public class EnemyRaiseParametersService : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly EnemyConfigSettings _enemyConfigSettings;
        private readonly EnemyParametersService _enemyParametersService;
        
        public EnemyRaiseParametersService(
            SignalBus signalBus,
            EnemyConfigSettings configSettings,
            EnemyParametersService enemyParametersService
        )
        {
            _signalBus = signalBus;
            _enemyConfigSettings = configSettings;
            _enemyParametersService = enemyParametersService;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<SpawnEnemySignal>(RaiseParameters);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SpawnEnemySignal>(RaiseParameters);
        }

        private void RaiseParameters(SpawnEnemySignal spawnEnemySignal)
        {
            _enemyParametersService.RaiseHealth(_enemyConfigSettings.RaiseHealth);
            _enemyParametersService.RaiseAttackDamage(_enemyConfigSettings.RaiseAttackDamage);
        }
    }
}