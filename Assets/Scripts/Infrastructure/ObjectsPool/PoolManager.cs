using System.Collections.Generic;
using Systems.Factory.Impl;
using Data;
using Db.PrefabBase.Impl;
using UnityEngine;
using Zenject;

namespace Infrastructure.ObjectsPool
{
    public class PoolManager : MonoBehaviour
    {
        private Dictionary<PrefabsBase, PrefabData[]> poolsDictionary = new Dictionary<PrefabsBase, PrefabData[]>();

        [Inject] private GameFactory _factory;
        
        public void Initialize(PrefabData[] newPools, PrefabsBase prefabsBase)
        {
            var objectPooling = new ObjectPooling(_factory);
            poolsDictionary.Add(prefabsBase, newPools);
            var objectsParent = new GameObject ();
            DontDestroyOnLoad(objectsParent);
            objectsParent.name = "Pool";
            for (int i = 0; i < newPools.Length; i++) {
                if(newPools[i].prefab!=null)
                {
                    newPools[i].parent = objectsParent;
                    newPools[i].ferula = objectPooling;
                    newPools[i].ferula.Initialize(newPools[i].count, newPools[i].prefab, objectsParent.transform);
                }
            }
        }

        public void ClearPool(PrefabsBase prefabsBase)
        {
            var pools = poolsDictionary[prefabsBase];
            foreach (var pool in pools)
            {
                foreach (var poolObject in pool.ferula.Objects)
                {
                    GameObject.Destroy(poolObject.gameObject);
                }
                GameObject.Destroy(pool.parent);
            }

            poolsDictionary.Remove(prefabsBase);
        }

        public GameObject GetObject (string name, Vector3 position = default, Quaternion rotation = default) {
            GameObject result = null;
            if (poolsDictionary != null) {
                foreach (var pair in poolsDictionary)
                {
                    foreach (var poolPart in pair.Value)
                    {
                        if (string.Compare (poolPart.name, name) == 0) 
                        {
                            result = poolPart.ferula.GetObject ().gameObject;
                            result.transform.position = position;
                            result.transform.rotation = rotation;
                            result.SetActive (true);
                            return result;
                        }
                    }
                }
            } 
            return result;
        }

        public GameObject InstantiateSingle(GameObject prefab)
        {
            var obj = GameObject.Instantiate(prefab);
            return obj;
        }

    }
}
