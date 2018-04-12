using System;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class PlayerReset : MonoBehaviour, IDeathListener
    {
        private Vector2 initialPosition;
        private Quaternion initialRotation;

        private Rigidbody2D rb;

        public void OnDeath ()
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;

            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
        }

        private void Start ()
        {
            initialPosition = transform.position;
            initialRotation = transform.rotation;
        }

        private void Awake ()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
}
