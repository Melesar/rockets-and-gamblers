using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RocketsAndGamblers
{
    public abstract class AttackTargetProvider : ScriptableObject
    {
        public abstract Task<int> GetAttackTargetId ();
    }
}
