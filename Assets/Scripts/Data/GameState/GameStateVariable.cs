using Framework.Data;
using UnityEngine;

namespace RocketsAndGamblers.Data
{
    [CreateAssetMenu(menuName = "R&G/Game state")]
    public class GameStateVariable : Variable<GameState>
    {
        public void Set(GameState newState)
        {
            Value = newState;
        }
    }
}