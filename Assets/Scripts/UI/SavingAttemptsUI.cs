using Framework.References;
using UnityEngine;

namespace RocketsAndGamblers.UI
{
    public class SavingAttemptsUI : MonoBehaviour
    {
        [SerializeField] private IntReference currentAttempts;
        [SerializeField] private GameObject[] ticks;

        private bool isEnabled;
        
        public void OnSavingStateChanged(bool newState)
        {
            isEnabled = newState;

            if (!isEnabled) {
                SetTicksActive(false);
            }
        }

        private void OnAttemptsValueChanged(int oldValue, int newValue)
        {
            if (!isEnabled) {
                return;
            }

            for (int i = 0; i < ticks.Length; i++) {
                ticks[i].SetActive(i < currentAttempts);
            }
        }

        private void SetTicksActive(bool isActive)
        {
            foreach (var t in ticks) {
                t.SetActive(isActive);
            }
        }

        private void Awake()
        {
            currentAttempts.valueChanged += OnAttemptsValueChanged;
        }

        private void OnDestroy()
        {
            currentAttempts.valueChanged -= OnAttemptsValueChanged;
        }
    }
}