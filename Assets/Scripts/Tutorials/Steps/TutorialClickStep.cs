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

        private TutorialDisabler disabler;
        private GameObject arrowInstance;
        
        public void OnClick()
        {            
            if (disabler != null) {
                disabler.IsDisabled = true;
            }

            Destroy(arrowInstance);
            NextStep();
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (mockupClickAction) {
                mockupOnClick.Invoke();
            }
        }
        
        protected override void OnTutorialStep()
        {
            if (!mockupClickAction && disabler != null) {
                disabler.IsDisabled = false;
            }
            
            InstantiateArrow();
        }

        private void InstantiateArrow()
        {
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