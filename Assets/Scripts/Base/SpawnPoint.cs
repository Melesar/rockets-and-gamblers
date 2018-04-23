using RocketsAndGamblers.Database;
using UnityEngine;

namespace RocketsAndGamblers
{
    [RequireComponent(typeof(ObjectIdentity))]
    public class SpawnPoint : MonoBehaviour
    {
        public GameObject Spawn (GameObject prefab)
        {
            var t = transform;
            return Instantiate(prefab, t.position, t.rotation);
        }
    }
}
