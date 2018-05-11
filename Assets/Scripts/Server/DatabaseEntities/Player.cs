using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace RocketsAndGamblers.Server
{
    [DataTable("users")]
    public class Player
    {
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "deviceId")]
        public string DeviceId { get; set; }
        
        [JsonProperty(PropertyName = "googlePlayToken")]
        public string GooglePlayToken { get; set; }
        
        [JsonProperty(PropertyName = "fbToken")]
        public string FbToken { get; set; }
        
        [JsonProperty(PropertyName = "accessToken")]
        public string AccessToken { get; set; }
        
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(DeviceId)}: {DeviceId}, {nameof(Username)}: {Username}";
        }
    }
}

