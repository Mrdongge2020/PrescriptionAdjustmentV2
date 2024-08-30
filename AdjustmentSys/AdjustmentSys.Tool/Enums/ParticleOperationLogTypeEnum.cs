using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.Enums
{
    public enum ParticleOperationLogTypeEnum
    {
        [Description("新增药品")]
        新增药品 = 0,
        [Description("编辑药品")]
        编辑药品 = 1,
        [Description("删除药品")]
        删除药品 = 3
        
    }
}
