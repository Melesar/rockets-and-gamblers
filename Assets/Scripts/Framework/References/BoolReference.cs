using Framework.Data;
using System;

namespace Framework.References
{
    [Serializable]
    public class BoolReference : DataReference<bool>
    {
        public BoolVariable variable;

        public override Variable<bool> Variable => variable;
    }
}
