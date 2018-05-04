using System.IO;
using System.Text;
using System.Threading.Tasks;
using Framework.References;
using RocketsAndGamblers.Server;
using UnityEngine;

namespace RocketsAndGamblers.Data
{
    [CreateAssetMenu(menuName = "R&G/Base provider/Azure")]
    public class AzureBaseProvider : BaseDescriptionProvider
    {
        public StringReference connectionString;
        [Space]
        public StringReference layoutsContainerName;
        public StringReference basesContainerName;
        [Space] 
        public StringReference baseFileNameFormat;
        
        private AzureBlobContainer layoutsContainer;
        private AzureBlobContainer basesContainer;
        
        public override async Task<BaseDescription> GetPlayerBase(int playerId, bool isAttacking)
        {
            var fileName = string.Format(baseFileNameFormat, playerId);
            using (var stream = new MemoryStream()) {
                try {
                    await basesContainer.DownloadFile(fileName, stream);
                } catch (AzureException) {
                    //Provided player id doesn't exist, so we need to download a new base from layout
                    await DownloadLayout(stream);
                }
                var json = Encoding.UTF8.GetString(stream.GetBuffer());
                var description = JsonUtility.FromJson<BaseDescription>(json);
                description.isAttacking = isAttacking;

                return description;
            }
        }

        public override async Task UpdatePlayerBase(int playerId, BaseDescription newDescription)
        {
            var fileName = string.Format(baseFileNameFormat, playerId);
            var baseJson = JsonUtility.ToJson(newDescription);

            await basesContainer.UploadFile(baseJson, fileName);
        }

        private async Task DownloadLayout(Stream targetStream)
        {
            var fileNames = await layoutsContainer.ListFiles();
            var layoutName = fileNames[Random.Range(0, fileNames.Count)];

            await layoutsContainer.DownloadFile(layoutName, targetStream);
        }

        private void OnEnable()
        {
            layoutsContainer = new AzureBlobContainer(connectionString, layoutsContainerName);
            basesContainer = new AzureBlobContainer(connectionString, basesContainerName);
        }
    }
}