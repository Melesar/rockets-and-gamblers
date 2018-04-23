using Framework.Data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RocketsAndGamblers
{
    public class SuccessfullAttemptHandler : MonoBehaviour
    {
        public BoolVariable isTryingToSaveBase;

        public void OnAttackSuccessfull()
        {
            if (!isTryingToSaveBase) {
                return;
            }

            ExecuteEvents.Execute<ISuccessfullAttemptListener>(gameObject, null,
                (handler, data) => handler.OnSuccessfullSavingAttempt());
        }
    }
}