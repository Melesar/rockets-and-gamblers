using UnityEngine;
using RocketsAndGamblers.Data.Interfaces;
using System;
using System.Threading.Tasks;
using UnityEngine.Events;

using Framework.Data;
using Framework.References;

namespace RocketsAndGamblers.Data
{
    [CreateAssetMenu(menuName = "R&G/Resource provider")]
    public abstract class ResourceProvider : ScriptableObject, IResourceProvider
    {
        public IntVariable resourceVariable;
        public StringReference resourceName;

        public virtual async Task<int> GetResourceAmount (int playerId)
        {
            return 0;
        }

        public virtual void UpdateResourceAmount (int playerId, int newResourceAmount, UnityAction<ResourceResponse> callback)
        {

        }
    }
}
