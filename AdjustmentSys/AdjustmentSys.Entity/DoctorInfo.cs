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
    /// 医生信息表
    /// </summary>
    [Table("DoctorInfo")]
    public class DoctorInfo:DeleteModel
    {
        /// <summary>
        /// 医生名称
        /// </summary>
        [Column("DoctorName")]
        [MaxLength(20)]
        public string DoctorName { get; set; }

        /// <summary>
        /// 医生名称首字母简称
        /// </summary>
        [Column("InitialPinyin")]
        [MaxLength(500)]
        public string InitialPinyin { get; set; }

        /// <summary>
        /// 医生所属科室id
        /// </summary>
        [Column("DoctorDepartmentID")]
        public int? DoctorDepartmentID { get; set; }
        /// <summary>
        /// 医生所属科室名称
        /// </summary>
        [Column("DoctorDepartmentName")]
        [MaxLength(20)]
        public string? DoctorDepartmentName { get; set; }

        /// <summary>
        /// 医生办公室
        /// </summary>
        [Column("Office")]
        [MaxLength(50)]
        public string? Office { get; set; }

        /// <summary>
        /// 医生电话
        /// </summary>
        [Column("Phone")]
        [MaxLength(50)]
        public string? Phone { get; set; }

        /// <summary>
        /// 医生Email
        /// </summary>
        [Column("EMail")]
        [MaxLength(50)]
        public string? EMail { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        [MaxLength(200)]
        public string? Remark { get; set; }
    }
}
