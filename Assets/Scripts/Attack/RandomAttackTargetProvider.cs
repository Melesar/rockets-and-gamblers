﻿using System.Threading.Tasks;
using Framework.Data;
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

        protected override async Task<string> GetTargetId()
        {
            var playerId = playerData.Id;
            var usersTable = database.GetTable<Server.Player>();

            //TODO query not the whole table, but a limited chunck of players selected randomly
            var otherPlayers = await usersTable.Where(u => u.Id != playerId).ToListAsync();
            
            var result = otherPlayers[Random.Range(0, otherPlayers.Count)];

            database.CachePlayer(result);
            
            return result.Id;
        }
    }
}