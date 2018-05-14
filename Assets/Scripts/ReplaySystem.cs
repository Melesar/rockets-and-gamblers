using System.Collections.Generic;
using UnityEngine;

namespace RocketsAndGamblers
{ public class Replay{
        private Vector2 cords;
        private float t;

        public Replay(Vector2 cords, float t)
        {
            this.cords = cords;
            this.t = t;
        }
    }
    public class TestInput : MonoBehaviour
    {
        private float StartTime;
        private List<Replay> coords = new List<Replay>();

        
        void Start()
        {
            StartTime = Time.time;
        }
        public void OnTouch(Vector2 touchCoords)
        {
            coords.Add(new Replay(touchCoords, Time.time - StartTime));
            Debug.Log(touchCoords);
            Debug.Log(Time.time - StartTime);
        }
    }
   
}