using Framework.RuntimeSets;
using Framework.UI;
using RocketsAndGamblers.Server;
using TMPro;
using UnityEngine;

namespace RocketsAndGamblers.Replay
{
    public class ReplayButton : MonoBehaviour
    {
        [Header("Objects references")]
        public TMP_Text countText;
        public GameObject countObject;

        [Header("Data references")]
        public AttackHistory replaysSet;
        public WindowDescriptor replaysWindowDescriptor;

        private int currentReplaysCount;

        public void OnButtonPressed()
        {
            replaysWindowDescriptor.Invoke();
        }
        
        private void Update()
        {
            //TODO rework constant checking to event-based
            if (currentReplaysCount == replaysSet.Count) {
                return;
            }
            
            currentReplaysCount = replaysSet.Count;

            countObject.SetActive(currentReplaysCount > 0);
            countText.text = currentReplaysCount.ToString();
        }
    }
}