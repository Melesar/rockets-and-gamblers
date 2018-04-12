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

        public new void Add (ObjectIdentity item)
        {
            //Workaround for Unity Edtor as it doesn't recreate list itself
            objects.RemoveAll(i => i == null);
            base.Add(item);
        }

        protected override ICollection<ObjectIdentity> Collection => objects;
    }
}
