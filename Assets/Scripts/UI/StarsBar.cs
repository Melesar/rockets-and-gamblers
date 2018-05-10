using Framework.References;
using UnityEngine;
using UnityEngine.UI;

namespace RocketsAndGamblers.UI
{
    public class StarsBar : MonoBehaviour
    {
        [SerializeField] private Image fillBar;
        
        [Space]
        
        [SerializeField] private IntReference currentAttempts;
        [SerializeField] private IntReference maxAttempts;

        private void OnAttemptsValueChanged (int oldValue, int newValue)
        {
            fillBar.fillAmount = 1f - newValue / (float) maxAttempts;
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