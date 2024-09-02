using AdjustmentSys.DAL.Common;
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
    }
}
