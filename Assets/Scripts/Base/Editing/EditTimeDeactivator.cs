using Framework.Data;
using RocketsAndGamblers.Data;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class EditTimeDeactivator : MonoBehaviour
    {
        public float disabledRendererAlfa;

        private SpriteRenderer spriteRenderer;

        public void OnEditingStateChanged (bool newState)
        {
            var alfa = newState ? disabledRendererAlfa : 1f;

            var currentColor = spriteRenderer.color;
            currentColor.a = alfa;
            spriteRenderer.color = currentColor;
        }

        private void Awake ()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}
