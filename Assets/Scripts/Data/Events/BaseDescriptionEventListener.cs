using System;
using Framework.EventListeners;
using Framework.Events;
using UnityEngine.Events;

namespace RocketsAndGamblers.Data
{
    public class BaseDescriptionEventListener : GameEventListener<BaseDescription>
    {
        public BaseDescriptionEvent baseDescriptionEvent;
        public BaseDescriptionUnityEvent unityEvent;

        protected override GameEvent<BaseDescription> GameEvent => baseDescriptionEvent;
        protected override UnityEvent<BaseDescription> OnRaised => unityEvent;
    }

    [Serializable]
    public class BaseDescriptionUnityEvent : UnityEvent<BaseDescription> { }
}
