using UnityEngine;
using System.Collections;
using System.Linq;

public class PlanetOrbit : MonoBehaviour
{
    public float gravityForce = 2f;
    public LayerMask layerMask;

    private CircleCollider2D orbitCollider;
    private DistanceJoint2D joint;
    private Rigidbody2D rb;
    private Rigidbody2D shipRb;

    public Vector2 GetShipDirection (Vector2 shipPosition)
    {
        var toAnchor = rb.position - shipRb.position;
        var forceDirection = Vector3.Cross(toAnchor, -Vector3.forward).normalized;
        var shipDirection = shipRb.GetRelativeVector(Vector3.right);

        return (Mathf.Abs(Vector2.Dot(forceDirection, shipDirection)) > 0.97f)
            ? (Vector2) forceDirection
            : shipDirection;

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (!Framework.Utilites.ContainsLayer(layerMask, collision.gameObject.layer)) {
            return;
        }
        //Debug.Log("Enter");

        shipRb = collision.GetComponent<Rigidbody2D>();
        joint.connectedBody = shipRb;
        collision.GetComponent<ShipMovement>().CurrentOrbit = this;
        //joint.distance = orbitCollider.radius;
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        //Debug.Log("Exit");

        //joint.connectedBody = null;
        //joint = null;
    }

    private void Awake ()
    {
        orbitCollider = GetComponents<CircleCollider2D>().FirstOrDefault(c => c.isTrigger);
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<DistanceJoint2D>();
    }
}
