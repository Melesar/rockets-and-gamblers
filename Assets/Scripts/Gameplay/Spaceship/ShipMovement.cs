using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed;

    public PlanetOrbit CurrentOrbit { get; set; }

    private Vector3 velocity;

    private Rigidbody2D rb;

    private void FixedUpdate ()
    {
        CalculateVelocity();

        rb.velocity = velocity;

        //if (!IsMatchVelocity()) {
        //    rb.AddForce(velocity);
        //}

        var angle = Vector2.Angle(Vector2.right, rb.velocity);
        angle = rb.velocity.y < 0 ? -angle : angle;
        rb.rotation = angle;
    }

    private void CalculateVelocity ()
    {
        var direction = CurrentOrbit?.GetShipDirection(rb.position) ?? rb.GetRelativeVector(Vector3.right);

        velocity = direction.normalized * speed;
    }

    private bool IsMatchVelocity ()
    {
        var targetSpeed = velocity.magnitude;
        var currentSpeed = rb.velocity.magnitude;

        var isSpeedMatch = Mathf.Abs(targetSpeed - currentSpeed) < 0.01;
        var isDirectionMatch = Vector2.Dot(velocity, rb.velocity) / targetSpeed / currentSpeed < 0.05f;

        return isSpeedMatch && isDirectionMatch;
    }

    private void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
