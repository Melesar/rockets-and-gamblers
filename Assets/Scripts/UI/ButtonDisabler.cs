using UnityEngine;
using UnityEngine.UI;

namespace RocketsAndGamblers.UI
{
    public class ButtonDisabler : MonoBehaviour
    {
        private Button button;

        public void SetButtonInteractable (bool isInteractable)
        {
            button.interactable = isInteractable;
        }

        public void OnEditingStateChanged (bool currentState)
        {
            SetButtonInteractable(!currentState);
        }

        private void Awake ()
        {
            button = GetComponent<Button>();
        }
    }
}
