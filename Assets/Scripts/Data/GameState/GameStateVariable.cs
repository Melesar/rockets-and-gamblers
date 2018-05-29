using Framework.Data;
using UnityEngine;

namespace RocketsAndGamblers.Data
{
    [CreateAssetMenu(menuName = "R&G/Game state variable")]
    public class GameStateVariable : Variable<GameState>
    {
        protected override void OnValueChanged(GameState oldValue, GameState newValue)
        {
            if (oldValue != null) {
                oldValue.IsCurrent = false;
            }
            
            newValue.IsCurrent = true;
            base.OnValueChanged(oldValue, newValue);
        }
    }
}