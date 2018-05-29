using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Framework.References;
using Framework.UI;
using RocketsAndGamblers.Data;
using RocketsAndGamblers.Database;
using RocketsAndGamblers.Server;
using UnityEngine;

namespace RocketsAndGamblers.Replay
{
    public class ReplayManager : MonoBehaviour
    {
        public StringReference connection;
        public StringReference containerName;
        public ObjectsDatabase objectsDatabase;
        public StringReference replayFileName;
        public GameObject shipPrefab;
        public ObjectId spawnpointId;

        public GameState replayState;
        public WindowDescriptor replayConfirmationWindow;
        
        private AzureBlobContainer replaysContainer;
        private GameObject playerInstance;
        
        public void OnReplayStateChanged(bool active)
        {
            if (active) {
                OnReplayCliked().WrapErrors();
            } else {
                Destroy(playerInstance);
            }
        }

        public void OnAttackSuccessfull()
        {
            if (replayState.IsCurrent) {
                replayConfirmationWindow.Invoke();
            }
        }
        
        private async Task OnReplayCliked()
        {
            var downloadReplay = await GetReplay(replayFileName);

            var spawnPoint = objectsDatabase.GetById(spawnpointId.id)?.GetComponent<SpawnPoint>();
            
            playerInstance = spawnPoint.Spawn(shipPrefab);
            
            var replayMovement = playerInstance.AddComponent<ReplayMovement>();
            await replayMovement.Lauch(downloadReplay);
        }

        private async Task<Replay> GetReplay(string fileName)
        {
            using (var stream = new MemoryStream()) {
                try {
                    await replaysContainer.DownloadFile(fileName, stream);
                } catch (AzureException) { }

                var json = Encoding.UTF8.GetString(stream.GetBuffer());
                var replay = JsonUtility.FromJson<Replay>(json);

                return replay;
            }
        }
        
        private void Awake()
        {
            replaysContainer = new AzureBlobContainer(connection, containerName);
        }
    }
}