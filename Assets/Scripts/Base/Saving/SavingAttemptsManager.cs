using Framework.Data;
using Framework.Events;
using Framework.References;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class SavingAttemptsManager : MonoBehaviour
    {
        [SerializeField] private IntReference attemptsCount;
        [SerializeField] private IntReference attemptsRequired;

        [SerializeField] private GameEvent onSavingSuccessfull;

        public void OnPlayerDead()
        {
            attemptsCount.Value = 0;
        }

        public void OnAttackSuccessfull()
        {
            attemptsCount.Value += 1;

            if (attemptsCount.Value == attemptsRequired) {
                onSavingSuccessfull.Raise();
            }    
        }
    }
}