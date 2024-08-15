using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AdjustmentSys.Models.Drug
{
    public class ParticlesInfoEditModel
    {
        /// <summary>
        /// 颗粒id
        /// </summary>
        public int? ID { get; set; }
        /// <summary>
        /// 名称简称
        /// </summary>   
        public string Name { get; set; }
        /// <summary>
        /// 名称全称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名称简称全拼
        /// </summary>
        public string NameFullPinyin { get; set; }
        /// <summary>
        /// 名称简称首字母拼音
        /// </summary>
        public string NameSimplifiedPinyin { get; set; }
        /// <summary>
        /// 厂家id
        /// </summary>
        public int ManufacturerId { get; set; }
        /// <summary>
        /// 上市编号
        /// </summary>
        public string? ListingNumber { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
  
        /// <summary>
        /// His码
        /// </summary>
        public string HisCode { get; set; }
        /// <summary>
        /// HIS名称
        /// </summary>
        public string? HisName { get; set; }
        /// <summary>
        /// 颗粒密度
        /// </summary>
        public float Density { get; set; }
        /// <summary>
        /// 颗粒当量
        /// </summary>
        public float Equivalent { get; set; }
        /// <summary>
        /// 剂量上限
        /// </summary>
        public float? DoseLimit { get; set; }
        /// <summary>
        /// 大包装码
        /// </summary>
        public string? PackageNumber { get; set; }
        /// <summary>
        /// 批发价
        /// </summary>
        public decimal? WholesalePrice { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        public decimal? RetailPrice { get; set; }
    }
}
