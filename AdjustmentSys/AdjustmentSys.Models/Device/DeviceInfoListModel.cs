using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdjustmentSys.Tool.Enums;

namespace AdjustmentSys.Models.Device
{
    public class DeviceInfoListModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 设备编组
        /// </summary>
        public string DeviceCode { get; set; }
        /// <summary>
        ///名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///设备类型
        /// </summary>
        public DeviceTypeEnum DeviceType { get; set; }

        /// <summary>
        ///设备类型
        /// </summary>
        public string DeviceTypeText { get { return DeviceType.ToString(); }  }
        /// <summary>
        ///IP地址
        /// </summary>
        [Column("IPAddress")]
        [MaxLength(20)]
        public string IPAddress { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人名称
        /// </summary>
        public string? CreateName { get; set; }
        /// <summary>
        ///设备药柜编号
        /// </summary>
        public string? MedicineCabinetCode { get; set; }

        /// <summary>
        ///是否启用
        /// </summary>
        public string IsEnable { get; set; }
    }
}
