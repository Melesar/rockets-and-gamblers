using Framework.EventListeners;
using UnityEngine;

namespace RocketsAndGamblers.Data
{
    public class GameStateTracker : MonoBehaviour
    {
        [SerializeField] private GameStateReference gameState;
        [SerializeField] private GameState trackedState;
        [SerializeField] private bool inverseValue;

        [SerializeField] private BoolUnityEvent onStateChanged;

        private void OnStateChanged(GameState oldState, GameState newState)
        {
            if (oldState != trackedState && newState == trackedState) {
                onStateChanged.Invoke(!inverseValue);  //State became active
            } else if (oldState == trackedState && newState != trackedState) {
                onStateChanged.Invoke(inverseValue); //State deactivated
            }
        }
        
        private void Awake()
        {
            gameState.valueChanged += OnStateChanged;
        }

        private void OnDestroy()
        {
            gameState.valueChanged -= OnStateChanged;
        }
    }
}