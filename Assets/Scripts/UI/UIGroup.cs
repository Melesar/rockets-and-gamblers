using UnityEngine;

namespace RocketsAndGamblers.UI
{
    public class UIGroup : MonoBehaviour
    {
        public void SetActive(bool isActive)
        {
            foreach (Transform child in transform) {
                child.gameObject.SetActive(isActive);
            }
        }
    }
}