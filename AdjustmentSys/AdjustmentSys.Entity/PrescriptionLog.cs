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
    /// 处方日志表，主要用于创建处方判断处方编号是否存在
    /// </summary>
    [Table("PrescriptionLog")]
    public class PrescriptionLog:BaseModel
    {
        /// <summary>
        /// 处方编号
        /// </summary>
        [Column("PrescriptionID")]
        [MaxLength(50)]
        public string PrescriptionID { get; set; }

        /// <summary>
        /// 处方创建时间
        /// </summary>
        [Column("CreateTime")]
        public DateTime CreateTime { get; set; }
    }
}
