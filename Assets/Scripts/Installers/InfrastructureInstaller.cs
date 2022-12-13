using System.Collections.Generic;
using Data;
using Db.PrefabBase.Impl;
using Db.PrefabService.Impl;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class InfrastructureInstaller : MonoInstaller
    {
        [SerializeField] private PrefabsBase[] _prefabsBases;
        
        public override void InstallBindings()
        {
            List<PrefabData> prefabs = new List<PrefabData>();
            foreach (var prefabsBase in _prefabsBases)
            {
                foreach (var prefab in prefabsBase.Objects)
                {
                    prefabs.Add(prefab);
                }
            }

            var prefabService = new PrefabService(prefabs.ToArray());
            Container.BindInterfacesAndSelfTo<PrefabService>().FromInstance(prefabService).AsSingle();
        }
    }
}