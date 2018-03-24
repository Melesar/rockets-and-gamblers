using Framework.UI.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Framework.UI
{
    public class Window : MonoBehaviour
    {
        public WindowDescriptor descriptor;

        private EventSystem eventSystem;
        private BaseEventData eventData;

        public void Open()
        {
            ExecuteEvents.Execute<IWindowOpenListener>(gameObject, eventData,
                (handler, data) => handler.OnWindowOpened());
        }

        public void Close()
        {
            ExecuteEvents.Execute<IWindowCloseListener>(gameObject, eventData,
                (handler, data) => handler.OnWindowClosed());
        }

        private void Start()
        {
            descriptor.Invoked += Open;
        }

        private void Awake()
        {
            eventSystem = EventSystem.current;
            eventData = new BaseEventData(eventSystem);
        }

        private void OnDestroy()
        {
            descriptor.Invoked -= Open;
        }
    }
}