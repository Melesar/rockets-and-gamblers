using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Threading.Tasks;

namespace RocketsAndGamblers.Server
{
    public class AzureBlobStorage
    {
        private CloudBlobContainer container;

        public async Task<Stream> DownloadFile(string filename)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(filename);
            Stream stream = new MemoryStream();

            await blockBlob.DownloadToStreamAsync(stream);

            return stream;
        }

        public async Task UploadFile(string filePath, string cloudFilename)
        {
            if (File.Exists(filePath))
            {
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(cloudFilename);
                await blockBlob.UploadFromFileAsync(filePath);
            }
        }

        public AzureBlobStorage(string connectionString, string containerName)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient Blobclient = account.CreateCloudBlobClient();
            container = Blobclient.GetContainerReference(containerName);
        }
    }
}
