using UnityEngine;

namespace RocketsAndGamblers.Data
{
    [CreateAssetMenu(menuName = "R&G/Game state")]
    public class GameState : ScriptableObject
    {
        public bool IsCurrent { get; set; }
    }
}