using System.Collections;
using Framework.References;
using UnityEngine;
using UnityEngine.UI;

namespace RocketsAndGamblers.UI
{
    public class StarsBar : MonoBehaviour
    {
        [SerializeField] private Image fillBar;
        [SerializeField] private float fillTime;
        
        [Space]
        
        [SerializeField] private IntReference currentAttempts;
        [SerializeField] private IntReference maxAttempts;

        private void OnAttemptsValueChanged (int oldValue, int newValue)
        {
            StartCoroutine(FillCoroutine());
        }

        private float dampVelocity;

        private IEnumerator FillCoroutine()
        {
            var targetFillAmount = 1f - currentAttempts / (float) maxAttempts;
            var distance = fillBar.fillAmount - targetFillAmount;
            var numSteps = fillTime / Time.deltaTime;
            var step = distance / numSteps;

            for (int i = 0; i < numSteps; i++) {
                fillBar.fillAmount -= step;
                yield return null;
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