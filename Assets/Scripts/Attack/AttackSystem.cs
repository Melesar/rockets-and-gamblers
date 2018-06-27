using Framework.Events;
using RocketsAndGamblers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketsAndGamblers.Player;
using UnityEngine;

namespace RocketsAndGamblers
{
    [CreateAssetMenu(menuName = "R&G/Attack system")]
    public class AttackSystem : ScriptableObject
    {
        [Header("Attack settings")]
        public AttackTargetProvider targetProvider;

        public PlayerData playerData;
        //TODO local storage stub
        public BaseDescriptionProvider enemyBaseProvider;
        public BaseDescriptionProvider playerBaseProvider;

        public BaseBuilder baseBuilder;

        [Header("Events")]
        public GameEvent attackStarted;
        public GameEvent attackFinished;

        [Header("Game state")] 
        public GameStateVariable currentGameState;
        public GameState attackState;
        public GameState defaultState;
        
        public void Attack ()
        {
            AttackAsync()
                .WrapErrors();
        }

        public void ReturnToBase ()
        {
            ReturnToBaseAsync().WrapErrors();
        }

        public async Task AttackAsync ()
        {
            attackStarted.Raise();

            var targetId = await targetProvider.GetAttackTargetId();

            var baseDescription = await enemyBaseProvider.GetPlayerBase(targetId, true);

            await Scenes.UnloadScenes();

            await Scenes.LoadAttackScene();

            currentGameState.Value = attackState;

            await baseBuilder.BuildBase(baseDescription);

            attackFinished.Raise();
        }

        public async Task ReturnToBaseAsync ()
        {
            attackStarted.Raise();

            var baseDescription = await playerBaseProvider.GetPlayerBase(playerData.Id, false);

            await Scenes.UnloadScenes();

            await Scenes.LoadPlayerScene();

            currentGameState.Value = defaultState;

            await baseBuilder.BuildBase(baseDescription);

            attackFinished.Raise();
        }
    }
}
