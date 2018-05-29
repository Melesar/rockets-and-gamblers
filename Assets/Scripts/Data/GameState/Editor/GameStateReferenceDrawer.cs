using Framework.Editor.PropertyDrawers;
using RocketsAndGamblers.Data;
using UnityEditor;
using UnityEngine;

namespace RocketsAndGamblers.Editor
{
    [CustomPropertyDrawer(typeof(GameStateReference))]
    public class GameStateReferenceDrawer : DataReferenceDrawer
    {
        protected override void DrawConstantField(SerializedProperty property, Rect position)
        {
            var valueProperty = property.FindPropertyRelative("constantValue");
            valueProperty.objectReferenceValue = EditorGUI.ObjectField(position, valueProperty.objectReferenceValue,
                typeof(GameState), false);
        }

        protected override void DrawVariableField(SerializedProperty property, Rect position)
        {
            var variableProperty = property.FindPropertyRelative("state");
            EditorGUI.ObjectField(position, variableProperty, GUIContent.none);
        }
    }
}