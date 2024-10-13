using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.Enums
{
    public enum MakeParticleStatuEnum
    {
        [Description("无")]
        无 = 0,
        [Description("待称重")]
        待称重 = 1,
        [Description("待调剂")]
        待调剂 = 2,
        [Description("调剂中")]
        调剂中 = 3,
        [Description("待取出")]
        待取出 = 4,
        [Description("调剂完成")]
        调剂完成 = 5,
        [Description("待上药")]
        待上药 = 6

    }
}
