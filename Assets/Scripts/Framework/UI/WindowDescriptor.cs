using UnityEngine;
using UnityEngine.Events;

namespace Framework.UI
{
    [CreateAssetMenu(menuName = "Framework/UI/Window descriptor")]
    public class WindowDescriptor : ScriptableObject
    {
        public GameObject windowPrefab;

        private UnityAction invoked;

        private int subscribersCount;

        public event UnityAction Invoked
        {
            add
            {
                invoked += value;
                subscribersCount++;
            }
            remove
            {
                invoked -= value;
                subscribersCount--;
            }
        }

        public void Invoke()
        {
            invoked?.Invoke();
        }

        //TODO Implement window spawning in case of no subscribers
    }
}