using UnityEngine;

namespace RocketsAndGamblers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShipPhysics : MonoBehaviour
    {
        public float maxSpeed;

        public Vector2 Position => rb.position;
        public Vector2 ForwardDirection => rb.GetRelativeVector(Vector3.right);

        private Rigidbody2D rb;
        private Vector2 slowVelocity;

        private float maxSpeedThreshold;

        public void Move (Vector2 direction)
        {
            CalclulateVelocity(direction);
            RotateShip();
        }

        public void AddImpulseForce (Vector2 force)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        private void CalclulateVelocity (Vector2 direction)
        {
            if (rb.velocity.magnitude > maxSpeedThreshold) {
                var targetVelocity = rb.velocity.normalized * maxSpeed;
                rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref slowVelocity, 1f, 1000f, Time.deltaTime);
            } else {
                rb.velocity = direction.normalized * maxSpeed;
            }

            //Debug.Log(Vector2.Dot(rb.velocity.normalized, direction.normalized));
        }

        private void RotateShip ()
        {
            var angle = Vector2.Angle(Vector2.right, rb.velocity);
            angle = rb.velocity.y < 0 ? -angle : angle;
            rb.rotation = angle;
        }

        private void Awake ()
        {
            rb = GetComponent<Rigidbody2D>();
            maxSpeedThreshold = maxSpeed + 0.4f;
        }
    }
}
