using System;
using System.Collections.Generic;
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
        封口交流电机回季超时 = 0,
        出盒交流电机回零超时 = 1,
        下药电机回季超时 = 2,
        转盘电机回季超时 = 3,
        下盒电机回零超时 = 4,
        走膜电机回季超时 = 5,
        下盒位有药盒 = 6,
        下盒失败 = 7,
        封口位没药盒 = 8,
        走膜失败 = 9,
        交流电机正转超时 = 10,
        交流电机反转超时 = 11,
        封口机膜到位信号异常 = 12,
        封口未达到封口温度 = 13,
        出盒电机超时 = 14,
        出盒失败 = 15
    }
}
