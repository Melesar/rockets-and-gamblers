using Framework.References;
using UnityEngine;

namespace RocketsAndGamblers.Tutorials
{
    public class TutorialSMB : StateMachineBehaviour
    {
        [SerializeField] private StringReference trigger;
        [SerializeField] private TutorialTransition transition;

        private Animator animator;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            OnEnter(animator);
        }

        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            OnEnter(animator);
        }
        
        private void OnEnter(Animator animator)
        {
            this.animator = animator;
            
            transition.RegisterOutput(TriggerAnimator);
            transition.OnInput();
        }

        private void TriggerAnimator()
        {
            if (animator != null) {
                animator.SetTrigger(trigger);
            }
        }
    }
}