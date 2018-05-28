using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Text;
using RocketsAndGamblers.Server;
using Framework.References;
using RocketsAndGamblers.Player;
using System.Threading.Tasks;
using RocketsAndGamblers.Replay;

namespace RocketsAndGamblers.Replay
{
    public class ReplayUpload : MonoBehaviour
    {

        public string connection;
        public string containerName;

        public PlayerData attackingPlayer;
        public StringReference attackedPlayerId;
        public AttackHistoryData dataUpload;

        private AzureBlobContainer replaysContainer;
        private Replay replayStart;
        private float StartTime;

        private void Awake()
        {
            replayStart = new Replay();
            replaysContainer = new AzureBlobContainer(connection, containerName);
        }

        void Start()
        {
            StartTime = Time.time;
        }

        public void OnPlayerDeath()
        {
            replayStart.inputs.Clear();
        }

        public void OnTouch(Vector2 touchCoords)
        {
            replayStart.AddToList(new InputData(touchCoords, Time.time - StartTime));
        }

        private async Task OnAttackSuccessfullAsync()
        {
            string str = JsonUtility.ToJson(replayStart);
            var fileName = $"replay_{attackedPlayerId}_{attackingPlayer.Id}";

            await replaysContainer.UploadFile(str, fileName);
            await dataUpload.InsertTable(attackingPlayer.Id, attackedPlayerId, fileName);
        }

        public void OnAttackSuccessfull()
        {
            OnAttackSuccessfullAsync().WrapErrors();
        }
    }
}