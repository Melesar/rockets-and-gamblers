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

namespace RocketsAndGamblers
{

    public class ReplayUpload : MonoBehaviour
    {
        public string TestReplay;
        private Replay replayStart;

        public string connection;
        public string containerName;

        public PlayerData attackingPlayer;
        public StringReference attackedPlayerId;


        private AzureBlobContainer replaysContainer;
        private float StartTime;
        public static List<InputData> coords = new List<InputData>();

        private void Awake()
        {

            replayStart = new Replay();
            replaysContainer = new AzureBlobContainer(connection, containerName);
        }

        void Start()
        {


            StartTime = Time.time;

        }
        public void OnTouch(Vector2 touchCoords)
        {
            replayStart.AddToList(new InputData(touchCoords, Time.time - StartTime));

            Debug.Log(touchCoords);
            Debug.Log(Time.time - StartTime);

        }

        public async void OnAttackSuccessfull()
        {
            Debug.Log("Successfull attack");
            Debug.Log("Total items: " + coords.Count);


            string str = JsonUtility.ToJson(replayStart);
            //string replayName = JsonConvert.SerializeObject(coords);
            var fileName = string.Format("replay_{0}_{1}", attackedPlayerId, attackingPlayer.Id);
            Debug.Log("Gotowy json: " + str);
            Debug.Log(attackedPlayerId);
            await replaysContainer.UploadFile(str, fileName);

        }







    }

}