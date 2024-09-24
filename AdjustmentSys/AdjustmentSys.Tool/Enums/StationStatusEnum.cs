using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.Enums
{
    /// <summary>
    /// 工位状态枚举
    /// </summary>
    public enum StationStatusEnum
    {
        [Description("无")]
        无 = 0,
        [Description("待放入")]
        待放入 = 1,
        [Description("待调剂")]
        待调剂 = 2,
        [Description("调剂中")]
        调剂中 = 3,
        [Description("待取走")]
        待取走 = 4,
        [Description("回零中")]
        回零中 = 5,
        [Description("回零完成")]
        回零完成 = 6,
        [Description("被禁用")]
        被禁用 = 7,
        [Description("余量不足")]
        余量不足 = 8,
        [Description("非处方药品")]
        非处方药品 = 9,
        [Description("该药品未称重")]
        该药品未称重 = 10
    }
}
