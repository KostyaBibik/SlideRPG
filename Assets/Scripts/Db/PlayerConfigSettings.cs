using UnityEngine;
using Views;

namespace Db
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(PlayerConfigSettings),
        fileName = nameof(PlayerConfigSettings))]
    public class PlayerConfigSettings : ScriptableObject
    {
        [SerializeField] private PlayerView playerView;

        public PlayerView PlayerView => playerView;
    }
}