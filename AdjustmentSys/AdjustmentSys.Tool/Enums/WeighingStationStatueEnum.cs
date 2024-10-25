using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.Enums
{
    /// <summary>
    /// 称重工位状态
    /// </summary>
    public enum WeighingStationStatueEnum
    {
        [Description("无")]
        无 = 0,
        [Description("称重完成")]
        称重完成 = 1,
        [Description("余量不足")]
        余量不足 = 2,
        [Description("非处方药品")]
        非处方药品 = 3,
        [Description("该药品已称重")]
        该药品已称重 = 4
    }
}
