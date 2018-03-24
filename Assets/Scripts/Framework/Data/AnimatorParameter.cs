using System;

namespace Framework.Data
{
    [Serializable]
    public struct AnimatorParameter
    {
        public AnimatorParamType type;
        public string name;

        public int intValue;
        public float floatValue;
        public bool boolValue;
        
        public enum AnimatorParamType
        {
            Int, Float, Bool, Trigger
        }
    }
}