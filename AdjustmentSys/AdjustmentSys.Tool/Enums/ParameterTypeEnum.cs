using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.Enums
{
    /// <summary>
    /// 系统参数类型
    /// </summary>
    public enum ParameterTypeEnum
    {
        [Description("功能设置")]
        功能设置 = 0,
        [Description("打印设置")]
        打印设置 = 1
    }
}
