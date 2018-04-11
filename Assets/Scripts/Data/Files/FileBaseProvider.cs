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

        public override async Task<BaseDescription> GetPlayerBase (int playerId, bool isAttacking)
        {
            var filePath = GetFilePath(playerId);

            using (var www = new WWW(filePath)) {
                await www;

                if (www.error != null) {
                    throw new InvalidOperationException("Error getting base description : " + www.error);
                }

                var description = JsonUtility.FromJson<BaseDescription>(www.text);
                description.isAttacking = isAttacking;

                return description;
            }
        }

        public override async Task UpdatePlayerBase (int playerId, BaseDescription newDescription)
        {
            var filePath = GetFilePath(playerId);

            CheckAndCreateFolder(filePath);

            var json = JsonUtility.ToJson(newDescription);

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

        public string GetFilePath (int playerId)
        {
            var fileName = string.Format(fileNameFormat, playerId);
            return Path.Combine(Application.streamingAssetsPath, fileName);
        }
    }
}
