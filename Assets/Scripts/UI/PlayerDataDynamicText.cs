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
            //TODO local storage stub
            var dynamicText = GetComponent<DynamicText>();
            dynamicText.Text = playerData.PlayerName;
//            var player = await database.GetPlayerAsync(playerData.Id);
//
//            dynamicText.Text = player.Username;
        }
    }
}