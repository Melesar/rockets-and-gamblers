using RocketsAndGamblers.Data;
using UnityEngine;

namespace RocketsAndGamblers.Effects
{
    [RequireComponent(typeof(Camera))]
    public class ImmidiateGraphicsDrawer : MonoBehaviour
    {
        [SerializeField] private ImmidiateGraphicsSet set;
        
        private void OnPostRender()
        {
            foreach (var item in set) {
                item.OnPostRender();
            }    
        }

        private void Start()
        {
            
        }

        private void OnDestroy()
        {
            set.Clear();
        }
    }
}