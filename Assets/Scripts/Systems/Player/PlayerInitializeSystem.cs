using System;
using Systems.Factory;
using Helper;
using Signals;
using Zenject;

namespace Systems.Player
{
    public class PlayerInitializeSystem : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly IEntityFactory _entityFactory;
        private readonly SceneHolder _sceneHolder;
        
        public PlayerInitializeSystem(
            SignalBus signalBus,
            IEntityFactory entityFactory,
            SceneHolder sceneHolder
        )
        {
            _signalBus = signalBus;
            _entityFactory = entityFactory;
            _sceneHolder = sceneHolder;
        }

        private void InitializePlayer(InitializePlayerSignal initializePlayerSignal)
        {
            var playerPos = _sceneHolder.SpawnPosPlayer;
            
            var player = _entityFactory.Create("Player", playerPos);
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<InitializePlayerSignal>(InitializePlayer);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<InitializePlayerSignal>(InitializePlayer);
        }
    }
}