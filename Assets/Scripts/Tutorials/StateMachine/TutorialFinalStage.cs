using UnityEngine;

namespace RocketsAndGamblers.Tutorials
{
    public class TutorialFinalStage : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            TutorialUtility.SetTutorialRunning(false);
        }

        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            TutorialUtility.SetTutorialRunning(false);
        }
    }
}