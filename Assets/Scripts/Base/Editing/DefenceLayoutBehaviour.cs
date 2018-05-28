using System.Threading;
using Framework.References;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class DefenceLayoutBehaviour : MonoBehaviour
    {
        public BoolReference isEditingBase;

        protected Vector3 originalPosition;
        
        protected bool IsDirty { get; set; }

        public void OnBaseSaved()
        {
            IsDirty = false;
        }

        protected virtual void SaveOriginalState()
        {
            originalPosition = transform.position;
            IsDirty = true;
        }

        protected virtual void RestoreOriginalState()
        {
            if (IsDirty) {
                transform.position = originalPosition;
            }
        }
        
        private void OnBaseEditingValueChanged(bool oldValue, bool newValue)
        {
            if (newValue) {
                SaveOriginalState();
            } else {
                RestoreOriginalState();
            }
        }

        protected virtual void Awake()
        {
            //isEditingBase.valueChanged += OnBaseEditingValueChanged;
        }

        protected virtual void OnDestroy()
        {
            //isEditingBase.valueChanged -= OnBaseEditingValueChanged;
        }
    }
}