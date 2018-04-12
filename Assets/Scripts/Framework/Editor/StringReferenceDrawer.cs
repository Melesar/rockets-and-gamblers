using Framework.Data;
using Framework.References;
using UnityEditor;
using UnityEngine;

namespace Framework.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(StringReference))]
    public class StringReferenceDrawer : DataReferenceDrawer
    {
        protected override void DrawConstantField(SerializedProperty property, Rect position)
        {
            var valueProperty = property.FindPropertyRelative("constantValue");
            valueProperty.stringValue = EditorGUI.TextField(position, valueProperty.stringValue);
        }

        protected override void DrawVariableField(SerializedProperty property, Rect position)
        {
            var variableProperty = property.FindPropertyRelative("variable");
            EditorGUI.ObjectField(position, variableProperty, GUIContent.none);
        }
    }
}