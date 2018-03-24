using Framework.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Framework.EventListeners
{
    public class GameObjectEventListener : GameEventListener<GameObject>
    {
        public GameObjectEvent gameEvent;
        public GameObjectUnityEvent onRaised;

        protected override GameEvent<GameObject> GameEvent => gameEvent;
        protected override UnityEvent<GameObject> OnRaised => onRaised;
    }

    [System.Serializable]
    public class GameObjectUnityEvent : UnityEvent<GameObject>
    {

    }
}