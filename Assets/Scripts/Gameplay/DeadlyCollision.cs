using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class DeadlyCollision : MonoBehaviour
    {
        public bool actOnTrigger;

        private void OnTriggerEnter2D (Collider2D collision)
        {
            if (actOnTrigger) {
                Kill(collision.gameObject);
            }
        }

        private void OnCollisionEnter2D (Collision2D collision)
        {
            if (!actOnTrigger) {
                Kill(collision.gameObject);
            }
        }

        private void Kill (GameObject collision)
        {
            var playerDeath = collision.GetComponent<PlayerDeath>();
            playerDeath?.Die();
        }
    }
}
