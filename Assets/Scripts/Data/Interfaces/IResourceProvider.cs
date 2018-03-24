using UnityEngine.Events;
using System.Threading.Tasks;

namespace RocketsAndGamblers.Data.Interfaces
{
    public class ResourceResponse
    {
        public int newResourceAmount;
    }

    public interface IResourceProvider
    {
        Task<int> GetResourceAmount(int playerId);

        void UpdateResourceAmount (int playerId, int newResourceAmount, UnityAction<ResourceResponse> callback);
    }
}