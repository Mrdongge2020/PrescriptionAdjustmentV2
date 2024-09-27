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
    /// 药柜详情表
    /// </summary>
    [Table("MedicineCabinetDetail")]
    public class MedicineCabinetDetail:UpdateModel
    {
        /// <summary>
        /// 药柜id
        /// </summary>
        [Column("MedicineCabinetId")]
        public int MedicineCabinetId { get; set; }
        /// <summary>
        /// 横坐标
        /// </summary>
        [Column("CoordinateX")]
        public int CoordinateX { get; set; }
        /// <summary>
        /// 纵坐标
        /// </summary>
        [Column("CoordinateY")]
        public int CoordinateY { get; set; }
        /// <summary>
        /// 颗粒id
        /// </summary>
        [Column("ParticlesID")]
        public int? ParticlesID { get; set; }

        /// <summary>
        /// 效期至
        /// </summary>
        [Column("ValidityTime")]
        public DateTime? ValidityTime { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
        [Column("BatchNumber")]
        [MaxLength(20)]
        public string? BatchNumber { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        [Column("Stock")]
        public float? Stock { get; set; }
        /// <summary>
        /// 瓶头累计调整量
        /// </summary>
        [Column("BottleHeadAdjustAmount")]
        public float? BottleHeadAdjustAmount { get; set; }
        /// <summary>
        /// 累计的误差量
        /// </summary>
        [Column("TotalErrorAmount")]
        public float? TotalErrorAmount { get; set; }
        /// <summary>
        /// 上次系数误差量
        /// </summary>
        [Column("LastCoefficientErrorAmount")]
        public float? LastCoefficientErrorAmount { get; set; }
        /// <summary>
        /// 总共使用数量
        /// </summary>
        [Column("TotalUsedAmount")]
        public float? TotalUsedAmount { get; set; }
        /// <summary>
        /// 本次调整量
        /// </summary>
        [Column("CurentAdjustAmount")]
        public float? CurentAdjustAmount { get; set; }
        /// <summary>
        /// 上次称重的重量
        /// </summary>
        [Column("LastWeightAmount")]
        public float? LastWeightAmount { get; set; }
        /// <summary>
        /// 空瓶重量
        /// </summary>
        [Column("EmptyBottleWeight")]
        public float? EmptyBottleWeight { get; set; }
        /// <summary>
        /// 密度系数
        /// </summary>
        [Column("DensityCoefficient")]
        public float? DensityCoefficient { get; set; }
        
        /// <summary>
        /// rfd
        /// </summary>
        [Column("RFID")]
        public int? RFID { get; set; }
        
    }
}
