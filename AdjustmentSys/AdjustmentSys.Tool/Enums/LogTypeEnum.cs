using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.Enums
{
    public enum LogTypeEnum
    {
        [Description("Adjustment")]
        处方调剂,
        [Description("DataBase")]
        数据库,
        [Description("UserOpter")]
        用户操作,
        [Description("SysError")]
        系统异常
    }
}
