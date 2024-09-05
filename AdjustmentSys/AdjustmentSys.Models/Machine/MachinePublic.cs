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
        public static double Weight = 0;//天平重量
        public static bool WeightState = false;//天平重量数据读取成功状态 
        public static Int32 ReadRfidData = 0; //读取到天平RFID数据
        public static bool ConnectionState = false; //设备连接状态
        public static Int32 WriteRfidData = 0; //写入RFID数据
        public static bool WriteRfidExcule = false; //写入RFID启动
        public static bool WriteRfidFish = false;   //写入RFID完成
        public static bool WriteRfidError = false;   //写入RFID失败
        public static short SealYTime;//封口延时
        public static bool LEDgr;//灯颜色
        public static Int16[] RD600 = new Int16[51];  //0-41 存储状态 42-47 存储每个药柜的的列数  49灯柜颜色，50 开启灯柜
        public static Int16[] WD600 = new Int16[51];  //0-41 存储状态 42-47 存储每个药柜的的列数  49灯柜颜色，50 开启灯柜
        public static DataTable DataTableEorr = new DataTable();
        public static bool DensityExcule; //密度测量开始
        public static int DensityParticlesID; //密度测量颗粒
        public static bool DensityFinsh;     //密度测量完成
        public static Int16 Densitynuber;  //密度测量次数
        public static Int16 DensityGnuber; //密度测量工位
        public static double DensityWeight1; //密度测量前重量
        public static double DensityWeight2; //密度测量后重量
    }
}
