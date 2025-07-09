using AdjustmentSys.Entity.BaseEntity;
using AdjustmentSys.Tool.Enums;
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
    /// 系统配置表
    /// </summary>
    [Table("ConfigInfo")]
    public class ConfigInfo:BaseModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Column("Name")]
        [MaxLength(20)]
        public string Name { get; set; }
        /// <summary>
        /// 中文名称
        /// </summary>
        [Column("ChineseName")]
        [MaxLength(20)]
        public string ChineseName { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [Column("DataValue")]
        [MaxLength(20)]
        public string DataValue { get; set; }

        /// <summary>
        /// 值类型
        /// </summary>
        [Column("DataValueType")]
        [MaxLength(20)]
        public string DataValueType { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        [Column("DataValuMin")]
        public double? DataValuMin { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        [Column("DataValuMax")]
        public double? DataValuMax { get; set; }

        /// <summary>
        /// 设备id
        /// </summary>
        [Column("DeviceId")]
        public int DeviceId { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        [Column("DeviceType")]
        public DeviceTypeEnum DeviceType { get; set; }
    }
}
