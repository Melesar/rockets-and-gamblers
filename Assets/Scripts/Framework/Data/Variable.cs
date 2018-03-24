using UnityEngine;
using UnityEngine.Events;

namespace Framework.Data
{
    public abstract class Variable<T> : ScriptableObject
    {
        [SerializeField]
        private T value;

        public event UnityAction<T, T> valueChanged;

        private bool isEnabled;
        private T currentValue;

        public virtual T Value 
        { 
            get { return isEnabled ? currentValue : value; }
            set 
            {
                if (value.Equals(currentValue)) {
                    return;
                }

                var oldValue = currentValue;
                currentValue = value;

                OnValueChanged(oldValue, value);
            }
        }

        protected virtual void OnValueChanged (T previousValue, T newValue)
        {
            valueChanged?.Invoke(previousValue, newValue);
        }

        public static implicit operator T (Variable<T> variable)
        {
            return variable.Value;
        }

        protected virtual void OnEnable()
        {
            isEnabled = true;
            currentValue = value;
        }
    }
}