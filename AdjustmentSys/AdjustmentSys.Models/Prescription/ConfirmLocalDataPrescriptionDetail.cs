using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Entity;
using System.ComponentModel;

namespace AdjustmentSys.Models.Prescription
{
    public class ConfirmLocalDataPrescriptionDetail
    {
        /// <summary>
        /// 处方唯一编号
        /// </summary>
        public string PrescriptionID { get; set; }

        /// <summary>
        /// 颗粒序号
        /// </summary>
        public int ParticleOrder { get; set; }

        /// <summary>
        /// HIS颗粒名称
        /// </summary>
        public string? ParticlesNameHIS { get; set; }

        /// <summary>
        /// 颗粒HIS码
        /// </summary>
        public string ParticlesCodeHIS { get; set; }

        /// <summary>
        /// 我库颗粒id，默认-1
        /// </summary>
        public int ParticlesID { get; set; }
        /// <summary>
        /// 我库颗粒名称
        /// </summary>
        public string ParName { get; set; }
        /// <summary>
        /// 我库颗粒编号
        /// </summary>
        public int ParCode { get; set; }
        /// <summary>
        /// 颗粒批号
        /// </summary>
        public string? BatchNumber { get; set; }
        /// <summary>
        /// 有效期至
        /// </summary>
        public string? ValidityTime { get; set; }

        /// <summary>
        /// 颗粒饮片剂量
        /// </summary>
        public float DoseHerb { get; set; }

        /// <summary>
        /// 颗粒当量
        /// </summary>
        public float Equivalent { get; set; }

        /// <summary>
        /// 颗粒剂量
        /// </summary>
        public float Dose { get; set; }
        /// <summary>
        /// 剂量上限
        /// </summary>
        public float? DoseLimit { get; set; }

        /// <summary>
        /// 药品单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// x
        /// </summary>
        public int StationX { get; set; } = 0;
        /// <summary>
        /// y
        /// </summary>
        public int StationY { get; set; } = 0;
        /// <summary>
        /// 位置
        /// </summary>
        public string StationText { get { return "第" + StationX + "排第" + StationY + "列"; } }
        /// <summary>
        /// 状态
        /// </summary>
        public StationStatusEnum Status { get; set; }
        /// <summary>
        /// 状态文本
        /// </summary>
        public string StatusText { get { return Status.ToString(); } }

        /// <summary>
        /// 当前称重量
        /// </summary>
        public float CurrentWeightQuantity { get; set; } = 0;
        /// <summary>
        /// 颗粒密度
        /// </summary>
        public float Density { get; set; }
        /// <summary>
        /// 颗粒密度系数
        /// </summary>
        public float? DensityCoefficient { get; set; }
        /// <summary>
        /// 单格剂量
        /// </summary>
        public float? NewDose { get; set; }
        /// <summary>
        /// 量仓千分比
        /// </summary>
        public int Steper { get; set; }
        /// <summary>
        /// 药柜详情
        /// </summary>
        public MedicineCabinetDetail MedicineCabinetDetail { get; set; }
    }
}
