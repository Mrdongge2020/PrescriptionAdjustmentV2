using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.DAL.Prescription
{
    public class PrescriptionAdjustmentDAL
    {
        private readonly EFCoreContext _eFCoreContext = new EFCoreContext();

        /// <summary>
        /// 获取已下载列表数据
        /// </summary>
        /// <param name="preIds">处方编号</param>
        /// <returns></returns>
        public List<DownLoadedPre> GetDownLoadedPres(List<string> preIds) 
        {
            var data = _eFCoreContext.LocalDataPrescriptionInfos.Where(x => preIds.Contains(x.PrescriptionID))
                .Select(x => new DownLoadedPre
                {
                    PrescriptionID = x.PrescriptionID,
                    PatientName = x.PatientName,
                    PatientAge = x.PatientAge,
                    PatientSex = x.PatientSex.ToString(),
                    ProcessStatus = x.ProcessStatus,
                    Quantity = x.Quantity
                }).ToList();
            return data;
        }

        /// <summary>
        /// 获取处方集合中某些颗粒的使用量
        /// </summary>
        /// <param name="perIds">处方集合</param>
        /// <param name="parIds">颗粒集合</param>
        /// <returns></returns>
        public List<ParticUsedStockModel> GetParticUsedStocks(List<string> perIds,List<int> parIds) 
        {
            if (perIds==null) { return null; }

            string peridStr = "";
            foreach (var item in perIds)
            {
                peridStr += ",'" + item + "'";
            }
            string wherePrequery = "";
            if (peridStr!="") {
                peridStr = peridStr.Substring(1);
                wherePrequery = " and a.PrescriptionID in ("+ peridStr + ")  ";
            }
           
            string sql = $@" select a.ParticlesID as ParticId,sum(a.Dose*b.Quantity) as UsedAmount
                             from LocalDataPrescriptionDetail as a
                             join LocalDataPrescriptionInfo as b on a.PrescriptionID=b.PrescriptionID
                             where  a.ParticlesID in ({string.Join(',', parIds)}) {wherePrequery}
                             group by a.ParticlesID   ";

            return DBHelper.ExecuteQuery<ParticUsedStockModel>(sql);
        }

        /// <summary>
        /// 根据给定的处方编号获取已核对的处方编号
        /// </summary>
        /// <param name="preIds">给定的处方编号</param>
        /// <returns></returns>
        public List<string> GetConfirmedPrescriptions(List<string> preIds) 
        {
            var preids = _eFCoreContext.LocalDataPrescriptionInfos.Where(x => preIds.Contains(x.PrescriptionID) && x.ProcessStatus == ProcessStatusEnum.待调剂).Select(x=>x.PrescriptionID).ToList();
            return preids;
        }
        /// <summary>
        /// 确认处方
        /// </summary>
        /// <param name="preId">处方编号</param>
        /// <returns></returns>
        public bool ConfirmPrescription(string preId)
        {
            try
            {
                var preinfo = _eFCoreContext.LocalDataPrescriptionInfos.FirstOrDefault(x => x.PrescriptionID == preId);
                if (preinfo != null)
                {
                    preinfo.ProcessStatus = ProcessStatusEnum.待调剂;
                    _eFCoreContext.LocalDataPrescriptionInfos.Update(preinfo);
                    _eFCoreContext.SaveChanges();
                    return true;
                }
                else 
                { 
                    return false;
                }
                
            }
            catch (Exception e)
            {
                return false;
            }

        }
        /// <summary>
        /// 修改本地处方状态
        /// </summary>
        public string UpdatePrescriptionStatus(List<string> prescriptionIds, ProcessStatusEnum status)
        {
            string error = "";
            var preInfos = _eFCoreContext.LocalDataPrescriptionInfos.Where(x => prescriptionIds.Contains(x.PrescriptionID)).ToList();
            if (preInfos == null || preInfos.Count <= 0)
            {
                error = "未查找到相关处方信息";
                return error;
            }
            preInfos.ForEach(item => {
                item.ProcessStatus = status;
            });

            _eFCoreContext.LocalDataPrescriptionInfos.UpdateRange(preInfos);
            _eFCoreContext.SaveChanges();

            return error;
        }

        /// <summary>
        /// 复位处方
        /// </summary>
        /// <param name="prescriptionId">处方编号</param>
        /// <returns></returns>
        public bool ReturnPrescription(string prescriptionId) 
        {
            var dataPrescription = _eFCoreContext.DataPrescriptions.FirstOrDefault(x => x.PrescriptionID==prescriptionId);
            if (dataPrescription != null)
            {
                dataPrescription.ProcessStatus = 0;
            }
            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    //删除本地处方数据
                    _eFCoreContext.LocalDataPrescriptionInfos.Where(x => x.PrescriptionID == prescriptionId).ExecuteDelete();
                    _eFCoreContext.LocalDataPrescriptionDetails.Where(x => x.PrescriptionID == prescriptionId).ExecuteDelete();
                    //修改待下载数据
                    _eFCoreContext.DataPrescriptions.Update(dataPrescription);
                    _eFCoreContext.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 获取待调剂处方
        /// </summary>
        /// <param name="prescriptionId">处方编号</param>
        /// <returns></returns>
        public PrescriptionAwaitingAdjustmentModel GetPrescriptionByCode(string prescriptionId) 
        {
            PrescriptionAwaitingAdjustmentModel prescriptionAwaitingAdjustmentModel = new PrescriptionAwaitingAdjustmentModel();
            prescriptionAwaitingAdjustmentModel.PrescriptionInfo = _eFCoreContext.LocalDataPrescriptionInfos.FirstOrDefault(x => x.PrescriptionID == prescriptionId);
            prescriptionAwaitingAdjustmentModel.PrescriptionDetails = _eFCoreContext.LocalDataPrescriptionDetails.Where(x => x.PrescriptionID == prescriptionId).ToList();
            return prescriptionAwaitingAdjustmentModel;
        }
    }
}
