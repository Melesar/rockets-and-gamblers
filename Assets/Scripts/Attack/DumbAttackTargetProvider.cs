using System.Threading.Tasks;
using UnityEngine;

namespace RocketsAndGamblers
{
    [CreateAssetMenu(menuName = "R&G/Attack taget provider/Dumb provider")]
    public class DumbAttackTargetProvider : AttackTargetProvider
    {
        public int minId;
        public int maxId;
        
        protected async override Task<string> GetTargetId()
        {
            return Random.Range(minId, maxId + 1).ToString();
        }
    }
}