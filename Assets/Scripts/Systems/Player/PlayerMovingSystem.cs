using UnityEngine;
using Views;
using Zenject;

namespace Systems.Player
{
    public class PlayerMovingSystem : IInitializable
    {
        [Inject] private PlayerView _playerView;
        
        public PlayerMovingSystem()
        {
            
        }


        public void Initialize()
        {
            Debug.Log("_playerView: " + _playerView.name);
        }
    }
}