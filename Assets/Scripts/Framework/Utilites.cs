using UnityEngine;

namespace Framework
{
    public static class Utilites
    {
        public static bool ContainsLayer (this LayerMask mask, int layer)
        {
            var collidedLayerMask = 1 << layer;
            return collidedLayerMask == (mask & collidedLayerMask);
        }
    }
}
