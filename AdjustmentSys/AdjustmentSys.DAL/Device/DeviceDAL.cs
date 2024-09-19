using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Device;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.DAL.Device
{
    /// <summary>
    /// 设备数据操作
    /// </summary>
    public class DeviceDAL
    {
        private readonly EFCoreContext _eFCoreContext = new EFCoreContext();

        /// <summary>
        /// 新增或编辑设备
        /// </summary>
        /// <returns></returns>
        public string AddOrEditDeviceInfo(DeviceInfo deviceInfo)
        {
            string error = "";
            try
            {
                if (deviceInfo.ID != default(int))
                {
                    bool isExitDevice = _eFCoreContext.DeviceInfos.Any(x => x.Name == deviceInfo.Name && x.ID != deviceInfo.ID);
                    if (isExitDevice)
                    {
                        return "该设备名称已存在";
                    }
                    
                    var device = _eFCoreContext.DeviceInfos.FirstOrDefault(x => x.ID == deviceInfo.ID);
                    if (device == null)
                    {
                        return "未找到要编辑的设备信息，请刷新后再试";
                    }
                    device.Name = deviceInfo.Name;
                    device.DeviceType = deviceInfo.DeviceType;
                    device.IPAddress = deviceInfo.IPAddress;
                    device.DeviceCode= deviceInfo.DeviceCode;
                    device.MedicineCabinetCode = deviceInfo.MedicineCabinetCode;
                    device.IsEnable = deviceInfo.IsEnable;
                    //可省略
                    _eFCoreContext.DeviceInfos.Update(device);
                }
                else
                {
                    bool isExitDevice = _eFCoreContext.DeviceInfos.Any(x => x.Name == deviceInfo.Name);
                    if (isExitDevice)
                    {
                        return "该设备名称已存在";
                    }
                    
                    _eFCoreContext.DeviceInfos.Add(deviceInfo);
                }

                var result = _eFCoreContext.SaveChanges();
                if (result <= 0)
                {
                    error = (deviceInfo.ID > 0 ? "编辑" : "新增") + "设备信息失败，请稍后再试。";
                }
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return error;
        }

        /// <summary>
        /// 删除设备
        /// </summary>
        public string DeleteDeviceInfo(int id)
        {
            string errorMsg = "";
            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    //删除设备表
                    _eFCoreContext.DeviceInfos.Where(x => x.ID == id).ExecuteDelete();
                    //删除设备与药柜组的关联关系
                    _eFCoreContext.DeviceMedicineCabinetCodeRelations.Where(x => x.DeviceId == id).ExecuteDelete();
                    //删除设备的其他初始化信息？

                    _eFCoreContext.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    errorMsg = "删除药品信息失败,请稍后再试";
                }
            }

            return errorMsg;
        }

        /// <summary>
        /// 根据设备ID，获取设备信息
        /// </summary>
        /// <param name="id">设备id</param>
        /// <returns></returns>
        public DeviceInfo GetDeviceInfo(int id)
        {
            return _eFCoreContext.DeviceInfos.AsNoTracking().FirstOrDefault(x => x.ID == id);
        }

        /// <summary>
        ///获取设备列表
        /// </summary>
        /// <returns></returns>
        public List<DeviceInfoListModel> GetDeviceInfoList()
        {
            return _eFCoreContext.DeviceInfos.OrderBy(x=>x.ID).Select(x=>new DeviceInfoListModel()
            {
                ID = x.ID,
                Name = x.Name,
                DeviceCode = x.DeviceCode,
                DeviceType = x.DeviceType,
                IPAddress=x.IPAddress,
                CreateName = x.CreateName,
                CreateTime = x.CreateTime,
                MedicineCabinetCode=x.MedicineCabinetCode,
                IsEnable=x.IsEnable?"已启用":"已禁用"
            }).ToList();
        }
    }
}
