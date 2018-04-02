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

        private void Awake ()
        {
            var identity = GetComponent<ObjectIdentity>();
            set.Add(identity);
        }
    }
}
