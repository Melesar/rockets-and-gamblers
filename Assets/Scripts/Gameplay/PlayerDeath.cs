using Framework.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RocketsAndGamblers
{
    public class PlayerDeath : MonoBehaviour, IStopListener, ILaunchListener
    {
        public GameEvent deathEvent;

        private bool isVulnerable;
        
        public void Die ()
        {
            if (!isVulnerable) {
                return;
            }
            
            deathEvent.Raise();
            SendDeathMessage();
        }

        private void SendDeathMessage ()
        {
            ExecuteEvents.Execute<IDeathListener>(
                gameObject,
                new BaseEventData(EventSystem.current),
                (handler, data) => handler.OnDeath()                
            );
        }

        public void Stop()
        {
            isVulnerable = false;
        }

        public void Launch()
        {
            isVulnerable = true;
        }
    }
}
