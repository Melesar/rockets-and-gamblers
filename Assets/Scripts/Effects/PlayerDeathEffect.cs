using System.Collections;
using UnityEngine;

namespace RocketsAndGamblers.Effects
{
    public class PlayerDeathEffect : MonoBehaviour, IDeathListener
    {
        public SpriteRenderer renderer;
        public GameObject vfxPrefab;
        public float waitTime;

        private GameObject vfxInstance;
        
        public void OnDeath()
        {
            StartCoroutine(DeathCoroutine());
        }

        private IEnumerator DeathCoroutine()
        {
            SpawnVFX();
            renderer.enabled = false;

            yield return new WaitForSeconds(waitTime);

            renderer.enabled = true;
            Destroy(vfxInstance);
        }
        
        private void SpawnVFX()
        {
            vfxInstance = Instantiate(vfxPrefab);
            vfxInstance.transform.position = transform.position;
        }
    }
}