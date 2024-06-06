using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Drug
{
    /// <summary>
    /// 解析结果
    /// </summary>
    public class ManufacturerRuleResultModel
    {
        /// <summary>
        /// 颗粒密度
        /// </summary>
        public float Density { get; set; }
        /// <summary>
        /// 颗粒当量
        /// </summary>
        public float Equivalent { get; set; }
        /// <summary>
        /// 大包装码
        /// </summary>
        public string PackageNumber { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string BatchNumber { get; set; }
        /// <summary>
        /// 有效期至
        /// </summary>
        public string VaildUntil { get; set; }
        /// <summary>
        /// 包装类型
        /// </summary>
        public string PackageType { get; set; }
        /// <summary>
        /// 装量
        /// </summary>
        public float LoadCapacity { get; set; }
    }
}
