using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Machine
{
    public class CabinetStorageInfoTB
    {
        /// <summary>
        /// 药柜ID
        /// </summary>
        public int CabinetID { get; set; }
        /// <summary>
        /// 颗粒ID
        /// </summary>
        public int ParticlesID { get; set; }
        /// <summary>
        /// 类型 大小 药柜
        /// </summary>
        public int ArkID { get; set; }
        /// <summary>
        /// 层号
        /// </summary>
        public int Layer { get; set; }
        /// <summary>
        /// XP
        /// </summary>
        public int CoordinateX { get; set; }
        /// <summary>
        /// YP
        /// </summary>
        public int CoordinateY { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string BatchNumber { get; set; }
        /// <summary>
        /// 当前余量
        /// </summary>
        public float ParticlesStockQuantity { get; set; }
        /// <summary>
        /// 累计的误差量
        /// </summary>
        public float CoefficientTotalAmountUse { get; set; }
        /// <summary>
        ///瓶头累计调整量
        /// </summary>
        public float LastTotalAmountUse { get; set; }
        /// <summary>
        /// 上次系数误差量
        /// </summary>
        public float LastWeightTotalAmountUse { get; set; }
        /// <summary>
        /// <summary>
        /// 本次调整量
        /// </summary>
        public float OnyTotalAmountUse { get; set; }
        /// <summary>
        /// 使用量
        /// </summary>
        public float TotalAmountUse { get; set; }
        /// <summary>
        /// 密度
        /// </summary>
        //public float  Density { get; set; }
        /// <summary>
        /// 密度系数
        /// </summary>
        public float DensityCoefficient { get; set; }
        /// <summary>
        /// 到期日期
        /// </summary>
        public DateTime MaturityDate { get; set; }
        /// <summary>
        /// 空瓶重量
        /// </summary>
        public float EmptyBottleWeigh { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>     
        public string UpdateTime { get; set; }
        /// <summary>
        /// 网格字体
        /// </summary>
        public string FontParam { get; set; }
        /// <summary>
        /// 字体颜色
        /// </summary>
        public string FontColor { get; set; }
        /// <summary>
        /// 背景色
        /// </summary>
        public string BackColor { get; set; }
        /// <summary>
        /// 上次称重重量
        /// </summary>
        public float InPosition { get; set; }
        /// <summary>
        /// 特殊字段颗粒RFID
        /// </summary>
        public int DParticlesID { get; set; }
        /// <summary>
        /// 扩展字段 当前重量
        /// </summary>
        /// <param name="Detail"></param>
        /// <returns></returns>
        public double Weight { get; set; }
        /// <summary>
        /// 颗粒名称
        /// </summary>
        public string ParticlesName { get; set; }

        public bool SetDensityCoefficient() // 修改密度系数
        {
            try
            {

                return DBHelper.ExecuteNonQuery(string.Format(@"update MedicineCabinetDetail set DensityCoefficient={0} ,TotalUsedAmount={1},LastCoefficientErrorAmount={2} where MedicineCabinetId={3} and  ParticlesID={4} ", Math.Round(this.DensityCoefficient, 3), 0.01, LastWeightTotalAmountUse, this.CabinetID, this.ParticlesID));
            }
            catch(Exception e)
            {
                OperateLog.WriteLog(LogTypeEnum.数据库,$"调剂中修改{this.ParticlesName}的密度系数失败，应改为[{this.DensityCoefficient}]");
                return false;
            }

        }

        public bool MinusMargin(double subParticlesStockQuantity)
        {
            if (DBHelper.ExecuteNonQuery(string.Format(@"update MedicineCabinetDetail set Stock=Stock-{0},TotalUsedAmount=TotalUsedAmount+{0}, BottleHeadAdjustAmount=BottleHeadAdjustAmount+{1} ,LastWeightAmount={2} ,UpdateTime='{3}'  where ParticlesID={4} and MedicineCabinetId={5}", subParticlesStockQuantity, Math.Round(this.OnyTotalAmountUse, 2), this.InPosition, DateTime.Now, this.ParticlesID, this.CabinetID)))
            {
                DBHelper.ExecuteNonQuery(@"update MedicineCabinetDetail set Stock=0 where Stock<0");
                return true; ;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 上药加量
        /// </summary>
        /// <param name="Weight">量</param>
        /// <returns>完成状态</returns>

        public bool AddMargin(double Weight, bool IsRefreshCabient = false)
        {
            if (DBHelper.ExecuteNonQuery(string.Format(@"update MedicineCabinetDetail set Stock=Stock+{0},ValidityTime='{1}',TotalUsedAmount=0,LastCoefficientErrorAmount=0 ,BottleHeadAdjustAmount=0  where ParticlesID={2} and MedicineCabinetId={3}", Weight, this.MaturityDate, this.ParticlesID, this.CabinetID)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CabinetStorageInfoTB GetCabinetStorageInfo(int rfid)//查询药品在药柜的信息
        {

            CabinetStorageInfoTB objCabinetStorageInfoTB = new CabinetStorageInfoTB();
            DataTable Result_tb = this.SelectCabinetStorageInfoTB(rfid);
            if (Result_tb.Rows.Count == 1)
            {
                foreach (DataRow ParticlesLocation in Result_tb.Rows)
                {
                    objCabinetStorageInfoTB.ArkID = 0;// Convert.ToInt32(ParticlesLocation["ArkID"]);
                    objCabinetStorageInfoTB.Layer = 0;// Convert.ToInt32(ParticlesLocation["Layer"]);
                    objCabinetStorageInfoTB.CoordinateX = Convert.ToInt32(ParticlesLocation["CoordinateX"]);
                    objCabinetStorageInfoTB.CoordinateY = Convert.ToInt32(ParticlesLocation["CoordinateY"]);
                    objCabinetStorageInfoTB.ParticlesStockQuantity = Convert.ToSingle(ParticlesLocation["Stock"]);
                    objCabinetStorageInfoTB.TotalAmountUse = Convert.ToSingle(ParticlesLocation["TotalUsedAmount"]); //校准后的使用量
                    objCabinetStorageInfoTB.LastTotalAmountUse = Convert.ToSingle(ParticlesLocation["BottleHeadAdjustAmount"]);//瓶头调整量
                    objCabinetStorageInfoTB.CoefficientTotalAmountUse = Convert.ToSingle(ParticlesLocation["TotalErrorAmount"]);//校准余量
                    objCabinetStorageInfoTB.LastWeightTotalAmountUse = Convert.ToSingle(ParticlesLocation["LastCoefficientErrorAmount"]);//校准余量
                    objCabinetStorageInfoTB.DensityCoefficient = Convert.ToSingle(ParticlesLocation["DensityCoefficient"]);//校准余量
                    //objCabinetStorageInfoTB.Density = Convert.ToSingle(ParticlesLocation["Density"]);//校准余量
                    objCabinetStorageInfoTB.EmptyBottleWeigh = Convert.ToSingle(ParticlesLocation["EmptyBottleWeight"]);//空瓶重量
                    objCabinetStorageInfoTB.ParticlesID = Convert.ToInt32(ParticlesLocation["ParticlesID"]);
                    objCabinetStorageInfoTB.CabinetID = Convert.ToInt32(ParticlesLocation["MedicineCabinetId"]);
                    objCabinetStorageInfoTB.DParticlesID = Convert.ToInt32(ParticlesLocation["RFID"]); //& 0xFFFFF;//
                    if (ParticlesLocation["ValidityTime"] != null && string.IsNullOrEmpty(ParticlesLocation["ValidityTime"].ToString()) && DateTime.TryParse(ParticlesLocation["ValidityTime"].ToString(), out DateTime vt))
                    {
                        objCabinetStorageInfoTB.MaturityDate = vt;
                    }
                    else 
                    {
                        objCabinetStorageInfoTB.MaturityDate=DateTime.Now.AddYears(1);
                    }
                    
                    objCabinetStorageInfoTB.InPosition = Convert.ToInt32(ParticlesLocation["LastWeightAmount"]);//上次称重重量；
                    if (objCabinetStorageInfoTB.EmptyBottleWeigh == 0)
                    {
                        {
                            objCabinetStorageInfoTB.EmptyBottleWeigh = (float)223.5;
                        }
                    }
                }
                return objCabinetStorageInfoTB;
            }
            else
            {
                objCabinetStorageInfoTB = null;
                return objCabinetStorageInfoTB;
            }
        }

        public DataTable SelectCabinetStorageInfoTB(int rfid) //查询药品在药柜的信息
        {
            DataTable Result_tb = DBHelper.ExecuteQueryDataTable($@"select a.* 
                                                                    from MedicineCabinetDetail as a
                                                                    join MedicineCabinetInfo as b on a.MedicineCabinetId=b.ID
                                                                    Where a.RFID={rfid} and b.Code='{SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode}' ");

            return Result_tb;
        }
    }
}
