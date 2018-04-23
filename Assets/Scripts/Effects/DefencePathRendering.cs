using UnityEngine;

namespace RocketsAndGamblers.Effects
{
    [RequireComponent(typeof(LineRenderer))]
    public class DefencePathRendering : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        private Vector3[] linePoints;

        private int pointsCount;

        private void UpdateLine ()
        {
            for (int i = 0; i < pointsCount; i++) {
                var child = transform.GetChild(i);
                linePoints[i] = child.localPosition;
            }

            lineRenderer.SetPositions(linePoints);
        }

        private void Update()
        {
            UpdateLine();
        }

        private void Awake ()
        {
            lineRenderer = GetComponent<LineRenderer>();
            pointsCount = transform.childCount;
            linePoints = new Vector3[pointsCount];

            lineRenderer.positionCount = pointsCount;
        }
    }
}