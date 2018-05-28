using UnityEngine;

namespace RocketsAndGamblers.Tutorials
{
    public class Physics2DDisabler : TutorialDisabler
    {
        private Collider2D collider;

        public override bool IsDisabled
        {
            get { return base.IsDisabled; }
            set
            {
                base.IsDisabled = value;
                collider.enabled = !IsDisabled;
            }
        }

        private void Start()
        {
            IsDisabled = true;
        }
        
        protected override void Awake()
        {
            base.Awake();

            collider = GetComponent<Collider2D>();
        }
    }
}