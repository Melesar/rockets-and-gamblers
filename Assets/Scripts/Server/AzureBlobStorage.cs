using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using UnityEngine;

namespace RocketsAndGamblers.Server
{
    public class AzureBlobStorage
    {
        private CloudBlobContainer container;


        public async Task<Stream> DownloadFile(string filename)
        {
            CloudBlockBlob BlockBlob = container.GetBlockBlobReference(filename);
            Stream stream = new MemoryStream();

            await BlockBlob.DownloadToStreamAsync(stream);

            return stream;
        }

        public async Task UploadFile(string filePath, string cloudFilename)
        {
            if (File.Exists(filePath))
            {
                CloudBlockBlob Blockblob = container.GetBlockBlobReference(cloudFilename);
                await Blockblob.UploadFromFileAsync(filePath);
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
