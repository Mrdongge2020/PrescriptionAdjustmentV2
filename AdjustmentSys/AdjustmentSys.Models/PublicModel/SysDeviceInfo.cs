using AdjustmentSys.Models.User;
using AdjustmentSys.Tool.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.PublicModel
{
    public class SysDeviceInfo
    {
        /// <summary>
        /// 设备id
        /// </summary>
        public int DeviceId { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public DeviceTypeEnum DeviceType { get; set; }
        /// <summary>
        /// 设备连接状态
        /// </summary>
        public bool DeviceConnectStatus { get; set; }
        /// <summary>
        /// 药柜code
        /// </summary>
        public string MedicineCabinetCode { get; set; } = "20000";

        /// <summary>
        /// //应用单件模式，保存设备连接信息
        /// </summary>
        public static SysDeviceInfo _currentDeviceInfo = null;
        public static SysDeviceInfo currentDeviceInfo
        {
            get
            {
                if (_currentDeviceInfo == null)
                    _currentDeviceInfo = new SysDeviceInfo();
                return _currentDeviceInfo;
            }
        }
    }
}
