using AdjustmentSys.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Entity
{
    /// <summary>
    /// 厂家解析码表
    /// </summary>
    [Table("ManufacturerResolutionCode")]
    public class ManufacturerResolutionCode:UpdateModel
    {
        /// <summary>
        /// 厂家id
        /// </summary>
        [Column("ManufacturerId")]
        public int ManufacturerId { get; set; }

        /// <summary>
        /// 示例code
        /// </summary>
        [Column("ExampleCode")]
        [MaxLength(50)]
        public string ExampleCode { get; set; }

        /// <summary>
        /// 大包装码开始位置
        /// </summary>
        [Column("LargePackagingCodeIndex")]
        public int LargePackagingCodeIndex { get; set; }
        /// <summary>
        /// 大包装码长度
        /// </summary>
        [Column("LargePackagingCodeLength")]
        public int LargePackagingCodeLength { get; set; }

        /// <summary>
        /// 包装类型开始位置
        /// </summary>
        [Column("PackagingTypeIndex")]
        public int? PackagingTypeIndex { get; set; }
        /// <summary>
        /// 包装类型长度
        /// </summary>
        [Column("PackagingTypeLength")]
        public int? PackagingTypeLength { get; set; }

        /// <summary>
        /// 批号开始位置
        /// </summary>
        [Column("BatchNumberIndex")]
        public int? BatchNumberIndex { get; set; }
        /// <summary>
        /// 批号长度
        /// </summary>
        [Column("BatchNumberLength")]
        public int? BatchNumberLength { get; set; }

        /// <summary>
        /// 有效期开始位置
        /// </summary>
        [Column("ValidityPeriodIndex")]
        public int? ValidityPeriodIndex { get; set; }
        /// <summary>
        /// 有效期长度
        /// </summary>
        [Column("ValidityPeriodLength")]
        public int? ValidityPeriodLength { get; set; }

        /// <summary>
        /// 当量开始位置
        /// </summary>
        [Column("EquivalentIndex")]
        public int? EquivalentIndex { get; set; }
        /// <summary>
        /// 当量长度
        /// </summary>
        [Column("EquivalentLength")]
        public int? EquivalentLength { get; set; }
        /// <summary>
        /// 密度开始位置
        /// </summary>
        [Column("DensityIndex")]
        public int DensityIndex { get; set; }
        /// <summary>
        /// 密度长度
        /// </summary>
        [Column("DensityLength")]
        public int DensityLength { get; set; }

        /// <summary>
        /// 装量开始位置
        /// </summary>
        [Column("LoadingCapacityIndex")]
        public int LoadingCapacityIndex { get; set; }
        /// <summary>
        /// 装量长度
        /// </summary>
        [Column("LoadingCapacityLength")]
        public int LoadingCapacityLength { get; set; }
    }
}
