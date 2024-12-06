using AdjustmentSys.Tool.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdjustmentSys.Tool;

namespace AdjustmentSys.Models.MedicineCabinet
{
    public class MedicineCabinetOperationLogByPage
    {
        /// <summary>
        /// 使用量Sum
        /// </summary>
        public float UsedQuantitySum { get; set; } = 0;
        /// <summary>
        /// 上药量Sum
        /// </summary>
        public float AddQuantitySum { get; set; } = 0;
        /// <summary>
        /// 调整量Sum
        /// </summary>
        public float AdjustmentQuantitySum { get; set; } = 0;
        /// <summary>
        /// 列表数据
        /// </summary>
        public List<McParticLog> mcParticLogs { get; set; }
    }

    public class McParticLog 
    {
        /// <summary>
        /// 颗粒编号
        /// </summary>
        public int ParticleCode { get; set; }
        /// <summary>
        /// 颗粒名称
        /// </summary>
        public string ParticleName { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public MedicineCabinetOperationLogTypeEnum MedicineCabinetOperationLogType { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// 操作描述
        /// </summary>
        public string OperationLogDecribe { get { return StringHelper.GetEnumDescription(MedicineCabinetOperationLogType); } }
        /// <summary>
        /// 初始量
        /// </summary>
        public float InitialQuantity { get; set; } = 0;
        /// <summary>
        /// 当前称重量
        /// </summary>
        public float CurrentWeightQuantity { get; set; } = 0;
        /// <summary>
        /// 使用量
        /// </summary>
        public float UsedQuantity { get; set; } = 0;
        /// <summary>
        /// 上药量
        /// </summary>
        public float AddQuantity { get; set; } = 0;
        /// <summary>
        /// 调整量
        /// </summary>
        public float AdjustmentQuantity { get; set; } = 0;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        public string? CreateName { get; set; }
    }
}
