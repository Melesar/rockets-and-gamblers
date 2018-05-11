using System;
using System.Linq;
using System.Threading.Tasks;
using Framework.Data;
using Framework.References;
using RocketsAndGamblers.Server;
using UnityEngine;

namespace RocketsAndGamblers.Player
{
    public class PlayerNameFetcher : MonoBehaviour
    {
        [SerializeField] private StringReference playerId;
        [SerializeField] private StringVariable playerName;

        [SerializeField] private AzureDatabase database;

        private void Start()
        {
            StartAsync().WrapErrors();
        }

        private async Task StartAsync()
        {
            var player = await database.GetPlayerAsync(playerId);
            playerName.Value = player?.Username ?? "Unknown";
        }
    }
}