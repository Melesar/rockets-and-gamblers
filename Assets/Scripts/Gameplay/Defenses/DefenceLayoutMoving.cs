using System;
using Framework.References;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RocketsAndGamblers
{
    public class DefenceLayoutMoving : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        public BoolReference isEditingBase;

        private Camera mainCamera;
        private Vector2 positionOffset;

        public void OnBeginDrag (PointerEventData eventData)
        {
            if (!isEditingBase) {
                return;
            }

            var worldPoint = GetWorldPosition(eventData.position);
            positionOffset = (Vector2) transform.position - worldPoint;
        }

        public void OnDrag (PointerEventData eventData)
        {
            if (!isEditingBase) {
                return;
            }

            var worldPoint = GetWorldPosition(eventData.position);
            transform.position = worldPoint + positionOffset;
        }

        private Vector2 GetWorldPosition (Vector2 screenPosition)
        {
            return mainCamera.ScreenToWorldPoint(screenPosition);
        }

        private void Awake ()
        {
            mainCamera = Camera.main;
        }
    }
}
