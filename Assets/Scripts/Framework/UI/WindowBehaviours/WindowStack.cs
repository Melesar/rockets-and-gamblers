using Framework.Events;
using Framework.Interfaces;
using Framework.UI.Interfaces;
using UnityEngine;

namespace Framework.UI.WindowBehaviours
{
    [RequireComponent(typeof(Window))]
    public class WindowStack : MonoBehaviour, IUndoable, IWindowCloseListener, IWindowOpenListener
    {
        public UndoableGameEvent onUndoableAdd;
        public GameEvent onUndoableRemove;
        
        private Window window;

        private bool respondToClose;
        
        public void Undo()
        {
            respondToClose = false;
            window.Close();
        }

        public void OnWindowClosed()
        {
            if (!respondToClose) {
                respondToClose = true;
                return;
            }
            
            onUndoableRemove.Raise();
        }

        public void OnWindowOpened()
        {
            onUndoableAdd.Raise(this);
        }

        private void Awake()
        {
            window = GetComponent<Window>();
        }
    }
}