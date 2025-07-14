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
    public class PrescriptionPrintModel
    {
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
        public string PatientSex { get; set; }

        /// <summary>
        /// 患者年龄
        /// </summary>
        public string PatientAge { get; set; }

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
        /// 总价
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime PreDateTime { get; set; }
        /// <summary>
        /// 使用方法
        /// </summary>
        public string UsageMethod { get; set; }
        /// <summary>
        /// 生成的使用方法
        /// </summary>
        public string GenerateUseWay { get; set; }
        /// <summary>
        /// 生成的使用方法
        /// </summary>
        public string GenerateUseWay1 { get; set; }
        /// <summary>
        /// 住院床号
        /// </summary>
        public string? BedNumber { get; set; }
        /// <summary>
        /// 盒数/袋数
        /// </summary>
        public int BoxNumber { get; set; }
        /// <summary>
        /// 处方详情
        /// </summary>
        public List<PrintDetailModel> Details { get; set; }
    }

    public class PrintDetailModel 
    {
        /// <summary>
        /// 我库颗粒编码
        /// </summary>
        public string ParCode { get; set; }
        /// <summary>
        /// 我库颗粒名称
        /// </summary>
        public string ParName { get; set; }
        /// <summary>
        /// 颗粒饮片剂量
        /// </summary>
        public string DoseHerb { get; set; }
        /// <summary>
        /// 颗粒剂量
        /// </summary>
        public string Dose { get; set; }
    }
}
