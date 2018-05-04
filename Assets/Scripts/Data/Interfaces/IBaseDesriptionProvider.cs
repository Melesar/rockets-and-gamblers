using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketsAndGamblers.Data.Interfaces
{
    public interface IBaseDesriptionProvider
    {
        Task<BaseDescription> GetPlayerBase (string playerId, bool isAttacking);

        Task UpdatePlayerBase (string playerId, BaseDescription newDescription);
    }
}