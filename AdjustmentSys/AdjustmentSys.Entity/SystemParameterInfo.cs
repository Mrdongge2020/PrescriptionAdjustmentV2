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
    /// 系统参数表
    /// </summary>
    [Table("SystemParameterInfo")]
    public class SystemParameterInfo:UpdateModel
    {
        /// <summary>
        /// 设备类型
        /// </summary>
        [Column("DeviceType")]
        public DeviceTypeEnum DeviceType { get; set; }
        /// <summary>
        /// 系统参数类型
        /// </summary>
        [Column("ParameterType")]
        public ParameterTypeEnum ParameterType { get; set; }

        /// <summary>
        /// 参数名称
        /// </summary>
        [Column("ParameterName")]
        [MaxLength(20)]
        public string ParameterName { get; set; }
        /// <summary>
        /// 参数值
        /// </summary>
        [Column("ParameterValue")]
        [MaxLength(200)]
        public string ParameterValue { get; set; }
        /// <summary>
        /// 参数描述
        /// </summary>
        [Column("ParameterDescribe")]
        [MaxLength(50)]
        public string ParameterDescribe { get; set; }
    }
}
