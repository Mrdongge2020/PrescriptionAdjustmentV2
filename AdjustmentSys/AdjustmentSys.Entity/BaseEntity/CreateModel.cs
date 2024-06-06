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
    /// 创建实体
    /// </summary>
    public class CreateModel:BaseModel
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreateTime")]
        [Required]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column("CreateBy")]
        [Required]
        public int CreateBy { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        [Column("CreateName")]
        [MaxLength(20)]
        public string? CreateName { get; set; }
    }
}
