using UnityEngine;

namespace RocketsAndGamblers.Tutorials
{
    public abstract class TutorialDisabler : MonoBehaviour
    {
        private bool isDisabled = true;

        public virtual bool IsDisabled
        {
            get
            {
                return TutorialUtility.IsTutorialRunning() && isDisabled;
            }
            set { isDisabled = value; }
        }

        protected virtual void Awake()
        {
            if (!TutorialUtility.IsTutorialRunning()) {
                Destroy(this);
            }
        }
    }
}