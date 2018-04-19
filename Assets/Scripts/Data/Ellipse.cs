using UnityEngine;

namespace RocketsAndGamblers.Data
{
    public class Ellipse : MonoBehaviour
    {
        public float Height { get; set; }
        public float Width { get; set; }

        private Vector2 Center => transform.position;

        public Vector2 GetPoint (float t)
        {
            var x = Mathf.Cos(2f * t * Mathf.PI);
            var y = Mathf.Sin(2f * t * Mathf.PI);

            Vector2 offset = Width * x * transform.right + Height * y * transform.up;
            return Center + offset;
        }
    }
}