using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections;

namespace RocketsAndGamblers.Database
{
    [CreateAssetMenu(menuName = "R&G/Objects database")]
    public class ObjectsDatabase : ScriptableObject, IEnumerable<ObjectIdentity>
    {
        [SerializeField] private List<ObjectId> objectIds;

        private List<ObjectIdentity> instances;

        public ObjectIdentity Instantiate (int id, Vector3 position, Quaternion rotation)
        {
            var identity = objectIds.Find(o => o.id == id);

            if (identity == null) {
                return null;
            }

            var instance = Instantiate(identity.prefab, position, rotation);
            instances.Add(instance);

            return instance;
        }

        public ObjectIdentity GetById (int id)
        {
            return instances.Find(i => i.Id == id);
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return GetEnumerator();
        }

        public IEnumerator<ObjectIdentity> GetEnumerator ()
        {
            return instances.GetEnumerator();
        }
    }
}

