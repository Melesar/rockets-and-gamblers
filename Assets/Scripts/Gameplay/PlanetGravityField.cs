using UnityEngine;
using UnityEngine.Events;

public class PlanetGravityField : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layers;

    private bool isSomethingInside;
    private Rigidbody2D objectInside;

    public event UnityAction<Rigidbody2D> Enter;
    public event UnityAction<Rigidbody2D> Exit;

    public float Radius => radius;

    private void FixedUpdate ()
    {
        var collidersHit = Physics2D.OverlapCircle(transform.position, Radius, layers);
        if (!collidersHit && isSomethingInside) {
            Exit?.Invoke(objectInside);
            isSomethingInside = false;
            objectInside = null;
        } else if (collidersHit && !isSomethingInside){
            objectInside = collidersHit.attachedRigidbody;
            Enter?.Invoke(objectInside);
            isSomethingInside = true;
        }
    }

    private void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
