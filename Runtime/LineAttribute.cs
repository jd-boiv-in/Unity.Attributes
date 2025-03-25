using System;
using UnityEngine;

namespace JD.Attributes
{
    // From: https://vintay.medium.com/creating-custom-unity-attributes-divider-horizontal-line-dae2403a4c89
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class LineAttribute : PropertyAttribute
    {
        public const float DefaultHeight = 2.0f;
        public const AttributesColor DefaultColor = AttributesColor.Gray;

        public float Height { get; private set; }
        public AttributesColor Color { get; private set; }

        public LineAttribute(float height = DefaultHeight, AttributesColor color = DefaultColor)
        {
            Height = height;
            Color = color;
        }
    }
}
