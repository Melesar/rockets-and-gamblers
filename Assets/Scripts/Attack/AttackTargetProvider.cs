using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Data;
using UnityEngine;

namespace RocketsAndGamblers
{
    public abstract class AttackTargetProvider : ScriptableObject
    {
        public StringVariable attackedPlayerId;
        
        public async Task<string> GetAttackTargetId()
        {
            attackedPlayerId.Value = await GetTargetId();
            return attackedPlayerId;
        }

        protected abstract Task<string> GetTargetId();
    }
}
