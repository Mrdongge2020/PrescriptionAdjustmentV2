using AdjustmentSys.Tool.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Prescription
{
    public class PrescriptionInfoModel
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 处方编号
        /// </summary>
        public string PrescriptionID { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 患者性别
        /// </summary>
        public SexEnum PatientSex { get; set; }

        /// <summary>
        /// 患者年龄
        /// </summary>
        public int? PatientAge { get; set; }

        /// <summary>
        /// 出生月份
        /// </summary>
        public int? PatientBirthMonth { get; set; }

        /// <summary>
        /// 患者联系方式
        /// </summary>
        public string? PatientTel { get; set; }


        /// <summary>
        /// 开方医生
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 处方付数
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 分服次数
        /// </summary>
        public int TaskFrequency { get; set; }
        /// <sumary>
        /// 备注信息
        /// </summary>
        public string? Remarks { get; set; }
        /// <summary>
        /// 处方详情
        /// </summary>
        public List<PrescriptionDetailModel> Details { get; set; }
    }
}
