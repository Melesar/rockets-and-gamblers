using System;
using System.Linq;
using System.Threading.Tasks;
using Framework.Data;
using RocketsAndGamblers.Server;
using UnityEngine;
namespace RocketsAndGamblers.Player
{
    [CreateAssetMenu(menuName = "R&G/AttackHistory data")]
    public class AttackHistoryData : PersistantScriptableObject
    {
        [SerializeField] private AzureDatabase database;
        public PlayerData playerData;
        public string Id => id;

        [SerializeField, HideInInspector] private string id;

        public async Task InsertTable(string attackerId, string victimId, string replayname)
        {
            var currentAttackHistoryEntity = CreateAttackRecord(attackerId, victimId, replayname);
            var tableInsert = database.GetTable<AttackRecord>();
            await tableInsert.InsertAsync(currentAttackHistoryEntity);

        }


        private Server.AttackRecord CreateAttackRecord(string attackerId, string victimId, string replayname)
        {
            return new Server.AttackRecord
            {
                AttackerId = attackerId,
                VictimId = victimId,
                ReplayFileName = replayname

            };
        }
    }
}
