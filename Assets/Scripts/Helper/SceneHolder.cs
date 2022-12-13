using System.Linq;
using UnityEngine;

namespace Helper
{
    public class SceneHolder : MonoBehaviour
    {
        [SerializeField] private Transform spawnPosPlayer;
        [SerializeField] private Transform spawnPosEnemy;
        [SerializeField] private Transform[] spawnPosesFloor;

        public Vector3 SpawnPosPlayer => spawnPosPlayer.position;
        public Vector3 SpawnPosEnemy => spawnPosEnemy.position;
        public Vector3[] SpawnPosesFloor => spawnPosesFloor.Select(spawnPos => spawnPos.position).ToArray();
    }
}