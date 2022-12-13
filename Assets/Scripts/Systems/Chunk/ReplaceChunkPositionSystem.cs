using System.Collections;
using Helper;
using Services;
using UniRx;
using UnityEngine;
using Zenject;

namespace Systems.Chunk
{
    public class ReplaceChunkPositionSystem : IInitializable
    {
        private readonly ChunkService _chunkService;
        private readonly SceneHolder _sceneHolder;

        public ReplaceChunkPositionSystem(
            ChunkService chunkService,
            SceneHolder sceneHolder
        )
        {
            _chunkService = chunkService;
            _sceneHolder = sceneHolder;
        }


        public void Initialize()
        {
            Observable.FromCoroutine(ReplaceOnDelay)
                .Subscribe();
        }

        private IEnumerator ReplaceOnDelay()
        {
            do
            {
                yield return new WaitForSeconds(5f);

                for (var i = 0; i < _chunkService.Chunks.Length; i++)
                {
                    _chunkService.Chunks[i].transform.position = _sceneHolder.SpawnPosesFloor[i];
                }

            } while (true);
        }
    }
}