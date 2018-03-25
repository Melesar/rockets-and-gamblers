using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace Framework
{
    public class AssetWrapper : MonoBehaviour
    {
        public UnityEvent awake;
        public UnityEvent start;
        public UnityEvent update;

        private void Awake ()
        {
            awake.Invoke();
        }

        private void Start ()
        {
            start.Invoke();
        }

        private void Update ()
        {
            update.Invoke();
        }
    }
}

