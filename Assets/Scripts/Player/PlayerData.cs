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
                var user = CreateNewUser();
                await usersTable.InsertAsync(user);
                id = user.Id;
            }
            
            Debug.Log($"Initialization successfull. Current player id is: {id}");
        }

        private User CreateNewUser()
        {
            return new User {
                DeviceId = SystemInfo.deviceUniqueIdentifier,
                Username = "Joe Johnson"
            };
        }
    }
}