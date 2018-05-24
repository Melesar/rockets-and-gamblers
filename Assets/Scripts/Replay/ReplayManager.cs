using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using RocketsAndGamblers.Server;
using System.Text;
using Framework.References;
using RocketsAndGamblers.Database;
using RocketsAndGamblers;

public class ReplayManager : MonoBehaviour
{
    private AzureBlobContainer replaysContainer;

    public StringReference connection;
    public StringReference containerName;
    public StringReference replayFileName;
    public ObjectsDatabase objectsDatabase;
    public ObjectId spawnpointid;
    public GameObject shipPrefab;
    void Awake()
    {
        replaysContainer = new AzureBlobContainer(connection, containerName);
    }

    public async Task OnReplayCliked()
    {
        //Download replay file
        var downloadReplay = await GetReplay(replayFileName);
        //Setup scene to watch replay

        //Spawn player
        var spawnPoint = objectsDatabase.GetById(spawnpointid.id)?.GetComponent<SpawnPoint>();
        var player = spawnPoint.Spawn(shipPrefab);
        var replay= player.AddComponent<ReplayMovement>();
       await replay.SetShipOnPoint(downloadReplay);
        //Add ReplayMovement component to player
    }

    public void TurnOnUI(bool active)
    {
        if (active)
            OnReplayCliked().WrapErrors();

    }

    private async Task<Replay> GetReplay(string fileName)
    {
        //fileName = string.Format("replay_{0}_{1}", attackedPlayerId, attackingPlayer);

        using (var stream = new MemoryStream())
        {
            try
            {
                await replaysContainer.DownloadFile(fileName, stream);
            }
            catch (AzureException)
            {
                //Provided player id doesn't exist, so we need to download a new base from layout

            }
            var json = Encoding.UTF8.GetString(stream.GetBuffer());
            var replay = JsonUtility.FromJson<Replay>(json);

            return replay;
        }
    }


}
