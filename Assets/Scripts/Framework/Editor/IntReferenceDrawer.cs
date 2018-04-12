using Framework.References;
using UnityEditor;
using UnityEngine;

namespace Framework.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(IntReference))]
    public class IntReferenceDrawer : DataReferenceDrawer
    {
        protected override void DrawConstantField (SerializedProperty property, Rect position)
        {
            var valueProperty = property.FindPropertyRelative("constantValue");
            valueProperty.intValue = EditorGUI.IntField(position, valueProperty.intValue);
        }

        protected override void DrawVariableField (SerializedProperty property, Rect position)
        {
            var variableProperty = property.FindPropertyRelative("variable");
            EditorGUI.ObjectField(position, variableProperty, GUIContent.none);
        }
    }
}
