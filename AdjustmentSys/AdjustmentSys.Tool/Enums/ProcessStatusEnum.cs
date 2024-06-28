using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.Enums
{
    /// <summary>
    /// 处方状态
    /// </summary>
    public enum ProcessStatusEnum
    {
        [Description("待下载")]
        待下载 = 0,
        [Description("待核对")]
        待核对 = 1,
        [Description("待调剂")]
        待调剂 = 2,
        [Description("完成")]
        完成 = 3,
        [Description("作废")]
        作废 = 4
    }
}
