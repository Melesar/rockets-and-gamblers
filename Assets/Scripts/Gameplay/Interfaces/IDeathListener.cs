using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

namespace RocketsAndGamblers
{
    public interface IDeathListener : IEventSystemHandler
    {
        void OnDeath();
    }
}
