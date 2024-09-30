using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Machine
{
    /// <summary>
    /// 设备数据传输公共类
    /// </summary>
    public class MachinePublic
    {
        /// <summary>
        /// 天平重量
        /// </summary>
        public static double Weight = 0;
        /// <summary>
        /// 天平重量数据读取成功状态 
        /// </summary>
        public static bool WeightState = false;
        /// <summary>
        /// 读取到天平RFID数据
        /// </summary>
        public static Int32 ReadRfidData = 0;
        /// <summary>
        /// 设备连接状态
        /// </summary>
        public static bool ConnectionState = false;
        /// <summary>
        /// 写入RFID数据
        /// </summary>
        public static Int32 WriteRfidData = 0;
        /// <summary>
        /// 写入RFID启动
        /// </summary>
        public static bool WriteRfidExcule = false;
        /// <summary>
        /// 写入RFID完成
        /// </summary>
        public static bool WriteRfidFish = false;
        /// <summary>
        /// 写入RFID失败
        /// </summary>
        public static bool WriteRfidError = false;
        /// <summary>
        /// 封口延时
        /// </summary>
        public static short SealYTime;
        /// <summary>
        /// 灯颜色
        /// </summary>
        public static bool LEDgr;
        /// <summary>
        /// 0-41 存储状态 42-47 存储每个药柜的的列数  49灯柜颜色，50 开启灯柜
        /// </summary>
        public static Int16[] RD600 = new Int16[51];  //0-41 存储状态 42-47 存储每个药柜的的列数  49灯柜颜色，50 开启灯柜
        public static Int16[] WD600 = new Int16[51];  //0-41 存储状态 42-47 存储每个药柜的的列数  49灯柜颜色，50 开启灯柜
        public static DataTable DataTableEorr = new DataTable();
        /// <summary>
        /// 密度测量开始
        /// </summary>
        public static bool DensityExcule;
        /// <summary>
        /// 密度测量颗粒
        /// </summary>
        public static int DensityParticlesID;
        /// <summary>
        /// 密度测量完成
        /// </summary>
        public static bool DensityFinsh;
        /// <summary>
        /// 密度测量次数
        /// </summary>
        public static Int16 Densitynuber;
        /// <summary>
        /// 密度测量工位
        /// </summary>
        public static Int16 DensityGnuber;
        /// <summary>
        /// 密度测量前重量
        /// </summary>
        public static double AfterDensityWeight;
        /// <summary>
        /// 密度测量后重量
        /// </summary>
        public static double BeforeDensityWeight; 

    }
}
