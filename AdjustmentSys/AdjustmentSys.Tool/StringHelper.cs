using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool
{
    /// <summary>
    /// 字符串工具类
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// 判断字符串是否是int型数字,返回true是，false不是
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsIntNum(string str)
        {
            System.Text.RegularExpressions.Regex reg1
            = new System.Text.RegularExpressions.
            Regex(@"^[-]?[1-9]{1}\d*$|^[0]{1}$");
            bool ismatch = reg1.IsMatch(str);
           
            return ismatch;
        }
    }
}
