using AdjustmentSys.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Entity
{
    /// <summary>
    /// 颗粒详情信息
    /// </summary>
    [Table("ParticlesInfoExtend")]
    public class ParticlesInfoExtend:BaseModel
    {
        /// <summary>
        /// 颗粒id
        /// </summary>
        [Column("ParticlesID")]
        public int ParticlesID { get; set; }
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
        ///// <summary>
        ///// 批号
        ///// </summary>
        //[Column("BatchNumber")]
        //[MaxLength(50)]
        //public string? BatchNumber { get; set; }
        ///// <summary>
        ///// 有效期至
        ///// </summary>
        //[Column("VaildUntil")]
        //[MaxLength(20)]
        //public string? VaildUntil { get; set; }
        
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
