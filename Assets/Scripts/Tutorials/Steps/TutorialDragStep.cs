using Effects;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RocketsAndGamblers.Tutorials
{
    public class TutorialDragStep : TutorialStep, IDragHandler, IEndDragHandler
    {
        public Transform target;
        public Vector2 originArrowPosition;
        public Vector2 targetArrowPosition;
        public float pixelTolerance;

        public GameObject arrowPrefab;
        public TutorialLineRendering linePrefab;

        private Vector2 targetScreenPosition;        
        private TutorialDisabler disabler;
        
        private GameObject originalArrowInstance;
        private GameObject targetArrowInstance;
        private TutorialLineRendering lineInstance;

        private bool isOnPosition;

        public void OnDrag(PointerEventData eventData)
        {
            if (Vector2.Distance(eventData.position, targetScreenPosition) < pixelTolerance) {
                transform.position = target.position;
                isOnPosition = true;
            } else {
                isOnPosition = false;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!isOnPosition) {
                UpdateMarkers();
                return;
            }
            
            Destroy(originalArrowInstance);
            Destroy(targetArrowInstance);
            Destroy(lineInstance.gameObject);
            
            NextStep();
            
            if (disabler != null) {
                disabler.IsDisabled = true;
            }
        }
        
        protected override void OnTutorialStep()
        {
            if (disabler != null) {
                disabler.IsDisabled = false;
            }
            
            target.SetParent(null);

            originalArrowInstance = Instantiate(arrowPrefab);
            targetArrowInstance = Instantiate(arrowPrefab);
            lineInstance = Instantiate(linePrefab);

            UpdateMarkers();
        }

        private void UpdateMarkers()
        {
            RepositionArrow(originalArrowInstance.transform, transform, originArrowPosition);
            RepositionArrow(targetArrowInstance.transform, target, targetArrowPosition);
            ResetLine();
        }

        private void ResetLine()
        {
            var startPos = transform.position;
            var endPos = target.position;

            lineInstance.SetLinePositions(startPos, endPos);
        }
        
        private void RepositionArrow(Transform arrow, Transform parent, Vector2 localPosition)
        {
            var arrowDirection = parent.position - parent.TransformPoint(localPosition);

            arrow.localPosition = parent.TransformPoint(localPosition);
            arrow.right = arrowDirection;
        }

        protected override void Awake()
        {
            base.Awake();
            
            disabler = GetComponent<TutorialDisabler>();
            targetScreenPosition = Camera.main.WorldToScreenPoint(target.position);
        }
    }
}