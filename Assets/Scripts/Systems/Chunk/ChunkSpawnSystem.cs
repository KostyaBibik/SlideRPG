using System;
using Systems.Factory;
using Helper;
using Services;
using Signals;
using Views;
using Zenject;

namespace Systems.Chunk
{
    public class ChunkSpawnSystem : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly IEntityFactory _entityFactory;
        private readonly SceneHolder _sceneHolder;
        private readonly ChunkService _chunkService;

        public ChunkSpawnSystem(
            SignalBus signalBus,
            IEntityFactory entityFactory,
            SceneHolder sceneHolder,
            ChunkService chunkService
            )
        {
            _signalBus = signalBus;
            _entityFactory = entityFactory;
            _sceneHolder = sceneHolder;
            _chunkService = chunkService;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<ChunkSpawnSignal>(SpawnChunk);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<ChunkSpawnSignal>(SpawnChunk);
        }

        private void SpawnChunk(ChunkSpawnSignal spawnSignal)
        {
            foreach (var spawnPos in _sceneHolder.SpawnPosesFloor)
            {
                var chunk = _entityFactory.CreateForComponent<ChunkView>("Chunk");
                chunk.transform.position = spawnPos;
                _chunkService.AddChunkToService(chunk);
            }
        }
    }
}