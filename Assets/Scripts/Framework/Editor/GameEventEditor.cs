using Framework.Events;
using UnityEditor;
using UnityEngine;

namespace Framework.Editor.Inspectors
{
    [CustomEditor(typeof(GameEvent), true)]
    public class GameEventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            if (GUILayout.Button("Invoke")) {
                ((GameEvent) target).Raise();
            }
        }
    }
}