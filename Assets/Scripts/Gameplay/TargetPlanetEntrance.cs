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
            var animation = playerObject.GetComponent<SpaceshipEntranceAnimation>();
            
            playerMovement?.Stop();

            var targetPosition = GetTargetPosition();
            var targetRotation = GetTargetRotation(playerObject.transform);
            animation.Run(targetPosition, targetRotation);
            
            yield return new WaitUntil(animation.IsFinished);

            playerMovement?.Land();
            playerMovement?.Launch();
        }

        private void RepositionPlayer(GameObject playerObject)
        {
            playerObject.transform.position = transform.position;

            var spawnPointDirection = (spawnPointPosition - (Vector2)transform.position).normalized;
            playerObject.transform.right = spawnPointDirection;
        }

        private Vector3 GetTargetPosition()
        {
            return transform.position;
        }

        private float GetTargetRotation(Transform playerTransform)
        {
            var spawnPointDirection = (spawnPointPosition - (Vector2)transform.position).normalized;
            var angle = Vector2.Angle(playerTransform.right, spawnPointDirection);

            var totalAngle = angle + playerTransform.rotation.eulerAngles.z;
            var fullCircles = (int) (totalAngle / 360f);
            return totalAngle - fullCircles * 360;
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