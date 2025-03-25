using UnityEngine;
using UnityEditor;

namespace JD.Attributes
{
    [CustomPropertyDrawer(typeof(LineAttribute))]
    public class LineDecoratorDrawer : DecoratorDrawer
    {
        public override float GetHeight()
        {
            var lineAttr = (LineAttribute) attribute;
            return EditorGUIUtility.singleLineHeight + lineAttr.Height;
        }

        public override void OnGUI(Rect position)
        {
            var rect = EditorGUI.IndentedRect(position);
            rect.y += EditorGUIUtility.singleLineHeight / 3.0f;
            
            var lineAttr = (LineAttribute) attribute;
            rect.height = lineAttr.Height;
            
            EditorGUI.DrawRect(rect, lineAttr.Color.GetColor());
        }
    }
}
