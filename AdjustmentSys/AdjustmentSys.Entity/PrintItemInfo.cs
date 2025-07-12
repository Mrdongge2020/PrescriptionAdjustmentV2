using AdjustmentSys.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Entity
{
    /// <summary>
    /// 打印项表
    /// </summary>
    [Table("PrintItemInfo")]
    public class PrintItemInfo:BaseModel
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
        /// 抬头
        /// </summary>
        [Column("Title")]
        [MaxLength(50)]
        public string Title { get; set; }
        /// <summary>
        /// 选中值
        /// </summary>
        [Column("CheckedValue")]
        public int CheckedValue { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Column("Sort")]
        public double Sort { get; set; }
        /// <summary>
        /// 设备id
        /// </summary>
        [Column("DeviceId")]
        public int DeviceId { get; set; }
    }
}
