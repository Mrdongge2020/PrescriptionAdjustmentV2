using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Machine
{
    public class Coefficient
    {
        // AmountUs 本次系数误差量
        public void NCorrectionFactor(ref DataPrescriptionTB.DetailStructure Detail, float Nowweight)
        {
            float AmountUse = Convert.ToSingle(Nowweight - Detail.CabinetParticles.ParticlesStockQuantity + Detail.CabinetParticles.LastTotalAmountUse);// 当前系数误差量=当前重量-库存量-瓶头累计调整量
            float XAmountUse = Convert.ToSingle(AmountUse - Detail.CabinetParticles.LastWeightTotalAmountUse); //误差量

            if (Detail.CabinetParticles.ParticlesStockQuantity == 0 || Nowweight < 10 || Detail.CabinetParticles.TotalAmountUse < 0.1)
            {
                return;
            }

            float TheMedicineAfterUse = Convert.ToSingle(Detail.CabinetParticles.TotalAmountUse);
            if (Math.Abs(XAmountUse) < 0.4 || Math.Abs(AmountUse) < 0.6)//误差>0.3克开始调整 反之不调整
            {
               // OperateLog.WriteLog(LogTypeEnum.处方调剂, Detail.ParticlesName, Detail.CabinetParticles.DensityCoefficient.ToString(), AmountUse.ToString(), TheMedicineAfterUse.ToString(), "不调整"); //写日志

                return;
            }
            float SourceDensityCoefficien = Convert.ToSingle(Detail.CabinetParticles.DensityCoefficient);
            float d = Math.Abs((float)(XAmountUse / Detail.CabinetParticles.TotalAmountUse)); //调整系数
            float l = 0;
            double DensityCoefficient; //密度系数;
            double DensityCoefficienadd; //密度系数增加量;
            //&& XAmountUse > AmountU(se
            if (d > 0.05f && Math.Abs(AmountUse) > Math.Abs(Detail.CabinetParticles.LastTotalAmountUse) && Detail.CabinetParticles.LastTotalAmountUse != 0)
            {
                l = 0.03f;
            }
            else
            {
                if (d >= 0.01f)
                {
                    l = 0.01f;
                }
                else
                {
                    l = d;
                }


            }
            DensityCoefficienadd = l * SourceDensityCoefficien;  //最新的密度系数=调整百分比*原始密度
            if (AmountUse - Detail.CabinetParticles.LastWeightTotalAmountUse < 0) //实际系数误差量多密度减小    反之密度增加
            {
                DensityCoefficient = Math.Round(SourceDensityCoefficien + Math.Abs(DensityCoefficienadd), 3);
            }
            else
            {
                DensityCoefficient = Math.Round(SourceDensityCoefficien - Math.Abs(DensityCoefficienadd), 3);
            }
            // //调整范围
            // if(Math.Abs(1 - DensityCoefficient)>0.2)
            // {
            //     if (MessageBox.Show("当前颗粒偏差较大,请重新测密度或更换瓶头!<" + DensityCoefficient.ToString() + ">,是否强制修改系数?", "重要提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //     {
            //         if( ( Math.Abs(1-DensityCoefficient)) < 0.3)
            //         {
            //         Detail.CabinetParticles.LastWeightTotalAmountUse = AmountUse;
            //         Detail.CabinetParticles.DensityCoefficient = Convert.ToSingle(DensityCoefficient);
            //         Detail.CabinetParticles.SetDensityCoefficient();
            //         OperateLog.Write_Adjustment(Detail.ParticlesName, DensityCoefficient.ToString(), XAmountUse.ToString(), TheMedicineAfterUse.ToString(), "强制调整"); //写日志

            //         }
            //         else
            //         {
            //         Detail.CabinetParticles.LastWeightTotalAmountUse = AmountUse;
            //         Detail.CabinetParticles.DensityCoefficient = Convert.ToSingle(DensityCoefficient);                   
            ////         this.SetDensity(Detail.ParticlesID, 0);
            //         Detail.CabinetParticles.SetDensityCoefficient();
            //         OperateLog.Write_Adjustment(Detail.ParticlesName, DensityCoefficient.ToString(), XAmountUse.ToString(), TheMedicineAfterUse.ToString(), "超出限定范围,强制不调整!"); //写日志
            //         MessageBox.Show("当前颗粒偏差较大,该品种参数已清零,请重新测密度!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //         }
            //     }
            //     else
            //     {
            //         OperateLog.Write_Adjustment(Detail.ParticlesName, DensityCoefficient.ToString(), XAmountUse.ToString(), TheMedicineAfterUse.ToString(), "超出后修改被取消"); //写日志
            //     }
            // }
            // else
            // {
            Detail.CabinetParticles.LastWeightTotalAmountUse = AmountUse;
            Detail.CabinetParticles.DensityCoefficient = Convert.ToSingle(DensityCoefficient);
            Detail.CabinetParticles.SetDensityCoefficient();
            OperateLog.WriteLog(LogTypeEnum.处方调剂,"颗粒["+Detail.ParticlesName+"]密度系数["+DensityCoefficient.ToString()+"]误差量["+ XAmountUse.ToString()+"]使用量["+TheMedicineAfterUse.ToString()+ "]正常调整"); //写日志               
                                                                                                                                                             // }
                                                                                                                                                             //    ParticlesDictionaries.GetData();    //刷新颗粒字典
        }
    }
}
