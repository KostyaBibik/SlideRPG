using System.Collections.Generic;
using Systems.Factory.Impl;
using UnityEngine;

namespace Infrastructure.ObjectsPool
{
    public class ObjectPooling
    {
        private readonly GameFactory _gameFactory;

        #region Data
        public List<PoolObject> Objects;
        Transform objectsParent;
        #endregion

        public ObjectPooling(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        
        #region Interface
        public void Initialize (int count, GameObject sample, Transform objects_parent) {
            if(Objects == null)
                Objects = new List<PoolObject> ();
            objectsParent = objects_parent;
            for (int i=0; i<count; i++) {
                AddObject(sample, objects_parent);
            }
        }


        public PoolObject GetObject () {
            for (int i=0; i<Objects.Count; i++) {
                if (Objects[i].gameObject.activeInHierarchy==false) {
                    return Objects[i];
                }
            }
            AddObject(Objects[0].gameObject, objectsParent);
            return Objects[Objects.Count-1];
        }
        #endregion

        #region Methods
        void AddObject(GameObject gameObj, Transform objects_parent) {
            GameObject temp;
            var sample = gameObj.AddComponent<PoolObject>();
            temp = _gameFactory.Create(sample.gameObject.name);
            temp.name = sample.name;
            temp.transform.SetParent (objects_parent);
            Objects.Add(temp.GetComponent<PoolObject> ());
            if (temp.GetComponent<Animator> ())
                temp.GetComponent<Animator> ().StartPlayback ();
            temp.SetActive(false);
        }
        #endregion
    }
}
