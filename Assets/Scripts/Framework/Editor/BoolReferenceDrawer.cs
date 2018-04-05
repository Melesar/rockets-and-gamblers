using Framework.References;
using UnityEditor;
using UnityEngine;

namespace Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(BoolReference))]
    public class BoolReferenceDrawer : DataReferenceDrawer
    {
        protected override void DrawConstantField (SerializedProperty property, Rect position)
        {
            var valueProperty = property.FindPropertyRelative("constantValue");
            valueProperty.boolValue = EditorGUI.Toggle(position, valueProperty.boolValue);
        }

        protected override void DrawVariableField (SerializedProperty property, Rect position)
        {
            var variableProperty = property.FindPropertyRelative("variable");
            EditorGUI.ObjectField(position, variableProperty, GUIContent.none);
        }
    }
}