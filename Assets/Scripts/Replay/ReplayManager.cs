using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Framework.References;
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
        
        private AzureBlobContainer replaysContainer;


        private void Awake()
        {
            replaysContainer = new AzureBlobContainer(connection, containerName);
        }

        public async Task OnReplayCliked()
        {
            var downloadReplay = await GetReplay(replayFileName);

            var spawnPoint = objectsDatabase.GetById(spawnpointId.id)?.GetComponent<SpawnPoint>();
            var player = spawnPoint.Spawn(shipPrefab);
            var replay = player.AddComponent<ReplayMovement>();
            await replay.SetShipOnPoint(downloadReplay);
        }

        public void LaunchReplay(bool active)
        {
            if (active) {
                OnReplayCliked().WrapErrors();
            }
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
    }
}