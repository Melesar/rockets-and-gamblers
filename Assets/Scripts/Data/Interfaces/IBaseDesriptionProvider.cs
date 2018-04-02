using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketsAndGamblers.Data.Interfaces
{
    public interface IBaseDesriptionProvider
    {
        Task<BaseDescription> GetPlayerBase (int playerId, bool isAttacking);

        Task UpdatePlayerBase (int playerId, BaseDescription newDescription);
    }
}