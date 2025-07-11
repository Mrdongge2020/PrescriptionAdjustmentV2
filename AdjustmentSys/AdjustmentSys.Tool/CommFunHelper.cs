using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool
{
    public class CommFunHelper
    {
        public static T CopySimilarProperties<T, S>(T target, S source)
        {
            if (source == null)
                return default;

            var sourceType = typeof(S);
            var targetType = target.GetType();
            var sourceProperties = sourceType.GetProperties().Where(p => p.CanRead);

            foreach (var sourceProperty in sourceProperties)
            {
                var targetProperty = targetType.GetProperty(sourceProperty.Name);
                if (!(targetProperty != null && targetProperty.CanWrite)) { continue; }
                if (targetProperty.Name == "ID") { continue; }
                var sourceValue = sourceProperty.GetValue(source, null); //sourceProperty.GetValue(targetProperty, null);
                if (sourceValue != null)
                {
                    targetProperty.SetValue(target, sourceValue);
                }
                else
                {
                    var ptype = targetProperty.PropertyType;
                    // 设置默认值
                    if (ptype == typeof(int) || ptype == typeof(int?) || ptype == typeof(double) ||
                        ptype == typeof(double?) || ptype == typeof(float) || ptype == typeof(float?) ||
                        ptype == typeof(decimal) || ptype == typeof(decimal?))
                    {
                        targetProperty.SetValue(target, 0);
                    }
                    else if (ptype == typeof(string))
                    {
                        targetProperty.SetValue(target, "");
                    }
                    else if (ptype == typeof(DateTime))
                    {
                        targetProperty.SetValue(target, DateTime.Now);
                    }
                    // ... 其他类型
                    else
                    {
                        // 设置为null或其他默认值
                        targetProperty.SetValue(target, null);
                    }
                }
            }
            return target;
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString(); // 如果没有找到描述，则返回枚举的名称
        }
    }
}
