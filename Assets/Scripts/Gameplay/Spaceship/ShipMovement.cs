using System;
using System.Collections;
using UnityEngine;

namespace RocketsAndGamblers
{
    [RequireComponent(typeof(ShipPhysics))]
    public class ShipMovement : MonoBehaviour, IDeathListener
    {
        public float burstForce;

        public PlanetOrbit CurrentOrbit
        {
            get; set;
        }

        private ShipPhysics physics;

        public void Burst (Vector2 to)
        {
            if (CurrentOrbit == null) {
                return;
            }

            var direction = (to - physics.Position).normalized;
            physics.AddImpulseForce(direction * burstForce);

            Deattach();
        }

        public void Burst()
        {
            Burst(physics.Position + physics.ForwardDirection * 2f);
        }

        private void FixedUpdate ()
        {
            var velocity = CalculateVelocity();
            physics.Move(velocity);
        }

        private Vector2 CalculateVelocity ()
        {
            return CurrentOrbit?.GetShipDirection() ?? physics.ForwardDirection;
        }

        private void Awake ()
        {
            physics = GetComponent<ShipPhysics>();
        }

        public void OnDeath ()
        {
            Deattach();
        }

        private void Deattach ()
        {
            CurrentOrbit?.Deattach();
            CurrentOrbit = null;
        }
    }

}
