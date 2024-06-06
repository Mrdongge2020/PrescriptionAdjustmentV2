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
    /// 权限等级表
    /// </summary>
    [Table("LevelInfo")]
    public class LevelInfo:BaseModel
    {
        /// <summary>
        /// 等级名称
        /// </summary>
        [Column("LevelName")]
        [MaxLength(20)]
        public string LevelName { get; set; }
    }
}
