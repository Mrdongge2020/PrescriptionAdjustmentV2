using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.Enums
{
    /// <summary>
    /// 设备操作异常
    /// </summary>
    public enum DeviceErrorEnum
    {
        [Description("封口交流电机回零超时")]
        封口交流电机回零超时 = 0,
        [Description("出盒交流电机回零超时")]
        出盒交流电机回零超时 = 1,
        [Description("下药电机回零超时")]
        下药电机回零超时 = 2,
        [Description("转盘电机回零超时")]
        转盘电机回零超时 = 3,
        [Description("下盒电机回零超时")]
        下盒电机回零超时 = 4,
        [Description("走膜电机回零超时")]
        走膜电机回零超时 = 5,
        [Description("下盒位有药盒")]
        下盒位有药盒 = 6,
        [Description("下盒失败")]
        下盒失败 = 7,
        [Description("封口位没药盒")]
        封口位没药盒 = 8,
        [Description("走膜失败")]
        走膜失败 = 9,
        [Description("交流电机正转超时")]
        交流电机正转超时 = 10,
        [Description("交流电机反转超时")]
        交流电机反转超时 = 11,
        [Description("封口机膜到位信号异常")]
        封口机膜到位信号异常 = 12,
        [Description("封口未达到封口温度")]
        封口未达到封口温度 = 13,
        [Description("出盒电机超时")]
        出盒电机超时 = 14,
        [Description("出盒失败")]
        出盒失败 = 15
    }
}
