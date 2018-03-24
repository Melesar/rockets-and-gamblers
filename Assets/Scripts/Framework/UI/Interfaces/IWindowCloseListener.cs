using UnityEngine.EventSystems;

namespace Framework.UI.Interfaces
{
    public interface IWindowCloseListener : IEventSystemHandler
    {
        void OnWindowClosed();
    }
}