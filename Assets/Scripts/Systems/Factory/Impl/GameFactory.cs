using Db.PrefabService;
using UnityEngine;
using Zenject;

namespace Systems.Factory.Impl
{
    public class GameFactory : IEntityFactory
    {
        private readonly DiContainer _container;
        private readonly IPrefabService _prefabService;

        public GameFactory(
            DiContainer container,
            IPrefabService prefabService
        )
        {
            _container = container;
            _prefabService = prefabService;
        }
        
        public GameObject Create(
            string name,
            Vector3 position = default,
            Quaternion rotation = default,
            Transform parent = null
        )
        {
            var prefab = _prefabService.GetPrefabData(name);
            var gameObj = _container.InstantiatePrefab(prefab.prefab);
            gameObj.transform.position = position;
            gameObj.transform.rotation = rotation;
            if(parent != null)
                gameObj.transform.SetParent(parent);
            
            return gameObj;
        }

        public T CreateForComponent<T>(string name)
        {
            var prefab = _prefabService.GetPrefabData(name);
            var component = _container.InstantiatePrefabForComponent<T>(prefab.prefab);
            _container.Bind<T>().FromInstance(component).NonLazy();

            return component;
        }
    }
}