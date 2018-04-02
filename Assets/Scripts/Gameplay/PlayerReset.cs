using System;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class PlayerReset : MonoBehaviour, IDeathListener
    {
        private Vector2 initialPosition;
        private Quaternion initialRotation;

        public void OnDeath ()
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
        }

        private void Start ()
        {
            initialPosition = transform.position;
            initialRotation = transform.rotation;
        }
    }
}
