using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.MedicineCabinet;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using Microsoft.EntityFrameworkCore;
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
        /// <param name="prescriptionIds">处方编号集合</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public string UpdatePrescriptionStatus(List<string> prescriptionIds, ProcessStatusEnum status) 
        {
            string error = "";
            var preInfos = _eFCoreContext.DataPrescriptions.Where(x => prescriptionIds.Contains(x.PrescriptionID)).ToList();
            if (preInfos == null || preInfos.Count<=0)
            {
                error = "未查找到相关处方信息";
                return error;
            }
            preInfos.ForEach(item => {
                item.ProcessStatus = (int)status;
                item.Remarks = item.Remarks + "(" + DateTime.Now + "用户:" + SysLoginUser._currentUser.UserName + "修改处方状态为" + status.ToString() + ")";
            });
           
            _eFCoreContext.DataPrescriptions.UpdateRange(preInfos);
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

            totalCount = Convert.ToInt32(DBHelper.ExecuteScalar(sqlCount));
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
        /// 获取处方信息，主要回写处方录入用
        /// </summary>
        /// <returns></returns>
        public PrescriptionInfoModel GetPrescriptionInfo(string prescriptionID, ProcessStatusEnum? processStatus) 
        {
            string tableName = " LocalDataPrescriptionInfo ";
            if (processStatus.Value == ProcessStatusEnum.完成)
            {
                tableName = " LocalDataPrescriptionInfoRecord ";

            }
            else if (processStatus.Value == ProcessStatusEnum.待下载)
            {
                tableName = " DataPrescription ";
            }

            PrescriptionInfoModel prescriptionInfoModel = new PrescriptionInfoModel();
            string sql = $@" SELECT
	                                ID,
	                                PrescriptionID,
	                                PatientName,
	                                PatientSex,
	                                PatientAge,
	                                PatientBirthMonth,
	                                PatientTel,
	                                DoctorName,
	                                DepartmentName,
	                                Quantity,
	                                TaskFrequency,
	                                Remarks 
                              FROM
	                                {tableName} 
                              where PrescriptionID='{prescriptionID}' ";
            prescriptionInfoModel = DBHelper.ExecuteQueryOne<PrescriptionInfoModel>(sql);
            prescriptionInfoModel.Details = GetPrescriptionDetailList(prescriptionID,processStatus);
            return prescriptionInfoModel;
        }
        /// <summary>
        /// 查询处方详情
        /// </summary>
        /// <param name="prescriptionID">处方编号</param>
        /// <param name="processStatus">处方状态</param>
        /// <returns></returns>
        public List<PrescriptionDetailModel> GetPrescriptionDetailList(string prescriptionID, ProcessStatusEnum? processStatus,bool isQueryStock=false) 
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
                                  ,b.Code as ParCode
                                  ,c.DoseLimit
                                  ,ParticleOrder
                                  ,ParticlesNameHIS
                                  ,ParticlesCodeHIS
                                  ,a.ParticlesID
                                  ,a.BatchNumber
                                  ,DoseHerb
                                  ,a.Equivalent
                                  ,Dose
                                  ,Price
                            from {tableName} as a
                            left join ParticlesInfo as b on  a.ParticlesID=b.ID 
                            left join ParticlesInfoExtend as c on a.ParticlesID=c.ParticlesID
                            where a.PrescriptionID='{prescriptionID}'
                            order by ParticleOrder asc ";

            List<PrescriptionDetailModel> result = DBHelper.ExecuteQuery<PrescriptionDetailModel>(sql);
            if (result==null) 
            { 
                return null;
            }
            if (isQueryStock) 
            {
                //获取药柜上的库存信息等
                string code = SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
                if (string.IsNullOrEmpty(code))
                {
                    //根据编号获取药柜id
                    List<int> mcids = _eFCoreContext.MedicineCabinetInfos.Where(x => x.Code == code).Select(x => x.ID).ToList();
                    List<int> parIds= result.Select(x => x.ID).ToList();
                    if (mcids==null)
                    {
                        return result;
                    }
                    var mcdlist= _eFCoreContext.MedicineCabinetDetails.Where(x =>mcids.Contains(x.MedicineCabinetId) && x.ParticlesID>0 && parIds.Contains((int)x.ParticlesID)).ToList();
                    if (mcdlist == null) 
                    {
                        return result;
                    }
                    foreach (var item in result)
                    {
                        item.Stock = mcdlist.FirstOrDefault(x => x.ParticlesID == item.ParticlesID)?.Stock;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取医生科室
        /// </summary>
        /// <param name="docId">医生id</param>
        /// <returns></returns>
        public string GetDoctorDepartment(int docId) 
        {
            string depName = _eFCoreContext.DoctorInfos.FirstOrDefault(x=>x.ID==docId)?.DoctorDepartmentName;
            return depName;
        }

        /// <summary>
        /// 获取颗粒信息
        /// </summary>
        /// <param name="parId">颗粒id</param>
        /// <returns></returns>
        public ParticlesInfoModel GetParticlesInfo(int parId) 
        {
            string sql = $@" select a.ID,a.Name as ParName,HisCode,a.Code,b.Equivalent,DoseLimit,RetailPrice
                        from ParticlesInfo as a
                        left join ParticlesInfoExtend as b on a.ID=b.ParticlesID
                        where a.ID={parId} ";
            ParticlesInfoModel particlesInfoModel= DBHelper.ExecuteQueryOne<ParticlesInfoModel>(sql);
            if (particlesInfoModel == null)
            {
                return null;
            }
            //获取药柜上的库存信息等
            string code= SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
            if (string.IsNullOrEmpty(code)) 
            { 
                //根据编号获取药柜id
                List<int> mcids=_eFCoreContext.MedicineCabinetInfos.Where(x=>x.Code==code).Select(x=>x.ID).ToList();
                if (mcids!=null && mcids.Count>0)
                {
                    particlesInfoModel.Stock= _eFCoreContext.MedicineCabinetDetails.FirstOrDefault(x=>mcids.Contains(x.MedicineCabinetId) && x.ParticlesID== parId)?.Stock;
                }
            }
           return particlesInfoModel;
        }

        /// <summary>
        /// 获取所有相容规则
        /// </summary>
        /// <returns></returns>
        public List<ParticleProhibitionRule> GetAllRuler() 
        {
            var rulers = _eFCoreContext.ParticleProhibitionRules.ToList();
            return rulers;
        }

        #region 协定方
        /// <summary>
        /// 新增或编辑协定方
        /// </summary>
        /// <param name="agreementPrescriptionId">协定方id</param>
        /// <param name="agreementPrescriptionInfo">基本信息</param>
        /// <param name="agreementPrescriptionDetails">详情信息</param>
        /// <returns></returns>
        public string AddOrEditAgreementPrescriptionInfo(int? agreementPrescriptionId, AgreementPrescriptionInfo agreementPrescriptionInfo,List<AgreementPrescriptionDetail> agreementPrescriptionDetails)
        {
            string error = "";
            if (agreementPrescriptionId == null)
            {

                #region 新增协定方
                using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
                {
                    try
                    {
                        _eFCoreContext.AgreementPrescriptionInfos.Add(agreementPrescriptionInfo);
                        _eFCoreContext.SaveChanges();
                        agreementPrescriptionDetails.ForEach(x => { x.AgreementPrescriptionId = agreementPrescriptionInfo.ID; });
                        _eFCoreContext.AgreementPrescriptionDetails.AddRange(agreementPrescriptionDetails);
                        _eFCoreContext.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        error = "保存协定方信息失败,请稍后再试";
                    }
                } 
                #endregion

            }else 
            {
                #region 编辑协定方

                var info = _eFCoreContext.AgreementPrescriptionInfos.FirstOrDefault(x => x.ID == agreementPrescriptionId);
                if (info == null)
                {
                    error = "编辑协定方信息失败,未找到要修改的协定方";
                    return error;
                }
                info.Name = agreementPrescriptionInfo.Name;
                info.Description = agreementPrescriptionInfo.Description;

                using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
                {
                    try
                    {
                       //删除旧的协定方详情数据
                        _eFCoreContext.AgreementPrescriptionDetails.Where(x=>x.AgreementPrescriptionId== agreementPrescriptionId).ExecuteDelete();
                        //更新协定方基本信息
                        _eFCoreContext.AgreementPrescriptionInfos.Update(info);
                        //重新插入新的协定方详情数据
                        _eFCoreContext.AgreementPrescriptionDetails.AddRange(agreementPrescriptionDetails);
                        _eFCoreContext.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        error = "编辑协定方信息失败,请稍后再试";
                    }
                } 
                #endregion
            }

            return error;
        }

        /// <summary>
        /// 删除协定方
        /// </summary>
        /// <param name="agreementPrescriptionId">协定方id</param>
        /// <returns></returns>
        public string DeleteAgreementPrescriptionInfo(int agreementPrescriptionId) 
        {
            string error = "";

            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    //删除协定方基本信息
                    _eFCoreContext.AgreementPrescriptionInfos.Where(x => x.ID == agreementPrescriptionId).ExecuteDelete();
                    //删除协定方详情数据
                    _eFCoreContext.AgreementPrescriptionDetails.Where(x => x.AgreementPrescriptionId == agreementPrescriptionId).ExecuteDelete();

                    _eFCoreContext.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    error = "删除协定方信息失败,请稍后再试";
                }
            }
            return error;
        }
        /// <summary>
        /// 判断协定方是否已存在
        /// </summary>
        /// <param name="agreementPrescriptionId">协定方id</param>
        /// <param name="name">协定方名称</param>
        /// <returns></returns>
        public bool IsExitAgreementPrescription(int? agreementPrescriptionId,string name) 
        {
            if (agreementPrescriptionId != null)
            {
                return _eFCoreContext.AgreementPrescriptionInfos.Any(x => x.Name == name && x.ID != agreementPrescriptionId);
            }
            else 
            {
                return _eFCoreContext.AgreementPrescriptionInfos.Any(x => x.Name == name);
            }
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
            var where = _eFCoreContext.AgreementPrescriptionInfos.AsNoTracking()
                .Where(x =>1==1);

            //名称条件
            if (!string.IsNullOrEmpty(name))
            {
                where = where.Where(x => (x.Name.Contains(name)));
            }

            //统计总记录数
            count = where.Count();
            if (count == 0)
            {
                return null;
            }

            //结果按照创建时间倒序排序
            where = where.OrderByDescending(x => x.CreateTime);

            //跳过翻页的数量
            var list = where.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();

            return list;
        }

        /// <summary>
        /// 获取协定方详情信息
        /// </summary>
        /// <param name="agreementPrescriptionId">协定方id</param>
        /// <returns></returns>
        public List<AgreementPrescriptionDetailModel> GetAgreementPrescriptionDetails(int agreementPrescriptionId) 
        {
            string sql = $@" select
	                         a.ID,
	                         a.ParticlesId,
	                         a.DoseHerb,
	                         a.Equivalent,
	                         a.Dose,
	                         a.Price,
	                         b.Name 
                             from AgreementPrescriptionDetail as a
                             left join ParticlesInfo as b on a.ParticlesId=b.ID  
                             where  AgreementPrescriptionId={agreementPrescriptionId} ";

            return DBHelper.ExecuteQuery<AgreementPrescriptionDetailModel>(sql); 
        }

        /// <summary>
        /// 获取协定方详情，主要编辑协定方回显用
        /// </summary>
        /// <param name="agreementPrescriptionId">协定方id</param>
        /// <returns></returns>
        public List<PrescriptionDetailModel> GetAgreementPrescriptionDetailsV1(int agreementPrescriptionId)
        {
            string sql = $@" select
	                                 a.ID,
	                                 b.Name as ParName,
							         b.Code as ParCode,
							         c.DoseLimit,
							         c.HisName as ParticlesNameHIS,
							         c.HisCode as ParticlesCodeHIS,
							         a.ParticlesID,
	                                 a.DoseHerb,
	                                 a.Equivalent,
	                                 a.Dose,
	                                 a.Price
                             from AgreementPrescriptionDetail as a
                             left join ParticlesInfo as b on a.ParticlesId=b.ID  
							 left join ParticlesInfoExtend as c on b.ID=c.ParticlesID
                             where  a.AgreementPrescriptionId={agreementPrescriptionId} ";

            return DBHelper.ExecuteQuery<PrescriptionDetailModel>(sql);
        }

        /// <summary>
        /// 获取协定方名称
        /// </summary>
        /// <param name="agreementPrescriptionId">协定方id</param>
        /// <returns></returns>
        public string GetAgreementPrescriptionName(int agreementPrescriptionId)
        {
            return _eFCoreContext.AgreementPrescriptionInfos.FirstOrDefault(x => x.ID == agreementPrescriptionId)?.Name;
        }
        #endregion
    }
}
