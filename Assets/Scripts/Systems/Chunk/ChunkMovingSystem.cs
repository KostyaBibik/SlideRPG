using System;
using Services;
using Signals;
using UnityEngine;
using Zenject;

namespace Systems.Chunk
{
    public class ChunkMovingSystem : IInitializable, IDisposable, ITickable
    {
        private readonly SignalBus _signalBus;
        private readonly ChunkService _chunkService;

        private bool _isMoving;
        
        public ChunkMovingSystem(
            SignalBus signalBus,
            ChunkService chunkService
        )
        {
            _signalBus = signalBus;
            _chunkService = chunkService;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<DetectEnemySignal>(StopMoving);
            _signalBus.Subscribe<StartMoveSignal>(StartMoving);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<DetectEnemySignal>(StopMoving);
            _signalBus.Unsubscribe<StartMoveSignal>(StartMoving);
        }

        private void StopMoving(DetectEnemySignal detectEnemySignal)
        {
            _isMoving = false;
        }

        private void StartMoving(StartMoveSignal startMoveSignal)
        {
            _isMoving = true;
        }
        
        public void Tick()
        {
            if(!_isMoving)
                return;

            var chunks = _chunkService.Chunks;
            foreach (var chunk in chunks)
            {
                var chunkTransform = chunk.transform;
                chunkTransform.position += -chunkTransform.forward * Time.deltaTime;
            }
        }
    }
}