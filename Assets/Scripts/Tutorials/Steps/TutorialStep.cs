using Framework.EventListeners;
using Framework.Events;
using UnityEngine;
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
        
        protected virtual void Awake()
        {
            if (!TutorialUtility.IsTutorialRunning()) {
                Destroy(this);
                return;
            }
            
            transition.RegisterInput(OnTutorialStep);
        }
    }
}