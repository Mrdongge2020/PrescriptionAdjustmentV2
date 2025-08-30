using AdjustmentSys.DAL.Common;
using AdjustmentSys.Models.Machine;
using AdjustmentSys.Tool.FileOpter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdjustmentSys.Tool.TCP.PIDTool;
using System.Windows.Forms;
using Sunny.UI;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Models.User;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.Models.FileModel;
using AdjustmentSys.Models.Prescription;
using static AdjustmentSys.Models.Machine.DataPrescriptionTB;

namespace AdjustmentSysUI.UITool
{
    public class PrescriptionProcessingFactory
    {

        Coefficient ASCoefficient = new Coefficient();
        public Int16 LidHoleNumber = 2;//药盒类型

        public bool AdjustAWay { get; set; }//调剂方式 饮片 颗粒
        public int CabinetID { get; set; }//本机关联药柜ID
        public double BoxCellVolume { get; set; }//药盒单格体积
        public double DoseLimitDown { get; set; }    //颗粒底限量
        public double DoseLimitDefaultValue { get; set; } //底限后默认值

        UIPage uipage = new UIPage();

        PrescriptionAdjustmentBLL _prescriptionAdjustmentBLL = new PrescriptionAdjustmentBLL();

        private bool DataCheck(DataPrescriptionTB Pres)
        {
            if (Pres == null)
            {
                uipage.ShowErrorDialog("处方实例对象为NULL,无效状态!", "警告");
                return false;
            }

             if (this.LidHoleNumber <= 0)
            {
                uipage.ShowErrorDialog("当前药盒类型参数不合法!", "警告");
                return false;
            }
            
            if (this.CabinetID <= 0)
            {
                uipage.ShowErrorDialog("当前药柜编号参数为无效值!", "警告");
                return false;
            }
            if (this.BoxCellVolume <= 0)
            {
                uipage.ShowErrorDialog("药盒单格体积参数为无效值!", "警告");
                return false;
            }
            
            return true;
            
        }

