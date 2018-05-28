using Framework.References;
using TMPro;
using UnityEngine;

namespace RocketsAndGamblers.Tutorials
{
    public class TutorialAnimationAndTextStep : TutorialSubstep
    {
        [TextArea]
        [SerializeField] private string textToDisplay;
        
        [SerializeField] private TMP_Text textComponent;
        [SerializeField] private Animator animator;
        [SerializeField] private StringReference animatorTrigger;
        
        public override void OnSubstep()
        {
            textComponent.text = textToDisplay;
            animator.SetTrigger(animatorTrigger);
        }
    }
}