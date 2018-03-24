using UnityEngine;
using UnityEngine.EventSystems;

namespace Framework.EventListeners
{
    public interface ITriggerListener : IEventSystemHandler
    {
        void OnTriggerEnter(Collider2D other);
    }
}