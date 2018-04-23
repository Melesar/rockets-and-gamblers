using RocketsAndGamblers.Database;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class SavingBaseManager : MonoBehaviour
    {
        public ObjectId spawnPointId;
        public ObjectsDatabase database;

        [Space]

        public GameObject playerPrefab;

        private GameObject playerInstance;

        public void OnStateChanged(bool newState)
        {
            if (newState) {
                SpawnPlayer();
            } else {
                RemovePlayer();
            }
        }

        private void SpawnPlayer()
        {
            var spawnPoint = database.GetById(spawnPointId.id)?.GetComponent<SpawnPoint>();
            if (spawnPoint) {
                playerInstance = spawnPoint.Spawn(playerPrefab);
            }
        }

        private void RemovePlayer()
        {
            Destroy(playerInstance);
        }
    }
}