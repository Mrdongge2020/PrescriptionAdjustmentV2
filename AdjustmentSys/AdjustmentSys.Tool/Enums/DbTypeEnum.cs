using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.Enums
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DbTypeEnum
    {
        
        [Description("SqlServer")]
        SqlServer,
        [Description("OLEDB")]
        OLEDB,
        [Description("Oracle")]
        Oracle,
        [Description("MySql")]
        MySql,
        [Description("Firebird")]
        Firebird
    }
}
