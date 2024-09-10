using AdjustmentSys.Common.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Drug
{
    public class ParticlesMateModel
    {
        /// <summary>
        /// 药品简称
        /// </summary>   
        [Title(Titile = "药品简称")]
        public string ParName { get; set; }

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
        /// 密度
        /// </summary>
        [Title(Titile = "密度")]
        public float Density { get; set; }

        /// <summary>
        /// 当量
        /// </summary>
        [Title(Titile = "当量")]
        public float Equivalent { get; set; }
        /// <summary>
        /// 包装码
        /// </summary>
        [Title(Titile = "包装码")]
        public string? PackageNumber { get; set; }
    }
}
