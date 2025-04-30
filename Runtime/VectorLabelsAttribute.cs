using UnityEngine;

namespace JD.Attributes
{
    public class VectorLabelsAttribute : PropertyAttribute
    {
        public readonly string[] Labels;

        public VectorLabelsAttribute(params string[] labels)
        {
            Labels = labels;
        }
    }
}