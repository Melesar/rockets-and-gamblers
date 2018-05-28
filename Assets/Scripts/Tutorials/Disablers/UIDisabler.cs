using UnityEngine;
using UnityEngine.UI;

namespace RocketsAndGamblers.Tutorials
{
    public class UIDisabler : TutorialDisabler
    {
        private Button button;

        public override bool IsDisabled
        {
            get { return base.IsDisabled; }
            set
            {
                base.IsDisabled = value;
                button.interactable = !IsDisabled;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            button = GetComponent<Button>();
            button.interactable = !IsDisabled;
        }
    }
}