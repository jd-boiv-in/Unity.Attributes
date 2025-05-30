using UnityEditor;
using UnityEngine;

namespace JD.Attributes
{
    // Add a checkbox to a Vector2 to use the value as random
    [CustomPropertyDrawer(typeof(RandomAttribute))]
    public class RandomDrawer : PropertyDrawer
    {
        private const int TwoLinesThreshold = 375;

        private bool _random;
        private bool _isRandom;
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var factor = Screen.width < TwoLinesThreshold ? 2 : 1;
            return factor * base.GetPropertyHeight(property, label);
        }

        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var vectorLabels = (RandomAttribute) attribute;
            if (property.propertyType == SerializedPropertyType.Vector2)
            {
                var array = new float[] { property.vector2Value.x, property.vector2Value.y };
                _isRandom = !Mathf.Approximately(array[0], array[1]);
                array = DrawFields(position, array, ObjectNames.NicifyVariableName(property.name), EditorGUI.FloatField, vectorLabels);
                property.vector2Value = new Vector2(array[0], array[1]);
            }
            else if (property.propertyType == SerializedPropertyType.Vector2Int)
            {
                var array = new int[] { property.vector2IntValue.x, property.vector2IntValue.y };
                _isRandom = array[0] != array[1];
                array = DrawFields(position, array, ObjectNames.NicifyVariableName(property.name), EditorGUI.IntField, vectorLabels);
                property.vector2IntValue = new Vector2Int(array[0], array[1]);
            }
        }

        private T[] DrawFields<T>(Rect rect, T[] vector, string mainLabel, System.Func<Rect, GUIContent, T, T> fieldDrawer, RandomAttribute labels)
        {
            var result = vector;
            var isRandom = _random || _isRandom;
            
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
                fieldRect.width = rect.width / (!isRandom ? 2 : vector.Length + 1);
            }
            else
            {
                fieldRect.x += mainLabelRect.width;
                fieldRect.width = (rect.width - mainLabelRect.width) / (!isRandom ? 2 : vector.Length + 1);
            }

            EditorGUI.LabelField(mainLabelRect, mainLabel);

            if (isRandom)
            {
                for (var i = 0; i < vector.Length; i++)
                {
                    var label = new GUIContent(i == 0 ? "From" : "To");
                    var labelSize = EditorStyles.label.CalcSize(label);
                    EditorGUIUtility.labelWidth = Mathf.Max(labelSize.x + 5, 0.3f * fieldRect.width);
                    result[i] = fieldDrawer(fieldRect, label, vector[i]);
                    fieldRect.x += fieldRect.width + 6;
                }
            }
            else
            {
                var label = new GUIContent("Const.");
                var labelSize = EditorStyles.label.CalcSize(label);
                EditorGUIUtility.labelWidth = Mathf.Max(labelSize.x + 5, 0.3f * fieldRect.width);
                var value = fieldDrawer(fieldRect, label, vector[0]);
                for (var i = 0; i < vector.Length; i++)
                    result[i] = value;
                fieldRect.x += fieldRect.width + 6;
            }

            // Random checkbox
            {
                fieldRect.x += 6;
                var label = new GUIContent("Random");
                var labelSize = EditorStyles.label.CalcSize(label);
                EditorGUIUtility.labelWidth = Mathf.Max(labelSize.x + 5, 0.3f * fieldRect.width);
                fieldRect.x += fieldRect.width - labelSize.x - (isRandom ? 40 : 34);
                
                _random = EditorGUI.Toggle(fieldRect, label, isRandom);
            }

            EditorGUIUtility.labelWidth = 0;

            return result;
        }
    }
}