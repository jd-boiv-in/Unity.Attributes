using UnityEngine;
using UnityEditor;

#if ODIN_INSPECTOR
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using Sirenix.OdinInspector.Editor;
#endif

namespace JD.Attributes
{
#if ODIN_INSPECTOR
    // Odin version so we can have the line appears BEFORE everything
    [DrawerPriority(2.0, 0.0, 0.0)]
    public class LineDecoratorDrawer : OdinAttributeDrawer<LineAttribute>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            var rect = EditorGUI.IndentedRect(EditorGUILayout.GetControlRect(false));
            rect.x += 3;
            rect.y += 12 - Attribute.Height / 2f;
            rect.width -= 6;
            rect.height = Attribute.Height;
            SirenixEditorGUI.DrawSolidRect(rect, Attribute.Color.GetColor());
            
            CallNextDrawer(label);
        }
    }
#else
    // From: https://vintay.medium.com/creating-custom-unity-attributes-divider-horizontal-line-dae2403a4c89
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
#endif
}
