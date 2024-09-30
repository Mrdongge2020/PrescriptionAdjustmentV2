using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Assembiy
{
    /// <summary>
    /// 封口对象
    /// </summary>
    public class Sealbox
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
        /// 步进回零启动
        /// </summary>
        public bool HomeExcute { get; set; }
        /// <summary>
        /// 交流回零启动
        /// </summary>
        public bool HomeExcute1 { get; set; }
        /// <summary>
        /// 步进回零完成
        /// </summary>
        public bool HomeFinsh { get; set; }
        /// <summary>
        /// 交流回零完成
        /// </summary>
        public bool HomeFinsh1 { get; set; }
        /// <summary>
        /// 异常
        /// </summary>
        public int Error { get; set; }
        /// <summary>
        /// 异常复位
        /// </summary>
        public int RestError { get; set; }
        /// <summary>
        /// 步进电机回零开关状态
        /// </summary>
        public bool HomeX { get; set; }
        /// <summary>
        /// 交流电机上限位
        /// </summary>
        public bool InX1 { get; set; }
        /// <summary>
        /// 交流电机下限位
        /// </summary>
        public bool InX2 { get; set; }
        /// <summary>
        ///检测封口膜到位信号
        /// </summary>
        public bool InX3 { get; set; }
        /// <summary>
        /// 步进回零补偿值
        /// </summary>
        public int HomeData { get; set; }
        /// <summary>
        /// 交流回零补偿值
        /// </summary>
        public int HomeData1 { get; set; }
        /// <summary>
        /// 封口走膜长度
        /// </summary>
        public short Data1 { get; set; }
        /// <summary>
        /// 封口退膜长度
        /// </summary>
        public short Data2 { get; set; }
        /// <summary>
        /// 封口切断后退膜长度
        /// </summary>
        public short Data3 { get; set; }
        /// <summary>
        /// 封口延时
        /// </summary>
        public UInt16 SealTime { get; set; }

    }
}
