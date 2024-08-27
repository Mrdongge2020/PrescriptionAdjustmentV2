using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Prescription
{
    public class CheckPrescriptionResultModel
    {
        /// <summary>
        /// 错误类型，
        /// 1=剂量上限状态
        /// 2=颗粒余量状态
        /// 3=颗粒相容性规则检查
        /// 4=数据非法检查
        /// </summary>
        public int ErrorType { get; set; }
        /// <summary>
        /// 错误详情
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 是否已忽略
        /// </summary>
        public bool IsPass { get; set; }=false;
    }
}
