using System.Collections;
using Framework.References;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class SpaceshipEntranceAnimation : MonoBehaviour
    {
        private Rigidbody2D rb;
        private bool isFinished;

        public bool IsFinished()
        {
            return isFinished;
        }

        public void Run (Vector2 targetPosition, float targetRotation)
        {
            isFinished = false;
            StartCoroutine(RunCoroutine(targetPosition, targetRotation));
        }

        private IEnumerator RunCoroutine(Vector2 targetPosition, float targetRotation)
        {
            while (ShouldMove(targetPosition, targetRotation)) {
                rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, 0.1f));
                rb.MoveRotation(Mathf.MoveTowardsAngle(rb.rotation, targetRotation, 15f));
                yield return null;
            }

            isFinished = true;
        }

        private bool ShouldMove(Vector2 targetPosition, float targetRotation)
        {
            return Vector2.Distance(targetPosition, rb.position) > 0.05f
                   || !Mathf.Approximately(rb.rotation, targetRotation);
        }

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
}