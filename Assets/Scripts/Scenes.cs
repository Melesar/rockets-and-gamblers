using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace RocketsAndGamblers
{
    public static class Scenes
    {
        private const int PlayerSceneIndex = 1;
        private const int AttackSceneIndex = 2;
        private const int SaveBaseSceneIndex = 3;

        public static async Task LoadPlayerBaseScene (string sceneName)
        {
            await UnloadScenes();

            await LoadPlayerScene();

            await LoadBaseScene(sceneName);
        }

        public static async Task LoadAttackBaseScene (string sceneName)
        {
            await UnloadScenes();

            await LoadAttackScene();

            await LoadBaseScene(sceneName);
        }

        public static async Task LoadBaseScene (string sceneName)
        {
            await LoadScene(sceneName);
        }

        public static async Task LoadPlayerScene ()
        {
            await LoadScene(PlayerSceneIndex);
        }

        public static async Task LoadAttackScene ()
        {
            await LoadScene(AttackSceneIndex);
        }

        public static async Task LoadSaveBaseScene()
        {
            await LoadScene(SaveBaseSceneIndex);
        }

        public static async Task UnloadScenes ()
        {
            while (SceneManager.sceneCount > 0) {
                var scene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
                await SceneManager.UnloadSceneAsync(scene);
            }
        }

        private static async Task LoadScene (int index)
        {
            var scenesCount = SceneManager.sceneCount;
            await SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);

            var loadedScene = SceneManager.GetSceneAt(scenesCount);
            SceneManager.SetActiveScene(loadedScene);
        }

        private static async Task LoadScene (string sceneName)
        {
            var scenesCount = SceneManager.sceneCount;
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            var loadedScene = SceneManager.GetSceneAt(scenesCount);
            SceneManager.SetActiveScene(loadedScene);
        }

        
    }
}
