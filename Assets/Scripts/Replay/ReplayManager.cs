using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using RocketsAndGamblers.Server;
using System.Text;

public class ReplayManager : MonoBehaviour
{
    private AzureBlobContainer replaysContainer;
    private ReplayMovment newReplay;
    public string replayFile;
    // Use this for initialization
    public string connection;
    public string containerName;
    
    async void Awake()
    {
        newReplay = new ReplayMovment();
        replaysContainer = new AzureBlobContainer(connection, containerName);
        newReplay.SetShipOnPoint(await GetReplay(replayFile));
    }



    public async Task<Replay> GetReplay(string fileName)
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
