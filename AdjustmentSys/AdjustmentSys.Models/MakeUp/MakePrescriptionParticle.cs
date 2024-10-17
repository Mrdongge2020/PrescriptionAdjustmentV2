using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.MakeUp
{
    /// <summary>
    /// 调剂颗粒显示
    /// </summary>
    public class MakePrescriptionParticle
    {
        /// <summary>
        /// 颗粒名称
        /// </summary>
        public string ParticlesName { get; set; }
        /// <summary>
        /// 颗粒码
        /// </summary>
        public int ParticlesCode { get; set; }
        /// <summary>
        /// rfid
        /// </summary>
        public int Rfid { get; set; }
        /// <summary>
        /// 调剂重量
        /// </summary>
        public double Dose { get; set; }
        /// <summary>
        /// 坐标X
        /// </summary>
        public int StationX { get; set; }

        /// <summary>
        /// 坐标Y
        /// </summary>
        public int StationY { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string StationText { get { return "第" + StationX + "排第" + StationY + "列"; } }
        /// <summary>
        /// 完成的下药次数
        /// </summary>
        public int FishDrugeCount { get; set; }
        /// <summary>
        /// 量仓的千分比
        /// </summary>
        public int Steper { get; set; }
        /// <summary>
        ///  true已经扣除库存， false 还未扣除库存
        /// </summary>
        public bool Deduct { get; set; }
        /// <summary>
        /// 颗粒状态  
        /// </summary>
        public MakeParticleStateEnum MakeParticleState { get; set; }
        /// <summary>
        /// 状态文本
        /// </summary>
        public string StatusText { get { return StringHelper.GetEnumDescription(MakeParticleState); } }

        /// <summary>
        /// 当前称重量
        /// </summary>
        public float CurrentWeightQuantity { get; set; } = 0;

        /// <summary>
        /// 单格剂量
        /// </summary>
        public float NewDose { get; set; }
        /// <summary>
        /// 提前扣除的库存
        /// </summary>
        public float EarlyDeductionStock { get; set; }
    }
}
