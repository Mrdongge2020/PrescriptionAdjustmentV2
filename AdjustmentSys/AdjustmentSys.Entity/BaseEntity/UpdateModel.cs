using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Entity.BaseEntity
{
    /// <summary>
    ///  更新实体
    /// </summary>
    public class UpdateModel: CreateModel
    {
        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("UpdateTime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Column("UpdateBy")]
        public int? UpdateBy { get; set; }
        /// <summary>
        /// 更新人名称
        /// </summary>
        [Column("UpdateName")]
        [MaxLength(20)]
        public string? UpdateName { get; set; }
    }
}
