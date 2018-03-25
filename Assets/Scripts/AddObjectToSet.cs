using UnityEngine;
using System.Collections;
using RocketsAndGamblers.Database;
using RocketsAndGamblers.Data;

namespace RocketsAndGamblers
{
    [RequireComponent(typeof(ObjectIdentity))]
    public class AddObjectToSet : MonoBehaviour
    {
        public ObjectsSet set;

        private ObjectIdentity identity;

        private void Start ()
        {
            set.Add(identity);
        }

        private void Awake ()
        {
            identity = GetComponent<ObjectIdentity>();
        }
    }
}
