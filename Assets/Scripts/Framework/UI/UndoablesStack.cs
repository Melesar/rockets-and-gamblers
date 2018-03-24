using System.Collections.Generic;
using Framework.Interfaces;
using UnityEngine;

namespace Framework.UI
{
    public class UndoablesStack : MonoBehaviour
    {
        private readonly Stack<IUndoable> stack = new Stack<IUndoable>();
        
        public void Add(IUndoable undoable)
        {
            stack.Push(undoable);
        }

        public void Remove()
        {
            if (stack.Count != 0) {
                stack.Pop();
            }
        }

        private void Undo()
        {
            if (stack.Count != 0) {
                stack.Pop().Undo();
            }
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape)) {
                Undo();
            }
        }
    }
}