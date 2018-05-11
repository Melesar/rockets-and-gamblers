using System.Runtime.InteropServices;
using RocketsAndGamblers.Data;
using RocketsAndGamblers.Effects;
using UnityEngine;
using UnityEngine.Timeline;

namespace DefaultNamespace
{
    public class CircleRenderer : MonoBehaviour, IImmidiateGraphics
    {
        [SerializeField] private ImmidiateGraphicsSet set;
        
        [Header("Rendering")]
        [SerializeField] private Material mat;
        [SerializeField] private Color color;
        
        [Header("Parameters")]
        [SerializeField] private float radius;
        [SerializeField] private float thickness;
        [SerializeField, Range(1, 10)] private int segmentsCount;
        [SerializeField] private float gapLenght;
        [SerializeField] private float rotationSpeed;
        [SerializeField, Range(0.01f, 1f)] private float angleStep;

        private float segmentLenght;
        private float currentAngle;
        private Vector3 center;

        private const float DoublePI = 2f * Mathf.PI;
        
        public void OnPostRender()
        {
            RenderCircle();
        }
        
        private void RenderCircle()
        {
            mat.SetPass(0);
            GL.Begin(GL.QUADS);
            GL.Color(color);

            currentAngle = Mathf.Repeat(currentAngle + rotationSpeed * Time.deltaTime, DoublePI);
            for (int i = 0; i < segmentsCount; i++) {
                var segmentEnd = currentAngle + segmentLenght;
                for (float angle = currentAngle; angle < segmentEnd; angle += angleStep) {
                    DrawCircleSegment(angle);                                        
                }

                currentAngle = segmentEnd + gapLenght;
            }
                
            
            GL.End();
        }

        private void DrawCircleSegment(float angle)
        {
            var v1 = center + GetOffset(radius, angle);
            var v2 = center + GetOffset(radius + thickness, angle);
            var v3 = center + GetOffset(radius + thickness, angle + angleStep);
            var v4 = center + GetOffset(radius, angle + angleStep);
            
            GL.Vertex(v1);
            GL.Vertex(v2);
            GL.Vertex(v3);
            GL.Vertex(v4);
        }

        private Vector3 GetOffset(float radius, float angle)
        {
            return new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));
        }

//        private void OnValidate()
//        {
//            segmentLenght = DoublePI / segmentsCount - gapLenght;
//        }

        private void Awake()
        {
            center = transform.position;
            segmentLenght = DoublePI / segmentsCount - gapLenght;

            set.Add(this);
        }
    }
}