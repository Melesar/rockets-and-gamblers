using UnityEngine;
using UnityEngine.Events;

namespace RocketsAndGamblers
{
    [System.Serializable]
    public class PositionEvent : UnityEvent<Vector2>
    {
    }

    public class ShipControls : MonoBehaviour
    {
        [SerializeField] private PositionEvent onTouch;

        private Camera mainCamera;

        private void Update ()
        {
            TrackTouch();
        }

        private void TrackTouch ()
        {
            if (!Input.GetMouseButtonDown(0)) {
                return;
            }

            var touchCoords = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            onTouch.Invoke(touchCoords);
        }

        private void Awake ()
        {
            mainCamera = Camera.main;
        }
    }
}
