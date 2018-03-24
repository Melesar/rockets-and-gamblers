using UnityEngine;
using System.Collections.Generic;

namespace Framework.Input.Data
{
    [System.Serializable]
    public struct PlayerControlData
    {
        [SerializeField]
        private List<InputAxisData> axisData;

        public float GetAxis(string axisName) 
        {
            return axisData?.Find(data => data.axisName == axisName).axisValue ?? 0f;
        }

        public void AddAxisData (string axisName, float axisValue)
        {
            if (axisData == null) {
                axisData = new List<InputAxisData>();
            }

            axisData.Add(new InputAxisData(axisName, axisValue));
        }

        public void Clear()
        {
            axisData.Clear();
        }
    }

    [System.Serializable]
    public struct InputAxisData
    {
        public string axisName;
        public float axisValue;

        public InputAxisData (string axisName, float axisValue)
        {
            this.axisName = axisName;
            this.axisValue = axisValue;
        }
    }
}