using UnityEngine;

namespace RocketsAndGamblers.Database
{
    public class ObjectIdentity : MonoBehaviour
    {
        [SerializeField] private ObjectId id;

        public int Id => id.id;

        public int RuntimeId { get; set; }
    }
}
