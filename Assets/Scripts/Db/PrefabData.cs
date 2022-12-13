using System;
using Infrastructure.ObjectsPool;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PrefabData
    {
        public string name;
        public GameObject prefab;
        internal int count;
        internal ObjectPooling ferula;
        internal GameObject parent;
    }
}