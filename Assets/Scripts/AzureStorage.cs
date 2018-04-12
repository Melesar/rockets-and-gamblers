using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using UnityEngine;
using Random = System.Random;

public class Class1
{
    public string Block = "Blockname";
    public string key;
    public string Pageblock = "PageBlockName";
    protected CloudStorageAccount StorageAccount;

    Class1(){
        StorageAccount = CloudStorageAccount.Parse(key);
} 

    public async Task ConnectTest() {
        //ClearOutput();
        WriteLine("-- Test polaczenie --");

    }
	
    public async Task BasicStorageBlockBlobOperationsAsync(string path,string file,string container_name)
    {
        //Client for intreacting with blob
        CloudBlobClient blobClient = StorageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference(container_name);

        try
        {
            await container.CreateIfNotExistsAsync();
            
        }
        catch (StorageException)
        {
            WriteLine("If you are running with the default configuration please make sure you have started the storage emulator. Press the Windows key and type Azure Storage to select and run it from the list of applications - then restart the sample.");
            throw;
        }
        // Upload a BlockBlob to the newly created container
        WriteLine("2. Uploading BlockBlob");
        CloudBlockBlob blockBlob = container.GetBlockBlobReference(file);

#if WINDOWS_UWP
		StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync(Application.streamingAssetsPath.Replace('/', '\\'));
		StorageFile sf = await storageFolder.GetFileAsync(file);
		await blockBlob.UploadFromFileAsync(sf);
#else
        await blockBlob.UploadFromFileAsync(Path.Combine(Application.streamingAssetsPath, file));
       
#endif
    }
    public async Task GetContainersList(string container_name) {
        WriteLine("List of Containers");
        BlobContinuationToken token = null;
        CloudBlobClient blobClient = StorageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference(container_name);
        BlobResultSegment list = await container.ListBlobsSegmentedAsync(token);
        foreach (IListBlobItem blob in list.Results)
        {
            // Blob type will be CloudBlockBlob, CloudPageBlob or CloudBlobDirectory
            // Use blob.GetType() and cast to appropriate type to gain access to properties specific to each type
            WriteLine(string.Format("- {0} (type: {1})", blob.Uri, blob.GetType()));

        }
        
           }
    public async Task DownloadFile(string path, string filename)
    {
        CloudBlobClient blobClient = StorageAccount.CreateCloudBlobClient();

        Console.WriteLine.Format("Download Blob from {0}", blockBlob.Uri.AbsoluteUri);
        filename= string.Format("CopyOf{0}", filename);

#if WINDOWS_UWP
		storageFolder = ApplicationData.Current.TemporaryFolder;
		sf = await storageFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
		path = sf.Path;
		await blockBlob.DownloadToFileAsync(sf);
#else
        path = Path.Combine(Application.temporaryCachePath, filename);


        await blockBlob.DownloadToFileAsync(path, FileMode.Create);
#endif
        WriteLine("File save at: "+path);

    }

    public async Task DeletFile(string file,string containername) {
        WriteLine("Deleting "+file+ "from"+containername);
        CloudBlobContainer container = blobClient.GetContainerReference(containername);
        CloudBlockBlob blockBlob = container.GetBlockBlobReference(file);
        await blockBlob.DeleteAsync();
    }
    public async Task DeleteContainer(string containername) {
        WriteLine("Delete container: "+containername);
        CloudBlobClient blobClient = StorageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference(containername);
        await container.DeleteAsync();
    }
    public async Task CreatePageBlop(string PageBlopName,string containername ) {
       
        CloudBlobClient blobClient = StorageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference(containername);
        WriteLine("Creating new Page blop "+PageBlopName+" in "+containername);
        await container.CreateIfNotExistsAsync();
        CloudPageBlob pageBlob = container.GetPageBlobReference(PageBlobName);
        await pageBlob.CreateAsync(512 * 2 /*size*/); // size needs to be multiple of 512 bytes
        WriteLine("Write to "+ PageBlopName);
        byte[] samplePagedata = new byte[512];
        Random random = new Random();
        random.NextBytes(samplePagedata);
        await pageBlob.UploadFromByteArrayAsync(samplePagedata, 0, samplePagedata.Length);
    }
    public async Task GetPageBlopList(string PageBlopName, string containername) {
        BlobContinuationToken token = null;
        CloudBlobClient blobClient = StorageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference(containername);
        do
        {
            BlobResultSegment resultSegment = await container.ListBlobsSegmentedAsync(token);
            token = resultSegment.ContinuationToken;
            foreach (IListBlobItem blob in resultSegment.Results)
            {
                // Blob type will be CloudBlockBlob, CloudPageBlob or CloudBlobDirectory
                WriteLine(string.Format("{0} (type: {1}", blob.Uri, blob.GetType()));
            }
        } while (token != null);
       

    }
    public void WriteLine(string text) {
        Console.WriteLine(text);
    }
}
