using UnityEngine;

namespace JD.Attributes
{
    public enum AttributesColor
    {
        Clear,
        White,
        Black,
        Gray,
        Red,
        Pink,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    public static class AttributesColorExtensions
    {
        public static Color GetColor(this AttributesColor color)
        {
            switch (color)
            {
                case AttributesColor.Clear:
                    return new Color32(0, 0, 0, 0);
                case AttributesColor.White:
                    return new Color32(255, 255, 255, 255);
                case AttributesColor.Black:
                    return new Color32(0, 0, 0, 255);
                case AttributesColor.Gray:
                    return new Color32(128, 128, 128, 255);
                case AttributesColor.Red:
                    return new Color32(255, 0, 63, 255);
                case AttributesColor.Pink:
                    return new Color32(255, 152, 203, 255);
                case AttributesColor.Orange:
                    return new Color32(255, 128, 0, 255);
                case AttributesColor.Yellow:
                    return new Color32(255, 211, 0, 255);
                case AttributesColor.Green:
                    return new Color32(98, 200, 79, 255);
                case AttributesColor.Blue:
                    return new Color32(0, 135, 189, 255);
                case AttributesColor.Indigo:
                    return new Color32(75, 0, 130, 255);
                case AttributesColor.Violet:
                    return new Color32(128, 0, 255, 255);
                default:
                    return new Color32(0, 0, 0, 255);
            }
        }
    }
}
