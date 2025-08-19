using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Machine
{
    public class MachinePublic
    {
        /// <summary>
        /// 
        /// </summary>
        public static bool ZeroWeight;//天平重量清零
        public static double Weight = 0;//天平重量
        public static bool WeightState = false;//天平重量数据读取成功状态 
        public static float showParticleWeight = 0;
        public static Int32 ReadRFIDdate = 0; //读取到天平RFID数据
        public static bool Connectionstate = false; //设备连接状态
        public static Int32 WriteRFIDdate = 0; //写入RFID数据
        public static bool WriteRFIDExcule = false; //写入RFID启动
        public static bool WriteRFIDFish = false;   //写入RFID完成
        public static bool WriteRFIDEorr = false;   //写入RFID失败
        public static short SealYTime;//封口延时
        public static bool LEDgr;//灯颜色
        public static Int16[] RD600 = new Int16[51];  //0-41 存储状态 42-47 存储每个药柜的的列数  49灯柜颜色，50 开启灯柜
        public static Int16[] WD600 = new Int16[51];  //0-41 存储状态 42-47 存储每个药柜的的列数  49灯柜颜色，50 开启灯柜
        public static DataTable DataTableEorr = new DataTable();

        public static bool Outshowok = false;
        public static int Outboxunber;
        public static Int32 UpdateParticles;
        public static CabinetStorageInfoTB objCabinetStorageInfoTB = new CabinetStorageInfoTB();

        public static double SetTemperature1 = 0;
        public static double SetTemperature2 = 0;
        public static double SetTemperature3 = 0;
        public static double ReadTemperature1 = 0;
        public static double ReadTemperature2 = 0;
        public static double ReadTemperature3 = 0;

        #region
        public static bool DensityExcule; //密度测量开始
        public static int DensityParticlesID; //密度测量颗粒
        public static bool DensityFinsh;     //密度测量完成
        public static Int16 Densitynuber;  //密度测量次数
        public static Int16 DensityGnuber; //密度测量工位
        public static double DensityWeight1; //密度测量前重量
        public static double DensityWeight2; //密度测量后重量
        public static int DensityState = 0; //密度测量状态
        public static bool DensityTestOK;
        public static DensityTestModel densityTestModel = new DensityTestModel();
        #endregion
    }

    public class DensityTestModel 
    {
        public int DensityParticlesID { get; set; } //密度测量颗粒
        public string DensityParticlesName { get; set; } //密度测量颗粒名称
        public int DensityFlishNumber { get; set; } //密度测量下药完成次数
        public int DensityGnuber { get; set; }//密度测量工位
        public float DensityWeight1 { get; set; } //密度测量前重量
        public float DensityWeight2 { get; set; } //密度测量后重量
        public int DensityState { get; set; } = 0; //密度测量状态
    }
}
