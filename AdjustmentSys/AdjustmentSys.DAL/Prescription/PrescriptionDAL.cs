using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdjustmentSys.DAL.Prescription
{
    public class PrescriptionDAL
    {
        private readonly EFCoreContext _eFCoreContext = new EFCoreContext();

        /// <summary>
        /// 新增处方信息
        /// </summary>
        /// <param name="dataPrescription">处方信息</param>
        /// <param name="dataPrescriptionDetails">处方详情信息</param>
        /// <returns></returns>
        public string AddPrescription(DataPrescription dataPrescription,List<DataPrescriptionDetail> dataPrescriptionDetails) 
        {
            string error = "";
            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    _eFCoreContext.DataPrescriptions.Add(dataPrescription);
                    _eFCoreContext.DataPrescriptionDetails.AddRange(dataPrescriptionDetails);
                    _eFCoreContext.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    error = "保存处方信息失败,请稍后再试";
                }
            }
            return error;
        }

        /// <summary>
        /// 修改处方状态
        /// </summary>
        /// <param name="preId">处方id</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public string UpdatePrescriptionStatus(int preId, ProcessStatusEnum status) 
        {
            string error = "";
            var preInfo = _eFCoreContext.LocalDataPrescriptionInfos.FirstOrDefault(x => x.ID == preId);
            if (preInfo == null)
            {
                error = "未查找到处方信息";
                return error;
            }

            preInfo.ProcessStatus = status;
            preInfo.Remarks = preInfo.Remarks + "("+DateTime.Now+"用户:" +SysLoginUser._currentUser.UserName + "修改处方状态为"+ status.ToString()+ ")";
            _eFCoreContext.LocalDataPrescriptionInfos.Update(preInfo);
            _eFCoreContext.SaveChanges();

            return error;
        }

    }
}
