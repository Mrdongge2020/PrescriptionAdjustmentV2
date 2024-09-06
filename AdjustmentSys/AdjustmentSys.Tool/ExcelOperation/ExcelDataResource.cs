using System;
using System.Collections.Generic;
using System.Text;

namespace AdjustmentSys.Common.Tool
{
    public class ExcelDataResource
    {
        /// <summary>
        /// 页签名称
        /// </summary>
        public string SheetName { get; set; }
        /// <summary>
        /// 标题所在行
        /// </summary>
        public int TitleIndex { get; set; }

        /// <summary>
        /// 每一行的数据
        /// </summary>
        public List<object>? SheetDataResource { get; set; }
    }
     

    public class UserInfo
    {
        [Title(Titile = "用户Id")]
        public int UserId { get; set; }
         
        [Title(Titile = "用户名称")]
        public string UserName { get; set; }

        [Title(Titile = "用户年龄")]
        public int Age { get; set; }

        [Title(Titile = "用户类型")]
        public int UserType { get; set; }
         
        [Title(Titile = "描述")]
        public string Description { get; set; }
    }
     
    public class ClassInfo
    {
        [Title(Titile = "学生Id")]
        public int UserId { get; set; }


        [Title(Titile = "学生名称")]
        public string UserName { get; set; }

        [Title(Titile = "学生年龄")]
        public int Age { get; set; }

        [Title(Titile = "学生类型")]
        public int UserType { get; set; }


        [Title(Titile = "学生描述1")]
        public string Description1 { get; set; }

        [Title(Titile = "学生描述2")]
        public string Description2 { get; set; }

        [Title(Titile = "学生描述3")]
        public string Description3 { get; set; }

        [Title(Titile = "学生描述4")]
        public string Description4 { get; set; }
    }
}
