using System.Collections;
using RocketsAndGamblers.Database;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class TargetPlanetEntrance : MonoBehaviour
    {
        public ObjectsDatabase database;
        public ObjectId spawnPointId;

        private Collider2D triggerCollider;
        private Vector2 spawnPointPosition;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (!collider.gameObject.CompareTag("Player")) {
                return;
            }

            triggerCollider.enabled = false;

            StartCoroutine(PreparePlayerToReturn(collider.gameObject));
        }

        private IEnumerator PreparePlayerToReturn(GameObject playerObject)
        {
            var playerMovement = playerObject.GetComponent<ShipMovement>();
            var blinkAnimation = playerObject.GetComponent<SpaceshipBlinkAnimation>();

            playerMovement?.Stop();
            blinkAnimation?.Blink();

            yield return new WaitForSeconds(1f);

            RepositionPlayer(playerObject);

            blinkAnimation?.Reappear();

            var initialLaunch = playerObject.GetComponent<InitialLaunch>();
            if (initialLaunch != null) {
                initialLaunch.enabled = true;
            }
        }

        private void RepositionPlayer(GameObject playerObject)
        {
            playerObject.transform.position = transform.position;

            var spawnPointDirection = (spawnPointPosition - (Vector2)transform.position).normalized;
            //playerObject.transform.up = Vector3.Cross(spawnPointDirection, -Vector3.forward);
            playerObject.transform.right = spawnPointDirection;
        }

        private void Start()
        {
            var spawnPoint = database.GetById(spawnPointId.id);
            if (spawnPoint == null) {
                return;
            }

            spawnPointPosition = spawnPoint.transform.position;
        }

        private void Awake()
        {
            triggerCollider = GetComponent<Collider2D>();
        }
    }
}