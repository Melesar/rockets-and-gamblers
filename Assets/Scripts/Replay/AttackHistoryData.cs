using System.Threading.Tasks;
using Framework.Data;
using RocketsAndGamblers.Server;
using UnityEngine;

namespace RocketsAndGamblers.Replay
{
    [CreateAssetMenu(menuName = "R&G/AttackHistory data")]
    public class AttackHistoryData : ScriptableObject
    {
        [SerializeField] private AzureDatabase database;

        [SerializeField, HideInInspector] private string id;

        public async Task InsertTable(string attackerId, string victimId, string replayname)
        {
            var currentAttackHistoryEntity = CreateAttackRecord(attackerId, victimId, replayname);
            var tableInsert = database.GetTable<AttackRecord>();
            await tableInsert.InsertAsync(currentAttackHistoryEntity);

        }


        private AttackRecord CreateAttackRecord(string attackerId, string victimId, string replayname)
        {
            return new AttackRecord
            {
                AttackerId = attackerId,
                VictimId = victimId,
                ReplayFileName = replayname

            };
        }
    }
}
