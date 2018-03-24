using Framework.EventListeners;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Framework.Events
{
    public class CollisionBroadcaster : MonoBehaviour
    {
        private EventSystem eventSystem;
        private BaseEventData eventData;

        private void OnCollisionEnter2D(Collision2D other)
        {
            ExecuteEvents.ExecuteHierarchy<ICollisionListener>(gameObject, eventData,
                (handler, data) => handler.OnCollisionEnter(other));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            ExecuteEvents.ExecuteHierarchy<ITriggerListener>(gameObject, eventData,
                (handler, data) => handler.OnTriggerEnter(other));
        }

        private void Awake()
        {
            eventSystem = EventSystem.current;
            eventData = new BaseEventData(eventSystem);
        }
    }
}