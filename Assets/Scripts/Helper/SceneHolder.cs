using UnityEngine;

namespace Helper
{
    public class SceneHolder : MonoBehaviour
    {
        [SerializeField] private Transform spawnPosPlayer;
        [SerializeField] private Transform spawnPosFloor;

        public Vector3 SpawnPosPlayer => spawnPosPlayer.position;
        public Vector3 SpawnPosFloor => spawnPosFloor.position;
    }
}