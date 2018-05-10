using System.Linq;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace RocketsAndGamblers
{
    [RequireComponent(typeof(PlanetGravityField))]
    public class PlanetOrbit : MonoBehaviour
    {
        private DistanceJoint2D joint;
        private Rigidbody2D rb;
        private Rigidbody2D shipRb;

        public void Deattach ()
        {
            joint.connectedBody = null;
            shipRb = null;
        }

        private void OnGravityFieldEnter (Rigidbody2D collision)
        {
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

