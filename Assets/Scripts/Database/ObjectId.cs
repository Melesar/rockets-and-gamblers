using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RocketsAndGamblers.Database
{
    [CreateAssetMenu(menuName = "R&G/Object id")]
    public class ObjectId : ScriptableObject
    {
        public int id;
        public ObjectIdentity prefab;
    }
}
