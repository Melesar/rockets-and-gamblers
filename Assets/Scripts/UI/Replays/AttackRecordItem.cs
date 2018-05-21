using Framework.Data;
using Framework.UI;
using RocketsAndGamblers.Server;
using TMPro;
using UnityEngine;

namespace RocketsAndGamblers.UI
{
    public class AttackRecordItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text playerNameText;
        
        [SerializeField] private StringVariable recordFileName;
        [SerializeField] private BoolVariable isWatchingReplay;
        
        private AttackRecord Record { get; set; }
        
        public void Init(AttackRecord record)
        {
            Record = record;
            playerNameText.text = Record.AttackerName;
        }

        public void OnReplayButtonClicked()
        {
            recordFileName.Value = Record.ReplayFileName;
            isWatchingReplay.Value = true;
        }

        
    }
}