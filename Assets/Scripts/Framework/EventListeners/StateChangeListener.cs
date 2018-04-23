using Framework.Data;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Framework.EventListeners
{
    public class StateChangeListener : MonoBehaviour, IEventListener<bool>
    {
        public BoolVariable stateVariable;
        public bool inverseValue;

        public BoolUnityEvent onStateChanged;

        public void OnEventRaised (bool newState)
        {
            onStateChanged.Invoke(newState);
        }

        private void Awake ()
        {
            stateVariable.valueChanged += VariableValueChanged;
        }

        private void OnDestroy ()
        {
            stateVariable.valueChanged -= VariableValueChanged;
        }

        private void VariableValueChanged (bool previousValue, bool newValue)
        {
            OnEventRaised(inverseValue ? !newValue : newValue);
        }
    }

    [Serializable]
    public class BoolUnityEvent : UnityEvent<bool> {}
}
