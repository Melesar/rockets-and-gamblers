using Framework.RuntimeSets;
using RocketsAndGamblers.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RocketsAndGamblers.Data
{
    [CreateAssetMenu(menuName = "R&G/Set/Objects set")]
    public class ObjectsSet : RuntimeSet<ObjectIdentity>
    {
        protected List<ObjectIdentity> objects
            = new List<ObjectIdentity>();

        protected override ICollection<ObjectIdentity> Collection => objects;
    }
}
