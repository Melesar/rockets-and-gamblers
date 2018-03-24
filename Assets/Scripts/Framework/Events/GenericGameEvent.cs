using UnityEngine;
using System.Collections.Generic;
using Framework.EventListeners;

namespace Framework.Events
{
    public abstract class GameEvent<T> : ScriptableObject
    {
        private readonly HashSet<IEventListener<T>> listeners = 
            new HashSet<IEventListener<T>>();

        public void Raise(T data)
        {
            foreach(var listener in listeners) {
                listener.OnEventRaised(data);
            }
        }

        public void AddListener(IEventListener<T> listener) 
        {   
            listeners.Add(listener);
        }

        public void RemoveListener(IEventListener<T> listener)
        {
            listeners.Remove(listener);
        }
    }
}