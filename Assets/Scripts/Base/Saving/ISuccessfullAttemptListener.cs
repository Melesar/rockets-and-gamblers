using UnityEngine.EventSystems;

namespace RocketsAndGamblers
{
    public interface ISuccessfullAttemptListener : IEventSystemHandler
    {
        void OnSuccessfullSavingAttempt();
    }
}