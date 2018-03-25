using Framework.Events;
using RocketsAndGamblers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RocketsAndGamblers
{
    [CreateAssetMenu(menuName = "R&G/Attack system")]
    public class AttackSystem : ScriptableObject
    {
        public AttackTargetProvider targetProvider;
        public BaseDescriptionProvider baseDescriptionProvider;
        public BaseBuilder baseBuilder;

        public GameEvent attackStarted;
        public GameEvent attackFinished;

        public void Attack ()
        {
            AttackAsync()
                .WrapErrors();
        }

        public async Task AttackAsync ()
        {
            attackStarted.Raise();

            await new WaitForSeconds(2f);

            var targetId = await targetProvider.GetAttackTargetId();

            var baseDescription = await baseDescriptionProvider.GetPlayerBase(targetId);

            await Scenes.UnloadScenes();

            await Scenes.LoadAttackScene();

            await baseBuilder.BuildBase(baseDescription);

            attackFinished.Raise();
        }
    }
}
