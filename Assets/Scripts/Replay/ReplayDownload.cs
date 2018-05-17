using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Text;
using RocketsAndGamblers.Server;
using Framework.References;
using RocketsAndGamblers.Player;
using System.Threading.Tasks;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class ReplayDownload : MonoBehaviour
    {
        public PlayerData currentPlayer;
        public AzureDatabase database;
        public AttackHistory history;

        private async void Start()
        {

            await GetAttackHistory();
        }


        private async Task GetAttackHistory()
        {
            var table = database.GetTable<AttackRecord>();
            var entities = await table.Where(r => r.VictimId == currentPlayer.Id).ToEnumerableAsync();
            foreach (var entity in entities)
            {
                history.Add(entity);
            }
        }

        //public async Task<Replay> GetReplay(string fileName)
        //{
        //    //fileName = string.Format("replay_{0}_{1}", attackedPlayerId, attackingPlayer);

        //    using (var stream = new MemoryStream())
        //    {
        //        try
        //        {
        //            await replaysContainer.DownloadFile(fileName, stream);
        //        }
        //        catch (AzureException)
        //        {
        //            //Provided player id doesn't exist, so we need to download a new base from layout

        //        }
        //        var json = Encoding.UTF8.GetString(stream.GetBuffer());
        //        var replay = JsonUtility.FromJson<Replay>(json);


        //        return replay;
        //    }
        //}
    }
}
