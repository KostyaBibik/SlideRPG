using Data;

namespace Db.PrefabService
{
    public interface IPrefabService
    {
        PrefabData GetPrefabData(string name);
    }
}