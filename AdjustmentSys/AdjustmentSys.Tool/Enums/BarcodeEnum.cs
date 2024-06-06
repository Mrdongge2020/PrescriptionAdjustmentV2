using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.Enums
{
    /// <summary>
    /// 解析类型枚举
    /// </summary>
    public enum BarcodeEnum
    {
        /// <summary>
        /// 大包装码
        /// </summary>
        [Description("大包装码")]
        Packaging,
        /// <summary>
        /// 包装类型
        /// </summary>
        [Description("包装类型")]
        PackagingType,
        /// <summary>
        /// 批号
        /// </summary>
        [Description("批号")]
        BatchNumber,
        /// <summary>
        /// 有效期
        /// </summary>
        [Description("有效期")]
        VaildUntil,
        /// <summary>
        /// 当量
        /// </summary>
        [Description("当量")]
        Equivalent,
        /// <summary>
        /// 密度
        /// </summary>

        [Description("密度")]
        Density,
        /// <summary>
        /// 装量
        /// </summary>
        [Description("装量")]
        LoadingCapacity
    }
}
