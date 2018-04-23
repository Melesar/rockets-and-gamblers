using RocketsAndGamblers.Database;

namespace RocketsAndGamblers.Defenses
{
    public class Defense : LayoutObject
    {
        protected ObjectIdentity objectId;

        protected virtual void Awake()
        {
            objectId = GetComponent<ObjectIdentity>();
        }
    }
}

