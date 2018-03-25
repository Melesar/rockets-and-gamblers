using RocketsAndGamblers.Data;
using System.Collections.Generic;
using UnityEngine;

namespace RocketsAndGamblers
{
    [CreateAssetMenu(menuName = "R&G/Base properties")]
    public class BaseProperties : ScriptableObject
    {
        public int playerId;

        public int goldMiningLimit;
        public int omoniumVeinsMax;

        public List<int> availableDefenses;

        public BaseDescriptionProvider provider;
    }
}
