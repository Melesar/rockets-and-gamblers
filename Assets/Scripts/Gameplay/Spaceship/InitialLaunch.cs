using UnityEngine;

namespace RocketsAndGamblers
{
    [RequireComponent(typeof(ShipMovement), typeof(ShipPhysics))]
    public class InitialLaunch : MonoBehaviour
    {
        private ShipPhysics physics;

        private float burstForce;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) {
                LaunchAndDisable();
            }
        }

        private void LaunchAndDisable()
        {
            var to = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var direction = (to - physics.Position).normalized;
            physics.AddImpulseForce(direction * burstForce);

            enabled = false;
        }

        private void Awake()
        {
            physics = GetComponent<ShipPhysics>();
            burstForce = GetComponent<ShipMovement>().burstForce;
        }
    }
}