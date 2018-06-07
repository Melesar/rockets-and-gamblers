using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace RocketsAndGamblers
{
    [System.Serializable]
    public class PositionEvent : UnityEvent<Vector2>
    {
    }

    public class ShipControls : MonoBehaviour, IStopListener, ILaunchListener
    {
        [SerializeField] private PositionEvent onTouch;

        private EventSystem eventSystem;
        private Camera mainCamera;

        private bool isStopped;

        private void Update ()
        {
            TrackTouch();
        }

        private void TrackTouch ()
        {
            if (isStopped) {
                return;
            }

            if (!Input.GetMouseButtonDown(0)) {
                return;
            }

            if (IsPointerOverUIObject()) {
                return;
            }

            var touchCoords = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            onTouch.Invoke(touchCoords);
        }
        
        private bool IsPointerOverUIObject() 
        {
            var eventDataCurrentPosition = new PointerEventData(eventSystem) {
                position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
            };
            
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }

        private void Awake ()
        {
            mainCamera = Camera.main;
            eventSystem = EventSystem.current;
        }

        public void Stop()
        {
            isStopped = true;
        }

        public void Launch()
        {
            isStopped = false;
        }
    }
}
