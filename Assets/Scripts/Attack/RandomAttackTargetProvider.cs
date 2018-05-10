using System.Threading.Tasks;
using Framework.References;
using RocketsAndGamblers.Player;
using RocketsAndGamblers.Server;
using UnityEngine;

namespace RocketsAndGamblers
{
    [CreateAssetMenu(menuName = "R&G/Attack taget provider/Random from database")]
    public class RandomAttackTargetProvider : AttackTargetProvider
    {
        [SerializeField] private AzureDatabase database;
        [SerializeField] private PlayerData playerData;

        public override async Task<string> GetAttackTargetId()
        {
            var playerId = playerData.Id;
            var usersTable = database.GetTable<User>();

            //TODO query not the whole table, but a limited chunck of players selected randomly
            var otherPlayers = await usersTable.Where(u => u.Id != playerId).ToListAsync();
            
            var result = otherPlayers[Random.Range(0, otherPlayers.Count)].Id;
            lastTargetId.Value = result;
            
            return result;
        }
    }
}