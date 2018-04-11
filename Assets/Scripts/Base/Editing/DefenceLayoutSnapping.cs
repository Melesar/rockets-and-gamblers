﻿using RocketsAndGamblers.Data;
using RocketsAndGamblers.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Linq;

namespace RocketsAndGamblers
{
    public class DefenceLayoutSnapping : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public ObjectsSet objectsToSnap;

        [Tooltip("Sprite to be rendered with low opacity while not poining to any object to snap")]
        public Sprite mockupSprite;

        private bool isSnapped;

        private Vector2 originalPosition;
        private Vector2 snapPosition;

        private Transform mockupTransform;
        private Camera mainCamera;

        public void OnBeginDrag (PointerEventData eventData)
        {
            SetActiveMockup(true);
            SetActiveObjects(true);
        }

        public void OnDrag (PointerEventData eventData)
        {
            var pointPosition = ScreenToWorldPoint(eventData.position);
            mockupTransform.position = pointPosition;;

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

            var objectTransform = @object.transform;

            snapPosition = objectTransform.position;
            transform.position = snapPosition;
        }

        private void ApplySnapping ()
        {
            isSnapped = false;
            originalPosition = snapPosition;
            transform.position = snapPosition;
        }

        private void RevertSnapping ()
        {
            isSnapped = false;
            transform.position = originalPosition;
        }

        private void SetActiveMockup (bool isActive)
        {
            mockupTransform.gameObject.SetActive(isActive);
        }

        private void SetActiveObjects (bool isActive)
        {
            var deactivators = objectsToSnap.Select(o => o.GetComponent<EditTimeDeactivator>());
            foreach (var item in deactivators) {
                item.SetActive(isActive);
            }
        }

        private RaycastHit2D[] results = new RaycastHit2D[2];

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

        private void Awake ()
        {
            mainCamera = Camera.main;
            originalPosition = transform.position;
        }
    }
}

