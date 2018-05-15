using Framework.Events;
using RocketsAndGamblers.Data;
using RocketsAndGamblers.Player;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class Bootstrap : MonoBehaviour
    {
        public PlayerData playerData;
        public BaseDescriptionProvider baseProvider;
        public BaseBuilder baseBuilder;

        private async void Start ()
        {
            await playerData.Init();

            var baseDescription = await baseProvider.GetPlayerBase(playerData.Id, false);

            //If the user is new, we need to copy his layout as a new base
            if (!baseDescription.isPersistant) {
                await baseProvider.UpdatePlayerBase(playerData.Id, baseDescription);
            }
            
            Tutorials.TutorialUtility.SetTutorialRunning(true);

            await Scenes.LoadPlayerScene();

            await baseBuilder.BuildBase(baseDescription);
        }
    }
}

