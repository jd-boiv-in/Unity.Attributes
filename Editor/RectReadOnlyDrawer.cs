using UnityEngine;
using UnityEditor;

namespace JD.Attributes
{
    [CustomPropertyDrawer(typeof(RectReadOnlyAttribute))]
    public class RectReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.LabelField(new Rect(position.x, position.y, EditorGUIUtility.labelWidth, position.height), label);

            var padding = 4f;
            var labelCharWidth = 14f;
            var fieldWidth = (position.width - EditorGUIUtility.labelWidth - 4 * (labelCharWidth + (padding * 2))) / 4f;
            var x = position.x + EditorGUIUtility.labelWidth;

            EditorGUI.BeginProperty(position, label, property);

            // X
            EditorGUI.BeginDisabledGroup(true);
            EditorGUI.LabelField(new Rect(x, position.y, labelCharWidth, position.height), "X");
            EditorGUI.PropertyField(new Rect(x + padding + labelCharWidth, position.y, fieldWidth, position.height), property.FindPropertyRelative("x"), GUIContent.none);

            // Y
            x += labelCharWidth + fieldWidth + (padding * 2);
            EditorGUI.LabelField(new Rect(x, position.y, labelCharWidth, position.height), "Y");
            EditorGUI.PropertyField(new Rect(x + padding + labelCharWidth, position.y, fieldWidth, position.height), property.FindPropertyRelative("y"), GUIContent.none);

            // W
            x += labelCharWidth + fieldWidth + (padding * 2);
            EditorGUI.LabelField(new Rect(x, position.y, labelCharWidth, position.height), "W");
            EditorGUI.PropertyField(new Rect(x + padding + labelCharWidth, position.y, fieldWidth, position.height), property.FindPropertyRelative("width"), GUIContent.none);

            // H
            x += labelCharWidth + fieldWidth + (padding * 2);
            EditorGUI.LabelField(new Rect(x, position.y, labelCharWidth, position.height), "H");
            EditorGUI.PropertyField(new Rect(x + padding + labelCharWidth, position.y, fieldWidth, position.height), property.FindPropertyRelative("height"), GUIContent.none);
            EditorGUI.EndDisabledGroup();
            
            EditorGUI.EndProperty();
        }
    }
}
