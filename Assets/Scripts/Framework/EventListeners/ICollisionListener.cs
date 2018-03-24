using UnityEngine;
using UnityEngine.EventSystems;

namespace Framework.EventListeners
{
    public interface ICollisionListener : IEventSystemHandler
    {
        void OnCollisionEnter(Collision2D collision);
    }
}