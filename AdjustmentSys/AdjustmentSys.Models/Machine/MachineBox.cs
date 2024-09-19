using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Machine
{
    public class MachineBox
    {
        public UInt16 Finshstate;//调剂 供盒 等完成状态
        public UInt16 Finshstate1;//单轴回零完成 等完成状态
        public bool Stop; //暂停
        public int[] RFID = new int[9];//rfid 数据

        public UInt16 SealTimeY;//封口延时
        public short SealPosation1;//读到封口检测位
        public short SealPosation2;//读到封口位
        public short SealPosation3;//
        public UInt16 InX;//

        public short WoutY;//写输出
        public bool WExcute;// 写入数据
        public bool WFish;//写入成功
        public short WDnumber;//写入的寄存器
        public short WDate;//写入的数据

        public bool LEDgr;//灯柜亮灯颜色
        public bool WriteLED;//灯柜数据写入
        public bool WriteLEDfish;//灯柜数据写入
        public int Restsate;

        public int Packboxnumber = 10; //提示插屏工位
        public bool BQuestion; //提示插屏工位
        public int worksate;
        public long Time;//时间
        public int Porbar; //当前进度 
        public double TBox; //每一个盒子的处方占比
        public DetailgG[] ParticlesStation = new DetailgG[9]; //工位数据
        public int DetailedCount;//药品种类数量
        public int BoxCount;//盒子数量
        public int NowboxCount;//已经下盒数量
        public int NewBoxCount;//当前工位的盒子数量
        public int Boxfinish;//完成药盒的数量
        public int HCBoxfinish;
        public int Bc;//当前摆瓶数量


        public int yMoveCount;//位移次数转成1-16；   
        public int Mode; //模式
        public int Gnumber = 8;//工位数量
        public int Maxbox = 16;//盒子数量
        public int EmoveCount;//可以位移次数
        public int yEmoveCount;//位移次数转成1-16； 
        public int MoveCount; //当前位移次数
        public string PrescriptionID;//处方编号
        public string Prescriptionname;//患者名称

        public bool Zmove; //转盘开始位移
        public Int16 ZmoveV = 240; //转盘转动速度
        public int Zmovenuber; //位移格数
        public bool Zmoveing;//位移进行中
        public bool Zmovefinsh;//位移完成
        public Int64 ZmoveEorr;//下盒错误 bit ,1转盘丢步


        public bool Mbox; //开始下盒
        public bool HCMbox; //开始下盒
        public bool Mboxing;//下盒中
        public long MboxTime;//超时检查      
        public Int64 MboxEorr;//下盒错误 bit ,1该位置已有药盒， 2下药盒失败,3下盒电机超时         \\d .1该位置已有袋  .2打开袋模失败 .3封边失败 .4封底失败
        public bool Mboxfinsh;//下盒完成

        public int Mboxstep;//下盒步骤


        public bool Seal; //开始封口
        public bool HCSeal; //缓存启动开始封口
        public int SealTep; //设置的封口温度
        public int SealCH9; //开始封口
        public long SealTime;//超时检查

        public bool Sealfinsh;//封口完成
        public Int64 SealEorr;//封口错误bit 1未检测到膜， 2未检测到退膜 ，3封口机上升超时（未收到上限位信号），4封口机下降超时（未收到下限位信号） //D.1未检测到袋子 .2打开袋模失败 .3取袋失败 .4封袋顶封失败
        public int Sealstep;//封口步骤

        public bool Outbox; //开始出盒
        public bool HCOutbox; //开始出盒
        public long OutTime;//超时检查
        public bool Outboxing;//正在出盒
        public Int64 OutEorr;//出盒错误 bit ,1出盒失败， 2出盒电机超时
        public bool Outboxfinsh;//出盒完成
        public int Outboxstep;//出盒步骤



        public int HCcountmbox;//缓存供盒药盒序号
        public int HCcountseal;//缓存封口药盒序号
        public int HCcountoutbox;//缓存出盒序号
        public int HCmakebox;//下盒是盒子序号  


        public Med[] BoxST = new Med[17]; //药盒信息
        public static Med BoxSTnull;
        public List<DetailM> ParticlesDetailp; //处方的详细信息 

        public int[] Temp = new int[2]; //温湿度

        public bool TempL;  //温湿度链接状态
        public int Tempenuber = 0; //温湿度链接失败次数

        public int[] SealTemp = new int[1]; //封口温度
        public bool SealTempL;  //封口温度链接状态
        public int SealTempenuber = 0;//封口温度链接失败次数

        public bool HomeExcute;//回零启动
        public long HomeTime;//超时检查   
        public bool Homeing;//回零中
        public bool Homefinish;//回零完成
        public int HomeStep;//回零步骤
        public int HomeD1; //回零补位值;
        public int HomeD2; //回零补位值;

        public bool AxisHomeExcute;//单轴回零启动
        public long AxisHomeTime;//单轴超时检查   
        public bool AxisHomeing;//单轴回零中
        public bool AxisHomefinish;//单轴回零完成
        public int AxisHomeStep;//单轴回零步骤
        public int AxisHomenuber;//单轴回零编号
        public bool AxisHomeEorr;//单轴回零出错

        public bool[] TAxisHomeExcute = new bool[11];//单轴回零启动
        public bool[] TAxisHomefinish = new bool[11];//单轴回零完成
        public Int16[] WAxisHomeDate = new Int16[11];//写入单片机回零补位值

        public Int16 DrugeV = 240; //调剂速度

        public Workstate Runstate = new Workstate();

        public enum Workstate { Write, Home, Work, Density, Set, Rest } //等待回零， 回零， 调剂 密度测量中 ,调试模式 ,恢复模式

        public UInt32 iError; //异常 bit1温湿度未连接；2天平；3RFID未连接 4温控仪表未连接
        public UInt32 iRestError; //复位异常 =5复位该工位已有药盒错误， =6复位下盒失败错误 =12出盒失败错误 =13出盒超时
        public long Error; //异常 bit1温湿度未连接；2天平；3RFID未连接 4温控仪表未连接
        public long RestError; //复位异常 =5复位该工位已有药盒错误， =6复位下盒失败错误 =12出盒失败错误 =13出盒超时

    }


    public class DetailM
    {
        public string PrescriptionID; //处方编号 
        public string ParticlesName;//颗粒名  
        public string ParticlesCode;//颗粒码
        public string ParticlesNameHIS;//HIS颗粒名称
        public string ParticlesCodeHIS;//HIS码
        public int ArkID;//颗粒柜号
        public int Layer;//颗粒层号
        public int CoordinateX;//X坐标
        public int CoordinateY;//Y坐标
        public double ParticlesStockQuantity;//颗粒库存量
        public double Dweight;//当前称重重量
        public double TotalAmountUse;//误差量
        public double lastTotalAmountUse;//上次误差量
        public int DrugeValue;//完成的下药次数
        public double Dose;//每付调剂重量
        public double NewDose;//每袋调剂重量
        public double DeductStockWeight;   /// 提前扣除的库存
        public int Steper;//量仓的千分比
        public int state;//颗粒状态  =1待取出 =2已称重  =3 （已放入待调剂） =4调剂完成  =5等待上药  =6已有该药品称重状态
        public bool Deduct;// true已经扣除库存， false 还未扣除库存



    }
    public class DetailgG  //工位数据结构
    {
        public int Rfidnumber;//RFID获取的数据

        public bool Colkstate; //颗粒锁定
        public string ParticlesName;//颗粒名  
        public string ParticlesCode;//颗粒码
        public float Dweight;//称出来的重量
        public int DrugeValue;//完成的下药次数
        public bool HCStartDeruge; //启动调剂
        public bool StartDeruge; //启动调剂
        public bool Derugeing;
        public bool Derugefinish;//调剂完成；
        public int Particlesstate; //颗粒状态 =0本处方未包含该药品 =2待调剂状态  =8颗粒余量不足  =10不是该处方药品  =11已有该药品称重信息    =12该药品未称重   4;//工位待取走状态
        public int Drugestate; //调剂步骤
        public int Steper;// 量仓的千分比
        public Mathweight Mathw;
        public int Bar; //工位进度



    }
    public class Mathweight
    {
        public int MathdivWeight;
        public int MathmodWeight;
        public int Position;
        public int NewWeight;


    }
    public class Med //药盒数据结构
    {
        public string PrescriptionID;
        public List<ParticlesDetail> ParticlesDetail;
        public bool Outstate; //出盒状态
        public bool Gsealstate;//封口状态
        public int finishValue; //当前药盒完成的数量
        public int Bar; //药盒进度



    }
    public class ParticlesDetail
    {
        public string ParticlesCode;//颗粒码
        public int Steper;//量仓的千分比
        public bool finish;//颗粒完成状态

    }
}
