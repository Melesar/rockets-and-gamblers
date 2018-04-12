using UnityEngine;
using UnityEditor;

namespace Framework.Editor.PropertyDrawers
{
    public abstract class DataReferenceDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var labelRect = new Rect(position.x, position.y, position.width * 0.4f, position.height);
            var totalWidth = position.width;

            position = EditorGUI.PrefixLabel(labelRect, label);

            var useConstantValue = property.FindPropertyRelative("useConstantValue");

            var buttonRect = new Rect(position.x, position.y, position.height, position.height);
            //var selectButtonStyle = new GUIStyle() {normal = new GUIStyleState {background = EditorGUIUtility.FindTexture("mini popup")}};
            if (GUI.Button(buttonRect, string.Empty)) {
                var menu = new GenericMenu();
                menu.AddItem(new GUIContent {text = "Use variable"}, !useConstantValue.boolValue, 
                    () => OnMenuClicked(useConstantValue, false));
                menu.AddItem(new GUIContent {text = "Use constant value"}, useConstantValue.boolValue, 
                    () => OnMenuClicked(useConstantValue, true));
                menu.ShowAsContext();
            }

            var offset = position.height + 5f;
            var fieldRect = new Rect(position.x + offset, position.y, totalWidth - offset - position.x, position.height);
            if (useConstantValue.boolValue) {
                DrawConstantField(property, fieldRect);
            } else {
                DrawVariableField(property, fieldRect);
            }
        }

        protected abstract void DrawConstantField(SerializedProperty property, Rect position);
        protected abstract void DrawVariableField(SerializedProperty property, Rect position);

        private void OnMenuClicked(SerializedProperty property, bool newValue)
        {
            property.boolValue = newValue;
            property.serializedObject.ApplyModifiedProperties();
        }

        
        
        private void OnEnable()
        {
            
        }
    }
}