using Framework.References;
using UnityEngine;
using UnityEngine.UI;

namespace RocketsAndGamblers.UI
{
    public class Healthbar : MonoBehaviour
    {
        [SerializeField] private GameObject healthItemPrefab;
        [SerializeField] private Transform itemsBase;

        [SerializeField] private IntReference attemptsAvailable;
        [SerializeField] private IntReference attemptsLeft;

        private void OnAttemptsValueChanged(int oldValue, int newValue)
        {
            if (attemptsLeft == (int) attemptsAvailable) {
                return;
            }

            var disabledItemRenderer = itemsBase.GetChild(attemptsAvailable - attemptsLeft - 1).GetComponent<Image>();
            var color = disabledItemRenderer.color;
            color.a = 0.3f;
            disabledItemRenderer.color = color;
        }

        private void InitHealthbar()
        {
            for (int i = 0; i < attemptsAvailable; i++) {
                Instantiate(healthItemPrefab, itemsBase, false);
            }
        }

        private void Start ()
        {
            InitHealthbar();
        }

        private void Awake ()
        {
            attemptsLeft.valueChanged += OnAttemptsValueChanged;
        }

        private void OnDestroy ()
        {
            attemptsLeft.valueChanged -= OnAttemptsValueChanged;
        }
    }
}

