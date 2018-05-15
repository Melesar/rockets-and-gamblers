using Framework.UI;

namespace RocketsAndGamblers.Tutorials
{
    public class TutorialTextStep : TutorialStep
    {
        private Window window;

        public void OnTap()
        {
            window.Close();
            NextStep();
        }
        
        protected override void OnTutorialStep()
        {
            window.Open();        
        }

        protected override void Awake()
        {
            base.Awake();
            window = GetComponent<Window>();
        }
    }
}