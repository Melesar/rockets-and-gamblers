using UnityEngine.EventSystems;

namespace Framework.UI.Interfaces
{
    public interface IWindowOpenListener : IEventSystemHandler
    {
        void OnWindowOpened();
    }
}