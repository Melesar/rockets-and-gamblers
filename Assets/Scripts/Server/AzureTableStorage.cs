using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using UnityEngine.Networking;

namespace RocketsAndGamblers.Server
{
    public class AzureTableStorage
    {
        private readonly string connectionString;
        private readonly string tableName;

        public AzureTableStorage(string connectionString, string tableName)
        {
            this.connectionString = connectionString;
            this.tableName = tableName;
        }

        public async Task QueryEntities()
        {
            var url = $"{connectionString}/{tableName}()";
            using (var request = UnityWebRequest.Get(url)) {
                request.SetRequestHeader("x-ms-date", DateTime.Now.ToString());

            }
        }
    }
}