using RocketsAndGamblers.Data;
using UnityEngine;

namespace RocketsAndGamblers
{
    [CreateAssetMenu(menuName = "R&G/Base properties")]
    public class BaseProperties : ScriptableObject
    {
        public int goldMiningLimit;
        public int omoniumVeinsMax;

        public BaseDescriptionProvider provider;
    }
}
