using UnityEngine;

namespace Framework
{
    public class ObjectDestroyer : MonoBehaviour
    {
        public float delay;

        public void Destroy()
        {
            Destroy(gameObject, delay);
        }
    }
}