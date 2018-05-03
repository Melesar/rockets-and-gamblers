using System.IO;
using UnityEngine;

namespace Framework.Data
{
    /// <summary>
    /// A scriptable object that keeps its state after scene loading
    /// </summary>
    public abstract class PersistantScriptableObject : ScriptableObject
    {
        private static string persistantFilePath;

        private void RestoreState()
        {
            if (!Application.isPlaying) {
                return;
            } 

            if (string.IsNullOrEmpty(persistantFilePath)) {
                return;
            }

            var json = File.ReadAllText(persistantFilePath);
            JsonUtility.FromJsonOverwrite(json, this);

            File.Delete(persistantFilePath);
        }

        private void SaveState()
        {
            if (!Application.isPlaying) {
                return;
            }

            if (string.IsNullOrEmpty(persistantFilePath)) {
                CreateFilePath();
            }

            var json = JsonUtility.ToJson(this);
            File.WriteAllText(persistantFilePath, json);
        }

        private void CreateFilePath()
        {
            var folder = Path.Combine(Application.persistentDataPath, "Persistance");
            if (!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }

            var fileName = $"{GetType().Name}.state";

            persistantFilePath = Path.Combine(folder, fileName);
        }

        protected virtual void OnEnable ()
        {
            RestoreState();
        }

        protected virtual void OnDisable()
        {
            SaveState();
        }
    }
}