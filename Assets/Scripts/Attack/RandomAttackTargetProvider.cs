using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RocketsAndGamblers
{
    [CreateAssetMenu(menuName = "R&G/Attack provider/Random")]
    public class RandomAttackTargetProvider : AttackTargetProvider
    {
        [Header("Indicies range")]
        public int minId;
        public int maxId;

        public override async Task<int> GetAttackTargetId ()
        {
            return UnityEngine.Random.Range(minId, maxId + 1);
        }
    }
}
