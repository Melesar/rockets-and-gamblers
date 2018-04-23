using RocketsAndGamblers.Database;
using UnityEngine;

namespace RocketsAndGamblers.Data
{
    [RequireComponent(typeof(ObjectIdentity))]
    public abstract class AdditionalDataProvider : MonoBehaviour
    {
        private ObjectIdentity objectId;

        public AdditionalData GetAdditionalData()
        {
            var id = objectId ?? GetComponent<ObjectIdentity>();
            return new AdditionalData {
                objectRuntimeId = id.RuntimeId,
                data = SerializeToString()
            };
        }
    
        public abstract void InitFromString(string data);

        protected abstract string SerializeToString();

        protected virtual void Awake()
        {
            objectId = GetComponent<ObjectIdentity>();
        }
    }
}