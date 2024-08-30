using AdjustmentSys.Tool.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdjustmentSys.Entity.BaseEntity;

namespace AdjustmentSys.Entity
{
    /// <summary>
    /// 药柜颗粒操作日志表
    /// </summary>
    [Table("MedicineCabinetOperationLogInfo")]
    public class MedicineCabinetOperationLogInfo:CreateModel
    {
        /// <summary>
        /// 颗粒编号
        /// </summary>
        [Column("ParticleCode")]
        [MaxLength(20)]
        public string ParticleCode { get; set; }
        /// <summary>
        /// 颗粒名称
        /// </summary>
        [Column("ParticleName")]
        [MaxLength(20)]
        public string ParticleName { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        [Column("MedicineCabinetOperationLogType")]
        public MedicineCabinetOperationLogTypeEnum MedicineCabinetOperationLogType { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        [Column("DeviceName")]
        [MaxLength(20)]
        public string DeviceName { get; set; }
        /// <summary>
        /// 操作描述
        /// </summary>
        [Column("OperationLogDecribe")]
        [MaxLength(200)]
        public string OperationLogDecribe { get; set; }
        /// <summary>
        /// 初始量
        /// </summary>
        [Column("InitialQuantity")]
        public float InitialQuantity { get; set; } = 0;
        /// <summary>
        /// 当前称重量
        /// </summary>
        [Column("CurrentWeightQuantity")]
        public float CurrentWeightQuantity { get; set; } = 0;
        /// <summary>
        /// 使用量
        /// </summary>
        [Column("UsedQuantity")]
        public float UsedQuantity { get; set; } = 0;
        /// <summary>
        /// 上药量
        /// </summary>
        [Column("AddQuantity")]
        public float AddQuantity { get; set; } = 0;
        /// <summary>
        /// 调整量
        /// </summary>
        [Column("AdjustmentQuantity")]
        public float AdjustmentQuantity { get; set; } = 0;
    }
}
