using UnityEngine;
using UnityEditor;

namespace JD.Attributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyCopyAttribute))]
    public class ReadOnlyCopyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var value = property != null ? property.stringValue : "";

            // Calculate rects
            var labelWidth = EditorGUIUtility.labelWidth;
            var buttonWidth = 50f;
            var valueWidth = position.width - labelWidth - buttonWidth - 4f;

            var labelRect = new Rect(position.x, position.y, labelWidth, position.height);
            var valueRect = new Rect(position.x + labelWidth, position.y, valueWidth, position.height);
            var buttonRect = new Rect(position.x + labelWidth + valueWidth + 2f, position.y, buttonWidth, position.height);

            // Draw label
            if (property != null) EditorGUI.LabelField(labelRect, property.displayName);

            // Draw readonly value
            EditorGUI.BeginDisabledGroup(true);
            EditorGUI.TextField(valueRect, GUIContent.none, value);
            EditorGUI.EndDisabledGroup();

            // Draw copy button
            if (GUI.Button(buttonRect, "Copy"))
            {
                EditorGUIUtility.systemCopyBuffer = value;
            }
        }
    }
}
