using RocketsAndGamblers.Data;
using RocketsAndGamblers.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

namespace RocketsAndGamblers
{
    public class BaseBuilder : MonoBehaviour
    {
        public BaseDescriptionProvider baseProvider;
        public ObjectsDatabase database;

        private async void Start ()
        {
            var baseDescription = await baseProvider.GetPlayerBase(Constants.PlayerId);

            var bundle = await AssetBundle.LoadFromFileAsync(Path.Combine(Constants.AssetBundlesPath, baseDescription.bundleName));
            var sceneName = Path.GetFileNameWithoutExtension(bundle.GetAllScenePaths()[0]);
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            foreach (var obj in baseDescription.layout) {
                database.Instantiate(obj.id, obj.position, obj.rotation);
            }
        }
    }
}

