using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool
{
    /// <summary>
    /// 字符串工具类
    /// </summary>
    public  class StringHelper
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

        #region 数字转汉字
        private static char 转换数字(char x)
        {
            string stringChnNames = "零一二三四五六七八九";
            string stringNumNames = "0123456789";
            return stringChnNames[stringNumNames.IndexOf(x)];
        }
        private static string 转换万以下整数(string x)
        {
            string[] stringArrayLevelNames = new string[4] { "", "十", "百", "千" };
            string ret = "";
            int i;
            for (i = x.Length - 1; i >= 0; i--)
                if (x[i] == '0')
                    ret = 转换数字(x[i]) + ret;
                else
                    ret = 转换数字(x[i]) + stringArrayLevelNames[x.Length - 1 - i] + ret;
            while ((i = ret.IndexOf("零零")) != -1)
                ret = ret.Remove(i, 1);
            if (ret[ret.Length - 1] == '零' && ret.Length > 1)
                ret = ret.Remove(ret.Length - 1, 1);
            if (ret.Length >= 2 && ret.Substring(0, 2) == "一十")
                ret = ret.Remove(0, 1);
            return ret;
        }
        /// <summary>
        /// 将数字转换成汉子大小实例
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string ConvertInteger(string x)
        {
            int len = x.Length;
            string ret, temp;
            if (len <= 4)
                ret = 转换万以下整数(x);
            else if (len <= 8)
            {
                ret = 转换万以下整数(x.Substring(0, len - 4)) + "万";
                temp = 转换万以下整数(x.Substring(len - 4, 4));
                if (temp.IndexOf("千") == -1 && temp != "")
                    ret += "零" + temp;
                else
                    ret += temp;
            }
            else
            {
                ret = 转换万以下整数(x.Substring(0, len - 8)) + "亿";
                temp = 转换万以下整数(x.Substring(len - 8, 4));
                if (temp.IndexOf("千") == -1 && temp != "")
                    ret += "零" + temp;
                else
                    ret += temp;
                ret += "万";
                temp = 转换万以下整数(x.Substring(len - 4, 4));
                if (temp.IndexOf("千") == -1 && temp != "")
                    ret += "零" + temp;
                else
                    ret += temp;
            }
            int i;
            if ((i = ret.IndexOf("零万")) != -1)
                ret = ret.Remove(i + 1, 1);
            while ((i = ret.IndexOf("零零")) != -1)
                ret = ret.Remove(i, 1);
            if (ret[ret.Length - 1] == '零' && ret.Length > 1)
                ret = ret.Remove(ret.Length - 1, 1);
            return ret;
        }
        #endregion

        #region 枚举
        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum enumValue)
        {
            FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());
            DescriptionAttribute attr = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
            return attr?.Description ?? enumValue.ToString();
        } 
        #endregion
    }
}
