using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.FileModel;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.TCP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdjustmentSysUI.UITool
{
    public class PrescriptionFactory
    {
        PrescriptionAdjustmentBLL _prescriptionAdjustmentBLL = new PrescriptionAdjustmentBLL();
        /// <summary>
        /// 扣除下药完成颗粒的库存
        /// </summary>  
        public string DeductStock(PreModel PresData, double DeWeight)
        {
            List<MedicineCabinetOperationLogInfo> parLogs = new List<MedicineCabinetOperationLogInfo>();
            List<MedicineCabinetDetail> medicineCabinetDetails = new List<MedicineCabinetDetail>();

            PresData.Details.ForEach(item =>
            {
                MedicineCabinetOperationLogInfo parLog = new MedicineCabinetOperationLogInfo();
                //写扣除日志信息
                float MinusWeight = (float)(Math.Round((item.Dose * PresData.Quantity), 3) - DeWeight);    //扣除量=(颗粒剂量)*(处方付数)-之前扣除的下药量   
                float BTotalUsedAmount = (float)((DeWeight / (item.Dose * PresData.Quantity)) * item.MedicineCabinetDetail.CurentAdjustAmount);
                parLog.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
                parLog.CreateTime = DateTime.Now;
                parLog.ParticleCode = item.ParCode;
                parLog.ParticleId = (int)item.MedicineCabinetDetail?.RFID;
                parLog.ParticleName = item.ParName + (int)item.MedicineCabinetDetail?.RFID % 10000;
                parLog.InitialQuantity = (float)item.MedicineCabinetDetail?.Stock;
                parLog.CurrentWeightQuantity = item.CurrentWeightQuantity;
                parLog.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.调剂药品;
                parLog.UsedQuantity = MinusWeight;
                parLog.AddQuantity = 0;
                parLog.AdjustmentQuantity = (float)item.MedicineCabinetDetail.CurentAdjustAmount;
                parLog.OperationLogDecribe = "扣除日志信息";
                parLogs.Add(parLog);

                item.MedicineCabinetDetail.Stock = item.MedicineCabinetDetail.Stock - MinusWeight;
                item.MedicineCabinetDetail.CurentAdjustAmount = (float)BTotalUsedAmount;
                item.MedicineCabinetDetail.BottleHeadAdjustAmount = item.MedicineCabinetDetail.BottleHeadAdjustAmount + (float)BTotalUsedAmount;
                item.MedicineCabinetDetail.TotalUsedAmount = item.MedicineCabinetDetail.TotalUsedAmount + (float)MinusWeight;
                medicineCabinetDetails.Add(item.MedicineCabinetDetail);
            });
            //扣除库存
            var result = _prescriptionAdjustmentBLL.UpdateMedicineAndLog(medicineCabinetDetails, parLogs);

            return result;
        }

        /// <summary>
        /// 提前扣除部分库存
        /// </summary>
        public string DeductStockStep(PreModel PresData, float DeWeight)
        {
            List<MedicineCabinetOperationLogInfo> parLogs = new List<MedicineCabinetOperationLogInfo>();
            List<MedicineCabinetDetail> medicineCabinetDetails = new List<MedicineCabinetDetail>();

            PresData.Details.ForEach(item =>
            {
                MedicineCabinetOperationLogInfo parLog = new MedicineCabinetOperationLogInfo();
                //写扣除日志信息
                float MinusWeight = DeWeight;    //扣除量=(颗粒剂量)*(处方付数)    
                float BTotalUsedAmount = (float)((DeWeight / (item.Dose * PresData.Quantity)) * (item.MedicineCabinetDetail.CurentAdjustAmount));
                parLog.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
                parLog.CreateTime = DateTime.Now;
                parLog.ParticleCode = item.ParCode;
                parLog.ParticleId = (int)item.MedicineCabinetDetail?.RFID;
                parLog.ParticleName = item.ParName + (int)item.MedicineCabinetDetail?.RFID % 10000;
                parLog.InitialQuantity = (float)item.MedicineCabinetDetail?.Stock;
                parLog.CurrentWeightQuantity = item.CurrentWeightQuantity;
                parLog.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.调剂药品;
                parLog.UsedQuantity = MinusWeight;
                parLog.AddQuantity = 0;
                parLog.AdjustmentQuantity = BTotalUsedAmount;
                parLog.OperationLogDecribe = "扣除日志信息";
                parLogs.Add(parLog);

                item.MedicineCabinetDetail.Stock = item.MedicineCabinetDetail.Stock - MinusWeight;
                item.MedicineCabinetDetail.CurentAdjustAmount = (float)BTotalUsedAmount;
                item.MedicineCabinetDetail.BottleHeadAdjustAmount = item.MedicineCabinetDetail.BottleHeadAdjustAmount + (float)BTotalUsedAmount;
                item.MedicineCabinetDetail.TotalUsedAmount = item.MedicineCabinetDetail.TotalUsedAmount + (float)MinusWeight;
                medicineCabinetDetails.Add(item.MedicineCabinetDetail);
            });
            //扣除库存
            var result = _prescriptionAdjustmentBLL.UpdateMedicineAndLog(medicineCabinetDetails, parLogs);

            return result;        
        }

        /// <summary>
        /// 下发数据处理
        /// </summary>
        /// <param name="Detail"></param>
        /// <returns></returns>
        public Int16 DataHandles(ref ConfirmLocalDataPrescriptionDetail Detail, float NowWeight, int box) //当前称的重量
        {
            try
            {
                Detail.CurrentWeightQuantity = (float)Math.Round(NowWeight, 2);
                float Dosel = 0;
                float l = 1;
                if (Detail.MedicineCabinetDetail==null) { return 0; } //获取药瓶在药柜的最新信息
                if (NowWeight > 0)//半自动的校准方法
                {


                    NCorrectionFactor(ref Detail, NowWeight);//修改密度系数

                    float CoefficientTotalUsedAmount = Convert.ToSingle(NowWeight - Detail.MedicineCabinetDetail.Stock + Detail.MedicineCabinetDetail.TotalErrorAmount);//当前重量-库存量+累计误差量

                    if (Math.Abs(CoefficientTotalUsedAmount) > 0.5) //累计误差量大于0.3 做调整
                    {
                        PIDTool PIDTool = new PIDTool();
                        PIDTool.PID_Int(Detail, CoefficientTotalUsedAmount, box);
                        l = PIDTool.PID_Realize();//调整瓶头误差系数>1
                    }
                    else
                    {
                        l = 1;
                    }
                    //  float AmountUse = Convert.ToSingle(NowWeight - Detail.MedicineCabinetDetail.Stock);//当前重量-库存量=误差量
                    float Dosetow = Convert.ToSingle(Detail.NewDose * 2);       //本次药盒理论下药量
                    float OnyTotalUsedAmount = Dosetow * l - Dosetow;//本次一个药盒的整量误差调= 本次药盒理论下药量*本次调整系数-本次药盒理论下药量
                    Detail.MedicineCabinetDetail.CurentAdjustAmount = (float)Math.Round(OnyTotalUsedAmount * box, 2); ////该处方颗粒的的整量误差调
                    Dosel = Convert.ToSingle(Dosetow + OnyTotalUsedAmount);//理论重量+瓶头调整量=本次下药重量  +(Dosetow-Dosetow * Detail.MedicineCabinetDetail.DensityCoefficient )); //理论重量+瓶头调整量+系数调整量(理论重量- 密度系数*当前重量)

                }
                else //全自动的校准方法  
                {
                    float CoefficientTotalUsedAmount = Detail.MedicineCabinetDetail.TotalErrorAmount.Value - Detail.MedicineCabinetDetail.BottleHeadAdjustAmount.Value; //累计误差量-累计调整量=当前实际误差量
                    if (Math.Abs(CoefficientTotalUsedAmount) > 3) //累计误差量大于0.5 做调整
                    {
                        PIDTool PIDTool = new PIDTool();
                        PIDTool.PID_Int(Detail, CoefficientTotalUsedAmount, box);
                        l = PIDTool.PID_Realize();//调整瓶头误差系数>1
                    }
                    else
                    {
                        l = 1;
                    }
                    float Dosetow = Convert.ToSingle(Detail.NewDose * 2);       //本次药盒理论下药量
                    float OnyTotalUsedAmount = Dosetow * l - Dosetow;//本次一个药盒的整量误差调= 本次药盒理论下药量*本次调整系数-本次药盒理论下药量
                    Detail.MedicineCabinetDetail.CurentAdjustAmount = OnyTotalUsedAmount * box; ////该处方颗粒的的整量误差调
                    Dosel = Convert.ToSingle(Dosetow + OnyTotalUsedAmount);//理论重量+瓶头调整量=本次下药重量  +(Dosetow-Dosetow * Detail.MedicineCabinetDetail.DensityCoefficient )); //理论重量+瓶头调整量+系数调整量(理论重量- 密度系数*当前重量)
                }
                float Density = Convert.ToSingle(Detail.Density * Detail.DensityCoefficient * Detail.MedicineCabinetDetail.DensityCoefficient);//  Detail.MedicineCabinetDetail.DensityCoefficient * Detail.MedicineCabinetDetail.Density;
                if (Density == -1)
                {
                    MessageBox.Show("未获取到药品密度信息");
                    return 0;
                }
                double MaxWeight = (1.005594 * 10.48) * Density;// //计算出最大重量
                double Weight80 = (0.78257 * 10.48) * Density;// //计算出%80重量
                double Weight10 = (0.110428 * 10.48) * Density; //计算出%10重量
                double Weight4 = (0.0598 * 10.48) * Density; //计算出%4重量

                if (Dosel < MaxWeight) //计量仓一次完成时的体积计算方法
                {
                    float TheoryVolume = (float)(Dosel / Density / 10.48 * 100);//计算出理论体积 =重量/密度/全开体积*100
                    if (Weight80 <= Dosel) //大于 等于%80时的方程式
                    {
                        // y = 0.0105x2 - 0.9886x + 92.793
                        // return Convert.ToInt32(((0.0105 * TheoryVolume*TheoryVolume) -0.9886 *TheoryVolume +92.793) * 10);
                        //  y = 0.0052x2 - 0.1337x + 57.034   R2 = 1  
                        //y = 0.0149x2 - 1.8114x + 126.2R2 = 1
                        return Convert.ToInt16(((0.0149 * TheoryVolume * TheoryVolume) - 1.8114 * TheoryVolume + 126.2) * 10);
                    }
                    if (Weight10 <= Dosel) //大于等于%10时的方程式
                    {
                        //y = 1.0418x - 1.785
                        //  return Convert.ToInt32((1.04418* TheoryVolume-1.785) * 10);
                        //y = 0.0003x2 + 0.981x - 1.2928R2 = 0.9999
                        // return Convert.ToInt32(((0.0003 * TheoryVolume * TheoryVolume) + 0.981 * TheoryVolume - 1.2928) * 10);
                        //  y = -0.0008x2 + 1.0204x - 1.5266R2 = 0.9996
                        return Convert.ToInt16(((-0.0008 * TheoryVolume * TheoryVolume) + 1.0204 * TheoryVolume - 1.5266) * 10);

                    }

                    if (Weight4 <= Dosel) //大于等于%4时的方程式
                    {
                        // y = 1.0492x - 1.6034
                        //   return Convert.ToInt32((1.0492 * TheoryVolume - 1.6034) * 10);
                        //y = 1.0162x - 1.6034R2 = 0.9988
                        return Convert.ToInt16((1.0162 * TheoryVolume - 1.6034) * 10);
                    }
                    if (Weight4 > Dosel) //大于等于%4时的方程式
                    {
                        // y = 1.0492x - 1.6034
                        return 10;
                    }
                    //%10-%100 的方程式     //y = -0.0008x2 + 1.1037x - 2.6352
                    return Convert.ToInt16((-0.0008 * TheoryVolume * TheoryVolume + 1.1037 * TheoryVolume - 2.6352));
                }
                else //计量仓多次时的体积计算方法
                {
                    double Volume = 0;
                    double Weight = ((int)(Dosel / MaxWeight) - 1) * 1000;//(下药重量/最大重量 -1)*满剂量 
                    double newWeight = Dosel - (int)(Dosel / MaxWeight) * MaxWeight;//下药重量-（取整）（下药重量/最大重量）*最大重量=剩余重量
                    double TheoryVolume = (Double)((newWeight + MaxWeight) / 2) / (Density) / 10.82 * 100; //（剩余重量+最大重量）/2    /密度 = 最后两次下药的理论体积
                    if (Weight80 <= Dosel) //大于 等于%80时的方程式
                    {
                        // y = 0.0105x2 - 0.9886x + 92.793
                        Volume = Convert.ToInt32(((0.0149 * TheoryVolume * TheoryVolume) - 1.8114 * TheoryVolume + 126.2) * 10);
                    }
                    if (Weight10 <= Dosel) //大于等于%10时的方程式
                    {
                        //y = 1.0418x - 1.785
                        Volume = Convert.ToInt32(((-0.0008 * TheoryVolume * TheoryVolume) + 1.0204 * TheoryVolume - 1.5266) * 10);
                    }

                    if (Weight4 <= Dosel) //大于等于%4时的方程式
                    {
                        // y = 1.0492x - 1.6034
                        Volume = Convert.ToInt32((1.0162 * TheoryVolume - 1.6034) * 10); ;
                    }
                    if (Weight4 > Dosel) //大于等于%4时的方程式
                    {

                        Volume = 10;
                    }

                    return Convert.ToInt16(Weight + Volume * 2);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:5002", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }


        public void NCorrectionFactor(ref ConfirmLocalDataPrescriptionDetail Detail, float Nowweight)
        {
            float AmountUse = Convert.ToSingle(Nowweight - Detail.MedicineCabinetDetail.Stock + Detail.MedicineCabinetDetail.BottleHeadAdjustAmount);// 当前系数误差量=当前重量-库存量-瓶头累计调整量
            float XAmountUse = Convert.ToSingle(AmountUse - Detail.MedicineCabinetDetail.LastCoefficientErrorAmount); //误差量
            //if (Detail.MedicineCabinetDetail.TotalUsedAmount == 0 &&  Detail.MedicineCabinetDetail.Stock- Nowweight>97)
            //{
            //    MessageBox.Show("请将上药的颗粒倒入药瓶", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}

            if (Detail.MedicineCabinetDetail.Stock == 0 || Nowweight < 10 || Detail.MedicineCabinetDetail.TotalUsedAmount < 0.1)
            {
                return;
            }

            float TheMedicineAfterUse = Convert.ToSingle(Detail.MedicineCabinetDetail.TotalUsedAmount);
            if (Math.Abs(XAmountUse) < 0.3 || Math.Abs(AmountUse) < 0.3)//误差>0.3克开始调整 反之不调整
            {
                //OperateLog.Write_Adjustment(Detail.ParticlesName, Detail.MedicineCabinetDetail.DensityCoefficient.ToString(), AmountUse.ToString(), TheMedicineAfterUse.ToString(), "不调整"); //写日志

                return;
            }
            float SourceDensityCoefficien = Convert.ToSingle(Detail.MedicineCabinetDetail.DensityCoefficient);
            float d = Math.Abs((float)(XAmountUse / Detail.MedicineCabinetDetail.TotalUsedAmount)); //调整系数
            float l = 0;
            double DensityCoefficient; //密度系数;
            double DensityCoefficienadd; //密度系数增加量;

            if (d > 0.1f)
            {
                l = 0.01f;

            }
            else
            {
                l = 0.01f;
            }
            DensityCoefficienadd = l * SourceDensityCoefficien;  //最新的密度系数=调整百分比*原始密度
            if (AmountUse - Detail.MedicineCabinetDetail.LastCoefficientErrorAmount < 0) //实际系数误差量多密度减小    反之密度增加
            {
                DensityCoefficient = Math.Round(SourceDensityCoefficien + Math.Abs(DensityCoefficienadd), 3);
            }
            else
            {
                DensityCoefficient = Math.Round(SourceDensityCoefficien - Math.Abs(DensityCoefficienadd), 3);
            }
            //调整范围
            if (Math.Abs(1 - DensityCoefficient) > 0.2)
            {
                if (MessageBox.Show("当前颗粒偏差较大,请重新测密度或更换瓶头!<" + DensityCoefficient.ToString() + ">,是否强制修改系数?", "重要提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if ((Math.Abs(1 - DensityCoefficient)) < 0.3)
                    {
                        Detail.MedicineCabinetDetail.LastCoefficientErrorAmount = AmountUse;
                        Detail.MedicineCabinetDetail.DensityCoefficient = Convert.ToSingle(DensityCoefficient);
                        Detail.MedicineCabinetDetail.TotalUsedAmount = (float)0.01;
                        _prescriptionAdjustmentBLL.UpdateMedicineCabinetDetail(Detail.MedicineCabinetDetail);
                        //OperateLog.Write_Adjustment(Detail.ParticlesName, DensityCoefficient.ToString(), XAmountUse.ToString(), TheMedicineAfterUse.ToString(), "强制调整"); //写日志

                    }
                    else
                    {
                        Detail.MedicineCabinetDetail.LastCoefficientErrorAmount = AmountUse;
                        Detail.MedicineCabinetDetail.DensityCoefficient = Convert.ToSingle(DensityCoefficient);
                        //         this.SetDensity(Detail.ParticlesID, 0);
                        Detail.MedicineCabinetDetail.TotalUsedAmount = (float)0.01;
                        _prescriptionAdjustmentBLL.UpdateMedicineCabinetDetail(Detail.MedicineCabinetDetail);
                        //OperateLog.Write_Adjustment(Detail.ParticlesName, DensityCoefficient.ToString(), XAmountUse.ToString(), TheMedicineAfterUse.ToString(), "超出限定范围,强制不调整!"); //写日志
                        MessageBox.Show("当前颗粒偏差较大,该品种参数已清零,请重新测密度!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    //OperateLog.Write_Adjustment(Detail.ParticlesName, DensityCoefficient.ToString(), XAmountUse.ToString(), TheMedicineAfterUse.ToString(), "超出后修改被取消"); //写日志
                }
            }
            else
            {
                Detail.MedicineCabinetDetail.LastCoefficientErrorAmount = AmountUse;
                Detail.MedicineCabinetDetail.DensityCoefficient = Convert.ToSingle(DensityCoefficient);
                Detail.MedicineCabinetDetail.TotalUsedAmount = (float)0.01;
                _prescriptionAdjustmentBLL.UpdateMedicineCabinetDetail(Detail.MedicineCabinetDetail);
                //OperateLog.Write_Adjustment(Detail.ParticlesName, DensityCoefficient.ToString(), XAmountUse.ToString(), TheMedicineAfterUse.ToString(), "正常调整"); //写日志               
            }
            //    ParticlesDictionaries.GetData();    //刷新颗粒字典
        }

    }
}
