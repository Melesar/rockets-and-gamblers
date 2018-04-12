using Framework.References;
using UnityEditor;
using UnityEngine;

namespace Framework.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(FloatReference))]
    public class FloatReferenceDrawer : DataReferenceDrawer
    {
        protected override void DrawConstantField(SerializedProperty property, Rect position)
        {
            var valueProperty = property.FindPropertyRelative("constantValue");
            valueProperty.floatValue = EditorGUI.FloatField(position, valueProperty.floatValue);
        }

        protected override void DrawVariableField(SerializedProperty property, Rect position)
        {
            var variableProperty = property.FindPropertyRelative("variable");
            EditorGUI.ObjectField(position, variableProperty, GUIContent.none);
        }
    }
}