using AdjustmentSys.DAL.Common;
using AdjustmentSys.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.Common
{
    public  class CommonStaticDataBLL
    {
       private static  CommonStaticDataDAL commonStaticDataDAL = new CommonStaticDataDAL();

        /// <summary>
        /// 根据参数名称获取参数值
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static string GetSystemParameterValue(string parameterName) 
        { 
            return commonStaticDataDAL.GetSystemParameterValue(parameterName);
        }

        /// <summary>
        /// 根据参数所属设备类型获取所有参数信息
        /// </summary>
        /// <returns></returns>
        public static List<SystemParameterInfo> GetSystemParameterValue() 
        { 
            return commonStaticDataDAL.GetSystemParameterValue();
        }
    }
}
