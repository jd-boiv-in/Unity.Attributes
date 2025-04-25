using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace JD.Attributes
{
    // By Johannes Deml (send@johannesdeml.com)
    // See: https://discussions.unity.com/t/can-you-add-editor-tooltips-to-the-shader-properties/713679/3
    public class TooltipDrawer : MaterialPropertyDrawer
    {
        private GUIContent _guiContent;

        private readonly MethodInfo _internalMethod;
        private readonly Type[] _methodArgumentTypes;
        private readonly object[] _methodArguments;

        public TooltipDrawer(string tooltip)
        {
            _guiContent = new GUIContent(string.Empty, tooltip);

            _methodArgumentTypes = new[] { typeof(Rect), typeof(MaterialProperty), typeof(GUIContent) };
            _methodArguments = new object[3];
            
            _internalMethod = typeof(MaterialEditor).GetMethod("DefaultShaderPropertyInternal", BindingFlags.Instance | BindingFlags.NonPublic, null, _methodArgumentTypes, null);
        }

        public override void OnGUI(Rect position, MaterialProperty prop, String label, MaterialEditor editor)
        {
            _guiContent.text = label;
            if (_internalMethod == null) return;

            _methodArguments[0] = position;
            _methodArguments[1] = prop;
            _methodArguments[2] = _guiContent;
              
            _internalMethod.Invoke(editor, _methodArguments);
        }
    }
}