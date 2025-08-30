using AdjustmentSys.Models.Machine;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Tool.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.FileModel
{
    [Serializable]
    public class PrescriptionBinModel
    {
        /// <summary>
        /// 已下载处方列表
        /// </summary>
        public List<DownLoadedPre> LoadedPrescriptions { get; set; }

        /// <summary>
        /// 已核对的处方列表
        /// </summary>
        public List<DataPrescriptionTB> CheckedPreInfos { get; set; }

      
    }

    public class LoadedPrescription() 
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
        /// 处方状态
        /// </summary>
        public ProcessStatusEnum ProcessStatus { get; set; }
        /// <summary>
        /// 处方状态
        /// </summary>
        public string ProcessStatusText { get { return ProcessStatus.ToString(); } }
    }
}
