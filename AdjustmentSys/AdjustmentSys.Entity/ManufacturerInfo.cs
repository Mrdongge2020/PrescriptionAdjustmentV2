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
    /// 厂家信息表
    /// </summary>
    [Table("ManufacturerInfo")]
    public class ManufacturerInfo:DeleteModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        [Column("Sort")]
        public int Sort { get; set; }
        /// <summary>
        /// 厂家名称
        /// </summary>
        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
