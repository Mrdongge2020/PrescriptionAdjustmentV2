using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AdjustmentSys.Entity.BaseEntity;

namespace AdjustmentSys.Entity
{
    /// <summary>
    /// 科室信息表
    /// </summary>
    [Table("DepartmentInfo")]
    public class DepartmentInfo:UpdateModel
    {
        /// <summary>
        /// 科室名称
        /// </summary>
        [Column("DepartmentName")]
        [MaxLength(20)]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 科室地址
        /// </summary>
        [Column("Address")]
        [MaxLength(50)]
        public string Address { get; set; }

        /// <summary>
        /// 科室联系人
        /// </summary>
        [Column("Contacts")]
        [MaxLength(20)]
        public string Contacts { get; set; }

        /// <summary>
        /// 科室联系人电话
        /// </summary>
        [Column("ContactsPhone")]
        [MaxLength(50)]
        public string? ContactsPhone { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        [MaxLength(200)]
        public string? Remark { get; set; }

    }
}
