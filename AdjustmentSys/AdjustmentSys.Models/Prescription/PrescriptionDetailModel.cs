using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Prescription
{
    public class PrescriptionDetailModel
    {
        /// <summary>
        /// id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 颗粒序号
        /// </summary>
        public int ParticleOrder { get; set; }

        /// <summary>
        /// HIS颗粒名称
        /// </summary>
        public string ParticlesNameHIS { get; set; }

        /// <summary>
        /// 颗粒HIS码
        /// </summary>
        public string ParticlesCodeHIS { get; set; }

        /// <summary>
        /// 我库颗粒id
        /// </summary>
        public int ParticlesID { get; set; }
        /// <summary>
        /// 我库颗粒编码
        /// </summary>
        public int ParCode { get; set; }
        /// <summary>
        /// 我库颗粒名称
        /// </summary>
        public string ParName { get; set; }

        /// <summary>
        /// 颗粒批号
        /// </summary>
        public string BatchNumber { get; set; }
        /// <summary>
        /// 颗粒效期
        /// </summary>
        public string ValidityTime { get; set; }

        /// <summary>
        /// 颗粒饮片剂量
        /// </summary>
        public float DoseHerb { get; set; }

        /// <summary>
        /// 颗粒当量
        /// </summary>
        public float Equivalent { get; set; }

        /// <summary>
        /// 颗粒剂量
        /// </summary>
        public float Dose { get; set; }

        /// <summary>
        /// 药品单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public float? Stock { get; set; }
        /// <summary>
        /// 剂量上限
        /// </summary>
        public float? DoseLimit { get; set; }
    }
}
