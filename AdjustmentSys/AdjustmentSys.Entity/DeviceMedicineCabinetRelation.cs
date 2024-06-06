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
    /// 设备和药柜组关联信息表
    /// </summary>
    [Table("DeviceMedicineCabinetRelation")]
    public class DeviceMedicineCabinetCodeRelation:BaseModel
    {
        /// <summary>
        /// 药柜组code编号
        /// </summary>
        [Column("MedicineCabinetCode")]
        [MaxLength(20)]
        public string MedicineCabinetCode { get; set; }
       
        /// <summary>
        /// 药柜id
        /// </summary>
        [Column("MedicineCabinetId")]
        public int DeviceId { get; set; }
    }
}
