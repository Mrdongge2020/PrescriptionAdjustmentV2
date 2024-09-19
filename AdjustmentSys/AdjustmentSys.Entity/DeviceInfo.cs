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
    /// 设备信息表
    /// </summary>
    [Table("DeviceInfo")]
    public class DeviceInfo:CreateModel
    {
        /// <summary>
        /// 设备编组
        /// </summary>
        [Column("DeviceCode")]
        [MaxLength(20)]
        public string DeviceCode { get; set; }
        /// <summary>
        ///名称
        /// </summary>
        [Column("Name")]
        [MaxLength(20)]
        public string Name { get; set; }
        /// <summary>
        ///设备类型
        /// </summary>
        [Column("DeviceType")]
        public DeviceTypeEnum DeviceType { get; set; }
        /// <summary>
        ///IP地址
        /// </summary>
        [Column("IPAddress")]
        [MaxLength(20)]
        public string? IPAddress { get; set; }
        /// <summary>
        ///设备药柜编号
        /// </summary>
        [Column("MedicineCabinetCode")]
        [MaxLength(20)]
        public string? MedicineCabinetCode { get; set; }

        /// <summary>
        ///是否启用
        /// </summary>
        [Column("IsEnable")]
        public bool IsEnable { get; set; }
    }
}
