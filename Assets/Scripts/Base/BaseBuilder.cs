using Framework.Data;
using RocketsAndGamblers.Data;
using RocketsAndGamblers.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RocketsAndGamblers
{

    [CreateAssetMenu(menuName = "R&G/Base builder")]
    public class BaseBuilder : ScriptableObject
    {
        public ObjectsDatabase database;

        public async Task BuildBase (BaseDescription baseDescription)
        {
            var bundle = await AssetBundle.LoadFromFileAsync(Path.Combine(Constants.AssetBundlesPath, baseDescription.bundleName));

            using (var disposable = new DisposableBundle(bundle)) {
                var sceneName = Path.GetFileNameWithoutExtension(bundle.GetAllScenePaths()[0]);

                await Scenes.LoadBaseScene(sceneName);

                foreach (var obj in baseDescription.layout) {
                    database.Instantiate(obj.id, obj.position, obj.rotation);
                }
            }
        }
    }
}
