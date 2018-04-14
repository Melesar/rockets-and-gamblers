﻿using Framework.Events;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class AttackTarget : MonoBehaviour
    {
        public GameEvent gameEvent;

        private void OnTriggerEnter2D (Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Player")) {
                return;
            }

            gameEvent.Raise();
        }
    }
}
