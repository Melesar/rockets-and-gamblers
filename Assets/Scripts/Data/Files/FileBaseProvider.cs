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

            if (!File.Exists(filePath)) {
                throw new InvalidOperationException("No base description found!");
            }

            using (var reader = new StreamReader(new FileStream(filePath, FileMode.OpenOrCreate))) {
                var json = await reader.ReadToEndAsync();
                var baseDescription = JsonUtility.FromJson<BaseDescription>(json);
                baseDescription.isAttacking = isAttacking;

                return baseDescription;
            }
        }

        public override async Task UpdatePlayerBase (int playerId, BaseDescription newDescription)
        {
            var filePath = GetFilePath(playerId);

            CheckAndCreateFolder(filePath);

            var json = JsonUtility.ToJson(newDescription);

            using (var writer = new StreamWriter(new FileStream(filePath, FileMode.OpenOrCreate))) {
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
