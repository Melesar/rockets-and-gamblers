using Framework.UI;
using UnityEditor;
using UnityEngine;

namespace Framework.Editor
{
    [CustomEditor(typeof(WindowDescriptor))]
    public class WindowDescriptorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Invoke")) {
                ((WindowDescriptor) target).Invoke(); 
            }
        }
    }
}