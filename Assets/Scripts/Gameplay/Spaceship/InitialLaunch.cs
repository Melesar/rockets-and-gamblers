using UnityEngine;

namespace RocketsAndGamblers
{
    [RequireComponent(typeof(ShipMovement), typeof(ShipPhysics))]
    public class InitialLaunch : MonoBehaviour
    {
        private ShipPhysics physics;
        private ShipMovement movement;

        private float burstForce;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) {
                LaunchAndDisable();
            }
        }

        private void LaunchAndDisable()
        {
            movement.Launch();

            var to = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var direction = (to - physics.Position).normalized;
            physics.AddImpulseForce(direction * burstForce);

            enabled = false;
        }

        private void Awake()
        {
            physics = GetComponent<ShipPhysics>();
            movement = GetComponent<ShipMovement>();

            burstForce = movement.burstForce;
        }
    }
}