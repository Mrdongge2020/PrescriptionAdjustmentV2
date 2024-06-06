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
    /// 药柜信息主表
    /// </summary>
    [Table("MedicineCabinetInfo")]
    public class MedicineCabinetInfo:BaseModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Column("Name")]
        [MaxLength(20)]
        public string Name { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        [Column("Code")]
        [MaxLength(20)]
        public string Code { get; set; }

        /// <summary>
        /// 规格，1=大药柜，2=小药柜
        /// </summary>
        [Column("Specifications")]
        public int? Specifications { get; set; }

        /// <summary>
        /// 横向个数
        /// </summary>
        [Column("RowCount")]
        public int RowCount { get; set; }
        /// <summary>
        /// 纵向个数
        /// </summary>
        [Column("ColCount")]
        public int ColCount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        [MaxLength(200)]
        public string? Remark { get; set; }
    }
}
