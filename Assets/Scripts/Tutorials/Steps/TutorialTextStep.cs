using TMPro;
using UnityEngine;

namespace RocketsAndGamblers.Tutorials
{
    public class TutorialTextStep : TutorialSubstep
    {
        [TextArea]
        public string textToDisplay;
        public TMP_Text textComponent;

        public override void OnSubstep()
        {
            textComponent.text = textToDisplay;
        }
    }
}