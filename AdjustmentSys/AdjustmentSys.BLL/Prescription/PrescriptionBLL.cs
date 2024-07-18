using AdjustmentSys.DAL.Prescription;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.Prescription
{
    public class PrescriptionBLL
    {
        PrescriptionDAL prescriptionDAL = new PrescriptionDAL();
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
        /// 修改处方状态
        /// </summary>
        /// <param name="preId">处方id</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public string UpdatePrescriptionStatus(int preId, ProcessStatusEnum status)
        {
            return prescriptionDAL.UpdatePrescriptionStatus(preId,status);
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
        public List<PrescriptionPageListModel> GetPrescriptionPageList(string prescriptionID, string patientName, DateTime? startTime, DateTime? endTime, int? prescriptionSource, ProcessStatusEnum? processStatus, int pageIndex, int pageSize, out int totalCount) 
        { 
            return prescriptionDAL.GetPrescriptionPageList(prescriptionID,patientName, startTime, endTime, prescriptionSource, processStatus, pageIndex, pageSize, out totalCount);
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
        public List<PrescriptionDetailModel> GetPrescriptionDetailList(string prescriptionID, ProcessStatusEnum? processStatus) 
        {
            return prescriptionDAL.GetPrescriptionDetailList(prescriptionID,processStatus);
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
    }
}
