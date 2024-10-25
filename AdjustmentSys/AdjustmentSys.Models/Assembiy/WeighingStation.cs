using AdjustmentSys.Tool;
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
        ///写入的RFID的数据
        /// </summary>
        public int WriteRfidData { get; set; }
        /// <summary>
        ///写入的寄存器
        /// </summary>
        public int WriteRegister { get; set; }
        /// <summary>
        ///读取的RFID的数据
        /// </summary>
        public int ReadRfidData { get; set; }
       
        /// <summary>
        ///称重重量
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// 颗粒名称
        /// </summary>
        public string ParticlesName { get; set; }
        /// <summary>
        /// 工位状态
        /// </summary>
        public WeighingStationStatueEnum State { get; set; }
        /// <summary>
        /// 工位状态文本
        /// </summary>
        public string StateText { get { return StringHelper.GetEnumDescription(this.State); } }


    }
}
