using Framework.EventListeners;
using Framework.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RocketsAndGamblers.Tutorials
{
    public abstract class TutorialStep : MonoBehaviour
    {
        [SerializeField] private TutorialTransition transition;

        protected abstract void OnTutorialStep();

        protected void NextStep()
        {
            transition.OnOutput();
        }

        protected void SetInput(UnityAction input)
        {
            transition.RegisterInput(input);
        }
        
        protected virtual void Awake()
        {
            if (!TutorialUtility.IsTutorialRunning()) {
                Destroy(this);
                return;
            }
            
            SetInput(OnTutorialStep);
        }
    }
}