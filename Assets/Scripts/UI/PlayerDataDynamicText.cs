using System.Threading.Tasks;
using Framework.UI;
using RocketsAndGamblers.Player;
using RocketsAndGamblers.Server;
using UnityEngine;

namespace RocketsAndGamblers.UI
{
    [RequireComponent(typeof(DynamicText))]
    public class PlayerDataDynamicText : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private AzureDatabase database;
        
        private async Task Start()
        {
            var dynamicText = GetComponent<DynamicText>();
            var player = await database.GetPlayerAsync(playerData.Id);

            dynamicText.Text = player.Username;
        }
    }
}