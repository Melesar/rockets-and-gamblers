using Framework.Data;
using System;

namespace Framework.References
{
    [Serializable]
    public class IntReference : DataReference<int>
    {
        public IntVariable variable;

        public override Variable<int> Variable => variable;
    }
}
