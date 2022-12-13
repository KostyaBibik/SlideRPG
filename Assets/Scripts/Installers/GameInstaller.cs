using Systems.Chunk;
using Systems.Enemy;
using Systems.Factory.Impl;
using Systems.Game;
using Systems.Player;
using Helper;
using Services;
using Signals;
using UnityEngine;
using Views;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private SceneHolder sceneHolder;
        [SerializeField] private PlayerView playerView;
        
        public override void InstallBindings()
        {
            InstallSignals();
            
            Container.Bind<SceneHolder>().FromInstance(sceneHolder).AsSingle();

            BindFactory();
            BindAndCreatePlayer();
            BindEnemy();
            BindServices();
            BindChunks();
            
            Container.BindInterfacesAndSelfTo<GameInitializeSystem>().AsSingle().NonLazy();
        }

        private void BindFactory()
        {
            Container
                .BindInterfacesAndSelfTo<GameFactory>()
                .AsSingle()
                .NonLazy();
        }

        private void BindChunks()
        {
            Container
                .BindInterfacesAndSelfTo<ChunkSpawnSystem>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<ChunkMovingSystem>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<ReplaceChunkPositionSystem>()
                .AsSingle()
                .NonLazy();
        }

        private void BindServices()
        {
            Container
                .BindInterfacesAndSelfTo<ChunkService>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<EnemyService>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<PlayerParametersService>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<EnemyRaiseParametersService>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<SoftService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindAndCreatePlayer()
        {
            var player = Container.InstantiatePrefabForComponent<PlayerView>(playerView);

            Container
                .BindInterfacesAndSelfTo<PlayerView>()
                .FromInstance(player)
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<DetectEnemySystem>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<PlayerAttackSystem>()
                .AsSingle()
                .NonLazy();
        }

        private void BindEnemy()
        {
            Container
                .BindInterfacesAndSelfTo<EnemySpawnSystem>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<EnemyMovingSystem>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<KillEnemySystem>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<EnemyParametersService>()
                .AsSingle()
                .NonLazy();
        }
        
        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<InitializePlayerSignal>();
            Container.DeclareSignal<StartMoveSignal>();
            Container.DeclareSignal<DetectEnemySignal>();
            Container.DeclareSignal<SpawnEnemySignal>();
            Container.DeclareSignal<ChunkSpawnSignal>();
            Container.DeclareSignal<KillEnemySignal>();
            Container.DeclareSignal<LoseSignal>();
        }
    }
}