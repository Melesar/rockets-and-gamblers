﻿using System.Linq;
using UnityEngine;

namespace RocketsAndGamblers
{
    [RequireComponent(typeof(PlanetGravityField))]
    public class PlanetOrbit : MonoBehaviour
    {
        private DistanceJoint2D joint;
        private Rigidbody2D rb;
        private Rigidbody2D shipRb;

        public Vector2 GetShipDirection ()
        {
            var toAnchor = rb.position - shipRb.position;
            var forceDirection = Vector3.Cross(toAnchor, -Vector3.forward).normalized;
            var shipDirection = shipRb.GetRelativeVector(Vector3.right);

            return (Mathf.Abs(Vector2.Dot(forceDirection, shipDirection)) > 0.97f)
                ? (Vector2)forceDirection
                : shipDirection;
        }

        public void Deattach ()
        {
            joint.connectedBody = null;
            shipRb = null;
        }

        private void OnGravityFieldEnter (Rigidbody2D collision)
        {
            Debug.Log("Gravity field enter");

            shipRb = collision;
            joint.connectedBody = shipRb;
            collision.GetComponent<ShipMovement>().CurrentOrbit = this;
        }

        private void Awake ()
        {
            rb = GetComponent<Rigidbody2D>();
            joint = GetComponent<DistanceJoint2D>();

            var gravityField = GetComponent<PlanetGravityField>();
            gravityField.Enter += OnGravityFieldEnter;
        }

        private void OnDestroy ()
        {
            var gravityField = GetComponent<PlanetGravityField>();
            gravityField.Enter -= OnGravityFieldEnter;
        }
    }

}
