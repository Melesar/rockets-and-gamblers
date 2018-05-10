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
        public StringVariable lastTargetId;
        
        public abstract Task<string> GetAttackTargetId ();
    }
}
