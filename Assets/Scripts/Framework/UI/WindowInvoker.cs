using UnityEngine;

namespace Framework.UI
{
    public class WindowInvoker : MonoBehaviour
    {
        public WindowDescriptor target;

        public void Invoke()
        {
            target?.Invoke();
        }
    }
}