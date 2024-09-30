using AdjustmentSys.Tool.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Assembiy
{
    /// <summary>
    /// 调剂工位
    /// </summary>
    public class AdjustmentStation
    {
        /// <summary>
        /// 启动动作缓存
        /// </summary>
        public bool HCExcute { get; set; }
        /// <summary>
        /// 启动动作
        /// </summary>
        public bool Excute { get; set; }
        /// <summary>
        /// 动作完成
        /// </summary>
        public bool Finsh { get; set; }
        /// <summary>
        /// 回零启动
        /// </summary>
        public bool HomeExcute { get; set; }
        /// <summary>
        /// 回零完成
        /// </summary>
        public bool HomeFinsh { get; set; }
        /// <summary>
        /// 异常
        /// </summary>
        public int Error { get; set; }
        /// <summary>
        /// 异常复位
        /// </summary>
        public int RestError { get; set; }
        /// <summary>
        /// 回零开关状态
        /// </summary>
        public bool HomeX { get; set; }
        /// <summary>
        /// 回零补偿值
        /// </summary>
        public int HomeData { get; set; }
        /// <summary>
        ///RFID的数据
        /// </summary>
        public int RfidData { get; set; }
        /// <summary>
        ///下药脉冲数,转多少
        /// </summary>
        public int Data1 { get; set; }

        #region Soft
        /// <summary>
        /// 颗粒名称
        /// </summary>
        public string ParticlesName { get; set; }
        /// <summary>
        ///工位进度
        /// </summary>
        public int Bar { get; set; }
        /// <summary>
        ///完成的调剂次数
        /// </summary>
        public int DrugeValue { get; set; }
        /// <summary>
        /// 颗粒状态
        /// </summary>
        public  StationStatusEnum ParticlesState { get; set; }
        #endregion

    }
}
