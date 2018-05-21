using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Framework.References;
using Microsoft.WindowsAzure.MobileServices;
using UnityEngine;
using Newtonsoft.Json;

namespace RocketsAndGamblers.Server
{
    [CreateAssetMenu(menuName = "R&G/Azure database")]
    public class AzureDatabase : ScriptableObject
    {
        public StringReference databaseUrl;

        private MobileServiceClient Client { get; set; }

        private Dictionary<string, Player> cachedPlayers;

        private Dictionary<string, AttackRecord> cachedReplays;

        public IMobileServiceTable<T> GetTable<T>()
        {
            return Client.GetTable<T>();
        }

        public void CachePlayer(Player player)
        {
            if (player == null)
            {
                return;
            }

            if (!cachedPlayers.ContainsKey(player.Id))
            {
                cachedPlayers.Add(player.Id, player);
            }
        }

        //-----------------------------Inserting into AttackHistory table----------

        public void CacheReplay(AttackRecord record)
        {
            if (record == null)
            {
                return;
            }

            if (!cachedReplays.ContainsKey(record.Id))
            {
                cachedReplays.Add(record.Id, record);
            }
        }


        public async Task<Player> GetPlayerAsync(string id)
        {
            Player player;
            if (cachedPlayers.TryGetValue(id, out player))
            {
                return player;
            }

            player = await GetPlayerFromDatabaseAsync(id);

            if (player != null)
            {
                cachedPlayers.Add(id, player);
            }

            return player;
        }

        private async Task<Player> GetPlayerFromDatabaseAsync(string id)
        {
            var table = GetTable<Player>();
            var players = await table
                .Where(p => p.Id == id)
                .Take(1)
                .ToListAsync();

            return players.Count > 0 ? players[0] : null;
        }

        private void OnEnable()
        {
            cachedPlayers = new Dictionary<string, Player>();

#if UNITY_ANDROID
            // Android builds fail at runtime due to missing GZip support, so build a handler that uses Deflate for Android
            var handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate };
            Client = new MobileServiceClient(databaseUrl, handler);
#else
		    Client = new MobileServiceClient(databaseUrl);
#endif
        }
    }


}