﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Assembiy
{   /// <summary>
    /// 供盒类
    /// </summary>
    public class Supplybox
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
        public bool Finsh   { get; set; } 
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
        public bool  HomeX { get; set; }
        /// <summary>
        /// 检测供盒是否成功
        /// </summary>
        public bool InX1 { get; set; }
        /// <summary>
        /// 回零补偿值
        /// </summary>
        public int HomeData { get; set; }
        /// <summary>
        /// 缓存盒子序号
        /// </summary>
        public int HCboxIndex { get; set; }
        /// <summary>
        /// 对应盒子序号
        /// </summary>
        public int ExitBoxIndex { get; set; } = -1;

    }
}
