using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.Enums
{
    public enum WorkStateEnum
    {
        [Description("等待回零")]
        Write,
        [Description("回零")]
        Home, 
        [Description("调剂")]
        Work,
        [Description("密度测量中")]
        Density,
        [Description("调试模式")]
        Set,
        [Description("恢复模式")]
        Rest
    }
}
