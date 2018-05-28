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
        
        public override async Task<BaseDescription> GetPlayerBase(string playerId, bool isAttacking)
        {
            var fileName = string.Format(baseFileNameFormat, playerId);
            using (var stream = new MemoryStream()) {
                await DownloadBase(fileName, stream);
                
                var json = Encoding.UTF8.GetString(stream.GetBuffer());
                var description = JsonUtility.FromJson<BaseDescription>(json);
                description.isAttacking = isAttacking;

                return description;
            }
        }

        private async Task DownloadBase(string fileName, Stream stream)
        {
            try {
                //If we are debugging tutorial, we want to download layout instead of the real base
                if (Tutorials.TutorialUtility.IsTutorialRunning() && 
                    Tutorials.TutorialUtility.IsDebugMode) {
                    await DownloadLayout(stream);
                } else {
                    await basesContainer.DownloadFile(fileName, stream);
                }
            } catch (AzureException) {
                //Provided player id doesn't exist, so we need to download a new base from layout
                await DownloadLayout(stream);
            }
        }

        public override async Task UpdatePlayerBase(string playerId, BaseDescription newDescription)
        {
            newDescription.isPersistant = true;
            
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