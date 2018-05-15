using Framework.UI;

namespace RocketsAndGamblers.Tutorials
{
    public class TutorialWindowStep : TutorialStep
    {
        private Window window;

        private TutorialSubstep[] substeps;
        private int currentSubstep;
        
        public void GoNext()
        {
            IterateSubsteps();
        }

        private void IterateSubsteps()
        {
            if (currentSubstep < substeps.Length) {
                SetInput(substeps[currentSubstep++].OnSubstep);
            } else {
                window.Close();
            }
            
            NextStep();
        }

        protected override void OnTutorialStep()
        {
            window.Open();
            
            //Directly invoke the first substep
            substeps[currentSubstep++].OnSubstep();
        }

        protected override void Awake()
        {
            base.Awake();
            
            window = GetComponent<Window>();
            substeps = GetComponents<TutorialSubstep>();
        }
    }
}