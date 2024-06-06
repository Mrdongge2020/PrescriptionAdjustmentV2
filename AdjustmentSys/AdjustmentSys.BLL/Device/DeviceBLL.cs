using AdjustmentSys.DAL.Device;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Device;
using AdjustmentSys.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.Device
{
    public class DeviceBLL
    {
        DeviceDAL deviceDAL = new DeviceDAL();
        /// <summary>
        /// 新增或编辑设备
        /// </summary>
        /// <returns></returns>
        public string AddOrEditDeviceInfo(DeviceInfo deviceInfo)
        {
            if (deviceInfo.ID == 0)
            {
                deviceInfo.CreateBy = SysLoginUser._currentUser.UserId;
                deviceInfo.CreateName = SysLoginUser._currentUser.UserName;
                deviceInfo.CreateTime = DateTime.Now;
            }
            return deviceDAL.AddOrEditDeviceInfo(deviceInfo);
        }

        /// <summary>
        /// 删除设备
        /// </summary>
        public string DeleteDeviceInfo(int id) 
        { 
            return deviceDAL.DeleteDeviceInfo(id);
        }

        /// <summary>
        /// 根据设备ID，获取设备信息
        /// </summary>
        /// <param name="id">设备id</param>
        /// <returns></returns>
        public DeviceInfo GetDeviceInfo(int id) 
        {
            return deviceDAL.GetDeviceInfo(id);
        }
        /// <summary>
        ///获取设备列表
        /// </summary>
        /// <returns></returns>
        public List<DeviceInfoListModel> GetDeviceInfoList()
        { 
            return deviceDAL.GetDeviceInfoList();
        }
    }
}
