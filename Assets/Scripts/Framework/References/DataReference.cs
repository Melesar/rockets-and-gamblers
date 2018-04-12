using Framework.Data;
using UnityEngine.Events;

namespace Framework.References
{
    public abstract class DataReference<T>
    {
        public bool useConstantValue;
        public T constantValue;

        public abstract Variable<T> Variable { get; }

        public T Value
        {
            get { return useConstantValue ? constantValue : Variable.Value; }

            set
            {
                if (Variable != null) {
                    Variable.Value = value;
                } else {
                    constantValue = value;
                }
            }
        }

        public event UnityAction<T, T> valueChanged
        {
            add
            {
                if (Variable != null) {
                    Variable.valueChanged += value;
                }
            }
            remove
            {
                if (Variable != null) {
                    Variable.valueChanged -= value;
                }
            }
        }

        public static implicit operator T (DataReference<T> reference)
        {
            return reference.Value;
        }
    }
}