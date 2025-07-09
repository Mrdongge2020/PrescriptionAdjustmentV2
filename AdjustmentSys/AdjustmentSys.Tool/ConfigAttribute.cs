using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ConfigAttribute : Attribute
    {
        public string Description { get; }
        public object DefaultValue { get; }

        public string ValueType { get; }

        public double ValueMin { get; }
        public double ValueMax { get; }
        public ConfigAttribute(string description, object defaultValue, string valueType,double valueMin=0,double valueMax = 0)
        {
            Description = description;
            DefaultValue = defaultValue;
            ValueType = valueType;
            ValueMin = valueMin;
            ValueMax = valueMax;
        }
    }
}
