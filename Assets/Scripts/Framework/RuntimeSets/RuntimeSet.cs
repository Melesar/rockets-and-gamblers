using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.RuntimeSets
{
    public abstract class RuntimeSet<T> : ScriptableObject, IEnumerable<T>
    {
        protected abstract ICollection<T> Collection { get; }

        public void Add(T element)
        {
            Collection.Add(element);
        }

        public void Remove(T element)
        {
            Collection.Remove(element);
        }

        public int Count => Collection.Count;

        public bool Contains(T element) => Collection.Contains(element);

        protected virtual void OnEnable()
        {

        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return Collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Collection.GetEnumerator();
        }
    }
}