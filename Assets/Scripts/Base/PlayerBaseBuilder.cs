using Framework.Events;
using RocketsAndGamblers.Data;
using RocketsAndGamblers.Player;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class PlayerBaseBuilder : MonoBehaviour
    {
        public PlayerData playerData;
        public BaseDescriptionProvider baseProvider;
        public BaseBuilder baseBuilder;

        private async void Start ()
        {
            await playerData.Init();

            var baseDescription = await baseProvider.GetPlayerBase(playerData.Id, false);

            await Scenes.LoadPlayerScene();

            await baseBuilder.BuildBase(baseDescription);
        }
    }
}

