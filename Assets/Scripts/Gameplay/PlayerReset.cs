using System;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class PlayerReset : MonoBehaviour, IDeathListener, ISuccessfullAttemptListener
    {
        private Vector2 initialPosition;
        private Quaternion initialRotation;

        private Rigidbody2D rb;

        public void OnDeath ()
        {
            ResetPlayer();
        }

        public void OnSuccessfullSavingAttempt ()
        {
            ResetPlayer();
        }

        private void ResetPlayer ()
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
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
