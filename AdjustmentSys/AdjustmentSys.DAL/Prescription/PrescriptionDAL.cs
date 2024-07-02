using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.MedicineCabinet;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public List<PrescriptionPageListModel> GetPrescriptionPageList(string prescriptionID, string patientName,DateTime? startTime,DateTime? endTime, int? prescriptionSource, ProcessStatusEnum? processStatus, int pageIndex, int pageSize, out int totalCount) 
        {
            string tableName = " LocalDataPrescriptionInfo ";

            string queryFilder = @" select  ID
                                          ,PrescriptionID
                                          ,PatientName
                                          ,PatientSex
                                          ,PatientAge
                                          ,PatientBirthMonth
                                          ,PatientBirthDay
                                          ,PatientTel
                                          ,PatientEmail
                                          ,PatientLocation
                                          ,DoctorName
                                          ,DepartmentName
                                          ,PrescriptionName
                                          ,CreateName
                                          ,CreateTime
                                          ,ValuerName
                                          ,ValueSn
                                          ,ValuationTime
                                          ,RegisterID
                                          ,PaymentType
                                          ,PaymentStatus
                                          ,PrescriptionType
                                          ,ImportTime
                                          ,Quantity
                                          ,TaskFrequency
                                          ,UnitPrice
                                          ,TotalPrice
                                          ,DetailedCount
                                          ,ProcessStatus
                                          ,PrescriptionSource
                                          ,Remarks
                                          ,UsageMethod
                                          ,BackupField1
                                          ,BackupField2
                                          ,BackupField3 ";

            string sqlWhere = " where 1=1 ";

            if (!string.IsNullOrEmpty(prescriptionID)) 
            {
                sqlWhere += " and  PrescriptionID like '%"+ prescriptionID + "%' ";
            }
            if (!string.IsNullOrEmpty(patientName))
            {
                sqlWhere += " and  PatientName like '%" + patientName + "%' ";
            }
            if (startTime.HasValue)
            {
                sqlWhere += " and  CreateTime>='" + startTime.Value.Date + "' ";
            }
            if (endTime.HasValue)
            {
                sqlWhere += " and  CreateTime<'" + endTime.Value.Date.AddDays(1) + "' ";
            }
            if (prescriptionSource.HasValue) 
            {
                sqlWhere += " and  PrescriptionSource=" + prescriptionSource;
            }
            if (processStatus.HasValue)
            {
                if (processStatus.Value == ProcessStatusEnum.完成)
                {
                    tableName = " LocalDataPrescriptionInfoRecord ";
                    queryFilder += @" ,DownloadName
                                      ,DownloadBy
                                      ,DownloadTime
                                      ,AllocateName
                                      ,DeviceName
                                      ,BoxNumber
                                      ,TimeConsuming
                                      ,AnalysisResult
                                      ,CompleteTime ";
                }
                else if (processStatus.Value == ProcessStatusEnum.待下载)
                {
                    tableName = " DataPrescription ";
                }
                else 
                {
                    queryFilder += @" ,DownloadName
                                      ,DownloadBy
                                      ,DownloadTime ";
                    sqlWhere += " and  ProcessStatus=" + (int)processStatus.Value;
                }
            }

            string sqlCount = $@" select count(1) from {tableName}   {sqlWhere} ";

            totalCount = DBHelper.ExecuteQueryOne<int>(sqlCount);
            if (totalCount<=0) 
            {
                return null;
            }

            string sql = $@" {queryFilder}
                             from {tableName}    
                             {sqlWhere}
                             order by CreateTime desc
                             OFFSET {pageSize * (pageIndex - 1)} ROW FETCH NEXT {pageSize} ROWS ONLY
                          ";
            List<PrescriptionPageListModel> result= DBHelper.ExecuteQuery<PrescriptionPageListModel>(sql);

            return result;

        }

        /// <summary>
        /// 查询处方详情
        /// </summary>
        /// <param name="prescriptionID">处方编号</param>
        /// <param name="processStatus">处方状态</param>
        /// <returns></returns>
        public List<PrescriptionDetailModel> GetPrescriptionDetailList(string prescriptionID, ProcessStatusEnum? processStatus) 
        {
            string tableName = " LocalDataPrescriptionDetail ";
            if (processStatus.Value == ProcessStatusEnum.完成)
            {
                tableName = " LocalDataPrescriptionDetailRecord ";
            
            }
            else if (processStatus.Value == ProcessStatusEnum.待下载)
            {
                tableName = " DataPrescriptionDetail ";
            }

            string sql = $@"select a.ID
                                  ,b.Name as ParName
                                  ,ParticleOrder
                                  ,ParticlesName
                                  ,ParticlesCodeHIS
                                  ,ParticlesID
                                  ,BatchNumber
                                  ,DoseHerb
                                  ,Equivalent
                                  ,Dose
                                  ,Price
                            from {tableName} as a
                            left join ParticlesInfo as b on  a.ParticlesID=b.ID 
                            where a.PrescriptionID='{prescriptionID}'
                            order by ParticleOrder asc ";

            List<PrescriptionDetailModel> result = DBHelper.ExecuteQuery<PrescriptionDetailModel>(sql);

            return result;
            
        }
    }
}
