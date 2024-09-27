using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Assembiy
{
    /// <summary>
    /// 转盘
    /// </summary>
    public class Turntable
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
        public bool HomeData { get; set; }

        /// <summary>
        /// 转动格数
        /// </summary>
        public int TurnNum { get; set; }
    }
}
