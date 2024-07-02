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
    public class PrescriptionPageListModel
    {
        /// <summary>
        /// ID主键
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
        /// 患者性别
        /// </summary>
        public string PatientSexText { get { return Enum.GetName(typeof(SexEnum),PatientSex); } }

        /// <summary>
        /// 患者年龄
        /// </summary>
        public int? PatientAge { get; set; }

        /// <summary>
        /// 出生月份
        /// </summary>
        public int? PatientBirthMonth { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public int? PatientBirthDay { get; set; }
        /// <summary>
        /// 患者年龄显示
        /// </summary>
        public string PatientAgeText { 
            get {
                string ageStr = "";
                if (PatientAge.HasValue) { ageStr += PatientAge + "岁"; }
                if (PatientBirthMonth.HasValue) { ageStr += PatientBirthMonth + "月"; }
                if (PatientBirthDay.HasValue) { ageStr += PatientBirthDay + "天"; }
                return ageStr;
               }
        }

        /// <summary>
        /// 患者联系方式
        /// </summary>
        public string? PatientTel { get; set; }

        /// <summary>
        /// 患者邮件
        /// </summary>
        public string? PatientEmail { get; set; }

        /// <summary>
        /// 患者的位置信息
        /// </summary>
        public string? PatientLocation { get; set; }

        /// <summary>
        /// 开方医生
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 协定处方名称
        /// </summary>
        public string? PrescriptionName { get; set; }

        /// <summary>
        /// 处方创建人
        /// </summary>
        public string? CreateName { get; set; }

        /// <summary>
        /// 处方创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 划价员
        /// </summary>
        public string? ValuerName { get; set; }

        /// <summary>
        /// 划价单号
        /// </summary>
        public string? ValueSn { get; set; }

        /// <summary>
        /// 划价时间
        /// </summary>
        public DateTime ValuationTime { get; set; }

        /// <summary>
        /// 挂单号
        /// </summary>
        public string RegisterID { get; set; }

        /// <summary>
        /// 处方缴费类型
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// 缴费状态
        /// </summary>
        public string PaymentStatus { get; set; }

        /// <summary>
        /// 处方类型，住院或门诊
        /// </summary>
        public string PrescriptionType { get; set; }

        /// <summary>
        /// 导入时间
        /// </summary>
        public DateTime ImportTime { get; set; }

        /// <summary>
        /// 处方付数
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 分服次数
        /// </summary>
        public int TaskFrequency { get; set; }

        /// <summary>
        /// 单付单价
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 处方总价
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 处方明细条数
        /// </summary>
        public int DetailedCount { get; set; }
        /// <summary>
        /// 处方状态
        /// </summary>
        public int ProcessStatus { get; set; }
        
        /// <summary>
        /// 处方状态文本
        /// </summary>
        public string ProcessStatusText {
            get { return Enum.GetName(typeof(ProcessStatusEnum), ProcessStatus); }
        } 
        
        /// <summary>
        /// 处方来源
        /// </summary>
        public int PrescriptionSource { get; set; }
        /// <summary>
        /// 处方来源
        /// </summary>
        public string PrescriptionSourceText { 
            get { return PrescriptionSource == 1 ? "HIS系统" : "TMC系统"; }
        }

        /// <sumary>
        /// 备注信息
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 处方使用方式
        /// </summary>
        public string UsageMethod { get; set; }

        /// <summary>
        /// 下载人名称
        /// </summary>
        public string? DownloadName { get; set; }
        /// <summary>
        /// 下载人
        /// </summary>
        public int? DownloadBy { get; set; }

        /// <summary>
        /// 下载时间
        /// </summary>
        public DateTime? DownloadTime { get; set; }
        /// <summary>
        /// 预留字段1
        /// </summary>
        public string BackupField1 { get; set; }

        /// <summary>
        /// 预留字段1
        /// </summary>
        public string BackupField2 { get; set; }

        /// <summary>
        /// 预留字段1
        /// </summary>
        public string BackupField3 { get; set; }
        /// <summary>
        /// 调配员姓名
        /// </summary>
        public string? AllocateName
        {
            get;
            set;
        }

        /// <summary>
        /// 调配设备名称
        /// </summary>
        public string? DeviceName
        {
            get;
            set;
        }

        /// <summary>
        /// 调配盒数
        /// </summary>
        public int? BoxNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 调配耗时秒
        /// </summary>
        public int? TimeConsumingSecond
        {
            get;
            set;
        }
        /// <summary>
        /// 处方分析结果
        /// </summary>
        public string? AnalysisResult
        {
            get;
            set;
        }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? CompleteTime
        {
            get;
            set;
        }
    }
}
