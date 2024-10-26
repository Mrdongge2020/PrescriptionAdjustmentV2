using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.FileModel;
using AdjustmentSys.Models.MakeUp;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.TCP;
using AdjustmentSysUI.Forms.DeviceForms;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AdjustmentSysUI.UITool
{
    public class PrescriptionFactory
    {
        PrescriptionAdjustmentBLL _prescriptionAdjustmentBLL = new PrescriptionAdjustmentBLL();

        UIPage uipage = new UIPage();

        /// <summary>
        /// 扣除下药完成颗粒的库存
        /// </summary>  
        public string DeductStock(int rfid,PreModel PresData, double DeWeight)
        {
            List<MedicineCabinetOperationLogInfo> parLogs = new List<MedicineCabinetOperationLogInfo>();
            List<MedicineCabinetDetail> medicineCabinetDetails = new List<MedicineCabinetDetail>();

            PresData.Details.ForEach(item =>
            {
                if (item.MedicineCabinetDetail.RFID==rfid) 
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
                }
            });
            //扣除库存
            var result = _prescriptionAdjustmentBLL.UpdateMedicineAndLog(medicineCabinetDetails, parLogs);

            return result;
        }

        /// <summary>
        /// 提前扣除部分库存
        /// </summary>
        public string DeductStockStep(int rfid, PreModel PresData, float DeWeight)
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
        public Int16 DataHandles(ref MedicineCabinetDetail mcDetail, MakePrescriptionParticle preParticle, int box) //当前称的重量
        {
            try
            {
                //Detail.CurrentWeightQuantity = (float)Math.Round(NowWeight, 2);
                float Dosel = 0;
                float l = 1;
                if (mcDetail == null) { return 0; } //获取药瓶在药柜的最新信息
                if (preParticle.CurrentWeightQuantity > 0)//半自动的校准方法
                {
                    NCorrectionFactor(ref mcDetail, preParticle.CurrentWeightQuantity);//修改密度系数

                    float CoefficientTotalUsedAmount = Convert.ToSingle(preParticle.CurrentWeightQuantity - mcDetail.Stock + mcDetail.TotalErrorAmount);//当前重量-库存量+累计误差量

                    if (Math.Abs(CoefficientTotalUsedAmount) > 0.5) //累计误差量大于0.3 做调整
                    {
                        PIDTool PIDTool = new PIDTool();
                        PIDTool.PID_Int(preParticle.NewDose, CoefficientTotalUsedAmount, box);
                        l = PIDTool.PID_Realize();//调整瓶头误差系数>1
                    }
                    else
                    {
                        l = 1;
                    }
                    float Dosetow = Convert.ToSingle(preParticle.NewDose * 2);       //本次药盒理论下药量
                    float OnyTotalUsedAmount = Dosetow * l - Dosetow;//本次一个药盒的整量误差调= 本次药盒理论下药量*本次调整系数-本次药盒理论下药量
                    mcDetail.CurentAdjustAmount = (float)Math.Round(OnyTotalUsedAmount * box, 2); ////该处方颗粒的的整量误差调
                    Dosel = Convert.ToSingle(Dosetow + OnyTotalUsedAmount);//理论重量+瓶头调整量=本次下药重量  +(Dosetow-Dosetow * Detail.MedicineCabinetDetail.DensityCoefficient )); //理论重量+瓶头调整量+系数调整量(理论重量- 密度系数*当前重量)

                }
                else //全自动的校准方法  
                {
                    float CoefficientTotalUsedAmount = mcDetail.TotalErrorAmount.Value - mcDetail.BottleHeadAdjustAmount.Value; //累计误差量-累计调整量=当前实际误差量
                    if (Math.Abs(CoefficientTotalUsedAmount) > 3) //累计误差量大于0.5 做调整
                    {
                        PIDTool PIDTool = new PIDTool();
                        PIDTool.PID_Int(preParticle.NewDose, CoefficientTotalUsedAmount, box);
                        l = PIDTool.PID_Realize();//调整瓶头误差系数>1
                    }
                    else
                    {
                        l = 1;
                    }
                    float Dosetow = Convert.ToSingle(preParticle.NewDose * 2);       //本次药盒理论下药量
                    float OnyTotalUsedAmount = Dosetow * l - Dosetow;//本次一个药盒的整量误差调= 本次药盒理论下药量*本次调整系数-本次药盒理论下药量
                    mcDetail.CurentAdjustAmount = OnyTotalUsedAmount * box; ////该处方颗粒的的整量误差调
                    Dosel = Convert.ToSingle(Dosetow + OnyTotalUsedAmount);//理论重量+瓶头调整量=本次下药重量  +(Dosetow-Dosetow * Detail.MedicineCabinetDetail.DensityCoefficient )); //理论重量+瓶头调整量+系数调整量(理论重量- 密度系数*当前重量)
                }
                float Density = Convert.ToSingle(preParticle.Density * mcDetail.DensityCoefficient * preParticle.DensityCoefficient);//  Detail.MedicineCabinetDetail.DensityCoefficient * Detail.MedicineCabinetDetail.Density;
                if (Density == -1)
                {

                    uipage.ShowErrorTip("未获取到药品密度信息");
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

        /// <summary>
        /// 调整密度系数
        /// </summary>
        /// <param name="Detail">药柜颗粒详情信息</param>
        /// <param name="Nowweight">当前称重</param>
        public void NCorrectionFactor(ref MedicineCabinetDetail Detail, float Nowweight)
        {
            float AmountUse = Convert.ToSingle(Nowweight - Detail.Stock + Detail.BottleHeadAdjustAmount);// 当前系数误差量=当前重量-库存量-瓶头累计调整量
            float XAmountUse = Convert.ToSingle(AmountUse - Detail.LastCoefficientErrorAmount); //误差量

            if (Detail.Stock == 0 || Nowweight < 10 || Detail.TotalUsedAmount < 0.1)
            {
                return;
            }

            float TheMedicineAfterUse = Convert.ToSingle(Detail.TotalUsedAmount);
            if (Math.Abs(XAmountUse) < 0.3 || Math.Abs(AmountUse) < 0.3)//误差>0.3克开始调整 反之不调整
            {
                return;
            }
            float SourceDensityCoefficien = Convert.ToSingle(Detail.DensityCoefficient);
            float d = Math.Abs((float)(XAmountUse / Detail.TotalUsedAmount)); //调整系数
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
            if (AmountUse - Detail.LastCoefficientErrorAmount < 0) //实际系数误差量多密度减小    反之密度增加
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
                var anster = uipage.ShowAskDialog("警告!", "当前颗粒偏差较大, 请重新测密度或更换瓶头! < " + DensityCoefficient.ToString() + " >, 是否强制修改系数 ?", UIStyle.Blue, false, UIMessageDialogButtons.Ok);
                if (!anster) { return; }

                if ((Math.Abs(1 - DensityCoefficient)) < 0.3)
                {
                    Detail.LastCoefficientErrorAmount = AmountUse;
                    Detail.DensityCoefficient = Convert.ToSingle(DensityCoefficient);
                    Detail.TotalUsedAmount = (float)0.01;
                    _prescriptionAdjustmentBLL.UpdateMedicineCabinetDetail(Detail);
                }
                else
                {
                    Detail.LastCoefficientErrorAmount = AmountUse;
                    Detail.DensityCoefficient = Convert.ToSingle(DensityCoefficient);
                    Detail.TotalUsedAmount = (float)0.01;
                    _prescriptionAdjustmentBLL.UpdateMedicineCabinetDetail(Detail);
                    uipage.ShowInfoDialog("重要提示!", $"当前颗粒偏差较大,该品种参数已清零,请重新测密度!");
                }
            }
            else
            {
                Detail.LastCoefficientErrorAmount = AmountUse;
                Detail.DensityCoefficient = Convert.ToSingle(DensityCoefficient);
                Detail.TotalUsedAmount = (float)0.01;
                _prescriptionAdjustmentBLL.UpdateMedicineCabinetDetail(Detail);
            }
        }

        #region 本类字段
        public Int16 BoxType { get; set; }//药盒类型

        public double BoxCellVolume { get; set; }//药盒单格体积

        public int AdjustWay { get; set; }//调剂方式

        public float DoseLimitDown { get; set; }//剂量底限
        #endregion

        /// <summary>
        /// 处方相关计算
        /// </summary>
        /// <returns>新拆分处方</returns>
        public PreModel PrescriptionHandles(PreModel prescription,out string errorMsg)
        {
            try
            {
                StringBuilder ErrorOut = new StringBuilder("");

                double TotalV = this.PresVolume(prescription,out errorMsg); //获取该处方总体积
                if (errorMsg!="") 
                {
                    return null;
                }
                if (TotalV <= 0)
                {
                    errorMsg="检测到数据异常溢出,将终止此处方调剂,请检该处方中颗粒剂量,密度,当量参数是否有为零的.";
                    return null;
                }
               
                int CalculateCellNumber = prescription.TaskFrequency * prescription.Quantity;  //理论总格数=分付次数*付数                

                while (true)
                {
                    if ((CalculateCellNumber % this.BoxType == 0) && (TotalV <= BoxCellVolume * CalculateCellNumber) && (CalculateCellNumber % (prescription.TaskFrequency * prescription.Quantity) == 0))
                    {
                        break;
                    }
                    else
                    {
                        CalculateCellNumber += 1;
                    }
                }


                if (CalculateCellNumber % this.BoxType != 0)  //判断处方格数合法性
                {
                    errorMsg="当前处方不符合" + this.BoxType + "分药盒/袋调剂,余<" + CalculateCellNumber % this.BoxType + ">.";
                    return null;
                }

                prescription.Details.ForEach(item => 
                {
                    if (item.Dose < this.DoseLimitDown)  //如果小于最小底限量即取默认值
                    {
                        item.NewDose = this.DoseLimitDown; //this.DoseLimitDefaultValue;
                    }
                    else
                    {
                        item.NewDose = (float)(Math.Round(((item.Dose * prescription.Quantity) / CalculateCellNumber), 2));//根据格数平均剂量
                    }
                });

                string unit = "格";
                if (SysDeviceInfo._currentDeviceInfo.DeviceType == DeviceTypeEnum.半自动袋装)
                {
                    unit = "袋";
                }
                prescription.BoxNumber = CalculateCellNumber / this.BoxType; //计算总盒数;
                prescription.BreakNumber = CalculateCellNumber / (prescription.Quantity * prescription.TaskFrequency) - 1;    //计算拆分次数
                prescription.GenerateUseWay =  "每日" + StringHelper.ConvertInteger(prescription.TaskFrequency.ToString()) + "" + "次;每次" + StringHelper.ConvertInteger(((CalculateCellNumber / (prescription.Quantity * prescription.TaskFrequency)).ToString())) + unit + "";
               
                return prescription;
            }
            catch (Exception ex)
            {
                errorMsg="出现错误:"+ ex.Message  ;
                return null;
            }
        }

        /// <summary>
        /// 药盒体积和计算
        /// </summary>
        /// <param name="PresData">处方信息</param>
        /// <param name="errorMsg">错误信息</param>
        /// <returns></returns>
        private float PresVolume(PreModel PresData,out string errorMsg)     //返回处方总体积
        {
            float TotalVolume = 0;
            foreach (ConfirmLocalDataPrescriptionDetail detail in PresData.Details)
            {
                errorMsg = ParticlesParamCheck(detail);
                if (errorMsg!="") 
                {
                    return -1;
                }

                float density = (float)Math.Floor((detail.MedicineCabinetDetail.DensityCoefficient.Value * detail.Density) * 1000) / 1000;
                if (this.AdjustWay == 0)//调剂方式选择
                {
                    TotalVolume += (detail.Dose / density);//颗粒计量/颗粒密度
                }
                else
                {
                    TotalVolume += ((detail.DoseHerb / detail.Equivalent) / density);//（饮片计量/当量）/颗粒密度                                                         
                }
            }
            if (TotalVolume > int.MaxValue)
            {
                errorMsg = $"处方{PresData.PrescriptionID}体积超出限制{int.MaxValue}";
                return -1;
            }
            errorMsg = "";
            return TotalVolume * PresData.Quantity; //总体积,单位:ml
        }

        private string ParticlesParamCheck(ConfirmLocalDataPrescriptionDetail detail)  //颗粒参数检查
        {
            string errorStr = "";
            if (detail.Density <= 0.1)
            {
                errorStr="颗粒'" + detail.ParName + "'密度<=0.1";
                return errorStr;
            }
            if (detail.DensityCoefficient <= 0 || detail.MedicineCabinetDetail.DensityCoefficient<=0)
            {
                errorStr="颗粒'" + detail.ParName + "'密度系数<=0.";
                return errorStr;
            }
            if (detail.Dose <= 0 || detail.DoseHerb <= 0)
            {
                errorStr="颗粒'" + detail.ParName + "'饮片剂量或颗粒剂量<=0.";
                return errorStr;
            }
            if (detail.DoseLimit <= 0 || detail.Equivalent <= 0)
            {
                errorStr="颗粒'" + detail.ParName + "'剂量上限或当量<=0.";
                return errorStr;
            }
            
            return errorStr;
        }
    }
}
