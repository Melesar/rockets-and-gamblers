using Framework.UI.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace RocketsAndGamblers.UI
{
    public class RaycastTargetSwitcher : MonoBehaviour, IWindowOpenListener, IWindowCloseListener
    {
        private Graphic[] graphic;

        public void OnWindowClosed ()
        {
            foreach (var item in graphic) {
                item.raycastTarget = false;
            }
        }

        public void OnWindowOpened ()
        {
            foreach (var item in graphic) {
                item.raycastTarget = true;
            }
        }

        private void Awake ()
        {
            graphic = GetComponents<Graphic>();
        }
    }
}
