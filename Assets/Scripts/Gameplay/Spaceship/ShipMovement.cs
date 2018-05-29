using System;
using System.Collections;
using RocketsAndGamblers.Effects;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RocketsAndGamblers
{
    [RequireComponent(typeof(ShipPhysics))]
    public class ShipMovement : MonoBehaviour, IDeathListener, IAfterVFXListener, ISuccessfullAttemptListener
    {
        public IOrbit CurrentOrbit
        {
            get; set;
        }

        private ShipPhysics physics;
        private bool isStopped;

        public void Burst (Vector2 to)
        {
            if (isStopped || CurrentOrbit == null) {
                return;
            }

            var direction = (to - physics.Position).normalized;
            physics.AddImpulseForce(direction);

            Deattach();
        }

        public void Burst()
        {
            Burst(physics.Position + physics.ForwardDirection * 2f);
        }

        public void Land()
        {
            CurrentOrbit = new IntermediateOrbit();
        }

        private void FixedUpdate ()
        {
            if (isStopped) {
                return;
            }

            physics.Move();
        }

        private void Start()
        {
            Land();
            Launch();
        }

        private void Awake ()
        {
            physics = GetComponent<ShipPhysics>();
        }

        public void OnDeath ()
        {
            Deattach();
            Stop();
        }

        private void Deattach ()
        {
            CurrentOrbit?.Deattach();
            CurrentOrbit = null;
        }

        public void Launch()
        {
            isStopped = false;

            ExecuteEvents.Execute<ILaunchListener>(gameObject, null, (handler, data) => handler.Launch());
        }

        public void Stop()
        {
            isStopped = true;

            ExecuteEvents.Execute<IStopListener>(gameObject, null, (handler, data) => handler.Stop());
        }

        public void AfterVFX()
        {
            Land();
            Launch();
        }

        public void OnSuccessfullSavingAttempt()
        {
            Land();
            Launch();
        }
    }

}
