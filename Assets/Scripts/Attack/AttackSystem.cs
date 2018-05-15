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
        public AttackTargetProvider targetProvider;

        public PlayerData playerData;
        public BaseDescriptionProvider baseProvider;

        public BaseBuilder baseBuilder;

        public GameEvent attackStarted;
        public GameEvent attackFinished;

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

            var baseDescription = await baseProvider.GetPlayerBase(targetId, true);

            await Scenes.UnloadScenes();

            await Scenes.LoadAttackScene();

            await baseBuilder.BuildBase(baseDescription);

            attackFinished.Raise();
        }

        public async Task ReturnToBaseAsync ()
        {
            attackStarted.Raise();

            var baseDescription = await baseProvider.GetPlayerBase(playerData.Id, false);

            await Scenes.UnloadScenes();

            await Scenes.LoadPlayerScene();

            await baseBuilder.BuildBase(baseDescription);

            attackFinished.Raise();
        }
    }
}
