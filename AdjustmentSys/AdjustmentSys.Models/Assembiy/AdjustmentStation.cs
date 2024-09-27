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
        public int RFIDData { get; set; }
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
    /// <summary>
    /// 工位状态枚举
    /// </summary>
    /// <summary>
    /// 工位状态枚举
    /// </summary>
    //public enum StationStatusEnum
    //{
    //    [Description("无")]
    //    无 = 0,
    //    [Description("待放入")]
    //    待放入 = 1,
    //    [Description("待调剂")]
    //    待调剂 = 2,
    //    [Description("调剂中")]
    //    调剂中 = 3,
    //    [Description("待取走")]
    //    待取走 = 4,
    //    [Description("回零中")]
    //    回零中 = 5,
    //    [Description("回零完成")]
    //    回零完成 = 6,
    //    [Description("被禁用")]
    //    被禁用 = 7,
    //    [Description("余量不足")]
    //    余量不足 = 8,
    //    [Description("非处方药品")]
    //    非处方药品 = 9,
    //    [Description("该药品未称重")]
    //    该药品未称重 = 10,
    //    [Description("该药品已称重")]
    //    该药品已称重 = 11
    //}



}
