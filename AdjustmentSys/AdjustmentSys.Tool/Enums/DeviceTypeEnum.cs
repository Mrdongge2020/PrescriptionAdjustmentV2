using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.Enums
{
    /// <summary>
    /// 设备类型
    /// </summary>
    public enum DeviceTypeEnum
    {
        [Description("全自动")]
        全自动 = 0,
        [Description("半自动袋装")]
        半自动袋装 = 1,
        [Description("半自动盒装")]
        半自动盒装 = 2,
        [Description("单工位")]
        单工位 = 3,
    }
}
