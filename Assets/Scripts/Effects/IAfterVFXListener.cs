using UnityEngine.EventSystems;

namespace RocketsAndGamblers.Effects
{
    public interface IAfterVFXListener : IEventSystemHandler
    {
        void AfterVFX();
    }
}