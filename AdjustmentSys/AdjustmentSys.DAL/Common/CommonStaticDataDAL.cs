using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.DAL.Common
{
    public class CommonStaticDataDAL
    {
        private readonly EFCoreContext _eFCoreContext = new EFCoreContext();

        /// <summary>
        /// 根据参数名称获取参数值
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public string GetSystemParameterValue(string parameterName) 
        {
            string valueStr = _eFCoreContext.SystemParameterInfos.FirstOrDefault(x => x.ParameterName == parameterName)?.ParameterValue;
            if (string.IsNullOrEmpty(valueStr))
            {
                return "";
            }
            else 
            { 
                return valueStr;
            }
        }

        /// <summary>
        /// 根据参数所属设备类型获取所有参数信息
        /// </summary>
        /// <returns></returns>
        public List<SystemParameterInfo> GetSystemParameterValue()
        {
            var  allParams = _eFCoreContext.SystemParameterInfos.Where(x=>x.DeviceType==SysDeviceInfo._currentDeviceInfo.DeviceType).ToList();
            if (allParams!=null && allParams.Count>0)
            {
                return allParams;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExecuteSQL(string sql)
        {
            return DBHelper.Execute(sql);
        }
    }
}
