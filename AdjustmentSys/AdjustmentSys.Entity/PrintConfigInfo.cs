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
    /// 打印配置表
    /// </summary>
    [Table("PrintConfigInfo")]
    public class PrintConfigInfo:BaseModel
    {
        /// <summary>
        /// 项名称
        /// </summary>
        [Column("ItemName")]
        [MaxLength(50)]
        public string ItemName { get; set; }
        /// <summary>
        /// 项中文名称
        /// </summary>
        [Column("ItemChineseName")]
        [MaxLength(50)]
        public string ItemChineseName { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [Column("DataValue")]
        [MaxLength(50)]
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
    }
}
