using Framework.Data;
using Framework.References;
using UnityEngine;

namespace RocketsAndGamblers.Data
{
    public class GameStateReference : DataReference<GameState>
    {
        [SerializeField] private GameStateVariable state;

        public override Variable<GameState> Variable => state;
    }
}