using Framework.References;
using UnityEngine;

namespace RocketsAndGamblers.UI
{
    public class SavingAttemptsUI : MonoBehaviour
    {
        [SerializeField] private IntReference currentAttempts;
        [SerializeField] private GameObject[] ticks;

        private void OnAttemptsValueChanged(int oldValue, int newValue)
        {
            for (int i = 0; i < ticks.Length; i++) {
                ticks[i].SetActive(i < currentAttempts);
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