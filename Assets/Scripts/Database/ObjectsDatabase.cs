using RocketsAndGamblers.Data;
using System.Collections.Generic;
using UnityEngine;

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

        public ObjectIdentity Instantiate(PositionData data)
        {
            var identity = objectIds.Find(o => o.id == data.id);

            if (identity == null) {
                return null;
            }

            var instance = Instantiate(identity.prefab, data.position, data.rotation);
            instance.RuntimeId = data.runtimeId;

            ClearNulls();
            Add(instance);

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


        public ObjectIdentity GetByRuntimeId(int runtimeId)
        {
            return objects.Find(i => i.RuntimeId == runtimeId);
        }

        private void ClearNulls ()
        {
            objects.RemoveAll(o => o == null);
        }
    }
}

