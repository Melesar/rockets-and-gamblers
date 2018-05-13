using System;
using Framework.References;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RocketsAndGamblers
{
    public class DefenceLayoutMoving : DefenceLayoutBehaviour, IDragHandler, IBeginDragHandler
    {
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

        protected override void Awake ()
        {
            base.Awake();
            
            mainCamera = Camera.main;
        }
    }
}
