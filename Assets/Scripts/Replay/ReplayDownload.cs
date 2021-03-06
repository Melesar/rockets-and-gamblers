﻿using System.Threading.Tasks;
using RocketsAndGamblers.Player;
using RocketsAndGamblers.Server;
using UnityEngine;

namespace RocketsAndGamblers.Replay
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
            history.Clear();
            
            var attackRecordsTable = database.GetTable<AttackRecord>();
            var playersTable = database.GetTable<Server.Player>();

            var entities = await attackRecordsTable
                .Where(r => r.VictimId == currentPlayer.Id)
                .Take(5)
                .ToEnumerableAsync();

            foreach (var entity in entities) {
                var attackerNames = await playersTable
                    .Where(p => p.Id == entity.AttackerId)
                    .Select(p => p.Username)
                    .ToListAsync();

                if (attackerNames.Count == 0) {
                    continue;
                }

                entity.AttackerName = attackerNames[0];
                history.Add(entity);
            }
        }
    }
}