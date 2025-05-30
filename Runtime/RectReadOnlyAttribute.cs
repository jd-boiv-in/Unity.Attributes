using System;
using UnityEngine;

namespace JD.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class RectReadOnlyAttribute : PropertyAttribute
    {
        public RectReadOnlyAttribute()
        {
            
        }
    }
}
