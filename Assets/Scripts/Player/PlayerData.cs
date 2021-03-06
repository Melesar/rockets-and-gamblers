﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Framework.Data;
using RocketsAndGamblers.Server;
using UnityEngine;

namespace RocketsAndGamblers.Player
{
    [CreateAssetMenu(menuName = "R&G/Player data")]
    public class PlayerData : PersistantScriptableObject
    {
        [SerializeField] private AzureDatabase database;
        
        public string Id => id;

        public string PlayerName =>
            PlayerPrefs.HasKey(PlayerNameKey) ? PlayerPrefs.GetString(PlayerNameKey) : "Unknown";
        
        [SerializeField] private string id;

        private const string PlayerNameKey = "PlayerName"; 

        public async Task Init()
        {
            //TODO local storage stub
            //await AzureInit();

            if (PlayerPrefs.HasKey(PlayerNameKey)) {
                return;
            }

            var playerName = await GetPlayerNameInput();
            PlayerPrefs.SetString(PlayerNameKey, playerName);
            PlayerPrefs.Save();
        }

        private async Task AzureInit()
        {
            var playersTable = database.GetTable<Server.Player>();
            var playerQuery = playersTable.Where(u => u.DeviceId == SystemInfo.deviceUniqueIdentifier);
            var currentPlayerEntity = (await playersTable.ReadAsync(playerQuery)).FirstOrDefault();

            if (currentPlayerEntity != null) {
                id = currentPlayerEntity.Id;
            } else {
                var playerName = await GetPlayerNameInput();
                currentPlayerEntity = CreateNewUser(playerName);
                await playersTable.InsertAsync(currentPlayerEntity);
                id = currentPlayerEntity.Id;
            }

            database.CachePlayer(currentPlayerEntity);
        }

        private async Task<string> GetPlayerNameInput()
        {
            if (!TouchScreenKeyboard.isSupported) {
                return "John from Unity";
            }
            
            var keyboard = TouchScreenKeyboard.Open(string.Empty, TouchScreenKeyboardType.Default,
                false, false, false, true, "Enter your player's name");

            await new WaitUntil(() => keyboard.status != TouchScreenKeyboard.Status.Visible);

            switch (keyboard.status) {
                case TouchScreenKeyboard.Status.Canceled:
                case TouchScreenKeyboard.Status.LostFocus:
                    return await GetPlayerNameInput();
                default:
                    return keyboard.text;
            }
        }

        private Server.Player CreateNewUser(string playerName)
        {
            return new Server.Player {
                DeviceId = SystemInfo.deviceUniqueIdentifier,
                Username = playerName
            };
        }
    }
}