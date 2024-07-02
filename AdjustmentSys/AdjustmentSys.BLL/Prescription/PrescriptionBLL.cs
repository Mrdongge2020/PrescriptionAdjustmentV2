using AdjustmentSys.DAL.Prescription;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Prescription;
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
        /// 查询处方详情
        /// </summary>
        /// <param name="prescriptionID">处方编号</param>
        /// <param name="processStatus">处方状态</param>
        /// <returns></returns>
        public List<PrescriptionDetailModel> GetPrescriptionDetailList(string prescriptionID, ProcessStatusEnum? processStatus) 
        {
            return prescriptionDAL.GetPrescriptionDetailList(prescriptionID,processStatus);
        }
    }
}
