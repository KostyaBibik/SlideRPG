using System;
using Data;

namespace Db.PrefabService.Impl
{
    public class PrefabService : IPrefabService
    {
        private readonly PrefabData[] _prefabs;

        public PrefabService(PrefabData[] prefabs)
        {
            _prefabs = prefabs;
        }

        public PrefabData GetPrefabData(string name)
        {
            foreach (var prefab in _prefabs)
            {
                if (prefab.name == name)
                    return prefab;
            }
            
            throw new Exception("Prefab not found!");
        }
    }
}