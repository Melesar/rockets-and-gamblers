using RocketsAndGamblers.Effects;
using UnityEngine;

namespace RocketsAndGamblers
{
    [RequireComponent(typeof(ShipMovement), typeof(ShipPhysics))]
    public class InitialLaunch : MonoBehaviour, IAfterVFXListener//, ISuccessfullAttemptListener, IDeathListener
    {
        private ShipPhysics physics;
        private ShipMovement movement;

        private float burstForce;
        private bool isEnabled = true;

        public void Enable()
        {
            isEnabled = true;
        }

        private void Update()
        {
            if (!isEnabled) {
                return;
            }

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

            isEnabled = false;
        }

        public void OnSuccessfullSavingAttempt ()
        {
            Enable();
        }

        public void OnDeath ()
        {
            Enable();
        }

        private void Awake()
        {
            physics = GetComponent<ShipPhysics>();
            movement = GetComponent<ShipMovement>();

            burstForce = movement.burstForce;
        }

        public void AfterVFX()
        {
            Enable();
        }
    }
}