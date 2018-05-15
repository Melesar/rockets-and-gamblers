using UnityEngine;
using UnityEngine.Events;

namespace RocketsAndGamblers.Tutorials
{
    [CreateAssetMenu(menuName = "R&G/Tutorial transition")]
    public class TutorialTransition : ScriptableObject
    {
        private UnityAction input;
        private UnityAction output;
        
        public void RegisterInput(UnityAction input)
        {
            this.input = input;
        }

        public void RegisterOutput(UnityAction output)
        {
            this.output = output;
        }

        public void ClearInput()
        {
            input = null;
        }

        public void ClearOutput()
        {
            output = null;
        }

        public void OnInput()
        {
            input?.Invoke();
        }

        public void OnOutput()
        {
            output?.Invoke();
        }
    }
}