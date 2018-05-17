using System;
using Framework.References;
using UnityEngine;
using UnityEngine.UI;

namespace RocketsAndGamblers.UI
{
    public class Star : MonoBehaviour
    {
        [SerializeField] private Sprite deactivatedSprite;
        
        [Space]
        
        [SerializeField] private IntReference attemptsToDeactivate;
        [SerializeField] private IntReference maximumAttempts;
        [SerializeField] private IntReference currentAttempts;

        private RectTransform rectTransform;

        private Image image;
        
        private void OnAttemptsValueChanged(int oldValue, int newValue)
        {
            if (newValue > attemptsToDeactivate) {
                Deactivate();
            }
        }
        
        private void Deactivate()
        {
            image.sprite = deactivatedSprite;
        }

        private void EstablishPosition()
        {
            var parentTransform = (RectTransform) transform.parent;
            var t = 1f - (float) attemptsToDeactivate / maximumAttempts;

            var position = rectTransform.anchoredPosition;
            position.x = parentTransform.rect.width * t;

            var halfWidth = rectTransform.rect.width / 2f;
            position.x = Mathf.Clamp(position.x, halfWidth, parentTransform.rect.width - halfWidth);
            
            rectTransform.anchoredPosition = position;
        }

        private void Start()
        {
            EstablishPosition();
        }

        private void Awake()
        {
            rectTransform = transform as RectTransform;
            image = GetComponent<Image>();
            currentAttempts.valueChanged += OnAttemptsValueChanged;
        }

        private void OnDestroy()
        {
            currentAttempts.valueChanged -= OnAttemptsValueChanged;
        }
    }
}