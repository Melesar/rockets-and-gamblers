using System.Threading.Tasks;
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

        public bool enableTutorial;

        private async void Start ()
        {
            await playerData.Init();

            var baseDescription = await baseProvider.GetPlayerBase(playerData.Id, false);

            if (!baseDescription.isPersistant) {
                await InitNewPlayer(baseDescription);
            }

            if (enableTutorial) {
                Tutorials.TutorialUtility.SetTutorialRunning(true);
            }

            await Scenes.LoadPlayerScene();

            await baseBuilder.BuildBase(baseDescription);
        }

        private async Task InitNewPlayer(BaseDescription baseDescription)
        {
            Tutorials.TutorialUtility.SetTutorialRunning(true);
            await baseProvider.UpdatePlayerBase(playerData.Id, baseDescription);
        }
    }
}

