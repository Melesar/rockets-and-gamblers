using System;
using System.Threading.Tasks;
using UnityEngine;

namespace RocketsAndGamblers.Data
{
    public abstract class BaseDescriptionProvider : ScriptableObject, Interfaces.IBaseDesriptionProvider
    {
        public abstract Task<BaseDescription> GetPlayerBase (int playerId, bool isAttacking);

        public abstract Task UpdatePlayerBase (int playerId, BaseDescription newDescription);
    }
}
