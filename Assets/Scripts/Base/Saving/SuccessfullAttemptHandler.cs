using Framework.Data;
using RocketsAndGamblers.Data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RocketsAndGamblers
{
    public class SuccessfullAttemptHandler : MonoBehaviour
    {
        public GameState stateToOperateIn;

        public void OnAttackSuccessfull()
        {
            if (!stateToOperateIn.IsCurrent) {
                return;
            }

            ExecuteEvents.Execute<ISuccessfullAttemptListener>(gameObject, null,
                (handler, data) => handler.OnSuccessfullSavingAttempt());
        }
    }
}