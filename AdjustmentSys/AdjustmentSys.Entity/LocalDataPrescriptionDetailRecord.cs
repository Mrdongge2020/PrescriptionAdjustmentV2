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
    /// 本地处方详情表记录
    /// </summary>
    [Table("LocalDataPrescriptionDetailRecord")]
    public class LocalDataPrescriptionDetailRecord: BaseModel
    {
        /// <summary>
        /// 处方唯一编号
        /// </summary>
        [Column("PrescriptionID")]
        [MaxLength(50)]
        public string PrescriptionID { get; set; }

        /// <summary>
        /// 颗粒序号
        /// </summary>
        [Column("ParticleOrder")]
        public int ParticleOrder { get; set; }

        /// <summary>
        /// HIS颗粒名称
        /// </summary>
        [Column("ParticlesNameHIS")]
        [MaxLength(50)]
        public string? ParticlesNameHIS { get; set; }

        /// <summary>
        /// 颗粒HIS码
        /// </summary>
        [Column("ParticlesCodeHIS")]
        [MaxLength(50)]
        public string ParticlesCodeHIS { get; set; }

        /// <summary>
        /// 我库颗粒id，默认-1
        /// </summary>
        [Column("ParticlesID")]
        public int ParticlesID { get; set; }

        /// <summary>
        /// 颗粒批号
        /// </summary>
        [Column("BatchNumber")]
        [MaxLength(50)]
        public string? BatchNumber { get; set; }
        /// <summary>
        /// 有效期至
        /// </summary>
        [Column("ValidityTime")]
        [MaxLength(20)]
        public string? ValidityTime { get; set; }

        /// <summary>
        /// 颗粒饮片剂量
        /// </summary>
        [Column("DoseHerb")]
        public float DoseHerb { get; set; }

        /// <summary>
        /// 颗粒当量
        /// </summary>
        [Column("Equivalent")]
        public float Equivalent { get; set; }

        /// <summary>
        /// 颗粒剂量
        /// </summary>
        [Column("Dose")]
        public float Dose { get; set; }

        /// <summary>
        /// 药品单价
        /// </summary>
        [Column("Price")]
        public decimal Price { get; set; }
    }
}
