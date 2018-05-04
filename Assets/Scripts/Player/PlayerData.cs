using System;
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

        [SerializeField, HideInInspector] private string id;

        public async Task Init()
        {
            var usersTable = database.GetTable<User>();
            var userQuery = usersTable.Where(u => u.DeviceId == SystemInfo.deviceUniqueIdentifier);
            var currentUserEntity = (await usersTable.ReadAsync(userQuery)).FirstOrDefault();
            
            if (currentUserEntity != null) {
                id = currentUserEntity.Id;
            } else {
                var playerName = await GetPlayerNameInput();
                var user = CreateNewUser(playerName);
                await usersTable.InsertAsync(user);
                id = user.Id;
            }
            
            Debug.Log($"Initialization successfull. Current player id is: {id}");
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

        private User CreateNewUser(string playerName)
        {
            return new User {
                DeviceId = SystemInfo.deviceUniqueIdentifier,
                Username = playerName
            };
        }
    }
}