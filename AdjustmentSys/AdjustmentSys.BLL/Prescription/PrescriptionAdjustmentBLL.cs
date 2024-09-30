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
        public (List<CheckPrescriptionResultModel>, List<ConfirmLocalDataPrescriptionDetail>) CheckPrescription(LocalDataPrescriptionInfo localDataPrescriptionInfo, List<PrescriptionDetailModel> prescriptionDetails,List<string> preIds) 
        {
            List<CheckPrescriptionResultModel> errorList = new List<CheckPrescriptionResultModel>();
            CommonDataBLL commonDataBLL = new CommonDataBLL();
            //所有药柜数据获取
            var cabinetDetails = commonDataBLL.GetMedicineCabinetDetails(SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode);
            //获取处方集合中某些颗粒的使用量
            List<ParticUsedStockModel> particUsedStockModels=  _prescriptionAdjustmentDAL.GetParticUsedStocks(preIds, prescriptionDetails.Select(x => x.ParticlesID).Distinct().ToList());
            //颗粒相容性规则获取
            var rulerList = commonDataBLL.GetParticleProhibitionRules();
            //获取药品字段数据
            var particls = commonDataBLL.GetCommonParticles();
            //颗粒余量下限
            float ylxxNum = 0;
            var ylxxStr = CommonStaticDataBLL.GetSystemParameterValue("KeLiYuLiangXiaXian");
            if (!string.IsNullOrEmpty(ylxxStr))
            {
                ylxxNum = float.TryParse(ylxxStr, out float ylxx) ? ylxx : 0;
            }
            //颗粒详情数据校验
            List<ConfirmLocalDataPrescriptionDetail> details= new List<ConfirmLocalDataPrescriptionDetail>();
            int index = 1;
            foreach (var item in prescriptionDetails)
            {
                var currentPar = particls.FirstOrDefault(x => x.ID == item.ParticlesID);
                ConfirmLocalDataPrescriptionDetail localDetail = new ConfirmLocalDataPrescriptionDetail() 
                { 
                     ParticleOrder = index,
                     PrescriptionID= localDataPrescriptionInfo.PrescriptionID,
                     ParticlesID= item.ParticlesID,
                     ParName= item.ParName,
                     ParCode= item.ParCode,
                     ParticlesCodeHIS= item.ParticlesCodeHIS,
                     ParticlesNameHIS= item.ParticlesNameHIS,
                     BatchNumber= item.BatchNumber,
                     ValidityTime=item.ValidityTime,                   
                     Dose=item.Dose,
                     Equivalent=item.Equivalent,
                     DoseHerb = item.DoseHerb,
                     Price = item.Price,
                     Status= StationStatusEnum.待放入,
                     Density= currentPar==null? 0 : currentPar.Density,
                     DensityCoefficient= currentPar == null ? 0 : currentPar.DensityCoefficient,
                     DoseLimit= currentPar==null? 0 :currentPar.DoseLimit
                };
                index++;
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

                var currentCabinetParticles = cabinetDetails.Where(x => x.ParticlesID==item.ParticlesID).OrderByDescending(x=>x.Stock).ToList();
                if (currentCabinetParticles == null || currentCabinetParticles.Count==0)
                {
                    errorList.Add(new CheckPrescriptionResultModel { ErrorType = 4, ErrorMessage = $"颗粒[{item.ParName}]<{item.ParCode}>未在药柜上架!" });
                }
                else
                {
                    var maxStock= currentCabinetParticles.Max(x => x.Stock);
                    if (maxStock - item.Dose * localDataPrescriptionInfo.Quantity - usedAmount < ylxxNum) //一瓶最大库存不够
                    {
                        if (currentCabinetParticles.Count == 1)//只有一瓶，直接提示库存不足
                        {
                            localDetail.StationX = currentCabinetParticles[0].CoordinateX;
                            localDetail.StationY = currentCabinetParticles[0].CoordinateY;
                            localDetail.MedicineCabinetDetail = currentCabinetParticles[0];
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
                            if (maxStock - item.Dose * localDataPrescriptionInfo.Quantity - usedAmount < ylxxNum * 2)
                            {
                                errorList.Add(new CheckPrescriptionResultModel { ErrorType = 4, ErrorMessage = $"颗粒[{item.ParName}]<{item.ParCode}>在药柜上余量不足以再调剂此处方!" });
                            }
                            else 
                            {
                                localDetail.ParticlesID = (int)currentCabinetParticles[0].ParticlesID;
                                localDetail.StationX = currentCabinetParticles[0].CoordinateX;
                                localDetail.StationY = currentCabinetParticles[0].CoordinateY;
                                localDetail.Dose = (float)currentCabinetParticles[0].Stock - ylxxNum;
                                localDetail.DoseHerb = localDetail.Dose * localDetail.Equivalent;
                                localDetail.MedicineCabinetDetail = currentCabinetParticles[0];
                                ConfirmLocalDataPrescriptionDetail localDetail1 = new ConfirmLocalDataPrescriptionDetail()
                                {
                                    ParticleOrder = index,
                                    PrescriptionID = localDataPrescriptionInfo.PrescriptionID,
                                    ParticlesID = (int)currentCabinetParticles[1].ParticlesID,
                                    ParName = item.ParName,
                                    ParCode = item.ParCode,
                                    ParticlesCodeHIS = item.ParticlesCodeHIS,
                                    ParticlesNameHIS = item.ParticlesNameHIS,
                                    BatchNumber = currentCabinetParticles[1].BatchNumber,
                                    ValidityTime = currentCabinetParticles[1].ValidityTime.ToString(),
                                    Dose = item.Dose- localDetail.Dose,
                                    Equivalent = item.Equivalent,
                                    DoseHerb = item.DoseHerb=localDetail.DoseHerb,
                                    Price = item.Price,
                                    Status = StationStatusEnum.待放入,
                                    StationX = currentCabinetParticles[1].CoordinateX,
                                    StationY = currentCabinetParticles[1].CoordinateY,
                                    MedicineCabinetDetail = currentCabinetParticles[1],
                                    Density = currentPar == null ? 0 : currentPar.Density,
                                    DensityCoefficient = currentPar == null ? 0 : currentPar.DensityCoefficient,
                                    DoseLimit = currentPar == null ? 0 : currentPar.DoseLimit
                                };
                                details.Add(localDetail1);
                                index++;
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
                        localDetail.StationX = currentCabinetParticles[0].CoordinateX;
                        localDetail.StationY = currentCabinetParticles[0].CoordinateY;
                        localDetail.MedicineCabinetDetail = currentCabinetParticles[0];
                        //单瓶充足密度系数校验
                        if (currentCabinetParticles[0].DensityCoefficient > 2 || currentCabinetParticles[0].DensityCoefficient < 0.5)
                        {
                            errorList.Add(new CheckPrescriptionResultModel { ErrorType = 4, ErrorMessage = $"颗粒[{item.ParName}]<{item.ParCode}>密度系数为<{currentCabinetParticles[0].DensityCoefficient}>超出限定范围(0.5~2),请重新测试密度值!" });
                        }
                    }

                    details.Add(localDetail);
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
                return (null,details);
            }
            return (errorList.Distinct().ToList(),details);
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

        /// <summary>
        /// 获取待调剂处方
        /// </summary>
        /// <param name="prescriptionId">处方编号</param>
        /// <returns></returns>
        public PrescriptionAwaitingAdjustmentModel GetPrescriptionByCode(string prescriptionId) 
        {
            return _prescriptionAdjustmentDAL.GetPrescriptionByCode(prescriptionId);
        }

        /// <summary>
        /// 更新药柜信息,并写入日志
        /// </summary>
        /// <param name="medicines">药柜信息</param>
        /// <param name="medicineCabinetOperationLogInfos">日志信息</param>
        /// <returns></returns>
        public string UpdateMedicineAndLog(List<MedicineCabinetDetail> medicines, List<MedicineCabinetOperationLogInfo> medicineCabinetOperationLogInfos)
        {
            return _prescriptionAdjustmentDAL.UpdateMedicineAndLog(medicines, medicineCabinetOperationLogInfos);
        }

        /// <summary>
        /// 更新药柜信息
        /// </summary>
        /// <param name="medicine"></param>
        /// <returns></returns>
        public string UpdateMedicineCabinetDetail(MedicineCabinetDetail detail) 
        {
            return _prescriptionAdjustmentDAL.UpdateMedicineCabinetDetail(detail);
        }
    }
}
