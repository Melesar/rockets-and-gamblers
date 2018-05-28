using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RocketsAndGamblers.Replay
{
    [System.Serializable]
    public class InputData
    {
        public Vector2 cords;
        public float t;

        public InputData(Vector2 cords, float t)
        {
            this.cords = cords;
            this.t = t;
        }
    }
    [System.Serializable]
    public class Replay
    {
        //TODO Encapsulate this
        public List<InputData> inputs = new List<InputData>();
        
        public void AddToList(InputData r)
        {
            inputs.Add(r);
        }
    }
}