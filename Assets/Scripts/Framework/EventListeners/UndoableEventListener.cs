using System;
using Framework.Events;
using Framework.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Framework.EventListeners
{
    public class UndoableEventListener : GameEventListener<IUndoable>
    {
        public UndoableGameEvent gameEvent;
        public UndoableUnityEvent unityEvent;

        public void Test(IUndoable d)
        {
            
        }

        protected override GameEvent<IUndoable> GameEvent => gameEvent;
        protected override UnityEvent<IUndoable> OnRaised => unityEvent;
    }
    
    [Serializable]
    public class UndoableUnityEvent : UnityEvent<IUndoable>{}
}