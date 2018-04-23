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

        //Workaround only before cloud implementation
        //Then only one field should stay
        public BaseDescriptionProvider enemyBaseProvider;
        public BaseDescriptionProvider playerBaseProvider;

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

        public void TryToSaveBase()
        {
            TryToSaveBaseAsync().WrapErrors();
        }

        public async Task AttackAsync ()
        {
            attackStarted.Raise();

            await new WaitForSeconds(2f);

            var targetId = await targetProvider.GetAttackTargetId();

            var baseDescription = await enemyBaseProvider.GetPlayerBase(targetId, true);

            await Scenes.UnloadScenes();

            await Scenes.LoadAttackScene();

            await baseBuilder.BuildBase(baseDescription);

            attackFinished.Raise();
        }

        public async Task ReturnToBaseAsync ()
        {
            attackStarted.Raise();

            await new WaitForSeconds(2f);

            var baseDescription = await playerBaseProvider.GetPlayerBase(Constants.PlayerId, false);

            await Scenes.UnloadScenes();

            await Scenes.LoadPlayerScene();

            await baseBuilder.BuildBase(baseDescription);

            attackFinished.Raise();
        }

        private async Task TryToSaveBaseAsync()
        {
            attackStarted.Raise();

            await new WaitForSeconds(2f);

            var baseDescription = await playerBaseProvider.GetPlayerBase(Constants.PlayerId, true);

            await Scenes.UnloadScenes();

            await Scenes.LoadSaveBaseScene();

            await baseBuilder.BuildBase(baseDescription);

            attackFinished.Raise();
        }
    }
}
