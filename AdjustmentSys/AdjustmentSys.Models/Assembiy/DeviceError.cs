using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Assembiy
{
    /// <summary>
    /// 设备异常信息
    /// </summary>
    public class DeviceError
    {
        /// <summary>
        /// 异常类型
        /// </summary>
        public DeviceErrorEnum ErrorType { get; set; }
        /// <summary>
        /// 异常描述
        /// </summary>
        public string ErrorDecript { get { return StringHelper.GetEnumDescription(ErrorType); } }
    }
}
