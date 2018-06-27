using System.Threading.Tasks;
using Framework.Data;
using Framework.References;
using RocketsAndGamblers.Server;
using UnityEngine;

namespace RocketsAndGamblers.Player
{
    public class PlayerNameFetcher : MonoBehaviour
    {
        //TODO local storage stub
        [SerializeField] private string[] playerNames;
        
        [SerializeField] private StringReference playerId;
        [SerializeField] private StringVariable playerName;

        [SerializeField] private AzureDatabase database;

        private void Start()
        {
            StartAsync().WrapErrors();
        }

        private async Task StartAsync()
        {
            //TODO local storage stub
            playerName.Value = playerNames[Random.Range(0, playerNames.Length)];
//            var player = await database.GetPlayerAsync(playerId);
//            playerName.Value = player?.Username ?? "Unknown";
        }
    }
}