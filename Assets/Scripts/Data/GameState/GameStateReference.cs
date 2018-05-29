using System;
using Framework.Data;
using Framework.References;
using UnityEngine;

namespace RocketsAndGamblers.Data
{
    [Serializable]
    public class GameStateReference : DataReference<GameState>
    {
        [SerializeField] private GameStateVariable state;

        public override Variable<GameState> Variable => state;
    }
}