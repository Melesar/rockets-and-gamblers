using Framework.References;
using RocketsAndGamblers.Data;
using RocketsAndGamblers.Database;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace RocketsAndGamblers
{
    public class DefenceLayoutSnapping : DefenceLayoutBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public ObjectsSet objectsToSnap;

        [Tooltip("Sprite to be rendered with low opacity while not poining to any object to snap")]
        public Sprite mockupSprite;

        private bool isSnapped;

        private Vector2 currentSnapPosition;
        private Vector2 snapPosition;

        private Transform mockupTransform;
        private ObjectIdentity snappedObject;
        private Camera mainCamera;

        public event UnityAction<ObjectIdentity> snapped;

        public void OnBeginDrag (PointerEventData eventData)
        {
            if (!isEditingBase) {
                return;
            }

            SetActiveMockup(true);
            SetActiveObjects(true);
        }

        public void OnDrag (PointerEventData eventData)
        {
            if (!isEditingBase) {
                return;
            }

            var pointPosition = ScreenToWorldPoint(eventData.position);
            mockupTransform.position = pointPosition;

            var objectPointed = RaycastAgainstObjects(pointPosition);
            if (objectPointed != null && !isSnapped) {
                SnapTo(objectPointed);
                SetActiveMockup(false);
            } else if (isSnapped && objectPointed == null) {
                RevertSnapping();
                SetActiveMockup(true);
            }
        }

        public void OnEndDrag (PointerEventData eventData)
        {
            if (!isEditingBase) {
                return;
            }

            if (isSnapped) {
                ApplySnapping();
            } else {
                RevertSnapping();
            }

            SetActiveMockup(false);
            SetActiveObjects(false);
        }

        private void SnapTo (ObjectIdentity @object)
        {
            isSnapped = true;

            snappedObject = @object;
            var objectTransform = snappedObject.transform;

            snapPosition = objectTransform.position;
            transform.position = snapPosition;
        }

        private void ApplySnapping ()
        {
            IsDirty = true;
            isSnapped = false;
            currentSnapPosition = snapPosition;
            transform.position = snapPosition;

            snapped?.Invoke(snappedObject);
            snappedObject = null;
        }

        private void RevertSnapping ()
        {
            isSnapped = false;
            transform.position = currentSnapPosition;
            snappedObject = null;
        }

        private void SetActiveMockup (bool isActive)
        {
            mockupTransform.gameObject.SetActive(isActive);
        }

        private void SetActiveObjects (bool isActive)
        {
            var deactivators = objectsToSnap
                .Select(o => o.GetComponent<EditTimeDeactivator>())
                .Where(d => d != null);
            
            foreach (var item in deactivators) {
                item.SetActive(isActive);
            }
        }

        private readonly RaycastHit2D[] results = new RaycastHit2D[2];

        private ObjectIdentity RaycastAgainstObjects (Vector2 origin)
        {
            var hitsNum = Physics2D.RaycastNonAlloc(origin, Vector2.zero, results);

            if (hitsNum == 0) {
                return null;
            }

            foreach (var hit in results) {
                var objectId = hit.collider.GetComponent<ObjectIdentity>();
                if (objectsToSnap.Contains(objectId)) {
                    return objectId;
                }
            }

            return null;
        }

        private void CreateMockup ()
        {
            var go = new GameObject ("mockup");
            go.SetActive(false);

            var spriteRenderer = go.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = mockupSprite;
            spriteRenderer.sortingLayerName = "Interactive";

            var color = new Color (1, 1, 1, 0.6f);
            spriteRenderer.color = color;

            mockupTransform = go.transform;
            mockupTransform.SetParent(transform);
            mockupTransform.localPosition = Vector3.zero;
        }

        private Vector2 ScreenToWorldPoint (Vector2 screenPoint)
        {
            return mainCamera.ScreenToWorldPoint(screenPoint);
        }

        private void Start ()
        {
            CreateMockup();
        }

        protected override void Awake ()
        {
            base.Awake();
            
            mainCamera = Camera.main;
            currentSnapPosition = transform.position;
            originalPosition = currentSnapPosition;
        }
    }
}

