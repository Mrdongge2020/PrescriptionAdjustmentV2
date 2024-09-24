using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Tool.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.FileModel
{
    [Serializable]
    public class DownLoadPreModel
    {
        /// <summary>
        /// 已下载的处方
        /// </summary>
        public List<string> LoadedPreIds { get; set; }
        /// <summary>
        /// 已核对的处方
        /// </summary>
        public List<PreModel> CheckedPreInfos { get; set; }
    }

    public class PreModel 
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
        public int? PatientAge { get; set; }
        /// <summary>
        /// 处方付数
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 分服次数
        /// </summary>
        public int TaskFrequency { get; set; }

        /// <summary>
        /// 处方明细条数
        /// </summary>
        public int DetailedCount { get; set; }
        /// <summary>
        /// 处方创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 处方使用方式
        /// </summary>
        public string? UsageMethod { get; set; }
        /// <summary>
        /// 处方状态
        /// </summary>
        public ProcessStatusEnum ProcessStatus { get; set; }
        /// <summary>
        /// 处方状态
        /// </summary>
        public string ProcessStatusText { get { return ProcessStatus.ToString(); } }
        /// <summary>
        /// 详情
        /// </summary>
        public List<ConfirmLocalDataPrescriptionDetail> Details { get; set; }
    }
}
