using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Entity.BaseEntity
{
    /// <summary>
    /// 删除实体
    /// </summary>
    public class DeleteModel: UpdateModel
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("IsDelete")]
        public bool IsDelete { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [Column("DeleteTime")]
        public DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 删除人
        /// </summary>
        [Column("DeleteBy")]
        public int? DeleteBy { get; set; }
        /// <summary>
        /// 删除人名称
        /// </summary>
        [Column("DeleteName")]
        [MaxLength(20)]
        public string? DeleteName { get; set; }
    }
}
