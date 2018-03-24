using UnityEngine;
using Framework.Data;

namespace Framework.References
{
    public abstract class DataReference<T>
    {
        public bool useConstantValue;
        public T constantValue;

        public abstract Variable<T> Variable { get; }

        public T Value => useConstantValue ? constantValue : Variable.Value;

        public static implicit operator T (DataReference<T> reference)
        {
            return reference.Value;
        }
    }
}