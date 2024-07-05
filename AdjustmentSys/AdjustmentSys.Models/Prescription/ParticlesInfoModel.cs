using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Prescription
{
    public class ParticlesInfoModel
    {
        /// <summary>
        /// 颗粒ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ParName { get; set; }
        /// <summary>
        /// His码
        /// </summary>
        public string HisCode { get; set; }
        /// <summary>
        /// His颗粒名称
        /// </summary>
        public string? HisName { get; set; }
        /// <summary>
        /// 药品编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 当量
        /// </summary>
        public float Equivalent { get; set; }

        /// <summary>
        /// 剂量上限
        /// </summary>
        public float? DoseLimit { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        public decimal RetailPrice { get; set; }
        /// <summary>
        /// 饮片剂量
        /// </summary>
        public float DoseHerb { get; set; }
        /// <summary>
        /// 颗粒剂量
        /// </summary>
        public float Dose { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public float? Stock { get; set; }


    }
}
