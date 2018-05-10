using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

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

            ExecuteEvents.Execute<IAfterVFXListener>(gameObject, null, (handler, data) => handler.AfterVFX());
        }
        
        private void SpawnVFX()
        {
            vfxInstance = Instantiate(vfxPrefab);
            vfxInstance.transform.position = transform.position;
        }
    }
}