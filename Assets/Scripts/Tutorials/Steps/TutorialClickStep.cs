using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace RocketsAndGamblers.Tutorials
{
    public class TutorialClickStep : TutorialStep, IPointerClickHandler
    {
        public Vector2 arrowLocalPosition;
        public GameObject arrowPrefab;
        
        [Space]

        public bool mockupClickAction;
        public UnityEvent mockupOnClick;

        private bool isActive;
        private TutorialDisabler disabler;
        private GameObject arrowInstance;
        
        public void OnClick()
        {            
            if (disabler != null) {
                disabler.IsDisabled = true;
            }

            isActive = false;
            Destroy(arrowInstance);
            NextStep();
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (mockupClickAction && isActive) {
                mockupOnClick.Invoke();
            }
            
            Destroy(arrowInstance);
            NextStep();
            isActive = false;
        }
        
        protected override void OnTutorialStep()
        {
            if (!mockupClickAction && disabler != null) {
                disabler.IsDisabled = false;
            }

            isActive = true;
            InstantiateArrow();
        }

        private void InstantiateArrow()
        {
            if (arrowPrefab == null) {
                return;
            }
            
            arrowInstance = Instantiate(arrowPrefab, transform);
            arrowInstance.transform.localPosition = arrowLocalPosition;

            var direction = transform.position - arrowInstance.transform.position;
            var rotationAngle = Vector2.SignedAngle(Vector2.right, direction);

            arrowInstance.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
        }

        protected override void Awake()
        {
            base.Awake();
            disabler = GetComponent<TutorialDisabler>();
        }

        
    }
}