        /// <summary>
        /// 下发数据处理
        /// </summary>
        /// <param name="Detail"></param>
        /// <returns></returns>
        public Int16 DataHandles(ref DataPrescriptionTB.DetailStructure Detail, float NowWeight, int box) //当前称的重量
        {
            try
            {
                Detail.CurrentWeight = Math.Round(NowWeight, 2);
                float Dosel = 0;
                float l = 1;
                // if (!Detail.CabinetParticles.GetCabinetStorage(ref Detail.CabinetParticles)) { return 0; } //获取药瓶在药柜的最新信息
                if (NowWeight > 0)//半自动的校准方法
                {

                    ASCoefficient.NCorrectionFactor(ref Detail, NowWeight);//修改密度系数

                    float CoefficientTotalAmountUse = Convert.ToSingle(NowWeight - Detail.CabinetParticles.ParticlesStockQuantity + Detail.CabinetParticles.CoefficientTotalAmountUse);//当前重量-库存量+累计误差量

                    if (Math.Abs(CoefficientTotalAmountUse) > 0.5) //累计误差量大于0.3 做调整
                    {
                        PIDmx pidmx = new PIDmx();
                        pidmx.PID_Int(Detail, CoefficientTotalAmountUse, box);
                        l = pidmx.PID_Realize();//调整瓶头误差系数>1
                    }
                    else
                    {
                        l = 1;
                    }
                    //  float AmountUse = Convert.ToSingle(NowWeight - Detail.CabinetParticles.ParticlesStockQuantity);//当前重量-库存量=误差量
                    float Dosetow = Convert.ToSingle(Detail.NewDose * 2);       //本次药盒理论下药量
                    float OnyTotalAmountUse = Dosetow * l - Dosetow;//本次一个药盒的整量误差调= 本次药盒理论下药量*本次调整系数-本次药盒理论下药量
                    Detail.CabinetParticles.OnyTotalAmountUse = (float)Math.Round(OnyTotalAmountUse * box, 2); ////该处方颗粒的的整量误差调
                    Dosel = Convert.ToSingle(Dosetow + OnyTotalAmountUse);//理论重量+瓶头调整量=本次下药重量  +(Dosetow-Dosetow * Detail.CabinetParticles.DensityCoefficient )); //理论重量+瓶头调整量+系数调整量(理论重量- 密度系数*当前重量)

                }
                else //全自动的校准方法  
                {
                    float CoefficientTotalAmountUse = Detail.CabinetParticles.CoefficientTotalAmountUse - Detail.CabinetParticles.LastTotalAmountUse; //累计误差量-累计调整量=当前实际误差量
                    if (Math.Abs(CoefficientTotalAmountUse) > 3) //累计误差量大于0.5 做调整
                    {
                        PIDmx pidmx = new PIDmx();
                        pidmx.PID_Int(Detail, CoefficientTotalAmountUse, box);
                        l = pidmx.PID_Realize();//调整瓶头误差系数>1
                    }
                    else
                    {
                        l = 1;
                    }
                    float Dosetow = Convert.ToSingle(Detail.NewDose * 2);       //本次药盒理论下药量
                    float OnyTotalAmountUse = Dosetow * l - Dosetow;//本次一个药盒的整量误差调= 本次药盒理论下药量*本次调整系数-本次药盒理论下药量
                    Detail.CabinetParticles.OnyTotalAmountUse = OnyTotalAmountUse * box; ////该处方颗粒的的整量误差调
                    Dosel = Convert.ToSingle(Dosetow + OnyTotalAmountUse);//理论重量+瓶头调整量=本次下药重量  +(Dosetow-Dosetow * Detail.CabinetParticles.DensityCoefficient )); //理论重量+瓶头调整量+系数调整量(理论重量- 密度系数*当前重量)
                }
                float Density = Convert.ToSingle(Detail.Density * Detail.DensityCoefficient * Detail.CabinetParticles.DensityCoefficient);//  Detail.CabinetParticles.DensityCoefficient * Detail.CabinetParticles.Density;
                if (Density == -1)
                {
                    uipage.ShowErrorDialog("未获取到药品密度信息");
                    return 0;
                }
                double MaxWeight = (1.063 * 10.48) * Density;// //计算出最大重量
                double Weight80 = (0.856 * 10.48) * Density;// //计算出%80重量
                double Weight10 = (0.110428 * 10.48) * Density; //计算出%10重量
                double Weight4 = (0.0598 * 10.48) * Density; //计算出%4重量

                if (Dosel < MaxWeight) //计量仓一次完成时的体积计算方法
                {
                    float TheoryVolume = (float)(Dosel / Density / 10.48 * 100);//计算出理论体积 =重量/密度/全开体积*100
                    if (Weight80 <= Dosel) //大于 等于%80时的方程式
                    {
                        // y = 0.0105x2 - 0.9886x + 92.793
                        // return Convert.ToInt32(((0.0105 * TheoryVolume*TheoryVolume) -0.9886 *TheoryVolume +92.793) * 10);

                        //y = 0.0149x2 - 1.8114x + 126.2R2 = 1
                        // y = 0.0003x2 + 0.8514x + 4.6636
                        //  return Convert.ToInt16(((0.0069 * TheoryVolume * TheoryVolume) - 0.3809 * TheoryVolume + 62.711) * 10);
                        return Convert.ToInt16((0.8935 * TheoryVolume + 3.798) * 10);
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
                    double TheoryVolume = (Double)((newWeight + MaxWeight) / 2) / (Density) / 10.48 * 100; //（剩余重量+最大重量）/2    /密度 = 最后两次下药的理论体积
                    Dosel = (float)((newWeight + MaxWeight) / 2);
                    if (Weight80 <= Dosel) //大于 等于%80时的方程式
                    {

                        Volume = Convert.ToInt16((0.8935 * TheoryVolume + 3.798) * 10);
                        goto a1;
                    }
                    if (Weight10 <= Dosel) //大于等于%10时的方程式
                    {
                        //y = 1.0418x - 1.785
                        Volume = Convert.ToInt32(((-0.0008 * TheoryVolume * TheoryVolume) + 1.0204 * TheoryVolume - 1.5266) * 10);
                        goto a1;
                    }

                    if (Weight4 <= Dosel) //大于等于%4时的方程式
                    {
                        // y = 1.0492x - 1.6034
                        Volume = Convert.ToInt32((1.0162 * TheoryVolume - 1.6034) * 10);
                        goto a1;
                    }
                    if (Weight4 > Dosel) //大于等于%4时的方程式
                    {

                        Volume = 10;
                        goto a1;
                    }

                a1: return Convert.ToInt16(Weight + Volume * 2);
                }

            }

            catch (Exception ex)
            {
                uipage.ShowErrorDialog("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:5002");
                return 0;
            }
        }
        /// <summary>
        /// 根据重量计算 开计量仓
        /// </summary>
        /// <param name="Dosel"></param>
        /// <returns></returns>
        public Int16 OdddataHandles(double Dosel, DataPrescriptionTB.DetailStructure Detail)
        {
            if (Detail==null)
            {
                uipage.ShowErrorDialog("未获取到药品信息");
                return 0;
            }
            float Density = Convert.ToSingle(Detail.Density * Detail.DensityCoefficient * Detail.CabinetParticles.DensityCoefficient);//  Detail.CabinetParticles.DensityCoefficient * Detail.CabinetParticles.Density;
            if (Density == -1)
            {
                uipage.ShowErrorDialog("未获取到药品密度信息");
                return 0;
            }
            double MaxWeight = (1.063 * 10.48) * Density;// //计算出最大重量
            double Weight80 = (0.856 * 10.48) * Density;// //计算出%80重量
            double Weight10 = (0.110428 * 10.48) * Density; //计算出%10重量
            double Weight4 = (0.0598 * 10.48) * Density; //计算出%4重量

            if (Dosel < MaxWeight) //计量仓一次完成时的体积计算方法
            {
                float TheoryVolume = (float)(Dosel / Density / 10.48 * 100);//计算出理论体积 =重量/密度/全开体积*100
                if (Weight80 <= Dosel) //大于 等于%80时的方程式
                {
                    // y = 0.0105x2 - 0.9886x + 92.793
                    // return Convert.ToInt32(((0.0105 * TheoryVolume*TheoryVolume) -0.9886 *TheoryVolume +92.793) * 10);

                    //y = 0.0149x2 - 1.8114x + 126.2R2 = 1
                    // y = 0.0003x2 + 0.8514x + 4.6636
                    //  return Convert.ToInt16(((0.0069 * TheoryVolume * TheoryVolume) - 0.3809 * TheoryVolume + 62.711) * 10);
                    return Convert.ToInt16((0.8935 * TheoryVolume + 3.798) * 10);
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
                double TheoryVolume = (Double)((newWeight + MaxWeight) / 2) / (Density) / 10.48 * 100; //（剩余重量+最大重量）/2    /密度 = 最后两次下药的理论体积
                Dosel = (float)((newWeight + MaxWeight) / 2);
                if (Weight80 <= Dosel) //大于 等于%80时的方程式
                {

                    Volume = Convert.ToInt16((0.8935 * TheoryVolume + 3.798) * 10);
                    goto a1;
                }
                if (Weight10 <= Dosel) //大于等于%10时的方程式
                {
                    //y = 1.0418x - 1.785
                    Volume = Convert.ToInt32(((-0.0008 * TheoryVolume * TheoryVolume) + 1.0204 * TheoryVolume - 1.5266) * 10);
                    goto a1;
                }

                if (Weight4 <= Dosel) //大于等于%4时的方程式
                {
                    // y = 1.0492x - 1.6034
                    Volume = Convert.ToInt32((1.0162 * TheoryVolume - 1.6034) * 10);
                    goto a1;
                }
                if (Weight4 > Dosel) //大于等于%4时的方程式
                {

                    Volume = 10;
                    goto a1;
                }

            a1: return Convert.ToInt16(Weight + Volume * 2);
            }

        }



        private bool ParticlesParamCheck(DataPrescriptionTB.DetailStructure PresDetail)  //颗粒参数检查
        {
            if (PresDetail==null) { 

                return false; 
            }
            if (PresDetail.Density == -1)
            {
                uipage.ShowErrorDialog("未获取到药品密度信息");
                return false;
            }
            if (PresDetail.Density <= 0.1)
            {
                uipage.ShowErrorDialog("颗粒'" + PresDetail.ParticlesName + "'密度<=0.1");
                return false;
            }
            if (PresDetail.DensityCoefficient <= 0)
            {
                uipage.ShowErrorDialog("颗粒'" + PresDetail.ParticlesName + "'密度系数<=0.");
                return false;
            }
            if (PresDetail.Dose <= 0 || PresDetail.DoseHerb <= 0)
            {
                uipage.ShowErrorDialog("颗粒'" + PresDetail.ParticlesName + "'饮片剂量或颗粒剂量<=0.");
                return false;
            }
            if (PresDetail.DoseLimit <= 0 || PresDetail.Equivalent <= 0)
            {
                uipage.ShowErrorDialog("颗粒'" + PresDetail.ParticlesName + "'剂量上限或当量<=0.");
                return false;
            }
            
            return true;
            
        }

        public LocalDataPrescriptionInfo GerLocalDataPrescriptionInfo(string PreId) 
        {
            PrescriptionAdjustmentBLL prescriptionAdjustmentBLL = new PrescriptionAdjustmentBLL();
            var preData = prescriptionAdjustmentBLL.GetPrescriptionByCode(PreId);
            if (preData == null)
            {
                return null;
            }
            else {
                return preData.PrescriptionInfo;
            }
           
            //LocalDataPrescriptionInfoRecord record = new LocalDataPrescriptionInfoRecord();
            //record.PrescriptionID= PresData.PrescriptionID;
            //record.PatientName= PresData.PatientName;
            //record.PatientSex= PresData.PatientSex;
            //record.PatientAge= PresData.PatientAge;
            //record.PatientBirthDay= PresData.PatientBirthDay;
            //record.PatientBirthMonth= PresData.PatientBirthMonth;
            //record.PatientTel= PresData.PatientTel;
            //record.PatientEmail= PresData.PatientEmail;
            //record.PatientLocation= PresData.PatientLocation;
            //record.DoctorName= PresData.DoctorName;
            //record.DepartmentName= PresData.DepartmentName;
            //record.CreateName= PresData.CreateName;
            //record.CreateTime= PresData.CreateTime;
            //record.ValuerName= PresData.ValuerName;
            //record.ValueSn=PresData.ValueSn;
            //record.ValuationTime=PresData.ValuationTime;
            //record.RegisterID= PresData.RegisterID;
            //record.PaymentType= PresData.PaymentType;
            //record.PaymentStatus= PresData.PaymentStatus;
            //record.PrescriptionType= PresData.PrescriptionType;
            //record.BedNumber= PresData.BedNumber;
            //record.ImportTime= PresData.ImportTime;
            //record.Quantity= PresData.Quantity;
            //record.DetailedCount= PresData.DetailedCount;
            //record.TaskFrequency= PresData.TaskFrequency;
            //record.UnitPrice= PresData.UnitPrice;
            //record.TotalPrice= PresData.TotalPrice;
            //record.PrescriptionSource= PresData.PrescriptionSource;
            //record.ProcessStatus=processStatus;
            //record.PrescriptionName= PresData.PrescriptionName;
            //record.Remarks= PresData.Remarks;
            //record.DownloadName = PresData.DownloadName;
            //record.DownloadTime= PresData.DownloadTime;
            //record.DownloadBy= PresData.DownloadBy;
            //record.UsageMethod= PresData.UsageMethod;
            //record.BackupField1= PresData.BackupField1;
            //record.BackupField2 = PresData.BackupField2;
            //record.BackupField3 = PresData.BackupField3;

          
        }

        public PrescriptionPrintModel GetPrescriptionPrintModel(DataPrescriptionTB preInfo)
        {
            //PrescriptionAdjustmentBLL prescriptionAdjustmentBLL = new PrescriptionAdjustmentBLL();
            //var preData = prescriptionAdjustmentBLL.GetPrescriptionByCode(PreId);
            //if (preData == null || preData.PrescriptionInfo==null)
            //{
            //    return null;
            //}
            
            //var preInfo=preData.PrescriptionInfo;
            
            PrescriptionPrintModel prescriptionPrintModel = new PrescriptionPrintModel();
            if (preInfo != null)
            {
                prescriptionPrintModel.PrescriptionID = preInfo.PrescriptionID;
                prescriptionPrintModel.PatientName = preInfo.PatientName;
                prescriptionPrintModel.PatientSex = preInfo.PatientSex.ToString();
                prescriptionPrintModel.PatientAge = preInfo.PatientAge.ToString();
                prescriptionPrintModel.DoctorName = preInfo.DoctorName;
                prescriptionPrintModel.DepartmentName = preInfo.DepartmentName;
                prescriptionPrintModel.Quantity = preInfo.Quantity;
                prescriptionPrintModel.TaskFrequency = preInfo.TaskFrequency;
                prescriptionPrintModel.TotalPrice = preInfo.TotalPrice;
                prescriptionPrintModel.Remarks = preInfo.Remarks;
                prescriptionPrintModel.UsageMethod = preInfo.UsageMethod;
                prescriptionPrintModel.BedNumber = preInfo.BedNumber;
                prescriptionPrintModel.PrescriptionName = preInfo.PrescriptionName;
                string processStatusText = preInfo.ProcessStatus.ToString();

                if (!string.IsNullOrEmpty(processStatusText) && processStatusText == "完成")
                {
                    prescriptionPrintModel.PreDateTime = DateTime.Now;
                }
                else
                {
                    prescriptionPrintModel.PreDateTime = preInfo.CreateTime;
                }

                if (preInfo.ParticlesDetail != null && preInfo.ParticlesDetail.Count > 0)
                {
                    List<PrintDetailModel>  printDetails = new List<PrintDetailModel>();
                    foreach (DetailStructure detail in preInfo.ParticlesDetail)
                    {
                        PrintDetailModel printDetailModel = new PrintDetailModel();
                        printDetailModel.ParCode = detail.ParticlesID.ToString();
                        string name =detail.ParticlesName.ToString();
                        printDetailModel.ParName = string.IsNullOrEmpty(name) ? detail.ParticlesNameHIS.ToString() : name;
                        printDetailModel.Dose = detail.Dose.ToString();
                        printDetailModel.DoseHerb = detail.DoseHerb.ToString();
                        printDetails.Add(printDetailModel);
                    }
                    prescriptionPrintModel.Details=printDetails;
                }
                else
                {
                    prescriptionPrintModel.Details = null;
                }
            }
            

            
            return prescriptionPrintModel;
        }
        private double PresVolume(DataPrescriptionTB PresData)     //返回处方总体积
        {
            try
            {
                double TotalVolume = 0.0f;
                foreach (DataPrescriptionTB.DetailStructure List in PresData.ParticlesDetail)
                {
                    if (ParticlesParamCheck(List))
                    {
                        //int did= (List.CabinetParticles.ParticlesID >> 20) > 0 ? (Convert.ToInt32(List.CabinetParticles.ParticlesID) & 0xFFFFF) : List.CabinetParticles.ParticlesID;
                        //var currentPar = pars.FirstOrDefault(x => x.ParticlesID == did);
                        //if (currentPar==null) 
                        //{
                        //    return -1.1f;
                        //}
                        float Density = (float)Math.Floor((List.DensityCoefficient * List.Density) * 1000) / 1000;
                        if (!ConfigTB.AdjustWay)//调剂方式选择
                        {
                            TotalVolume += (List.Dose / Density);//颗粒计量/颗粒密度
                                                                 // TotalVolume += (List.Dose / (List.Density * List.DensityCoefficient));//颗粒计量/颗粒密度
                        }
                        else
                        {
                            TotalVolume += ((List.DoseHerb / List.Equivalent) / Density);//（饮片计量/当量）/颗粒密度
                                                                                         //  TotalVolume += ((List.DoseHerb / List.Equivalent) / (List.Density * List.DensityCoefficient));//（饮片计量/当量）/颗粒密度
                        }
                    }
                    else
                    {
                        return -1.1f;
                    }
                }
                if (TotalVolume > int.MaxValue)
                {
                    return -1.1f;
                }
                return TotalVolume * PresData.Quantity; //总体积,单位:ml
            }
            catch (Exception ex)
            {
                uipage.ShowErrorDialog("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:5003");
                return -1;
            }
        }
        /// <summary>
        /// 处方加工厂
        /// </summary>
        /// <param name="Prescription">源处方</param>
        /// <param name="SelectNumber">一付调剂格数</param>
        /// <param name="TaskFrequency">分服次数</param>
        /// <returns>新拆分处方</returns>
        public DataPrescriptionTB PrescriptionHandles(DataPrescriptionTB Prescription)
        {
            try
            {
                StringBuilder ErrorOut = new StringBuilder("");
                if (!DataCheck(Prescription)) { return null; }  //检查基本参数有效性                         
                double TotalV = this.PresVolume(Prescription); //获取该处方总体积
                if (TotalV <= 0)
                {
                    uipage.ShowErrorDialog("检测到数据异常溢出,将终止此处方调剂,请检该处方中颗粒剂量,密度,当量参数是否有为零的.", "提示");
                    return null;
                }
                DataPrescriptionTB NewPrescription = new DataPrescriptionTB();   //新处方主表
                List<DataPrescriptionTB.DetailStructure> DetailList = new List<DataPrescriptionTB.DetailStructure>();     //新处方明细表
                int CalculateCellNumber = Prescription.TaskFrequency * Prescription.Quantity;//理论总格数=分付次数*付数                                                                                            
                if (TotalV >= BoxCellVolume * CalculateCellNumber)
                {

                    if (uipage.ShowAskDialog2("请确认是否拆分，单袋需要体积<" + Math.Round((double)(TotalV / CalculateCellNumber), 1).ToString() + ">，设定单袋体积<" + BoxCellVolume.ToString() + ">"))
                    {
                        while (true)
                        {
                            if ((CalculateCellNumber % this.LidHoleNumber == 0) && (TotalV <= BoxCellVolume * CalculateCellNumber) && (CalculateCellNumber % (Prescription.TaskFrequency * Prescription.Quantity) == 0))
                            {
                                break;
                            }
                            else
                            {
                                CalculateCellNumber += 1;
                            }
                        }
                        OperateLog.WriteLog(LogTypeEnum.用户操作, SysLoginUser._currentUser.UserName+ "确认拆分处方");
                    }
                }
                else
                {
                    if (CalculateCellNumber % this.LidHoleNumber != 0)
                    {
                        CalculateCellNumber += 1;
                        NewPrescription.Oddsate = true;
                    }
                    else
                    {
                        NewPrescription.Oddsate = false;
                    }
                }
                if (CalculateCellNumber % this.LidHoleNumber != 0)  //判断处方格数合法性
                {
                    uipage.ShowErrorDialog("当前处方不符合" + this.LidHoleNumber + "分药盒/袋调剂,余<" + CalculateCellNumber % this.LidHoleNumber + ">.", "错误");
                    return null;
                }
                foreach (DataPrescriptionTB.DetailStructure Det in Prescription.ParticlesDetail)
                {
                    DataPrescriptionTB.DetailStructure Detail = new DataPrescriptionTB.DetailStructure();
                    CabinetStorageInfoTB CabinetParticles = new CabinetStorageInfoTB();
                    if (Det.Dose < this.DoseLimitDown)  //如果小于最小底限量即取默认值
                    {
                        Detail.NewDose = this.DoseLimitDefaultValue;
                    }
                    else
                    {
                        if (!NewPrescription.Oddsate)
                        {
                            //拆分 或 偶数时计算计量
                            Detail.NewDose = Convert.ToDouble(Math.Round(((Det.Dose * Prescription.Quantity) / CalculateCellNumber), 2));//根据格数平均剂量
                        }
                        else
                        {
                            //奇数计算计量
                            Detail.NewDose = Convert.ToDouble(Math.Round((Det.Dose / Prescription.TaskFrequency), 2));
                        }
                    }
                    CabinetParticles = CabinetParticles.GetCabinetStorageInfo(Det.RFID.Value);

                    if (CabinetParticles != null)
                    {
                        Detail.CabinetParticles = Det.CabinetParticles;
                    }
                    else
                    {
                        ErrorOut.AppendLine("【" + Prescription.PatientName + "】的处方中,颗粒:【" + Det.ParticlesName + "】编号:【" + Det.ParticlesID + "】未注册上架,因此无法处理此处方!");
                    }
                    Detail.PrescriptionID = Det.PrescriptionID;
                    Detail.Density = Det.Density;
                    Detail.Dose = Det.Dose;
                    Detail.DoseHerb = Det.DoseHerb;
                    Detail.DensityCoefficient = Det.DensityCoefficient;
                    Detail.DoseLimit = Det.DoseLimit;
                    Detail.Equivalent = Det.Equivalent;
                    Detail.ParticlesID = Det.ParticlesID;
                    Detail.ParticlesNameHIS = Det.ParticlesNameHIS;
                    Detail.BatchNumber = Det.BatchNumber;
                    Detail.ParticlesName = Det.ParticlesName;
                    Detail.ParticlesCodeHIS = Det.ParticlesCodeHIS;
                    Detail.ParticleOrder = Det.ParticleOrder;
                    Detail.Price = Det.Price;
                    DetailList.Add(Detail);
                }
                if (ErrorOut.ToString() != "")
                {
                    uipage.ShowErrorDialog(ErrorOut.ToString(), "提示");
                    return null;
                }
                string BOX = PrintConfigTB.Box;

                NewPrescription.BoxNumber = CalculateCellNumber / this.LidHoleNumber; //计算总盒数;

                NewPrescription.BreakNumber = CalculateCellNumber / (Prescription.Quantity * Prescription.TaskFrequency) - 1;    //计算拆分次数
                NewPrescription.PrescriptionType = Prescription.PrescriptionType;
                NewPrescription.CreateTime = Prescription.CreateTime;
                NewPrescription.CreateName = Prescription.CreateName;
                NewPrescription.DepartmentName = Prescription.DepartmentName;
                NewPrescription.DetailedCount = Prescription.DetailedCount;
                NewPrescription.DoctorName = Prescription.DoctorName;
                NewPrescription.PatientAge = Prescription.PatientAge;
                NewPrescription.PatientBirthMonth = Prescription.PatientBirthMonth;
                NewPrescription.PatientName = Prescription.PatientName;
                NewPrescription.PatientSex = Prescription.PatientSex;
                NewPrescription.PatientTel = Prescription.PatientTel;
                NewPrescription.RegisterID = Prescription.RegisterID;
                NewPrescription.PaymentType = Prescription.PaymentType;
                NewPrescription.PrescriptionID = Prescription.PrescriptionID;
                NewPrescription.UnitPrice = Prescription.UnitPrice;
                NewPrescription.PrescriptionSource = Prescription.PrescriptionSource;
                NewPrescription.TotalPrice = Prescription.TotalPrice;
                NewPrescription.ProcessStatus = Prescription.ProcessStatus;
                NewPrescription.ImportTime = Prescription.ImportTime;
                NewPrescription.TaskFrequency = Prescription.TaskFrequency;
                NewPrescription.ValuationTime = Prescription.ValuationTime;
                NewPrescription.RegisterID = Prescription.RegisterID;
                NewPrescription.ValuerName = Prescription.ValuerName;
                NewPrescription.ValueSn = Prescription.ValueSn;
                NewPrescription.ParticlesDetail = DetailList;
                NewPrescription.Remarks = Prescription.Remarks;   //备注HISimport
                NewPrescription.UsageMethod = Prescription.UsageMethod;
                NewPrescription.GenerateUseWay = "" + PrintConfigTB.GenerateUsageMethodPrefix.Trim() + "每日" + Prescription.TaskFrequency.ToString() + "" + "次;每次1" + BOX + "";
                NewPrescription.Quantity = Prescription.Quantity;    //处方付数   
                //NewPrescription.PresLogObj = Prescription.PresLogObj;
                NewPrescription.GenerateUseWay1 = "" + PrintConfigTB.GenerateUsageMethodPrefix.Trim() + "每日" + Prescription.TaskFrequency.ToString() + "" + "次;每次1" + BOX + "";
                NewPrescription.BackupField1 = Prescription.BackupField1;
                NewPrescription.BackupField2 = Prescription.BackupField2;
                NewPrescription.BackupField3 = Prescription.BackupField3;
                NewPrescription.Writetime = Prescription.Writetime;
                return NewPrescription;
            }
            catch (Exception ex)
            {
                uipage.ShowErrorDialog("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:5004");
                return null;
            }
        }
        ///写累计误差日志
        /// <returns>成功=true,失败=false</returns> 
        //public bool WriteParticlesLog(int DeviceID, int UserID, DataPrescriptionTB.DetailStructure PrescriptionDetail)
        //{
        //    try
        //    {
        //        if (PrescriptionDetail.ParticlesID != 0)
        //        {
        //            MedicineCabinetOperationLogInfo parLog = new MedicineCabinetOperationLogInfo();
        //            //写扣除日志信息
        //            //float MinusWeight = (float)(Math.Round((item.Dose * PresData.Quantity), 3) - DeWeight);    //扣除量=(颗粒剂量)*(处方付数)-之前扣除的下药量   
        //            //float BTotalUsedAmount = (float)((DeWeight / (item.Dose * PresData.Quantity)) * item.MedicineCabinetDetail.CurentAdjustAmount);
        //            parLog.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
        //            parLog.MedicineCabinetCode = SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
        //            parLog.CreateTime = DateTime.Now;
        //            parLog.ParticleCode = PrescriptionDetail.ParticlesID;
        //            parLog.ParticleId = (int)PrescriptionDetail?.RFID;
        //            parLog.ParticleName = PrescriptionDetail.ParticlesName + (int)PrescriptionDetail?.RFID % 10000;
        //            parLog.InitialQuantity = PrescriptionDetail.CabinetParticles.ParticlesStockQuantity;
        //            parLog.CurrentWeightQuantity = (float)PrescriptionDetail.CurrentWeight;
        //            parLog.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.调剂药品;
        //            parLog.UsedQuantity = 0;
        //            parLog.AddQuantity = 0;
        //            parLog.AdjustmentQuantity = 0;
        //            parLog.OperationLogDecribe = "[正常调剂]执行批号(" + PrescriptionDetail.BatchNumber + ")";
                    

        //            //ParticlesLogTB ParTB = new ParticlesLogTB();
        //            //bool ExecuteResult = false;
        //            ////写日志操作

        //            //ParTB.CreateTime = DateTime.Now;
        //            //ParTB.ParticlesID = PrescriptionDetail.ParticlesID;
        //            //ParTB.ParticlesName = PrescriptionDetail.ParticlesName;
        //            //ParTB.OperationType = 3;
        //            //ParTB.InitialQuantity = PrescriptionDetail.CabinetParticles.ParticlesStockQuantity;
        //            //ParTB.CurrentWeight = PrescriptionDetail.CurrentWeight;
        //            //ParTB.UsageAmount = 0;  //使用量=(颗粒剂量)*(处方付数)
        //            //ParTB.UpCharge = 0;
        //            //ParTB.AdjustmentAmount = 0;
        //            //ParTB.DeviceID = DeviceID;
        //            //ParTB.UserID = UserID;
        //            //ParTB.Explain = "[正常调剂]执行批号(" + PrescriptionDetail.BatchNumber + ")";
        //            //ExecuteResult = ParTB.Insert();
        //            //if (ExecuteResult)
        //            //{
        //            //    return true;
        //            //}
        //            //else
        //            //{
        //            //    uipage.ShowErrorDialog("写入颗粒日志失败!", "提示");
        //            //    return false;
        //            //}
        //        }

        //        else
        //        {
        //            uipage.ShowErrorDialog("写颗粒日志时无处方数据!", "警告");
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        uipage.ShowErrorDialog("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:5005");
        //        return false;
        //    }
        //}

        /// <summary>
        /// 扣除下药完成颗粒的库存
        /// </summary>  
        public bool DeductStock(int rfid, DataPrescriptionTB PresData, double DeWeight)
        {
            List<MedicineCabinetOperationLogInfo> parLogs = new List<MedicineCabinetOperationLogInfo>();
     
            bool isTrue=false;
            PresData.ParticlesDetail.ForEach(item =>
            {
                if (item.RFID == rfid)
                {
                    MedicineCabinetOperationLogInfo parLog = new MedicineCabinetOperationLogInfo();
                    //写扣除日志信息
                    float MinusWeight = (float)(Math.Round((item.Dose * PresData.Quantity), 3) - DeWeight);    //扣除量=(颗粒剂量)*(处方付数)-之前扣除的下药量   
                    float BTotalUsedAmount = (float)Math.Round((DeWeight / (item.Dose * PresData.Quantity)) * (item.CabinetParticles.OnyTotalAmountUse), 2);
                    parLog.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
                    parLog.MedicineCabinetCode = SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
                    parLog.CreateTime = DateTime.Now;
                    parLog.ParticleCode = item.ParticlesID;
                    parLog.ParticleId = (int)item?.RFID;
                    parLog.ParticleName = item.ParticlesName + (int)item?.RFID % 10000;
                    parLog.InitialQuantity = (float)item?.CabinetParticles?.ParticlesStockQuantity;
                    parLog.CurrentWeightQuantity = (float)item?.CurrentWeight;
                    parLog.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.调剂药品;
                    parLog.UsedQuantity = MinusWeight;
                    parLog.AddQuantity = 0;
                    parLog.AdjustmentQuantity = (float)(item.CabinetParticles.OnyTotalAmountUse - BTotalUsedAmount);
                    parLog.OperationLogDecribe = item.Explain + "处方编号：" + item.PrescriptionID;
                    parLogs.Add(parLog);

                    item.CabinetParticles.OnyTotalAmountUse = item.CabinetParticles.OnyTotalAmountUse - (float)BTotalUsedAmount;
                    item.CabinetParticles.TotalAmountUse = (float)MinusWeight;
                    item.CabinetParticles.InPosition = (int)item.CurrentWeight;
                    item.CabinetParticles.ParticlesID = item.ParticlesID;
                    //item.CabinetParticles.ParticlesStockQuantity = item.MedicineCabinetDetail.Stock - MinusWeight;
                    //item.CabinetParticles.OnyTotalAmountUse = (float)BTotalUsedAmount;
                    //item.MedicineCabinetDetail.BottleHeadAdjustAmount = item.MedicineCabinetDetail.BottleHeadAdjustAmount + (float)BTotalUsedAmount;
                    //item.CabinetParticles.TotalAmountUse = MinusWeight;
                    //扣除库存
                    var result = _prescriptionAdjustmentBLL.AddMedicineCabinetOperationLogInfos(parLogs);
                    if (result != "")
                    {
                        OperateLog.WriteLog(LogTypeEnum.处方调剂, parLog.ParticleName + "记录扣除库存日志失败!");
                        uipage.ShowErrorDialog(parLog.ParticleName + "记录扣除库存日志失败!", "提示");
                        return;
                    }

                    if (item.CabinetParticles.MinusMargin(item.Dose * PresData.Quantity - DeWeight))
                    {
                        OperateLog.WriteLog(LogTypeEnum.处方调剂, parLog.ParticleName + "扣除库存失败!");
                        uipage.ShowErrorDialog(parLog.ParticleName + "扣除库存失败!", "提示");
                        return;
                    }

                    isTrue = true;
                    return;
                }
            });
            
            return isTrue;
        }

        /// <summary>
        /// 扣除下药完成颗粒的库存
        /// </summary>
        /// <param name="particlesID"></param>
        /// <param name="cabientID"></param>
        /// <param name="Amount"></param>
        /// <returns></returns>
        //public bool DeductStock(int DeviceID, int particlesID, int UserID, DataPrescriptionTB PresData, double DeWeight)
        //{
        //    try
        //    {
        //        if (PresData != null)
        //        {

        //            ParticlesLogTB ParTB = new ParticlesLogTB();
        //            foreach (DAL.DataPrescriptionTB.DetailStructure item in PresData.ParticlesDetail)
        //            {
        //                if (item.ParticlesID == particlesID)
        //                {
        //                    //写扣除日志信息
        //                    double MinusWeight = Math.Round((item.Dose * PresData.Quantity), 3) - DeWeight;    //扣除量=(颗粒剂量)*(处方付数)-之前扣除的下药量   
        //                    double BTotalAmountUse = Math.Round((DeWeight / (item.Dose * PresData.Quantity)) * (item.CabinetParticles.OnyTotalAmountUse), 2);
        //                    ParTB.CreateTime = DateTime.Now;
        //                    ParTB.ParticlesID = item.ParticlesID;
        //                    ParTB.ParticlesName = item.ParticlesName;
        //                    ParTB.InitialQuantity = item.CabinetParticles.ParticlesStockQuantity;
        //                    ParTB.CurrentWeight = item.CurrentWeight;
        //                    ParTB.OperationType = 2;
        //                    ParTB.UsageAmount = Math.Round((MinusWeight), 2);
        //                    ParTB.UpCharge = 0;
        //                    ParTB.AdjustmentAmount = item.CabinetParticles.OnyTotalAmountUse - BTotalAmountUse;
        //                    ParTB.DeviceID = DeviceID;
        //                    ParTB.UserID = UserID;
        //                    ParTB.Explain = item.Explain + "处方编号：" + item.PrescriptionID;
        //                    item.CabinetParticles.OnyTotalAmountUse = item.CabinetParticles.OnyTotalAmountUse - (float)BTotalAmountUse;
        //                    item.CabinetParticles.TotalAmountUse = (float)MinusWeight;
        //                    item.CabinetParticles.InPosition = (int)item.CurrentWeight;
        //                    item.CabinetParticles.ParticlesID = item.ParticlesID;
        //                    //扣除库存

        //                    if (!item.CabinetParticles.MinusMargin(item.Dose * PresData.Quantity - DeWeight))
        //                    {
        //                        uipage.ShowErrorDialog("扣除库存失败!", "提示");
        //                        return false;
        //                    }
        //                    if (!ParTB.Insert())
        //                    {
        //                        uipage.ShowErrorDialog("写入颗粒日志失败!", "提示");
        //                        return false;
        //                    }
        //                    return true;
        //                }

        //            }
        //            uipage.ShowErrorDialog("处方无颗粒：" + particlesID.ToString() + "的信息", "提示");
        //            return false;
        //        }
        //        else
        //        {
        //            uipage.ShowErrorDialog("无处方数据", "提示");
        //            return false;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        uipage.ShowErrorDialog("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:5005");
        //        return false;
        //    }
        //}


        /// <summary>
        /// 扣除下药完成颗粒的库存
        /// </summary>  
        public bool DeductStockStep(int rfid, DataPrescriptionTB PresData, double DeWeight)
        {
            List<MedicineCabinetOperationLogInfo> parLogs = new List<MedicineCabinetOperationLogInfo>();

            bool isTrue = false;
            PresData.ParticlesDetail.ForEach(item =>
            {
                if (item.RFID == rfid)
                {
                    MedicineCabinetOperationLogInfo parLog = new MedicineCabinetOperationLogInfo();
                    //写扣除日志信息
                    float MinusWeight = (float)DeWeight;    //扣除量=(颗粒剂量)*(处方付数)     
                    float BTotalUsedAmount = (float)Math.Round((DeWeight / (item.Dose * PresData.Quantity)) * (item.CabinetParticles.OnyTotalAmountUse), 2);
                    parLog.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
                    parLog.MedicineCabinetCode = SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
                    parLog.CreateTime = DateTime.Now;
                    parLog.ParticleCode = item.ParticlesID;
                    parLog.ParticleId = (int)item?.RFID;
                    parLog.ParticleName = item.ParticlesName + (int)item?.RFID % 10000;
                    parLog.InitialQuantity = (float)item?.CabinetParticles?.ParticlesStockQuantity;
                    parLog.CurrentWeightQuantity = (float)item?.CurrentWeight;
                    parLog.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.调剂药品;
                    parLog.UsedQuantity = MinusWeight;
                    parLog.AddQuantity = 0;
                    parLog.AdjustmentQuantity = BTotalUsedAmount;
                    parLog.OperationLogDecribe = item.Explain + "处方编号：" + item.PrescriptionID;
                    parLogs.Add(parLog);

                    item.CabinetParticles.OnyTotalAmountUse = item.CabinetParticles.OnyTotalAmountUse - (float)BTotalUsedAmount;
                    item.CabinetParticles.TotalAmountUse = (float)MinusWeight;
                    item.CabinetParticles.InPosition = (int)item.CurrentWeight;
                    item.CabinetParticles.ParticlesID = item.ParticlesID;
                    //item.CabinetParticles.ParticlesStockQuantity = item.MedicineCabinetDetail.Stock - MinusWeight;
                    //item.CabinetParticles.OnyTotalAmountUse = (float)BTotalUsedAmount;
                    //item.MedicineCabinetDetail.BottleHeadAdjustAmount = item.MedicineCabinetDetail.BottleHeadAdjustAmount + (float)BTotalUsedAmount;
                    //item.CabinetParticles.TotalAmountUse = MinusWeight;
                    //扣除库存
                    var result = _prescriptionAdjustmentBLL.AddMedicineCabinetOperationLogInfos(parLogs);
                    if (result != "")
                    {
                        OperateLog.WriteLog(LogTypeEnum.处方调剂, parLog.ParticleName + "记录扣除库存日志失败!");
                        uipage.ShowErrorDialog(parLog.ParticleName + "记录扣除库存日志失败!", "提示");
                        return;
                    }

                    if (item.CabinetParticles.MinusMargin(item.Dose * PresData.Quantity - DeWeight))
                    {
                        OperateLog.WriteLog(LogTypeEnum.处方调剂, parLog.ParticleName + "扣除库存失败!");
                        uipage.ShowErrorDialog(parLog.ParticleName + "扣除库存失败!", "提示");
                        return;
                    }

                    isTrue = true;
                    return;
                }
            });

            return isTrue;
        }

        /// <summary>
        /// 提前扣除部分库存
        /// </summary>
        /// <param name="particlesID"></param>
        /// <param name="cabientID"></param>
        /// <param name="Amount"></param>
        /// <returns></returns>
        //public bool DeductStockStep(int DeviceID, int particlesID, int UserID, DataPrescriptionTB PresData, double DeWeight)
        //{
        //    try
        //    {
        //        if (PresData != null)
        //        {

        //            ParticlesLogTB ParTB = new ParticlesLogTB();
        //            foreach (DAL.DataPrescriptionTB.DetailStructure item in PresData.ParticlesDetail)
        //            {
        //                if (item.ParticlesID == particlesID)
        //                {

        //                    //写扣除日志信息
        //                    double MinusWeight = DeWeight;    //扣除量=(颗粒剂量)*(处方付数)    
        //                    double BTotalAmountUse = Math.Round((DeWeight / (item.Dose * PresData.Quantity)) * (item.CabinetParticles.OnyTotalAmountUse), 2);
        //                    ParTB.CreateTime = DateTime.Now;
        //                    ParTB.ParticlesID = item.ParticlesID;
        //                    ParTB.ParticlesName = item.ParticlesName;
        //                    ParTB.InitialQuantity = item.CabinetParticles.ParticlesStockQuantity;
        //                    ParTB.CurrentWeight = item.CurrentWeight;
        //                    ParTB.OperationType = 2;
        //                    ParTB.UsageAmount = Math.Round((MinusWeight), 2);
        //                    ParTB.UpCharge = 0;
        //                    ParTB.AdjustmentAmount = BTotalAmountUse;
        //                    ParTB.DeviceID = DeviceID;
        //                    ParTB.UserID = UserID;
        //                    ParTB.Explain = item.Explain + "处方编号：" + item.PrescriptionID;
        //                    item.CabinetParticles.OnyTotalAmountUse = (float)BTotalAmountUse;
        //                    item.CabinetParticles.TotalAmountUse = (float)MinusWeight;
        //                    item.CabinetParticles.InPosition = (int)item.CurrentWeight;
        //                    item.CabinetParticles.ParticlesID = item.ParticlesID;
        //                    //扣除库存

        //                    if (!item.CabinetParticles.MinusMargin(DeWeight))
        //                    {
        //                        uipage.ShowErrorDialog("扣除库存失败!", "提示");
        //                        return false;
        //                    }
        //                    if (!ParTB.Insert())
        //                    {
        //                        uipage.ShowErrorDialog("写入颗粒日志失败!", "提示");
        //                        return false;
        //                    }

        //                    return true;
        //                }

        //            }
        //            uipage.ShowErrorDialog("处方无颗粒：" + particlesID.ToString() + "的信息", "提示");
        //            return false;
        //        }
        //        else
        //        {
        //            uipage.ShowErrorDialog("无处方数据", "提示");
        //            return false;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        uipage.ShowErrorDialog("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:5005");
        //        return false;
        //    }
        //}

        /// <summary>
        /// 设置完成扣除记录
        /// </summary>
        /// <param name="particlesID"></param>
        /// <param name="cabientID"></param>
        /// <param name="Amount"></param>
        /// <returns></returns>
        public bool setStockStep(int rfid, DataPrescriptionTB PresData)
        {
            try
            {
                bool isTrue = false;
                if (PresData != null)
                {
                    List<MedicineCabinetOperationLogInfo> parLogs = new List<MedicineCabinetOperationLogInfo>();
                    PresData.ParticlesDetail.ForEach(item =>
                    {
                        if (item.RFID == rfid)
                        {
                            MedicineCabinetOperationLogInfo parLog = new MedicineCabinetOperationLogInfo();
                            parLog.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
                            parLog.MedicineCabinetCode = SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
                            parLog.CreateTime = DateTime.Now;
                            parLog.ParticleCode = item.ParticlesID;
                            parLog.ParticleId = (int)item?.RFID;
                            parLog.ParticleName = item.ParticlesName + (int)item?.RFID % 10000;
                            parLog.InitialQuantity = (float)item?.CabinetParticles.ParticlesStockQuantity;;
                            parLog.CurrentWeightQuantity = 0;
                            parLog.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.调剂药品;
                            parLog.UsedQuantity = 0;
                            parLog.AddQuantity = 0;
                            parLog.AdjustmentQuantity = 0;
                            parLog.OperationLogDecribe = item.Explain + "设置调剂完成,处方编号：" + item.PrescriptionID;
                            parLogs.Add(parLog);

                            var result = _prescriptionAdjustmentBLL.AddMedicineCabinetOperationLogInfos(parLogs);
                            if (result != "")
                            {
                                OperateLog.WriteLog(LogTypeEnum.处方调剂, parLog.ParticleName + "记录设置完成扣除记录日志失败!");
                                uipage.ShowErrorDialog(parLog.ParticleName + "记录设置完成扣除记录日志失败!", "提示");
                                return;
                            }
                            isTrue = true;
                            return;
                        }
                    });  
                }
                else
                {
                    uipage.ShowErrorDialog("无处方数据", "提示");
                }

                return isTrue;
            }
            catch (Exception ex)
            {
                uipage.ShowErrorDialog("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:5005");
                return false;
            }
        }


        public bool CheckParticlesDetail(ref DataPrescriptionTB.DetailStructure Detai)
        {
            if (Detai.CabinetParticles.TotalAmountUse == 0 && Detai.CabinetParticles.ParticlesStockQuantity - Detai.CurrentWeight > 10) //用量=0 ，误差量
            {
                if (uipage.ShowAskDialog("颗粒|" + Detai.ParticlesName + "|未倒入药瓶!, 是否设置到:" + Math.Round(Detai.CurrentWeight, 1).ToString()))
                {
                    double labAddWeight = Math.Round(Detai.CurrentWeight - Detai.CabinetParticles.ParticlesStockQuantity, 2);
                    //上药,在当前余量的基础上加量

                    if (Detai.CabinetParticles.AddMargin(labAddWeight))
                    {
                        MedicineCabinetOperationLogInfo parLog = new MedicineCabinetOperationLogInfo();
                        parLog.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
                        parLog.MedicineCabinetCode = SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
                        parLog.CreateTime = DateTime.Now;
                        parLog.ParticleCode = Detai.ParticlesID;
                        parLog.ParticleId = (int)Detai?.RFID;
                        parLog.ParticleName = Detai.ParticlesName + (int)Detai?.RFID % 10000;
                        parLog.InitialQuantity = (float)Detai?.CabinetParticles.ParticlesStockQuantity; ;
                        parLog.CurrentWeightQuantity = (float)Math.Round(Detai.CurrentWeight, 2);
                        parLog.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.异常上药;
                        parLog.UsedQuantity = 0;
                        parLog.AddQuantity = (float)labAddWeight;
                        parLog.AdjustmentQuantity = 0;
                        parLog.OperationLogDecribe = "异常上药(" + labAddWeight.ToString() + "g)";
             
                        var result = _prescriptionAdjustmentBLL.AddMedicineCabinetOperationLogInfos(new List<MedicineCabinetOperationLogInfo> { parLog });
                        if (result != "")
                        {
                            OperateLog.WriteLog(LogTypeEnum.处方调剂, parLog.ParticleName + "记录异常上药日志失败!");
                            uipage.ShowErrorDialog(parLog.ParticleName + "记录异常上药日志失败!", "提示");
                            return false;
                        }
                        Detai.CabinetParticles.ParticlesStockQuantity = (float)Detai.CurrentWeight;
                    }
                    else
                    {
                        uipage.ShowErrorDialog("异常上药失败!", "异常");
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            //设置当前状态已称重 并将计算步数
            if (Detai.CurrentWeight < Detai.Dose + 10)
            {

                uipage.ShowErrorDialog("颗粒" + Detai.ParticlesName + "当前重量已经不足以调剂一付药，无法进行调剂？", "警告");
                return false;

            }
            //判断称重量
            if (Detai.CurrentWeight < ConfigTB.DoseLimitDown)
            {
                uipage.ShowErrorDialog("颗粒" + Detai.ParticlesName + "当前重量已经低于设定下限值，无法进行调剂？", "警告");
                return false;
            }


            //确认上药量与实际倒入量一致
            if (Detai.CabinetParticles.TotalAmountUse == 0 && (Detai.CurrentWeight - Detai.CabinetParticles.ParticlesStockQuantity) > 10) //用量=0 ，误差量
            {
                if (uipage.ShowAskDialog("请确认上次上药量与实际倒入量是否一致, 是否在当前库存直接添加" + Math.Round((Detai.CurrentWeight - Detai.CabinetParticles.ParticlesStockQuantity), 1).ToString() + "g"))
                {
                    double labAddWeight = Math.Round(Detai.CurrentWeight - Detai.CabinetParticles.ParticlesStockQuantity, 2);

                    //上药,在当前余量的基础上加量

                    if (Detai.CabinetParticles.AddMargin(labAddWeight))
                    {
                        MedicineCabinetOperationLogInfo parLog = new MedicineCabinetOperationLogInfo();
                        parLog.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
                        parLog.MedicineCabinetCode = SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
                        parLog.CreateTime = DateTime.Now;
                        parLog.ParticleCode = Detai.ParticlesID;
                        parLog.ParticleId = (int)Detai?.RFID;
                        parLog.ParticleName = Detai.ParticlesName + (int)Detai?.RFID % 10000;
                        parLog.InitialQuantity = (float)Detai?.CabinetParticles.ParticlesStockQuantity; ;
                        parLog.CurrentWeightQuantity = (float)Math.Round(Detai.CurrentWeight, 2);
                        parLog.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.异常上药;
                        parLog.UsedQuantity = 0;
                        parLog.AddQuantity = (float)labAddWeight;
                        parLog.AdjustmentQuantity = 0;
                        parLog.OperationLogDecribe = "异常上药(" + labAddWeight.ToString() + "g)";

                        var result = _prescriptionAdjustmentBLL.AddMedicineCabinetOperationLogInfos(new List<MedicineCabinetOperationLogInfo> { parLog });
                        if (result != "")
                        {
                            OperateLog.WriteLog(LogTypeEnum.处方调剂, parLog.ParticleName + "记录异常上药日志失败!");
                            uipage.ShowErrorDialog(parLog.ParticleName + "记录异常上药日志失败!", "提示");
                            return false;
                        }
                        Detai.CabinetParticles.ParticlesStockQuantity = (float)Detai.CurrentWeight;
                    }
                    else
                    {
                        uipage.ShowErrorDialog("异常上药失败!", "异常");
                        return false;
                    }
                }

                else
                {
                    return false;
                }
            }
            if (Detai.CabinetParticles.TotalAmountUse == 0 && Math.Abs(Detai.CabinetParticles.ParticlesStockQuantity - Detai.CurrentWeight) > 2) //用量=0 ，误差量
            {
                double labAddWeight = Math.Round(Detai.CurrentWeight - Detai.CabinetParticles.ParticlesStockQuantity, 2);
                //上药,在当前余量的基础上加量

                if (Detai.CabinetParticles.AddMargin(labAddWeight))
                {
                    MedicineCabinetOperationLogInfo parLog = new MedicineCabinetOperationLogInfo();
                    parLog.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
                    parLog.MedicineCabinetCode = SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
                    parLog.CreateTime = DateTime.Now;
                    parLog.ParticleCode = Detai.ParticlesID;
                    parLog.ParticleId = (int)Detai?.RFID;
                    parLog.ParticleName = Detai.ParticlesName + (int)Detai?.RFID % 10000;
                    parLog.InitialQuantity = (float)Detai?.CabinetParticles.ParticlesStockQuantity; ;
                    parLog.CurrentWeightQuantity = (float)Math.Round(Detai.CurrentWeight, 2);
                    parLog.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.异常上药;
                    parLog.UsedQuantity = 0;
                    parLog.AddQuantity = (float)labAddWeight;
                    parLog.AdjustmentQuantity = 0;
                    parLog.OperationLogDecribe = "异常上药(" + labAddWeight.ToString() + "g)";

                    var result = _prescriptionAdjustmentBLL.AddMedicineCabinetOperationLogInfos(new List<MedicineCabinetOperationLogInfo> { parLog });
                    if (result != "")
                    {
                        OperateLog.WriteLog(LogTypeEnum.处方调剂, parLog.ParticleName + "记录异常上药日志失败!");
                        uipage.ShowErrorDialog(parLog.ParticleName + "记录异常上药日志失败!", "提示");
                        return false;
                    }

   
                    Detai.CabinetParticles.ParticlesStockQuantity = (float)Detai.CurrentWeight;
                }
            }
            //判断是否倒入颗粒未扫码
            if (Detai.CabinetParticles.TotalAmountUse != 0 && Detai.CurrentWeight > Detai.CabinetParticles.InPosition + 5 && Detai.CabinetParticles.InPosition != 0 && Math.Abs(Detai.CurrentWeight - Detai.CabinetParticles.ParticlesStockQuantity) > 2)
            {
                if (uipage.ShowAskDialog("检测到未进行扫码，直接倒入药的违规操作，点击确认（已知晓），上药未扫码：" + Math.Round((Detai.CurrentWeight - Detai.CabinetParticles.ParticlesStockQuantity), 1).ToString() + "g"))
                {
                    double labAddWeight = Math.Round(Detai.CurrentWeight - Detai.CabinetParticles.ParticlesStockQuantity, 2);
                    if (Detai.CabinetParticles.AddMargin(labAddWeight))
                    {
                        MedicineCabinetOperationLogInfo parLog = new MedicineCabinetOperationLogInfo();
                        parLog.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
                        parLog.MedicineCabinetCode = SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
                        parLog.CreateTime = DateTime.Now;
                        parLog.ParticleCode = Detai.ParticlesID;
                        parLog.ParticleId = (int)Detai?.RFID;
                        parLog.ParticleName = Detai.ParticlesName + (int)Detai?.RFID % 10000;
                        parLog.InitialQuantity = (float)Detai?.CabinetParticles.ParticlesStockQuantity; ;
                        parLog.CurrentWeightQuantity = (float)Math.Round(Detai.CurrentWeight, 2);
                        parLog.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.余量校准;
                        parLog.UsedQuantity = 0;
                        parLog.AddQuantity = (float)labAddWeight;
                        parLog.AdjustmentQuantity = 0;
                        parLog.OperationLogDecribe = "上药未扫码,余量设置到" + Math.Round(Detai.CurrentWeight, 2).ToString() + "g";

                        var result = _prescriptionAdjustmentBLL.AddMedicineCabinetOperationLogInfos(new List<MedicineCabinetOperationLogInfo> { parLog });
                        if (result != "")
                        {
                            OperateLog.WriteLog(LogTypeEnum.处方调剂, parLog.ParticleName + "上药未扫码,余量设置到" + Math.Round(Detai.CurrentWeight, 2).ToString() + "g"+"记日志失败!");
                            uipage.ShowErrorDialog(parLog.ParticleName + "记录上药日志失败!", "提示");
                            return false;
                        }

                    }
                    else
                    {
                        uipage.ShowErrorDialog("上药未扫码,余量设置失败!", "异常");
                        return false;
                    }
                    Detai.CabinetParticles.ParticlesStockQuantity = (float)Detai.CurrentWeight;
                }
                else
                {
                    return false;
                }

            }

            ///检查瓶头异常  或异常上药
            float AmountUse = Convert.ToSingle(Detai.CurrentWeight - Detai.CabinetParticles.ParticlesStockQuantity + Detai.CabinetParticles.LastTotalAmountUse);// 当前系数误差量=当前重量-库存量-瓶头累计调整量
            float XAmountUse = Convert.ToSingle(AmountUse - Detai.CabinetParticles.LastWeightTotalAmountUse); //当前系数误差量-上次系数误差量= 上次调剂系数误差量
            if (ConfigTB.Percentageerror == 0 || ConfigTB.Percentageerror > 0.99)
            {
                ConfigTB.Percentageerror = 0.5f;
            }
            if (Detai.CabinetParticles.TotalAmountUse != 0 && Math.Abs(XAmountUse) > 2 && Math.Round((double)(Detai.CabinetParticles.TotalAmountUse * ConfigTB.Percentageerror), 2) < Math.Abs(XAmountUse))
            {
                if (uipage.ShowAskDialog("检测到颗粒" + Detai.ParticlesName + "重量异常。是否进行异常上药？或瓶头异常？"))
                {
                    if (Math.Abs(XAmountUse) > 20)
                    {
                        double labAddWeight = Math.Round(Detai.CurrentWeight - Detai.CabinetParticles.ParticlesStockQuantity, 2);
                        if (Detai.CabinetParticles.AddMargin(labAddWeight))
                        {
                            MedicineCabinetOperationLogInfo parLog = new MedicineCabinetOperationLogInfo();
                            parLog.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
                            parLog.MedicineCabinetCode = SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
                            parLog.CreateTime = DateTime.Now;
                            parLog.ParticleCode = Detai.ParticlesID;
                            parLog.ParticleId = (int)Detai?.RFID;
                            parLog.ParticleName = Detai.ParticlesName + (int)Detai?.RFID % 10000;
                            parLog.InitialQuantity = (float)Detai?.CabinetParticles.ParticlesStockQuantity; ;
                            parLog.CurrentWeightQuantity = (float)Math.Round(Detai.CurrentWeight, 2);
                            parLog.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.重量异常;
                            parLog.UsedQuantity = 0;
                            parLog.AddQuantity = (float)labAddWeight;
                            parLog.AdjustmentQuantity = 0;
                            parLog.OperationLogDecribe = "检测到重量异常,余量设置到" + Math.Round(Detai.CurrentWeight, 2).ToString() + "g";

                            var result = _prescriptionAdjustmentBLL.AddMedicineCabinetOperationLogInfos(new List<MedicineCabinetOperationLogInfo> { parLog });
                            if (result != "")
                            {
                                OperateLog.WriteLog(LogTypeEnum.处方调剂, parLog.ParticleName + "检测到重量异常,余量设置到" + Math.Round(Detai.CurrentWeight, 2).ToString() + "g" + "记日志失败!");
                                uipage.ShowErrorDialog(parLog.ParticleName + "重量异常日志写入失败", "提示");
                                return false;
                            }        
                        }
                        else
                        {
                            uipage.ShowErrorDialog("检测到重量异常,余量设置失败!", "异常");
                            return false;
                        }
                        Detai.CabinetParticles.ParticlesStockQuantity = (float)Detai.CurrentWeight;
                    }
                    else
                    {
                        MedicineCabinetOperationLogInfo parLog = new MedicineCabinetOperationLogInfo();
                        parLog.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
                        parLog.MedicineCabinetCode = SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
                        parLog.CreateTime = DateTime.Now;
                        parLog.ParticleCode = Detai.ParticlesID;
                        parLog.ParticleId = (int)Detai?.RFID;
                        parLog.ParticleName = Detai.ParticlesName + (int)Detai?.RFID % 10000;
                        parLog.InitialQuantity = (float)Detai?.CabinetParticles.ParticlesStockQuantity; ;
                        parLog.CurrentWeightQuantity = (float)Math.Round(Detai.CurrentWeight, 2);
                        parLog.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.重量异常;
                        parLog.UsedQuantity = 0;
                        parLog.AddQuantity = 0;
                        parLog.AdjustmentQuantity = 0;
                        parLog.OperationLogDecribe = "重量异常,误差量" + XAmountUse.ToString() + "g";

                        var result = _prescriptionAdjustmentBLL.AddMedicineCabinetOperationLogInfos(new List<MedicineCabinetOperationLogInfo> { parLog });
                        if (result != "")
                        {
                            OperateLog.WriteLog(LogTypeEnum.处方调剂, parLog.ParticleName + "检测到重量异常,余量设置到" + Math.Round(Detai.CurrentWeight, 2).ToString() + "g" + "记日志失败!");
                            uipage.ShowErrorDialog(parLog.ParticleName + "重量异常日志写入失败", "提示");
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /////
        /////
        /////全自动扣库存
        //public bool ParticlesAuotHandles(int DeviceID, int UserID, DataPrescriptionTB PresData)
        //{
        //    try
        //    {

        //        if (PresData != null)
        //        {
        //            ParticlesLogTB ParTB = new ParticlesLogTB();
        //            foreach (DAL.DataPrescriptionTB.DetailStructure item in PresData.ParticlesDetail)
        //            {
        //                if (item.Deductstate) { continue; }
        //                string Top = (item.CabinetParticles.ParticlesID >> 20) == 0 ? "" : (item.CabinetParticles.ParticlesID >> 20).ToString();
        //                //写扣除日志信息
        //                double MinusWeight = Math.Round((item.Dose * PresData.Quantity), 3);    //扣除量=(颗粒剂量)*(处方付数)    
        //                ParTB.CreateTime = DateTime.Now;
        //                ParTB.ParticlesID = item.CabinetParticles.ParticlesID;
        //                ParTB.ParticlesName = item.ParticlesName + Top;
        //                ParTB.InitialQuantity = item.CabinetParticles.ParticlesStockQuantity;
        //                ParTB.OperationType = 2;
        //                ParTB.UsageAmount = Math.Round((MinusWeight), 2);
        //                ParTB.UpCharge = 0;
        //                ParTB.AdjustmentAmount = item.CabinetParticles.OnyTotalAmountUse;
        //                ParTB.DeviceID = item.CabinetParticles.CabinetID;
        //                ParTB.UserID = UserID;
        //                ParTB.Explain = item.Explain;
        //                //扣除库存
        //                if (!item.CabinetParticles.MinusMargin(item.Dose * PresData.Quantity))
        //                {
        //                    uipage.ShowErrorDialog("扣除库存失败!", "提示");
        //                    return false;
        //                }
        //                if (!ParTB.Insert())
        //                {
        //                    uipage.ShowErrorDialog("写入颗粒日志失败!", "提示");
        //                    return false;
        //                }

        //            }

        //            return true;
        //        }

        //        else
        //        {
        //            return false;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        uipage.ShowErrorDialog("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:5005");
        //        return false;
        //    }

        //}

        ///// <summary>
        ///// 全自动单个品种扣库存
        ///// </summary>
        ///// <param name="DeviceID"></param>
        ///// <param name="UserID"></param>
        ///// <param name="PresData"></param>
        ///// <returns></returns>
        //public bool sParticlesAuotHandles(int DeviceID, int UserID, int ParticlesID, DataPrescriptionTB PresData)
        //{
        //    try
        //    {
        //        if (PresData != null)
        //        {
        //            ParticlesLogTB ParTB = new ParticlesLogTB();
        //            foreach (DAL.DataPrescriptionTB.DetailStructure item in PresData.ParticlesDetail)
        //            {
        //                if (item.CabinetParticles.ParticlesID == ParticlesID)
        //                {
        //                    string Top = (item.CabinetParticles.ParticlesID >> 20) == 0 ? "" : (item.CabinetParticles.ParticlesID >> 20).ToString();
        //                    //写扣除日志信息
        //                    double MinusWeight = Math.Round((item.Dose * PresData.Quantity), 3);    //扣除量=(颗粒剂量)*(处方付数)    
        //                    ParTB.CreateTime = DateTime.Now;
        //                    ParTB.ParticlesID = item.CabinetParticles.ParticlesID;
        //                    ParTB.ParticlesName = item.ParticlesName + Top;
        //                    ParTB.InitialQuantity = item.CabinetParticles.ParticlesStockQuantity;
        //                    ParTB.OperationType = 2;
        //                    ParTB.UsageAmount = Convert.ToDouble(MinusWeight);
        //                    ParTB.UpCharge = 0;
        //                    ParTB.AdjustmentAmount = item.CabinetParticles.OnyTotalAmountUse;
        //                    ParTB.DeviceID = item.CabinetParticles.CabinetID;
        //                    ParTB.UserID = UserID;
        //                    ParTB.Explain = item.Explain + item.PrescriptionID;
        //                    //扣除库存
        //                    if (!item.CabinetParticles.MinusMargin(item.Dose * PresData.Quantity))
        //                    {
        //                        uipage.ShowErrorDialog("扣除库存失败!", "提示");
        //                        return false;
        //                    }
        //                    if (!ParTB.Insert())
        //                    {
        //                        uipage.ShowErrorDialog("写入颗粒日志失败!", "提示");
        //                        return false;
        //                    }
        //                }
        //            }
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        uipage.ShowErrorDialog("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:5005");
        //        return false;
        //    }
        //}
    }
}
