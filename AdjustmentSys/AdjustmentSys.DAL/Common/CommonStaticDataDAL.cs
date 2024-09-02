using AdjustmentSys.EFCore;
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
    }
}
