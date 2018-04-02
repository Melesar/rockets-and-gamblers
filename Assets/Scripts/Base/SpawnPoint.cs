﻿using RocketsAndGamblers.Database;
using UnityEngine;

namespace RocketsAndGamblers
{
    [RequireComponent(typeof(ObjectIdentity))]
    public class SpawnPoint : MonoBehaviour
    {
        public void Spawn (GameObject prefab)
        {
            var t = transform;
            Instantiate(prefab, t.position, t.rotation);
        }
    }
}
