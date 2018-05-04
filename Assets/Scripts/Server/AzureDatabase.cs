using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Framework.References;
using Microsoft.WindowsAzure.MobileServices;
using UnityEngine;
using Newtonsoft.Json;

namespace RocketsAndGamblers.Server
{
    [CreateAssetMenu(menuName = "R&G/Azure database")]
    public class AzureDatabase : ScriptableObject
    {
        public StringReference databaseUrl;

        private MobileServiceClient Client { get; set; }
        
        public IMobileServiceTable<T> GetTable<T>()
        {
            return Client.GetTable<T>();
        }

        private void OnEnable()
        {
#if UNITY_ANDROID
            // Android builds fail at runtime due to missing GZip support, so build a handler that uses Deflate for Android
            var handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate };
            Client = new MobileServiceClient(databaseUrl, handler);
#else
		    Client = new MobileServiceClient(MobileAppUri);
#endif
        }
    }

    
}