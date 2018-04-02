using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections;
using RocketsAndGamblers.Data;

namespace RocketsAndGamblers.Database
{
    [CreateAssetMenu(menuName = "R&G/Objects database")]
    public class ObjectsDatabase : ObjectsSet
    {
        [SerializeField] private List<ObjectId> objectIds;

        public ObjectIdentity Instantiate (int id, Vector3 position, Quaternion rotation)
        {
            var identity = objectIds.Find(o => o.id == id);

            if (identity == null) {
                return null;
            }

            var instance = Instantiate(identity.prefab, position, rotation);

            ClearNulls();
            Add (instance);

            return instance;
        }

        public ObjectIdentity Instantiate (ObjectId id, Vector3 position, Quaternion rotation)
        {
            return Instantiate(id.id, position, rotation);
        }

        public ObjectIdentity GetById (int id)
        {
            ClearNulls();
            return objects.Find(i => i.Id == id);
        }

        private void ClearNulls ()
        {
            objects.RemoveAll(o => o == null);
        }
    }
}

