using Framework.UI;
using Framework.UI.Interfaces;
using RocketsAndGamblers.Server;
using UnityEngine;

namespace RocketsAndGamblers.UI
{
    public class ReplaysWindow : MonoBehaviour, IWindowOpenListener
    {
        [SerializeField] private AttackRecordItem itemPrefab;
        [SerializeField] private Transform contentBase;
        
        [Space]
        
        [SerializeField] private AttackHistory attackHistory;
        
        private Window window;

        public void OnWindowOpened()
        {
            ClearItems();
            SpawnItems();
        }
        
        public void OnWatchStateChanged(bool newState)
        {
            if (newState) {
                window.Close();
            }
        }

        private void SpawnItems()
        {
            foreach (var record in attackHistory) {
                var itemInstance = Instantiate(itemPrefab, contentBase, false);
                itemInstance.Init(record);
            }
        }

        private void ClearItems()
        {
            foreach (Transform child in contentBase) {
                Destroy(child.gameObject);
            }
        }
        
        private void Awake()
        {
            window = GetComponent<Window>();
        }
    }
}