using AdjustmentSys.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Entity
{
    /// <summary>
    ///协定处方详情表
    /// </summary>
    [Table("AgreementPrescriptionDetail")]
    public class AgreementPrescriptionDetail:BaseModel
    {
        /// <summary>
        /// 协定处方id
        /// </summary>
        [Column("AgreementPrescriptionId")]
        public int AgreementPrescriptionId { get; set; }
        /// <summary>
        /// 颗粒id
        /// </summary>
        [Column("Particles")]
        public int Particles { get; set; }
        /// <summary>
        /// 饮片剂量
        /// </summary>
        [Column("DoseHerb")]
        public float DoseHerb { get; set; }
        /// <summary>
        /// 当量
        /// </summary>
        [Column("Equivalent")]
        public float Equivalent { get; set; }
        /// <summary>
        /// 颗粒剂量
        /// </summary>
        [Column("Dose")]
        public float Dose { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [Column("Price")]
        public decimal Price { get; set; }

    }
}
