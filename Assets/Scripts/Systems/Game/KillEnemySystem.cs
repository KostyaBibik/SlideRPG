using System;
using Services;
using Signals;
using Zenject;
using Object = UnityEngine.Object;

namespace Systems.Game
{
    public class KillEnemySystem : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly EnemyService _enemyService;

        public KillEnemySystem(
            SignalBus signalBus,
            EnemyService enemyService
        )
        {
            _signalBus = signalBus;
            _enemyService = enemyService;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<KillEnemySignal>(OnKillEnemySignal);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<KillEnemySignal>(OnKillEnemySignal);
        }

        private void OnKillEnemySignal(KillEnemySignal killEnemySignal)
        {
            _enemyService.RemoveEnemyFromService(killEnemySignal.EnemyView);
            Object.Destroy(killEnemySignal.EnemyView.gameObject);
            
            _signalBus.Fire(new StartMoveSignal());
            _signalBus.Fire(new SpawnEnemySignal());
        }
    }
}