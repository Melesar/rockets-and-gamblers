﻿using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
namespace RocketsAndGamblers.Server
{
    [DataTable("attacks_history")]
    public class AttackRecord
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "attackerId")]
        public string AttackerId { get; set; }

        [JsonProperty(PropertyName = "victimId")]
        public string VictimId { get; set; }

        [JsonProperty(PropertyName = "replayfilename")]
        public string ReplayFileName { get; set; }


        public string AttackerName { get; set; }
    }
}