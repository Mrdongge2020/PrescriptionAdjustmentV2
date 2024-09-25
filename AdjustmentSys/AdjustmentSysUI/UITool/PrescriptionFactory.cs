using AdjustmentSys.Entity;
using AdjustmentSys.Models.FileModel;
using AdjustmentSys.Models.Prescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdjustmentSysUI.UITool
{
    public class PrescriptionFactory
    {
        /// <summary>
        /// 扣除下药完成颗粒的库存
        /// </summary>  
        public bool DeductStock(int DeviceID, int particlesID, int UserID, PreModel PresData, double DeWeight)
        {
            try
            {
                if (PresData != null)
                {

                    MedicineCabinetOperationLogInfo ParTB = new MedicineCabinetOperationLogInfo();
                    foreach (ConfirmLocalDataPrescriptionDetail item in PresData.Details)
                    {
                        if (item.ParticlesID == particlesID)
                        {
                            //写扣除日志信息
                            double MinusWeight = Math.Round((item.Dose * PresData.Quantity), 3) - DeWeight;    //扣除量=(颗粒剂量)*(处方付数)-之前扣除的下药量   
                            double BTotalAmountUse = Math.Round((DeWeight / (item.Dose * PresData.Quantity)) * (item.CabinetParticles.OnyTotalAmountUse), 2);
                            ParTB.CreateTime = DateTime.Now;
                            ParTB.ParticleCode = item.ParCode;
                            ParTB.ParticleId = item.RFID.Value;
                            ParTB.ParticleName = item.ParName+item.RFID%10000;
                            ParTB.InitialQuantity = item.sto;
                            ParTB.CurrentWeight = item.CurrentWeight;
                            ParTB.OperationType = 2;
                            ParTB.UsageAmount = Convert.ToDouble(MinusWeight);
                            ParTB.UpCharge = 0;
                            ParTB.AdjustmentAmount = item.CabinetParticles.OnyTotalAmountUse;
                            ParTB.DeviceID = DeviceID;
                            ParTB.UserID = UserID;
                            ParTB.Explain = item.Explain;
                            item.CabinetParticles.OnyTotalAmountUse = (float)BTotalAmountUse;
                            item.CabinetParticles.TotalAmountUse = (float)MinusWeight;
                            //扣除库存

                            if (!item.CabinetParticles.MinusMargin(item.Dose * PresData.Quantity - DeWeight))
                            {
                                MessageBox.Show("扣除库存失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            if (!ParTB.Insert())
                            {
                                MessageBox.Show("写入颗粒日志失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            return true;
                        }

                    }
                    MessageBox.Show("处方无颗粒：" + particlesID.ToString() + "的信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    MessageBox.Show("无处方数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:5005", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
