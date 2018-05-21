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

        public string Id => id;

        [SerializeField, HideInInspector] private string id;

        public async Task InsertTable(string attackerId, string victimId, string replayname)
        {
            var attackhistoryTable = database.GetTable<Server.AttackRecord>();
            var attackhistoryQuery = attackhistoryTable.Where(u => u.VictimId == SystemInfo.deviceUniqueIdentifier);
            var currentAttackHistoryEntity = (await attackhistoryTable.ReadAsync(attackhistoryQuery)).FirstOrDefault();

            if (currentAttackHistoryEntity != null)
            {
                id = currentAttackHistoryEntity.Id;
            }
            else
            {

                currentAttackHistoryEntity = CreateAttackRecord(attackerId,victimId,replayname);
                await attackhistoryTable.InsertAsync(currentAttackHistoryEntity);
                id = currentAttackHistoryEntity.Id;
            }

            database.CacheReplay(currentAttackHistoryEntity);
        }


        private Server.AttackRecord CreateAttackRecord(string attackerId, string victimId, string replayname)
        {
            return new Server.AttackRecord
            {
                AttackerId = attackerId,
                VictimId = victimId,
                ReplayFileName=replayname
                
            };
        }
    }
}
