using System;
using UnityEngine;

namespace JD.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class LineAttribute : PropertyAttribute
    {
        public const float DefaultHeight = 2.0f;
        public const AttributesColor DefaultColor = AttributesColor.Gray;

        public float Height { get; private set; }
        public float Offset { get; private set; }
        public AttributesColor Color { get; private set; }

        public LineAttribute(float height = DefaultHeight, float offset = 0, AttributesColor color = DefaultColor)
        {
            Height = height;
            Color = color;
            Offset = offset;
        }
    }
}
