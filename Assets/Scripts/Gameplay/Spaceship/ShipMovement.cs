using System.Collections;
using UnityEngine;

namespace RocketsAndGamblers
{
    [RequireComponent(typeof(ShipPhysics))]
    public class ShipMovement : MonoBehaviour
    {
        public float burstForce;

        public PlanetOrbit CurrentOrbit
        {
            get; set;
        }

        private ShipPhysics physics;

        public void Burst (Vector2 to)
        {
            var direction = (to - physics.Position).normalized;
            physics.AddImpulseForce(direction * burstForce);

            CurrentOrbit.Deattach();
            CurrentOrbit = null;
        }

        private void FixedUpdate ()
        {
            var velocity = CalculateVelocity();
            physics.Move(velocity);
        }

        private bool previousOption = false;

        private Vector2 CalculateVelocity ()
        {
            var option = CurrentOrbit != null;

            //NOT XOR
            //if ((!option || !previousOption) && (option || previousOption)) {
            //    Debug.Log("Shifted options");
            //}

            previousOption = option;
            return option ? CurrentOrbit.GetShipDirection(physics.Position) : physics.ForwardDirection;
        }

        private void Awake ()
        {
            physics = GetComponent<ShipPhysics>();
        }
    }

}
