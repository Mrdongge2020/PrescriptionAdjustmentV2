using AdjustmentSys.Tool.FileOpter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool
{
    public class IniConfigTB
    {
        
        /// <summary>
        /// 数据库备份日期
        /// </summary>
        [IniConfig("DataBaseSet", "BakDbDate", "1990-01-01")]
        public static string BakDbDate { get; set; }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        [IniConfig("DataBaseSet", "ConnString", "Server=47.109.107.251,1433;database=AdjustmentSysDB;uid=sa;pwd=LDSsql20231106;TrustServerCertificate=true")]
        public static string ConnString { get; set; }

        public static  void SetInitData() 
        {
            Type type = typeof(IniConfigTB);
            var properties = type.GetProperties().Where(p => (IniConfigAttribute)Attribute.GetCustomAttribute(p, typeof(IniConfigAttribute)) != null);
            foreach (var property in properties)
            {
                var descriptiveAttribute = (IniConfigAttribute)Attribute.GetCustomAttribute(property, typeof(IniConfigAttribute));
                if (descriptiveAttribute != null) 
                {
                    string keyValue = IniFileHelper.ReadIniData(descriptiveAttribute.Section, descriptiveAttribute.Key);
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        property.SetValue(null, keyValue);
                    }
                    else 
                    {
                        property.SetValue(null, descriptiveAttribute.KeyValue);
                        IniFileHelper.WriteIniData(descriptiveAttribute.Section, descriptiveAttribute.Key,descriptiveAttribute.KeyValue);
                    }
                }               
            }
        }
    }
}
