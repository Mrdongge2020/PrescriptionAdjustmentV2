using AdjustmentSys.Common.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Drug
{
    /// <summary>
    /// 颗粒导入/导出实体
    /// </summary>
    public class ParticlesExportModel
    {
        /// <summary>
        /// 药品编码
        /// </summary>
        [Title(Titile = "药品编码")]
        public int Code { get; set; }
        /// <summary>
        /// 药品简称
        /// </summary>   
        [Title(Titile = "药品简称")]
        public string ParName { get; set; }
        /// <summary>
        /// 药品全称
        /// </summary>
        [Title(Titile = "药品全称")]
        public string FullName { get; set; }
        /// <summary>
        /// 简称首拼
        /// </summary>
        [Title(Titile = "简称首拼")]
        public string NameSimplifiedPinyin { get; set; }
        /// <summary>
        /// 简称全拼
        /// </summary>
        [Title(Titile = "简称全拼")]
        public string NameFullPinyin { get; set; }
       
        /// <summary>
        /// 厂家id
        /// </summary>
        public int ManufacturerId { get; set; }
        /// <summary>
        /// 厂家名称
        /// </summary>
        [Title(Titile = "厂家名称")]
        public string ManufacturerName { get; set; }
        /// <summary>
        /// HIS编码
        /// </summary>
        [Title(Titile = "HIS编码")]
        public string HisCode { get; set; }
        /// <summary>
        /// HIS名称
        /// </summary>
        [Title(Titile = "HIS名称")]
        public string? HisName { get; set; }
        /// <summary>
        /// 密度
        /// </summary>
        [Title(Titile = "密度")]
        public float Density { get; set; }
        /// <summary>
        /// 密度系数
        /// </summary>
        [Title(Titile = "密度系数")]
        public float DensityCoefficient { get; set; }
        /// <summary>
        /// 当量
        /// </summary>
        [Title(Titile = "当量")]
        public float Equivalent { get; set; }
        /// <summary>
        /// 剂量上限
        /// </summary>
        [Title(Titile = "剂量上限")]
        public float? DoseLimit { get; set; }
        /// <summary>
        /// 包装码
        /// </summary>
        [Title(Titile = "包装码")]
        public string? PackageNumber { get; set; }
        /// <summary>
        /// 供货价
        /// </summary>
        [Title(Titile = "供货价")]
        public decimal? WholesalePrice { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        [Title(Titile = "零售价")]
        public decimal? RetailPrice { get; set; }
        /// <summary>
        /// 上市编号
        /// </summary>
        [Title(Titile = "上市编号")]
        public string? ListingNumber { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Title(Titile = "备注")]
        public string? Remark { get; set; }
    }

    /// <summary>
    /// 异常药品导出类
    /// </summary>
    public class ErrorParticlesExportModel
    {
        /// <summary>
        /// 是否通过错误校验
        /// </summary>
        public string IsPassed { get; set; }
        /// <summary>
        /// 异常信息
        /// </summary>
        [Title(Titile = "异常信息")]
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// 药品编码
        /// </summary>
        [Title(Titile = "药品编码")]
        public int Code { get; set; }
        /// <summary>
        /// 药品简称
        /// </summary>   
        [Title(Titile = "药品简称")]
        public string ParName { get; set; }
        /// <summary>
        /// 药品全称
        /// </summary>
        [Title(Titile = "药品全称")]
        public string FullName { get; set; }
        /// <summary>
        /// 简称首拼
        /// </summary>
        [Title(Titile = "简称首拼")]
        public string NameSimplifiedPinyin { get; set; }
        /// <summary>
        /// 简称全拼
        /// </summary>
        [Title(Titile = "简称全拼")]
        public string NameFullPinyin { get; set; }

        /// <summary>
        /// 厂家id
        /// </summary>
        public int ManufacturerId { get; set; }
        /// <summary>
        /// 厂家名称
        /// </summary>
        [Title(Titile = "厂家名称")]
        public string ManufacturerName { get; set; }
        /// <summary>
        /// HIS编码
        /// </summary>
        [Title(Titile = "HIS编码")]
        public string HisCode { get; set; }
        /// <summary>
        /// HIS名称
        /// </summary>
        [Title(Titile = "HIS名称")]
        public string? HisName { get; set; }
        /// <summary>
        /// 密度
        /// </summary>
        [Title(Titile = "密度")]
        public float Density { get; set; }
        /// <summary>
        /// 密度系数
        /// </summary>
        [Title(Titile = "密度系数")]
        public float DensityCoefficient { get; set; }
        /// <summary>
        /// 当量
        /// </summary>
        [Title(Titile = "当量")]
        public float Equivalent { get; set; }
        /// <summary>
        /// 剂量上限
        /// </summary>
        [Title(Titile = "剂量上限")]
        public float? DoseLimit { get; set; }
        /// <summary>
        /// 包装码
        /// </summary>
        [Title(Titile = "包装码")]
        public string? PackageNumber { get; set; }
        /// <summary>
        /// 供货价
        /// </summary>
        [Title(Titile = "供货价")]
        public decimal? WholesalePrice { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        [Title(Titile = "零售价")]
        public decimal? RetailPrice { get; set; }
        /// <summary>
        /// 上市编号
        /// </summary>
        [Title(Titile = "上市编号")]
        public string? ListingNumber { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Title(Titile = "备注")]
        public string? Remark { get; set; }
    }
}
