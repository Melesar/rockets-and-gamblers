using RocketsAndGamblers.Effects;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RocketsAndGamblers
{
    [RequireComponent(typeof(ShipMovement), typeof(ShipPhysics))]
    public class InitialLaunch : MonoBehaviour, IAfterVFXListener, ISuccessfullAttemptListener
    {
        public PositionEvent onLaunch;

        private ShipPhysics physics;
        private ShipMovement movement;

        private bool isEnabled = true;
        private EventSystem eventSystem;

        public void Enable()
        {
            isEnabled = true;
        }

        private void Update()
        {
            if (!isEnabled) {
                return;
            }

            if (Input.GetMouseButtonDown(0) && !eventSystem.IsPointerOverGameObject()) {
                LaunchAndDisable();
            }
        }

        private void LaunchAndDisable()
        {
            movement.Launch();

            var to = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var direction = (to - physics.Position).normalized;
            physics.AddImpulseForce(direction);

            isEnabled = false;

            onLaunch.Invoke(to);
        }

        public void OnSuccessfullSavingAttempt ()
        {
            Enable();
        }

        private void Awake()
        {
            physics = GetComponent<ShipPhysics>();
            movement = GetComponent<ShipMovement>();
            eventSystem = EventSystem.current;
        }

        public void AfterVFX()
        {
            Enable();
        }
    }
}