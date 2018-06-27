using UnityEngine;

using System;
using System.IO;
using System.Threading.Tasks;

namespace RocketsAndGamblers.Data
{
    [CreateAssetMenu(menuName = "R&G/Base provider/File")]
    public class FileBaseProvider : BaseDescriptionProvider
    {
        public string fileNameFormat;

        public string FileName => Path.Combine(Application.streamingAssetsPath, fileNameFormat);

        public override async Task<BaseDescription> GetPlayerBase (string playerId, bool isAttacking)
        {
            var baseJson = await GetBaseJson(playerId);
            
            var description = JsonUtility.FromJson<BaseDescription>(baseJson);
            description.isAttacking = isAttacking;

            return description;
        }

        public override async Task UpdatePlayerBase (string playerId, BaseDescription newDescription)
        {
            newDescription.isPersistant = true;

            var filePath = GetPersistantPath(playerId);

            //CheckAndCreateFolder(filePath);

            var json = JsonUtility.ToJson(newDescription);

//            File.WriteAllText(filePath, json);
            using (var writer = new StreamWriter(filePath, false)) {
                await writer.WriteAsync(json);
            }
        }

        private static void CheckAndCreateFolder (string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            if (!fileInfo.Directory.Exists) {
                fileInfo.Directory.Create();
            }
        }

        private string GetPersistantPath(string playerId)
        {
            var fileName = string.Format(fileNameFormat, playerId);
            return Path.Combine(Application.persistentDataPath, fileName);
        }

        public async Task<string> GetBaseJson (string playerId)
        {
            var fileName = string.Format(fileNameFormat, playerId);
            var persistantPath = Path.Combine(Application.persistentDataPath, fileName);

            if (File.Exists(persistantPath)) {
                return File.ReadAllText(persistantPath);
            }

            var path = Path.Combine(Application.streamingAssetsPath, fileName);
            using (var www = new WWW(path)) {
                await www;
                
                if (www.error != null) {
                    throw new InvalidOperationException("Error getting base description : " + www.error);
                }

                return www.text;
            }
        }
    }
}
