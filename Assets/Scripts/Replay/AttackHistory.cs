using System.Collections.Generic;
using Framework.RuntimeSets;
using RocketsAndGamblers.Server;
using UnityEngine;

namespace RocketsAndGamblers.Replay
{
    [CreateAssetMenu(menuName = "R&G/Set/Attack history")]
    public class AttackHistory : RuntimeSet<AttackRecord>
    {
        private readonly List<AttackRecord> records = new List<AttackRecord>();

        protected override ICollection<AttackRecord> Collection => records;
    }
}