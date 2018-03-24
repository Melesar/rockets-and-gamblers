using Framework.UI.Interfaces;
using UnityEngine;

namespace Framework.UI.WindowBehaviours
{
    public class WindowActivation : MonoBehaviour, IWindowOpenListener, IWindowCloseListener
    {
        public GameObject target;

        public void OnWindowOpened()
        {
            target?.SetActive(true);            
        }

        public void OnWindowClosed()
        {
            target.SetActive(false);
        }
    }
}