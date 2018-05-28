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
    public class ReplayUpload : MonoBehaviour, IDeathListener
    {
        public StringReference connection;
        public StringReference containerName;

        public PlayerData attackingPlayer;
        public StringReference attackedPlayerId;
        public AttackHistoryData dataUpload;

        public BoolReference isTryingToSaveBase;

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
            StartTime = Time.unscaledTime;
        }

        public void OnDeath()
        {
            replayStart.inputs.Clear();
        }

        public void OnTouch(Vector2 touchCoords)
        {
            if (isTryingToSaveBase) {
                return;
            }
            
            Debug.Log($"Touch coords: {touchCoords}");
            replayStart.AddToList(new InputData(touchCoords, Time.unscaledTime - StartTime));
        }

        private async Task OnAttackSuccessfullAsync()
        {
            string str = JsonUtility.ToJson(replayStart);
            var fileName = $"replay_{attackedPlayerId}_{attackingPlayer.Id}";

            await replaysContainer.UploadFile(str, fileName);
            await dataUpload.InsertTable(attackingPlayer.Id, attackingPlayer.Id, fileName);
        }

        public void OnAttackSuccessfull()
        {
            if (isTryingToSaveBase) {
                return;
            }
            
            OnAttackSuccessfullAsync().WrapErrors();
        }

    }
}