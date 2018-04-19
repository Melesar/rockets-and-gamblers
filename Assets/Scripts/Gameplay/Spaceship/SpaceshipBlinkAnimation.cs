using Framework.References;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class SpaceshipBlinkAnimation : MonoBehaviour
    {
        [SerializeField] private Animator flashAnimator;
        [SerializeField] private StringReference animatorTriggerParameter;

        private SpriteRenderer spriteRenderer;

        public void Blink ()
        {
            flashAnimator.gameObject.SetActive(true);
            spriteRenderer.enabled = false;

            flashAnimator.SetTrigger(animatorTriggerParameter);
        }

        public void Reappear ()
        {
            flashAnimator.gameObject.SetActive(false);
            spriteRenderer.enabled = true;
        }

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}