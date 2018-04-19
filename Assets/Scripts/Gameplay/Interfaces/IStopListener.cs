using UnityEngine.EventSystems;

namespace RocketsAndGamblers
{
    public interface IStopListener : IEventSystemHandler
    {
        void Stop();
    }
}