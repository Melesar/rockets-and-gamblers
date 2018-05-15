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
            transition.OnInput();
        }

        private void TriggerAnimator()
        {
            animator.SetTrigger(trigger);
        }

        private void OnEnable()
        {
            transition.RegisterOutput(TriggerAnimator);
        }
    }
}