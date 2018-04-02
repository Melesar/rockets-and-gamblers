using RocketsAndGamblers.Data;
using RocketsAndGamblers.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

namespace RocketsAndGamblers
{
    public class PlayerBaseBuilder : MonoBehaviour
    {
        public BaseDescriptionProvider baseProvider;
        public BaseBuilder baseBuilder;

        private async void Start ()
        {
            var baseDescription = await baseProvider.GetPlayerBase(Constants.PlayerId, false);

            await Scenes.LoadPlayerScene();

            await baseBuilder.BuildBase(baseDescription);
        }
    }
}

