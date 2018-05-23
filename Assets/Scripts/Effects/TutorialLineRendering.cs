using UnityEngine;

namespace Effects
{
    public class TutorialLineRendering : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        
        private readonly Vector3[] positions = new Vector3[2];
        
        public void SetLinePositions(Vector3 start, Vector3 end)
        {
            positions[0] = start;
            positions[1] = end;

            lineRenderer.SetPositions(positions);
            
            SetTextureOffset();
        }

        private void SetTextureOffset()
        {
            
        }

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
    }
}