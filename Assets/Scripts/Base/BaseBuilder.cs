using Framework.Data;
using RocketsAndGamblers.Data;
using RocketsAndGamblers.Database;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace RocketsAndGamblers
{
    [CreateAssetMenu(menuName = "R&G/Base builder")]
    public class BaseBuilder : ScriptableObject
    {
        [SerializeField] private ObjectId spawnPointId;
        [SerializeField] private GameObject playerPrefab;

        [SerializeField] private ObjectsDatabase database;
        [SerializeField] private BaseDescriptionEvent onBaseBuilt;

        public async Task BuildBase (BaseDescription baseDescription)
        {
            var bundle = await AssetBundle.LoadFromFileAsync(Path.Combine(Constants.AssetBundlesPath, baseDescription.bundleName));

            using (var disposable = new DisposableBundle(bundle)) {
                var sceneName = Path.GetFileNameWithoutExtension(disposable.GetAllScenePaths()[0]);

                await Scenes.LoadBaseScene(sceneName);

                SetupBaseLayout(baseDescription);
                SetupUpgrades(baseDescription);

                if (baseDescription.isAttacking) {
                    SpawnPlayerSpaceship();
                }

                onBaseBuilt.Raise(baseDescription);
            }
        }

        private void SetupBaseLayout (BaseDescription baseDescription)
        {
            foreach (var obj in baseDescription.layout) {
                database.Instantiate(obj.id, obj.position, obj.rotation);
            }
        }

        private void SetupUpgrades (BaseDescription baseDescription)
        {

        }

        private void SpawnPlayerSpaceship ()
        {
            var spawnPoint = database.GetById(spawnPointId.id)?.GetComponent<SpawnPoint>();
            if (spawnPoint) {
                spawnPoint.Spawn(playerPrefab);
            }
        }
    }
}
