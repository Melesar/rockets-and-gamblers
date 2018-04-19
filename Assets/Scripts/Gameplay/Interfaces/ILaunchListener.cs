using UnityEngine.EventSystems;

namespace RocketsAndGamblers
{
    public interface ILaunchListener : IEventSystemHandler
    {
        void Launch();
    }
}