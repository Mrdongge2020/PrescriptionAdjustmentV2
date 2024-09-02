using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.SystemSetting;
using AdjustmentSys.DAL.Prescription;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.Prescription
{
    public class PrescriptionAdjustmentBLL
    {
        PrescriptionAdjustmentDAL _prescriptionAdjustmentDAL = new PrescriptionAdjustmentDAL();

        /// <summary>
        /// 获取已下载列表数据
        /// </summary>
        /// <param name="preIds">处方编号</param>
        /// <returns></returns>
        public List<DownLoadedPre> GetDownLoadedPres(List<string> preIds) 
        { 
            return _prescriptionAdjustmentDAL.GetDownLoadedPres(preIds);
        }

        /// <summary>
        /// 确认处方检查
        /// </summary>
        /// <param name="localDataPrescriptionInfo">处方信息</param>
        /// <param name="prescriptionDetails">处方详情信息</param>
        /// <param name="preIds">列表已确认的处方编号集合</param>
        /// <returns></returns>
        public List<CheckPrescriptionResultModel> CheckPrescription(LocalDataPrescriptionInfo localDataPrescriptionInfo, List<PrescriptionDetailModel> prescriptionDetails,List<string> preIds) 
        {
            List<CheckPrescriptionResultModel> errorList = new List<CheckPrescriptionResultModel>();
            CommonDataBLL commonDataBLL = new CommonDataBLL();
            //所有药柜数据获取
            var cabinetDetails = commonDataBLL.GetMedicineCabinetDetails(SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode);
            //获取处方集合中某些颗粒的使用量
            List<ParticUsedStockModel> particUsedStockModels=  _prescriptionAdjustmentDAL.GetParticUsedStocks(preIds, prescriptionDetails.Select(x => x.ParticlesID).Distinct().ToList());
            //颗粒相容性规则获取
            var rulerList = commonDataBLL.GetParticleProhibitionRules();
            //颗粒详情数据校验
            foreach (var item in prescriptionDetails)
            {
                #region 剂量上限校验
                if (item.Dose > item.DoseLimit)
                {
                    errorList.Add(new CheckPrescriptionResultModel { ErrorType = 1, ErrorMessage = $"颗粒[{item.ParName}]<{item.ParCode}>超出剂量上限({item.DoseLimit}g)!" });
                }

                #endregion

                #region 数据非法校验
                if (prescriptionDetails.Count(x => x.ParticlesID == item.ParticlesID) > 1)
                {
                    errorList.Add(new CheckPrescriptionResultModel { ErrorType = 4, ErrorMessage = $"颗粒[{item.ParName}]<{item.ParCode}>有重复!" });
                }
                if (item.DoseHerb <= 0 || item.Equivalent <= 0 || item.Dose <= 0)
                {
                    errorList.Add(new CheckPrescriptionResultModel { ErrorType = 4, ErrorMessage = $"颗粒[{item.ParName}]<{item.ParCode}>的饮片剂量,当量,颗粒剂量均不能为0!" });
                }

                //获取当前颗粒已确认处方使用量
                double usedAmount = 0;
                if (particUsedStockModels != null && particUsedStockModels.Any(x => x.ParticId == item.ParticlesID))
                {
                    usedAmount = particUsedStockModels.FirstOrDefault(x => x.ParticId == item.ParticlesID).UsedAmount;
                }

                var currentCabinetParticles = cabinetDetails.Where(x => x.RFID.ToString().EndsWith(item.ParticlesID.ToString())).OrderByDescending(x=>x.Stock).ToList();
                if (currentCabinetParticles == null || currentCabinetParticles.Count==0)
                {
                    errorList.Add(new CheckPrescriptionResultModel { ErrorType = 4, ErrorMessage = $"颗粒[{item.ParName}]<{item.ParCode}>的未在药柜上架!" });
                }
                else
                {
                    var maxStock= currentCabinetParticles.Max(x => x.Stock);
                    if (maxStock - item.Dose * localDataPrescriptionInfo.Quantity - usedAmount < 10) //一瓶最大库存不够
                    {
                        if (currentCabinetParticles.Count == 1)//只有一瓶，直接提示库存不足
                        {
                            errorList.Add(new CheckPrescriptionResultModel { ErrorType = 4, ErrorMessage = $"颗粒[{item.ParName}]<{item.ParCode}>再药柜上余量不足以再调剂此处方!" });
                            //单瓶不足密度系数校验
                            if (currentCabinetParticles[0].DensityCoefficient > 2 || currentCabinetParticles[0].DensityCoefficient < 0.5)
                            {
                                errorList.Add(new CheckPrescriptionResultModel { ErrorType = 4, ErrorMessage = $"颗粒[{item.ParName}]<{item.ParCode}>密度系数为<{currentCabinetParticles[0].DensityCoefficient}>超出限定范围(0.5~2),请重新测试密度值!" });
                            }
                        }
                        else //多瓶要拿最大库存前两瓶判断总和是否足够
                        {
                            maxStock = currentCabinetParticles[0].Stock + currentCabinetParticles[1].Stock;
                            if (maxStock - item.Dose * localDataPrescriptionInfo.Quantity - usedAmount < 20)
                            {
                                errorList.Add(new CheckPrescriptionResultModel { ErrorType = 4, ErrorMessage = $"颗粒[{item.ParName}]<{item.ParCode}>再药柜上余量不足以再调剂此处方!" });
                            }
                            //多瓶密度系数校验
                            if (currentCabinetParticles[0].DensityCoefficient > 2 || currentCabinetParticles[0].DensityCoefficient < 0.5 || currentCabinetParticles[1].DensityCoefficient > 2 || currentCabinetParticles[1].DensityCoefficient < 0.5)
                            {
                                errorList.Add(new CheckPrescriptionResultModel { ErrorType = 4, ErrorMessage = $"颗粒[{item.ParName}]库存最大两瓶的<{item.ParCode}>密度系数为<{currentCabinetParticles[0].DensityCoefficient}和{currentCabinetParticles[1].DensityCoefficient}>超出限定范围(0.5~2),请重新测试密度值!" });
                            }
                        }
                    }
                    else 
                    {
                        //单瓶充足密度系数校验
                        if (currentCabinetParticles[0].DensityCoefficient > 2 || currentCabinetParticles[0].DensityCoefficient < 0.5)
                        {
                            errorList.Add(new CheckPrescriptionResultModel { ErrorType = 4, ErrorMessage = $"颗粒[{item.ParName}]<{item.ParCode}>密度系数为<{currentCabinetParticles[0].DensityCoefficient}>超出限定范围(0.5~2),请重新测试密度值!" });
                        }
                    }
                    
                }
                #endregion

                #region 余量状态校验
                SystemParameterBLL systemParameterBLL   = new SystemParameterBLL();
                string yuliangxiaxian = CommonStaticDataBLL.GetSystemParameterValue("KeLiYuLiangXiaXian");
                float lomit = (yuliangxiaxian == "" || !float.TryParse(yuliangxiaxian, out float value1)) ? 10 : float.Parse(yuliangxiaxian);
                if (currentCabinetParticles != null &&  currentCabinetParticles.Count != 0)
                {
                    var maxStock = currentCabinetParticles.Max(x => x.Stock);
                    if (maxStock - item.Dose * localDataPrescriptionInfo.Quantity - usedAmount < lomit) //一瓶最大库存不够
                    {
                        if (currentCabinetParticles.Count == 1)//只有一瓶，直接提示库存不足
                        {
                            errorList.Add(new CheckPrescriptionResultModel { ErrorType = 2, ErrorMessage = $"颗粒[{item.ParName}]<{item.ParCode}>剩余量已低于设定下限值{lomit}!" });
                        }
                        else //多瓶要拿最大库存前两瓶判断总和是否足够
                        {
                            maxStock = currentCabinetParticles[0].Stock + currentCabinetParticles[1].Stock;
                            if (maxStock - item.Dose * localDataPrescriptionInfo.Quantity - usedAmount < lomit*2)
                            {
                                errorList.Add(new CheckPrescriptionResultModel { ErrorType = 2, ErrorMessage = $"颗粒[{item.ParName}]<{item.ParCode}>剩余量已低于设定下限值{lomit}!" });
                            }
                        }
                    }          
                }
                #endregion

                #region 颗粒相容性规则检查
                if (rulerList==null || rulerList.Count<=0) 
                {
                    continue;
                }
                foreach (var item1 in prescriptionDetails.Where(x=>x.ParticlesID!=item.ParticlesID).ToList())
                {
                    if (rulerList.Any(x=>(x.FirstParticlesID+x.SecondParticlesID)==(item.ParticlesID+item1.ParticlesID))) 
                    {
                        errorList.Add(new CheckPrescriptionResultModel { ErrorType = 3, ErrorMessage = $"颗粒[{item.ParName}]与[{item1.ParName}]违反了相容性规则!" });
                    }
                }
                #endregion
            }

            if (errorList==null || errorList.Count<=0)
            {
                return null;
            }
            return errorList.Distinct().ToList();
        }

        /// <summary>
        /// 根据给定的处方编号获取已核对的处方编号
        /// </summary>
        /// <param name="preIds">给定的处方编号</param>
        /// <returns></returns>
        public List<string> GetConfirmedPrescriptions(List<string> preIds) 
        { 
            return _prescriptionAdjustmentDAL.GetConfirmedPrescriptions(preIds);
        }
        /// <summary>
        /// 确认处方
        /// </summary>
        /// <param name="preId">处方编号</param>
        /// <returns></returns>
        public bool ConfirmPrescription(string preId)
        {
            return _prescriptionAdjustmentDAL.ConfirmPrescription(preId);
        }
        /// <summary>
        /// 修改本地处方状态
        /// </summary>
        public string UpdatePrescriptionStatus(List<string> prescriptionIds, ProcessStatusEnum status) 
        {
            return _prescriptionAdjustmentDAL.UpdatePrescriptionStatus(prescriptionIds,status);
        }

        /// <summary>
        /// 复位处方
        /// </summary>
        /// <param name="prescriptionId">处方编号</param>
        /// <returns></returns>
        public bool ReturnPrescription(string prescriptionId) 
        { 
            return _prescriptionAdjustmentDAL.ReturnPrescription(prescriptionId);
        }
    }
}
