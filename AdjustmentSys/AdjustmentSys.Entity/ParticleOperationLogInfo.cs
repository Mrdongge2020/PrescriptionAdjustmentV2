using AdjustmentSys.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdjustmentSys.Tool.Enums;

namespace AdjustmentSys.Entity
{
    /// <summary>
    /// 颗粒操作日志表
    /// </summary>
    [Table("ParticleOperationLogInfo")]
    public class ParticleOperationLogInfo:CreateModel
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
        [Column("ParticleOperationLogType")]
        public ParticleOperationLogTypeEnum ParticleOperationLogType { get; set; }

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

    }
}
