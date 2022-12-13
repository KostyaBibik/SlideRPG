using System;
using Data;
using Data.PrefabBase;
using UnityEngine;

namespace Db.PrefabBase.Impl
{
    [CreateAssetMenu(menuName = "PrefabBase", fileName = nameof(PrefabsBase))]
    [Serializable]
    public class PrefabsBase : ScriptableObject, IPrefabBase
    {
        public PrefabData[] Objects;

        void OnValidate()
        {
            for (var i = 0; i < Objects.Length; i++)
            {
                Objects[i].name = Objects[i].prefab.name;
            }
        }
    }
}