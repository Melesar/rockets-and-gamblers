using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Framework.EventListeners;

namespace Framework.Events
{
    [CreateAssetMenu(menuName = "Framework/Events/Default event")]
    public class GameEvent : ScriptableObject
    {
        private readonly HashSet<IEventListener> listeners = 
            new HashSet<IEventListener>();

        public void Raise()
        {
            foreach(var listener in listeners) {
                listener.OnEventRaised();
            }
        }

        public void AddListener(IEventListener listener) 
        {   
            listeners.Add(listener);
        }

        public void RemoveListener(IEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}