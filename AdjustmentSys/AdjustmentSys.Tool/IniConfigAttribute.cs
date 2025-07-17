using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool
{
    /// <summary>
    /// ini初始化
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IniConfigAttribute : Attribute
    {
        public string Section { get; }

        public string Key { get; }

        public string KeyValue { get; }

        public IniConfigAttribute(string Section, string Key, string KeyValue)
        {
            this.Section = Section;
            this.Key = Key;
            this.KeyValue = KeyValue;
        }
    }
}
