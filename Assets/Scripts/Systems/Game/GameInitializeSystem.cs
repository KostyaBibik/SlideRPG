using Signals;
using Zenject;

namespace Systems.Game
{
    public class GameInitializeSystem : IInitializable
    {
        private readonly SignalBus _signalBus;

        public GameInitializeSystem(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _signalBus.Fire(new InitializePlayerSignal());
            _signalBus.Fire(new ChunkSpawnSignal());
            _signalBus.Fire(new StartMoveSignal());
            _signalBus.Fire(new SpawnEnemySignal());
        }
    }
}