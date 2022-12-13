using Systems.Factory.Impl;
using Systems.Game;
using Systems.Player;
using Helper;
using Signals;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private SceneHolder sceneHolder;
        
        public override void InstallBindings()
        {
            InstallSignals();
            
            Container.Bind<SceneHolder>().FromInstance(sceneHolder).AsSingle();

            Container
                .BindInterfacesAndSelfTo<GameFactory>()
                .AsSingle()
                .NonLazy();

            BindAndCreatePlayer();
            //Container.BindInterfacesAndSelfTo<PlayerInitializeSystem>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<GameInitializeSystem>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerMovingSystem>().AsSingle().NonLazy();
        }

        private void BindAndCreatePlayer()
        {
            
        }
        
        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<InitializePlayerSignal>();
        }
    }
}