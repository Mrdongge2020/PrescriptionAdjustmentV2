using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.Enums
{
    /// <summary>
    /// 要贵操作日志类型
    /// </summary>
    public enum MedicineCabinetOperationLogTypeEnum
    {
        [Description("上架药品")]
        上架药品 = 0,
        [Description("下架药品")]
        下架药品 = 1,
        [Description("调剂药品")]
        调剂药品 = 2,
        [Description("余量校准")]
        余量校准 = 3,
        [Description("余量调整")]
        余量调整 = 4,
        [Description("添加药品")]
        添加药品 = 5,
        [Description("异常上药")]
        异常上药 = 6
    }
}
