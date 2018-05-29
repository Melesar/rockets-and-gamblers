using System.Threading.Tasks;
using Framework.References;
using UnityEngine;

namespace RocketsAndGamblers
{
    [CreateAssetMenu(menuName = "R&G/Attack taget provider/Specific id from database")]
    public class PredefinedAttackTargetProvider : AttackTargetProvider
    {
        [SerializeField] private StringReference targetId;

        protected override async Task<string> GetTargetId()
        {
            return targetId;
        }
    }
}