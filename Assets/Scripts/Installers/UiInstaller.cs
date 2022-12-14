﻿using UnityEngine;
using Views.Ui.Impl;
using Zenject;

namespace Installers
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private AttackContainerView attackContainer;
        [SerializeField] private HealthContainerView healthContainer;
        [SerializeField] private AttackSpeedContainerView attackSpeedContainer;

        public override void InstallBindings()
        {
            Container.Bind<AttackContainerView>().FromInstance(attackContainer).AsSingle();
            Container.Bind<HealthContainerView>().FromInstance(healthContainer).AsSingle();
            Container.Bind<AttackSpeedContainerView>().FromInstance(attackSpeedContainer).AsSingle();
        }
    }
}