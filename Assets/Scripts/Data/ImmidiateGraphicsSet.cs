using System.Collections.Generic;
using Framework.RuntimeSets;
using RocketsAndGamblers.Effects;
using UnityEngine;

namespace RocketsAndGamblers.Data
{
    [CreateAssetMenu(menuName = "R&G/Set/Immidiate graphics set")]
    public class ImmidiateGraphicsSet : RuntimeSet<IImmidiateGraphics>
    {
        private List<IImmidiateGraphics> graphics = new List<IImmidiateGraphics>();
        
        protected override ICollection<IImmidiateGraphics> Collection => graphics;
        
        public new void Add (IImmidiateGraphics item)
        {
            //Workaround for Unity Edtor as it doesn't recreate list itself
            graphics.RemoveAll(i => i == null);
            base.Add(item);
        }
    }
}