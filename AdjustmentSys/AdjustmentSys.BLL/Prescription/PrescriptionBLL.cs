using AdjustmentSys.BLL.Common;
using AdjustmentSys.DAL.Prescription;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.Drug;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.Prescription
{
    public class PrescriptionBLL
    {
        PrescriptionDAL prescriptionDAL = new PrescriptionDAL();
        CommonDataBLL commonDataBLL = new CommonDataBLL();
        /// <summary>
        /// 新增处方信息
        /// </summary>
        /// <param name="dataPrescription">处方信息</param>
        /// <param name="dataPrescriptionDetails">处方详情信息</param>
        /// <returns></returns>
        public string AddPrescription(DataPrescription dataPrescription, List<DataPrescriptionDetail> dataPrescriptionDetails)
        {
            decimal totalPrice= dataPrescriptionDetails.Sum(x => x.Price*(decimal)x.DoseHerb);
            dataPrescription.CreateName = SysLoginUser._currentUser.UserName;
            dataPrescription.CreateTime= DateTime.Now;
            dataPrescription.ValuationTime= DateTime.Now;
            dataPrescription.ImportTime = DateTime.Now;
            dataPrescription.UnitPrice =Math.Round(totalPrice/dataPrescription.Quantity,3);
            dataPrescription.TotalPrice = totalPrice;
            dataPrescription.DetailedCount = dataPrescriptionDetails.Count;
            dataPrescription.ProcessStatus = 0;
            dataPrescription.PrescriptionSource = 1;

            return prescriptionDAL.AddPrescription(dataPrescription,dataPrescriptionDetails);
        }

        /// <summary>
        /// 待下载处方修改处方状态
        /// </summary>
        /// <param name="prescriptionIds">处方编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public string UpdatePrescriptionStatus(List<string> prescriptionIds, ProcessStatusEnum status)
        {
            return prescriptionDAL.UpdatePrescriptionStatus(prescriptionIds, status);
        }

        /// <summary>
        /// 查询处方列表分页数据
        /// </summary>
        /// <param name="prescriptionID">处方编号</param>
        /// <param name="patientName">患者名称</param>
        /// <param name="startTime">创建时间开始</param>
        /// <param name="endTime">创建时间结束</param>
        /// <param name="prescriptionSource">处方来源</param>
        /// <param name="processStatus">状态</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public List<PrescriptionPageListModel> GetPrescriptionPageList(string prescriptionID, string patientName, DateTime? startTime, DateTime? endTime, int? prescriptionSource, ProcessStatusEnum? processStatus, string sortString, int pageIndex, int pageSize, out int totalCount) 
        { 
            return prescriptionDAL.GetPrescriptionPageList(prescriptionID,patientName, startTime, endTime, prescriptionSource, processStatus,sortString, pageIndex, pageSize, out totalCount);
        }

        /// <summary>
        /// 获取处方信息，主要回写处方录入用
        /// </summary>
        /// <returns></returns>
        public PrescriptionInfoModel GetPrescriptionInfo(string prescriptionID, ProcessStatusEnum? processStatus) 
        {
            return prescriptionDAL.GetPrescriptionInfo(prescriptionID,processStatus);
        }
        /// <summary>
        /// 查询处方详情
        /// </summary>
        /// <param name="prescriptionID">处方编号</param>
        /// <param name="processStatus">处方状态</param>
        /// <returns></returns>
        public List<PrescriptionDetailModel> GetPrescriptionDetailList(string prescriptionID, ProcessStatusEnum? processStatus, bool isQueryStock=false) 
        {
            return prescriptionDAL.GetPrescriptionDetailList(prescriptionID,processStatus,isQueryStock);
        }

        /// <summary>
        /// 获取医生科室
        /// </summary>
        /// <param name="docId">医生id</param>
        /// <returns></returns>
        public string GetDoctorDepartment(int docId) 
        { 
            return prescriptionDAL.GetDoctorDepartment(docId);
        }

        /// <summary>
        /// 获取颗粒信息
        /// </summary>
        /// <param name="parId">颗粒id</param>
        /// <returns></returns>
        public ParticlesInfoModel GetParticlesInfo(int parId)
        {
            return prescriptionDAL.GetParticlesInfo(parId);
        }
        /// <summary>
        /// 获取所有相容规则
        /// </summary>
        /// <returns></returns>
        public List<ParticleProhibitionRule> GetAllRuler()
        { 
            return prescriptionDAL.GetAllRuler();
        }

        /// <summary>
        /// 相容性规则检查
        /// </summary>
        /// <param name="parId">当前颗粒id</param>
        /// <param name="parIds">已添加的颗粒id集合</param>
        /// <param name="durgDLData">药柜药品下拉集合</param>
        /// <returns></returns>
        public List<string> CheckRuler(int parId, List<int> parIds, List<ComboxModel> durgDLData)
        {
            //获取所有规则
            var rulers = GetAllRuler();
            if (rulers == null || rulers.Count == 0)
            {
                return null;
            }
            List<string> resultlist = new List<string>();
            foreach (var cid in parIds)
            {
                var currentRulers = rulers.Where(x => (parId == x.FirstParticlesID && cid == x.SecondParticlesID) || (parId == x.SecondParticlesID && cid == x.FirstParticlesID)).ToList();
                if (currentRulers == null)
                {
                    continue;
                }
                foreach (var cr in currentRulers)
                {
                    string fname = durgDLData.FirstOrDefault(x => x.Id == cr.FirstParticlesID)?.Name;
                    string sname = durgDLData.FirstOrDefault(x => x.Id == cr.SecondParticlesID)?.Name;
                    string rulerString = $"[{fname}]与[{sname}]违反药品相融规则[{cr.Name + "," + cr.Remark}]";
                    if (!resultlist.Contains(rulerString))
                    {
                        resultlist.Add(rulerString);
                    }
                }
            }
            return resultlist;
        }

        /// <summary>
        /// 新增或编辑协定方
        /// </summary>
        /// <param name="agreementPrescriptionId">协定方id</param>
        /// <param name="agreementPrescriptionInfo">基本信息</param>
        /// <param name="agreementPrescriptionDetails">详情信息</param>
        /// <returns></returns>
        public string AddOrEditAgreementPrescriptionInfo(int? agreementPrescriptionId, AgreementPrescriptionInfo agreementPrescriptionInfo, List<AgreementPrescriptionDetail> agreementPrescriptionDetails)
        {
            if (prescriptionDAL.IsExitAgreementPrescription(agreementPrescriptionId, agreementPrescriptionInfo.Name)) 
            {
                return "当前协定方名称在系统已存在";
            }
            if (agreementPrescriptionId==null) 
            {
                agreementPrescriptionInfo.CreateName = SysLoginUser._currentUser.UserName;
                agreementPrescriptionInfo.CreateBy = SysLoginUser._currentUser.UserId;
                agreementPrescriptionInfo.CreateTime = DateTime.Now;
            }
          
            return prescriptionDAL.AddOrEditAgreementPrescriptionInfo(agreementPrescriptionId,agreementPrescriptionInfo,agreementPrescriptionDetails);
        }

        /// <summary>
        /// 删除协定方
        /// </summary>
        /// <param name="agreementPrescriptionId">协定方id</param>
        /// <returns></returns>
        public string DeleteAgreementPrescriptionInfo(int agreementPrescriptionId)
        {
            return prescriptionDAL.DeleteAgreementPrescriptionInfo(agreementPrescriptionId);
        }
        /// <summary>
        /// 协定方列表查询
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        public List<AgreementPrescriptionInfo> GetAgreementPrescriptionByPage(string? name, int pageIndex, int pageSize, out int count) 
        {
            return prescriptionDAL.GetAgreementPrescriptionByPage(name, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 获取协定方详情信息
        /// </summary>
        /// <param name="agreementPrescriptionId">协定方id</param>
        /// <returns></returns>
        public List<AgreementPrescriptionDetailModel> GetAgreementPrescriptionDetails(int agreementPrescriptionId)
        {
            return prescriptionDAL.GetAgreementPrescriptionDetails(agreementPrescriptionId);
        }
        /// <summary>
        /// 获取协定方详情，主要编辑协定方回显用
        /// </summary>
        /// <param name="agreementPrescriptionId">协定方id</param>
        /// <returns></returns>
        public List<PrescriptionDetailModel> GetAgreementPrescriptionDetailsV1(int agreementPrescriptionId)
        { 
            return prescriptionDAL.GetAgreementPrescriptionDetailsV1(agreementPrescriptionId);
        }
        /// <summary>
        /// 获取协定方名称
        /// </summary>
        /// <param name="agreementPrescriptionId">协定方id</param>
        /// <returns></returns>
        public string GetAgreementPrescriptionName(int agreementPrescriptionId) 
        {
            return prescriptionDAL.GetAgreementPrescriptionName(agreementPrescriptionId);
        }

        /// <summary>
        /// 处方匹配his码
        /// </summary>
        public List<string> HisMate(List<string> preIds,out int successedCount) 
        {
            List<string> errorList = new List<string>();
            successedCount = 0;
            (List<DataPrescription> parinfos, List<DataPrescriptionDetail> parDetails) = GetPreData(preIds, out errorList);

            if (parDetails==null || parDetails.Count==0) 
            {
                return errorList;
            }
            //修改待下载的处方详情信息
            var isSuccess = prescriptionDAL.UpdateDataPrescriptionDetails(parDetails);
            if (isSuccess)
            {
                successedCount = parDetails.Count;
            }
            else 
            {
                errorList.Add($"匹配HIS码失败");
            }

            return errorList;
        }

        /// <summary>
        /// 下载处方数据到本地
        /// </summary>
        /// <param name="preIds">处方编号</param>
        /// <param name="errorStrings">错误信息</param>
        /// <returns></returns>
        public List<string> DownLoadPrescriptions(List<string> preIds,out List<string> errorStrings) 
        {
            (List<DataPrescription> parinfos, List<DataPrescriptionDetail> parDetails) = GetPreData(preIds, out errorStrings);
            if (parinfos == null || parinfos.Count <= 0)
            {
                return null;
            }

            //新增本地处方数据
            List<LocalDataPrescriptionInfo> localDataPrescriptionInfos = new List<LocalDataPrescriptionInfo>();
            foreach (var item in parinfos)
            {
                LocalDataPrescriptionInfo localDataPrescriptionInfo = new LocalDataPrescriptionInfo();
                localDataPrescriptionInfo = CommFunHelper.CopySimilarProperties<LocalDataPrescriptionInfo, DataPrescription>(localDataPrescriptionInfo,item);
                if (localDataPrescriptionInfo!=default) 
                {
                    localDataPrescriptionInfo.DownloadBy = SysLoginUser._currentUser.UserId;
                    localDataPrescriptionInfo.DownloadName = SysLoginUser._currentUser.UserName;
                    localDataPrescriptionInfo.DownloadTime = DateTime.Now;
                    localDataPrescriptionInfo.ProcessStatus = ProcessStatusEnum.待核对;
                    localDataPrescriptionInfos.Add(localDataPrescriptionInfo);
                }
            }
            //新增的本地处方编号
            preIds = localDataPrescriptionInfos.Select(x => x.PrescriptionID).ToList();

            //匹配HIS码
            var updateDataPrescriptionDetails = parDetails.Where(x => !preIds.Contains(x.PrescriptionID)).ToList();


            //新增本地处方详情数据
            var addLocalDataPrescriptionDetails = parDetails.Where(x => preIds.Contains(x.PrescriptionID))
                           .Select(x=>new LocalDataPrescriptionDetail() {
                                PrescriptionID = x.PrescriptionID,
                                ParticleOrder = x.ParticleOrder,
                                ParticlesCodeHIS = x.ParticlesCodeHIS,
                                ParticlesID = x.ParticlesID,
                                ParticlesNameHIS = x.ParticlesNameHIS,
                                BatchNumber = x.BatchNumber,
                                Dose=x.Dose,
                                DoseHerb=x.DoseHerb,
                                Equivalent=x.Equivalent,
                                Price=x.Price
                           }).ToList();
            //获取药柜信息
            var mcDetails= commonDataBLL.GetMedicineCabinetDetails(SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode);
            if (mcDetails!=null && mcDetails.Count>0)
            { 
                foreach (var adpd in addLocalDataPrescriptionDetails)
                {
                    var currentMC = mcDetails.FirstOrDefault(x=>x.ParticlesID==adpd.ParticlesID);
                    if (currentMC!=null)
                    {
                        adpd.BatchNumber= currentMC?.BatchNumber;
                        adpd.ValidityTime = currentMC?.ValidityTime?.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
            }

            //下载数据操作
            bool isSuccess = prescriptionDAL.DownLoadPrescription(updateDataPrescriptionDetails, localDataPrescriptionInfos,addLocalDataPrescriptionDetails);

            if (isSuccess)
            {
                return preIds;
            }
            else
            {
                errorStrings.Add($"下载处方失败");
                return null;
            }
        }

     


        /// <summary>
        /// 获取处方数据
        /// </summary>
        /// <param name="preIds"></param>
        /// <param name="errorStrings"></param>
        /// <returns></returns>
        private (List<DataPrescription>, List<DataPrescriptionDetail>) GetPreData(List<string> preIds, out List<string> errorStrings) 
        {
            
            errorStrings = new List<string>();
            //处方信息
            var allPreinfos = commonDataBLL.GetAllDataPrescriptions(preIds);
            if (allPreinfos == null || allPreinfos.Count <= 0)
            {
                errorStrings.Add("未找到相关处方数据");
                return (null,null);
            }

            //处方数据校验
            foreach (var prescriptionID in preIds)
            {
                var currentPre = allPreinfos.FirstOrDefault(x => x.PrescriptionID == prescriptionID);
                if (currentPre == null)
                {
                    errorStrings.Add($"处方[{prescriptionID}]已被其他设备下载");
                    preIds.Remove(prescriptionID);
                    continue;
                }
                if (currentPre.ProcessStatus == 4)
                {
                    errorStrings.Add($"处方[{prescriptionID}]已被其他设备作废");
                    preIds.Remove(prescriptionID);
                    continue;
                }
            }

            if (preIds.Count == 0)
            {
                return (null, null);
            }

            var datails = commonDataBLL.GetAllDataPrescriptionDetails(preIds);
            if (datails == null || datails.Count <= 0)
            {
                errorStrings.Add("未找到相关处方详情数据");
                return (null, null);
            }

            var allParticles = commonDataBLL.GetCommonParticles();

            List<DataPrescriptionDetail> detailList = new List<DataPrescriptionDetail>();
            foreach (var detail in datails)
            {
                ParticlesInfo currentParticle = new ParticlesInfo();
                if (detail.ParticlesID>0) 
                {
                    currentParticle=allParticles.FirstOrDefault(x => x.ID == detail.ParticlesID);
                }
                else
                {
                    currentParticle=allParticles.FirstOrDefault(x => x.HisCode == detail.ParticlesCodeHIS);
                }
                    
                if (currentParticle != null)
                {
                    detail.Equivalent = currentParticle.Equivalent;
                    detail.Dose = (float)Math.Round(detail.DoseHerb / currentParticle.Equivalent, 2);
                    detail.ParticlesCodeHIS = currentParticle.HisCode;
                    detail.ParticlesNameHIS=currentParticle.HisName;
                    detailList.Add(detail);
                }
                else
                {
                    errorStrings.Add($"颗粒[{detail.ParticlesNameHIS}]匹配HIS码失败");
                    if (preIds.Contains(detail.PrescriptionID))
                    {
                        preIds.Remove(detail.PrescriptionID);
                    }
                }
            }
            allPreinfos= allPreinfos.Where(x => preIds.Contains(x.PrescriptionID)).ToList();
            return (allPreinfos, detailList);
        }

        /// <summary>
        /// 根据处方编号获取处方全部信息
        /// </summary>
        /// <param name="preId">处方编号</param>
        /// <param name="processStatus">处方状态</param>
        /// <param name="isQueryStock">处方详情是否查询库存</param>
        /// <returns></returns>
        public (object, List<PrescriptionDetailModel>) GetAllPrescriptionInfo(string preId, ProcessStatusEnum processStatus, bool isQueryStock = false) 
        { 
            return prescriptionDAL.GetAllPrescriptionInfo(preId, processStatus, isQueryStock);
        }


    }
}
