using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RocketsAndGamblers.Server
{
    public class AzureBlobContainer
    {
        private readonly CloudBlobContainer container;

        public async Task DownloadFile(string filename, Stream targetStream)
        {
            var blockBlob = container.GetBlockBlobReference(filename);

            if (!blockBlob.Exists()) {
                throw new AzureException($"Requested file doesn't exist: {filename}");
            }
            await blockBlob.DownloadToStreamAsync(targetStream);
        }

        public async Task UploadFile(string fileContents, string cloudFilename)
        {
            var blockBlob = container.GetBlockBlobReference(cloudFilename);
            await blockBlob.UploadTextAsync(fileContents);
        }

        public async Task<List<string>> ListFiles()
        {
            var result = new List<string>();
            BlobContinuationToken token = null;
            
            do {
                var segment = await container.ListBlobsSegmentedAsync(token);
                token = segment.ContinuationToken;

                foreach (var blobItem in segment.Results) {
                    result.Add(GetFileName(blobItem.Uri));
                }
                
            } while (token != null);

            return result;
        }

        private string GetFileName(Uri itemUri)
        {
            var localPath = itemUri.LocalPath;
            return localPath.Substring(localPath.LastIndexOf('/') + 1);
        }

        public AzureBlobContainer(string connectionString, string containerName)
        {
            CloudStorageAccount account;
            if (!CloudStorageAccount.TryParse(connectionString, out account)) {
                throw new AzureException($"Failed to initialize azure account. Connection string may be invalid:\n{connectionString}");
            }

            var blobClient = account.CreateCloudBlobClient();

            container = blobClient.GetContainerReference(containerName);
            if (!container.Exists()) {
                throw new AzureException($"Wrong container name: {containerName}");
            }
        }
    }
}
