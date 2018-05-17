using Framework.RuntimeSets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "R&G/Set/Attack history")]
public class AttackHistory : RuntimeSet<AttackRecord>
{
    private List<AttackRecord> records = new List<AttackRecord>();

    protected override ICollection<AttackRecord> Collection => records;
}
