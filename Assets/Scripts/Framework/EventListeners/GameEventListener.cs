using UnityEngine;
using UnityEngine;
using UnityEngine.Events;
using Framework.Events;

namespace Framework.EventListeners
{
    public class GameEventListener : MonoBehaviour, IEventListener
    {
        public GameEvent gameEvent;
        public UnityEvent onRaised;

        public void OnEventRaised()
        {
            onRaised.Invoke();
        }

        private void Start()
        {
            gameEvent.AddListener(this);
        }

        private void OnDestroy()
        {
            gameEvent.RemoveListener(this);
        }
    }
}