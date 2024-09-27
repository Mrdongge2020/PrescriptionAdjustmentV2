using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.Enums
{
    /// <summary>
    /// 药盒状态枚举
    /// </summary>
    public enum BoxStatusEnum
    {
        [Description("无")]
        无 = 0,
        [Description("供盒中")]
        供盒中 = 1,
        [Description("待调剂")]
        待调剂 = 2,
        [Description("调剂中")]
        调剂中 = 3,
        [Description("待封口")]
        待封口 = 4,
        [Description("封口中")]
        封口中 = 5,
        [Description("待出盒")]
        待出盒 = 6,
        [Description("出盒中")]
        出盒中 = 7
    }
}
