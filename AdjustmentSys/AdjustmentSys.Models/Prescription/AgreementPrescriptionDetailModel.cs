using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Prescription
{
    public class AgreementPrescriptionDetailModel
    {
        /// <summary>
        /// id
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 颗粒id
        /// </summary>
        public int ParticlesId { get; set; }
        /// <summary>
        /// 饮片剂量
        /// </summary>
        public float DoseHerb { get; set; }
        /// <summary>
        /// 当量
        /// </summary>
        public float Equivalent { get; set; }
        /// <summary>
        /// 颗粒剂量
        /// </summary>
        public float Dose { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 颗粒名称
        /// </summary>
        public string Name { get; set; }
    }
}
