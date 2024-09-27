using AdjustmentSys.Tool.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdjustmentSys.Models.Machine.MachineBox;

namespace AdjustmentSys.Models.Assembiy
{
    public class BoxedDeviceModel
    {
        /// <summary>
        /// 回零启动（全部回零启动）
        /// </summary>
        public bool HomeExcute { get; set; }
        /// <summary>
        /// 运行状态
        /// </summary>
        public WorkStateEnum RunState { get; set; }
        /// <summary>
        /// 位移格数
        /// </summary>
        public int ZmoveNumber { get; set; }
        /// <summary>
        /// 调剂工位类
        /// </summary>
        public AdjustmentStation[] AdjustmentStations { get; set; }
        /// <summary>
        /// 供盒类
        /// </summary>
        public Supplybox Supplyboxs { get; set; }
        /// <summary>
        /// 转盘类
        /// </summary>
        public Turntable Turntable { get; set; }
        /// <summary>
        /// 出盒类
        /// </summary>
        public Outbox Outboxs { get; set; }
        /// <summary>
        /// 封口对象类
        /// </summary>
        public Sealbox Sealbox { get; set; }
        /// <summary>
        /// 称重工位类
        /// </summary>
        public WeighingStation WeighingStation { get; set; }
        /// <summary>
        /// 药盒类
        /// </summary>
        public Medbox[] Medboxs { get; set; }


    }
}
