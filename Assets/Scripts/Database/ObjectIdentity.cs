using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RocketsAndGamblers.Database
{
    public class ObjectIdentity : MonoBehaviour
    {
        [SerializeField] private ObjectId id;

        public int Id => id.id;



        private void Start ()
        {
            foreach (var id in FindObjectsOfType<ObjectId>()) {
                Debug.Log(id.id);
            }
        }
    }
}
