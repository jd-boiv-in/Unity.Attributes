using UnityEditor;
using UnityEngine;

namespace JD.Attributes
{
    // From https://discussions.unity.com/t/how-to-change-the-names-of-a-vector-3-that-is-set-in-the-inspector/216935/3
    [CustomPropertyDrawer(typeof(VectorLabelsAttribute))]
    public class VectorLabelsDrawer : PropertyDrawer
    {
        private static readonly GUIContent[] _defaultLabels = new GUIContent[]{ new GUIContent("X"), new GUIContent("Y"), new GUIContent("Z"), new GUIContent("W") };

        private const int TwoLinesThreshold = 375;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var factor = Screen.width < TwoLinesThreshold ? 2 : 1;
            return factor * base.GetPropertyHeight(property, label);
        }

        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var vectorLabels = (VectorLabelsAttribute)attribute;

            if (property.propertyType == SerializedPropertyType.Vector2Int)
            {
                var array = new int[] { property.vector2IntValue.x, property.vector2IntValue.y };
                array = DrawFields(position, array, ObjectNames.NicifyVariableName(property.name), EditorGUI.IntField, vectorLabels);
                property.vector2IntValue = new Vector2Int(array[0], array[1]);
            }
            else if (property.propertyType == SerializedPropertyType.Vector3Int)
            {
                var array = new int[] { property.vector3IntValue.x, property.vector3IntValue.y, property.vector3IntValue.z };
                array = DrawFields(position, array, ObjectNames.NicifyVariableName(property.name), EditorGUI.IntField, vectorLabels);
                property.vector3IntValue = new Vector3Int(array[0], array[1], array[2]);
            }
            else if (property.propertyType == SerializedPropertyType.Vector2)
            {
                var array = new float[] { property.vector2Value.x, property.vector2Value.y };
                array = DrawFields(position, array, ObjectNames.NicifyVariableName(property.name), EditorGUI.FloatField, vectorLabels);
                property.vector2Value = new Vector2(array[0], array[1]);
            }
            else if (property.propertyType == SerializedPropertyType.Vector3)
            {
                var array = new float[] { property.vector3Value.x, property.vector3Value.y, property.vector3Value.z };
                array = DrawFields(position, array, ObjectNames.NicifyVariableName(property.name), EditorGUI.FloatField, vectorLabels);
                property.vector3Value = new Vector3(array[0], array[1], array[2]);
            }
            else if (property.propertyType == SerializedPropertyType.Vector4)
            {
                var array = new float[] { property.vector4Value.x, property.vector4Value.y, property.vector4Value.z, property.vector4Value.w };
                array = DrawFields(position, array, ObjectNames.NicifyVariableName(property.name), EditorGUI.FloatField, vectorLabels);
                property.vector4Value = new Vector4(array[0], array[1], array[2]);
            }
        }

        private T[] DrawFields<T>(Rect rect, T[] vector, string mainLabel, System.Func<Rect, GUIContent, T, T> fieldDrawer, VectorLabelsAttribute vectorLabels)
        {
            var result = vector;

            var twoLinesLayout = Screen.width < TwoLinesThreshold;

            // Get the rect of the main label
            var mainLabelRect = rect;
            mainLabelRect.width = EditorGUIUtility.labelWidth;
            if (twoLinesLayout)
                mainLabelRect.height *= 0.5f;

            // Get the size of each field rect
            var fieldRect = rect;
            if (twoLinesLayout)
            {
                fieldRect.height *= 0.5f;
                fieldRect.y += fieldRect.height;
                fieldRect.width = rect.width / vector.Length;
            }
            else
            {
                fieldRect.x += mainLabelRect.width;
                fieldRect.width = (rect.width - mainLabelRect.width) / vector.Length;
            }

            EditorGUI.LabelField(mainLabelRect, mainLabel);

            for (var i = 0; i < vector.Length; i++)
            {
                var label = vectorLabels.Labels.Length > i ? new GUIContent((i > 0 ? " " : "") + vectorLabels.Labels[i]) : _defaultLabels[i];
                var labelSize = EditorStyles.label.CalcSize(label);
                EditorGUIUtility.labelWidth = Mathf.Max(labelSize.x + 5, 0.3f * fieldRect.width);
                result[i] = fieldDrawer(fieldRect, label, vector[i]);
                fieldRect.x += fieldRect.width;
            }

            EditorGUIUtility.labelWidth = 0;

            return result;
        }
    }
}