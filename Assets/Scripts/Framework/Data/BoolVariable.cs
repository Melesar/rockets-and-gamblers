using UnityEngine;

namespace Framework.Data
{
    [CreateAssetMenu(menuName = "Framework/Variables/Bool")]
    public class BoolVariable : Variable<bool>
    {
        public void Inverse ()
        {
            Value = !Value;
        }
    }
}
