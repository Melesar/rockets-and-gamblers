using Framework.Interfaces;
using UnityEngine;

namespace Framework.Events
{
    [CreateAssetMenu(menuName = "Events/Undoable event")]
    public class UndoableGameEvent : GameEvent<IUndoable>
    {
        
    }
}