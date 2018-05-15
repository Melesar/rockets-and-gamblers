using UnityEngine;
using UnityEngine.EventSystems;

namespace RocketsAndGamblers.Tutorials
{
    public class TutorialDragStep : TutorialStep, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Transform target;
        public Vector2 originArrowPosition;
        public Vector2 targetArrowPosition;
        public float pixelTolerance;

        public GameObject arrowPrefab;

        private Vector2 targetScreenPosition;        
        private TutorialDisabler disabler;
        private GameObject arrowInstance;
        private Transform arrowTransform;
        private bool isOnPosition;

        public void OnBeginDrag(PointerEventData eventData)
        {
            RepositionArrow(target, targetArrowPosition);
        }

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
                RepositionArrow(transform, originArrowPosition);
                return;
            }
            
            Destroy(arrowInstance);
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
            
            arrowInstance = Instantiate(arrowPrefab);
            arrowTransform = arrowInstance.transform;
            
            RepositionArrow(transform, originArrowPosition);
        }

        private void RepositionArrow(Transform parent, Vector2 localPosition)
        {
            arrowTransform.SetParent(parent);

            var arrowDirection = parent.position - parent.TransformPoint(localPosition);

            arrowTransform.localPosition = localPosition;
            arrowTransform.right = arrowDirection;
        }

        protected override void Awake()
        {
            base.Awake();
            
            disabler = GetComponent<TutorialDisabler>();
            targetScreenPosition = Camera.main.WorldToScreenPoint(target.position);
        }
    }
}