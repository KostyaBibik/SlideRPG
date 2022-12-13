using UnityEngine;

namespace Systems.Factory
{
    public interface IEntityFactory
    {
        GameObject Create(string name, Vector3 position = default, Quaternion rotation = default,
            Transform parent = null);

        T CreateForComponent<T>(string name);
    }
}