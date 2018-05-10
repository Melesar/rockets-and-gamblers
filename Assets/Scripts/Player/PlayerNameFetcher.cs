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
            var table = database.GetTable<User>();
            var usersTask = table.Where(u => u.Id == playerId)
                .Take(1)
                .ToEnumerableAsync();

            usersTask.Wait();

            var user = usersTask.Result.FirstOrDefault();

            playerName.Value = user?.Username ?? "Unknown";
        }
    }
}