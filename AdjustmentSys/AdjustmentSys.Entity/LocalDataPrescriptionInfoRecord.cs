using AdjustmentSys.Entity.BaseEntity;
using AdjustmentSys.Tool.Enums;
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
    /// 本地处方表记录
    /// </summary>
    [Table("LocalDataPrescriptionInfoRecord")]
    public class LocalDataPrescriptionInfoRecord : BaseModel
    {
        /// <summary>
        /// 处方编号
        /// </summary>
        [Column("PrescriptionID")]
        [MaxLength(50)]
        public string PrescriptionID { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        [Column("PatientName")]
        [MaxLength(50)]
        public string PatientName { get; set; }

        /// <summary>
        /// 患者性别
        /// </summary>
        [Column("PatientSex")]
        public SexEnum PatientSex { get; set; }

        /// <summary>
        /// 患者年龄
        /// </summary>
        [Column("PatientAge")]
        public int? PatientAge { get; set; }

        /// <summary>
        /// 出生月份
        /// </summary>
        [Column("PatientBirthMonth")]
        public int? PatientBirthMonth { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [Column("PatientBirthDay")]
        public int? PatientBirthDay { get; set; }

        /// <summary>
        /// 患者联系方式
        /// </summary>
        [Column("PatientTel")]
        [MaxLength(50)]
        public string? PatientTel { get; set; }

        /// <summary>
        /// 患者邮件
        /// </summary>
        [Column("PatientEmail")]
        [MaxLength(50)]
        public string? PatientEmail { get; set; }

        /// <summary>
        /// 患者的位置信息
        /// </summary>
        [Column("PatientLocation")]
        [MaxLength(200)]
        public string? PatientLocation { get; set; }

        /// <summary>
        /// 开方医生
        /// </summary>
        [Column("DoctorName")]
        [MaxLength(50)]
        public string DoctorName { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
        [Column("DepartmentName")]
        [MaxLength(50)]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 协定处方名称
        /// </summary>
        [Column("PrescriptionName")]
        [MaxLength(50)]
        public string? PrescriptionName { get; set; }

        /// <summary>
        /// 处方创建人
        /// </summary>
        [Column("CreateName")]
        [MaxLength(50)]
        public string? CreateName { get; set; }

        /// <summary>
        /// 处方创建时间
        /// </summary>
        [Column("CreateTime")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 划价员
        /// </summary>
        [Column("ValuerName")]
        [MaxLength(50)]
        public string? ValuerName { get; set; }

        /// <summary>
        /// 划价单号
        /// </summary>
        [Column("ValueSn")]
        [MaxLength(50)]
        public string? ValueSn { get; set; }

        /// <summary>
        /// 划价时间
        /// </summary>
        [Column("ValuationTime")]
        public DateTime ValuationTime { get; set; }

        /// <summary>
        /// 挂单号
        /// </summary>
        [Column("RegisterID")]
        [MaxLength(50)]
        public string RegisterID { get; set; }

        /// <summary>
        /// 处方缴费类型
        /// </summary>
        [Column("PaymentType")]
        [MaxLength(50)]
        public string PaymentType { get; set; }

        /// <summary>
        /// 缴费状态
        /// </summary>
        [Column("PaymentStatus")]
        [MaxLength(10)]
        public string PaymentStatus { get; set; }

        /// <summary>
        /// 处方类型，住院或门诊
        /// </summary>
        [Column("PrescriptionType")]
        [MaxLength(50)]
        public string PrescriptionType { get; set; }

        /// <summary>
        /// 导入时间
        /// </summary>
        [Column("ImportTime")]
        public DateTime ImportTime { get; set; }

        /// <summary>
        /// 处方付数
        /// </summary>
        [Column("Quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// 分服次数
        /// </summary>
        [Column("TaskFrequency")]
        public int TaskFrequency { get; set; }

        /// <summary>
        /// 单付单价
        /// </summary>
        [Column("UnitPrice")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 处方总价
        /// </summary>
        [Column("TotalPrice")]
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 处方明细条数
        /// </summary>
        [Column("DetailedCount")]
        public int DetailedCount { get; set; }

        /// <summary>
        /// 处方状态
        /// </summary>
        [Column("ProcessStatus")]
        public ProcessStatusEnum ProcessStatus { get; set; }

        /// <summary>
        /// 处方来源
        /// </summary>
        [Column("PrescriptionSource")]
        public int PrescriptionSource { get; set; }

        /// <sumary>
        /// 备注信息
        /// </summary>
        [Column("Remarks")]
        [MaxLength(500)]
        public string? Remarks { get; set; }

        /// <summary>
        /// 处方使用方式
        /// </summary>
        [Column("UsageMethod")]
        [MaxLength(200)]
        public string UsageMethod { get; set; }

        /// <summary>
        /// 下载人名称
        /// </summary>
        [Column("DownloadName")]
        [MaxLength(20)]
        public string DownloadName { get; set; }
        /// <summary>
        /// 下载人
        /// </summary>
        [Column("DownloadBy")]
        public int DownloadBy { get; set; }

        /// <summary>
        /// 下载时间
        /// </summary>
        [Column("DownloadTime")]
        public DateTime DownloadTime { get; set; }
        /// <summary>
        /// 预留字段1
        /// </summary>
        [Column("BackupField1")]
        [MaxLength(100)]
        public string BackupField1 { get; set; }

        /// <summary>
        /// 预留字段1
        /// </summary>
        [Column("BackupField2")]
        [MaxLength(100)]
        public string BackupField2 { get; set; }

        /// <summary>
        /// 预留字段1
        /// </summary>
        [Column("BackupField3")]
        [MaxLength(100)]
        public string BackupField3 { get; set; }
        /// <summary>
        /// 调配员姓名
        /// </summary>
        [Column("AllocateName")]
        [MaxLength(20)]
        public string AllocateName
        {
            get;
            set;
        }

        /// <summary>
        /// 调配设备名称
        /// </summary>
        [Column("DeviceName")]
        public string DeviceName
        {
            get;
            set;
        }

        /// <summary>
        /// 调配盒数
        /// </summary>
        [Column("BoxNumber")]
        public int BoxNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 调配耗时秒
        /// </summary>
        [Column("TimeConsumingSecond")]
        public int TimeConsumingSecond
        {
            get;
            set;
        }
        /// <summary>
        /// 调配耗时
        /// </summary>
        [Column("TimeConsuming")]
        [MaxLength(50)]
        public string TimeConsuming
        {
            get;
            set;
        }
        /// <summary>
        /// 处方分析结果
        /// </summary>
        [Column("AnalysisResult")]
        [MaxLength(100)]
        public string AnalysisResult
        {
            get;
            set;
        }
        /// <summary>
        /// 完成时间
        /// </summary>
        [Column("CompleteTime")]
        public DateTime CompleteTime
        {
            get;
            set;
        }
    }
}
