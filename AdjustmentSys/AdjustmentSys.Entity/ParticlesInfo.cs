using AdjustmentSys.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Entity
{
    /// <summary>
    /// 颗粒信息表
    /// </summary>
    [Table("ParticlesInfo")]
    public class ParticlesInfo:UpdateModel
    {
        /// <summary>
        /// 名称简称
        /// </summary>
        [Column("Name")]
        [MaxLength(20)]
        public string Name { get; set; }
        /// <summary>
        /// 名称全称
        /// </summary>
        [Column("FullName")]
        [MaxLength(50)]
        public string FullName { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        [Column("Code")]
        [MaxLength(20)]
        public int Code { get; set; }
        /// <summary>
        /// 名称简称全拼
        /// </summary>
        [Column("NameFullPinyin")]
        [MaxLength(500)]
        public string NameFullPinyin { get; set; }
        /// <summary>
        /// 名称简称首字母拼音
        /// </summary>
        [Column("NameSimplifiedPinyin")]
        [MaxLength(500)]
        public string NameSimplifiedPinyin { get; set; }
        /// <summary>
        /// 厂家id
        /// </summary>
        [Column("ManufacturerId")]
        public int ManufacturerId { get; set; }
        /// <summary>
        /// 上市编号
        /// </summary>
        [Column("ListingNumber")]
        [MaxLength(50)]
        public string? ListingNumber { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        [MaxLength(200)]
        public string? Remark { get; set; }

        /// <summary>
        /// His码
        /// </summary>
        [Column("HisCode")]
        [MaxLength(50)]
        public string HisCode { get; set; }
        /// <summary>
        /// HIS名称
        /// </summary>
        [Column("HisName")]
        [MaxLength(50)]
        public string? HisName { get; set; }
        /// <summary>
        /// 颗粒密度
        /// </summary>
        [Column("Density")]
        [Description("颗粒密度")]
        public float Density { get; set; }
        /// <summary>
        /// 密度系数
        /// </summary>
        [Column("DensityCoefficient")]
        public float? DensityCoefficient { get; set; }
        /// <summary>
        /// 颗粒当量
        /// </summary>
        [Column("Equivalent")]
        [Description("颗粒当量")]
        public float Equivalent { get; set; }
        /// <summary>
        /// 剂量上限
        /// </summary>
        [Column("DoseLimit")]
        [MaxLength(50)]
        public float? DoseLimit { get; set; }
        /// <summary>
        /// 大包装码
        /// </summary>
        [Column("PackageNumber")]
        [MaxLength(20)]
        public string? PackageNumber { get; set; }

        /// <summary>
        /// 批发价
        /// </summary>
        [Column("WholesalePrice")]
        public decimal? WholesalePrice { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        [Column("RetailPrice")]
        public decimal? RetailPrice { get; set; }

    }
}
