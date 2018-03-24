using UnityEngine;
using Framework.Events;
using UnityEngine.Events;

namespace Framework.EventListeners
{
    public abstract class GameEventListener<T> : MonoBehaviour, IEventListener<T>
    {
        protected abstract GameEvent<T> GameEvent { get; }
        protected abstract UnityEvent<T> OnRaised { get; }

        public void OnEventRaised(T data)
        {
            OnRaised.Invoke(data);
        }

        private void Start()
        {
            GameEvent.AddListener(this);
        }

        private void OnDestroy()
        {
            GameEvent.RemoveListener(this);
        }
    }
}