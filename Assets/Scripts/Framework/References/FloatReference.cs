using Framework.Data;

namespace Framework.References
{
    [System.Serializable]
    public class FloatReference : DataReference<float>
    {
        public FloatVariable variable;

        public override Variable<float> Variable => variable;
    }
}