using AdjustmentSys.Tool.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Assembiy
{   /// <summary>
    /// 称重工位
    /// </summary>
    public class WeighingStation
    {
        /// <summary>
        ///RFID的数据
        /// </summary>
        public int RFIDData { get; set; }
        /// <summary>
        ///称重重量
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// 颗粒名称
        /// </summary>
        public string ParticlesName { get; set; }
        /// <summary>
        /// 颗粒状态
        /// </summary>
        public StationStatusEnum ParticlesState { get; set; }

    }
}
