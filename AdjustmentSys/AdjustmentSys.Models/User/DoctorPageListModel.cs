using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.User
{

    /// <summary>
    /// 医生分页列表
    /// </summary>
    public class DoctorPageListModel
    {
        /// <summary>
        /// id
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 医生名称
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 医生名称首字母简称
        /// </summary>
        public string InitialPinyin { get; set; }

        /// <summary>
        /// 医生所属科室名称
        /// </summary>
        public string? DoctorDepartmentName { get; set; }

        /// <summary>
        /// 医生办公室
        /// </summary>
        public string? Office { get; set; }

        /// <summary>
        /// 医生电话
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// 医生Email
        /// </summary>
        public string? EMail { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人名称
        /// </summary>
        public string? CreateName { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新人名称
        /// </summary>
        public string? UpdateName { get; set; }
    }
}
