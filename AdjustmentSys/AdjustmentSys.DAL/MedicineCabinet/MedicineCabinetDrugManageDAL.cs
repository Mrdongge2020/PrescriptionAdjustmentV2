using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.MedicineCabinet;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.DAL.MedicineCabinet
{
    /// <summary>
    /// 药柜管理数据库操作
    /// </summary>
    public class MedicineCabinetDrugManageDAL
    {
        private readonly EFCoreContext _eFCoreContext = new EFCoreContext();
        /// <summary>
        /// 根据分组编号获取药柜药品信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<MedicineCabinetDetailListModel> GetCabinetDrugDetails(string code)
        {
            string sql = $@" SELECT
			                        a.ID,
			                        a.MedicineCabinetId,
			                        a.CoordinateX,
			                        a.CoordinateY,
			                        a.ParticlesID,
			                        c.Name AS ParticlesName,
			                        a.ValidityTime,
			                        a.Stock,
									a.DensityCoefficient,
			                        a.RFID 
                             FROM MedicineCabinetDetail AS a
                             JOIN MedicineCabinetInfo AS b ON a.MedicineCabinetId= b.ID
                             LEFT JOIN ParticlesInfo AS c ON a.ParticlesID= c.ID 
                             WHERE b.Code= '{code}'";
            var datails=DBHelper.ExecuteQuery<MedicineCabinetDetailListModel>(sql);
            return datails;
        }

        /// <summary>
        /// 根据分组编号获取药柜信息
        /// </summary>
        /// <param name="code">分组code</param>
        /// <returns></returns>
        public List<MedicineCabinetInfo> GetCabinets(string code)
        {
           return   _eFCoreContext.MedicineCabinetInfos.Where(x => x.Code == code).OrderBy(x=>x.ID).ToList();
        }

        /// <summary>
        /// 上架颗粒
        /// </summary>
        /// <param name="id">药柜id</param>
        /// <param name="code">药柜编号param>
        /// <param name="parId">颗粒id</param>
        public string ListingParticle(int id, string code, int parId)
        {
            //var meIds = _eFCoreContext.MedicineCabinetInfos.Where(x => x.Code == code).Select(x => x.ID).ToList();
            //if (_eFCoreContext.MedicineCabinetDetails.Any(x => meIds.Contains(x.MedicineCabinetId) && x.ParticlesID == parId))
            //{
            //    return "药柜已上架该颗粒了";
            //}
            var detail = _eFCoreContext.MedicineCabinetDetails.FirstOrDefault(x => x.ID == id);
            if (detail == null)
            {
                return "药柜信息不存在了";
            }
            detail.ParticlesID = parId;
            detail.DensityCoefficient = 1;
            detail.Stock = 0;
            detail.RFID = parId;
            _eFCoreContext.MedicineCabinetDetails.Update(detail);
            int index= _eFCoreContext.SaveChanges();
            return index > 0 ? "" : "上架颗粒失败，请稍后再试";
        }

        /// <summary>
        /// 下架颗粒
        /// </summary>
        /// <param name="id">药柜id</param>
        public string RemoveParticle(int id)
        {
            var detail = _eFCoreContext.MedicineCabinetDetails.FirstOrDefault(x => x.ID == id);
            if (detail == null)
            {
                return "药柜信息不存在了";
            }
            detail.ParticlesID = null;
            _eFCoreContext.MedicineCabinetDetails.Update(detail);
            int index = _eFCoreContext.SaveChanges();
            return index > 0 ? "" : "下架颗粒失败，请稍后再试";
        }

        /// <summary>
        /// 获取颗粒有效期列表
        /// </summary>
        public List<MedicineCabinetValidityModel> GetMedicineCabinetValidity(DateTime sdateTime, DateTime edateTime)
        {
            string sql = $@" SELECT
			                        c.Code AS ParticleCode,
			                        c.Name AS ParticleName,
			                        a.ValidityTime,
			                        a.BatchNumber
                             FROM MedicineCabinetDetail AS a
                             JOIN MedicineCabinetInfo AS b ON a.MedicineCabinetId= b.ID
                             LEFT JOIN ParticlesInfo AS c ON a.ParticlesID= c.ID 
                             WHERE a.ParticlesID>0 and  b.Code= '{SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode}' and a.ValidityTime>='{sdateTime}' and a.ValidityTime<='{edateTime}'
                             order by a.ValidityTime asc ";

            var datails = DBHelper.ExecuteQuery<MedicineCabinetValidityModel>(sql);
            return datails;
        }

        /// <summary>
        /// 修改药柜药品有效期
        /// </summary>
        /// <param name="particleId">颗粒id</param>
        /// <param name="validityDateTime">效期至</param>
        /// <returns></returns>
        public bool UpdateValidity(int? particleId,DateTime validityDateTime)
        {
            string sql = "";
            if (particleId.HasValue)
            {
                sql = $" UPDATE MedicineCabinetDetail SET ValidityTime='{validityDateTime}' where ParticlesID={particleId} and MedicineCabinetId in (select ID from MedicineCabinetInfo where Code='{SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode}') ";
            }
            else 
            {
                sql = $" UPDATE MedicineCabinetDetail SET ValidityTime='{validityDateTime}' where  MedicineCabinetId in (select ID from MedicineCabinetInfo where Code='{SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode}') ";
            }
           return  DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 获取颗粒位置导出信息
        /// </summary>
        /// <returns></returns>
        public List<ParticlesPositionExcelModel> GetParticlesPosition() 
        {
            string sql = @" select a.MedicineCabinetId,b.Code,b.Name as ParName,a.CoordinateX,a.CoordinateY
                            from MedicineCabinetDetail as a
                            left join ParticlesInfo as b on a.ParticlesID=b.ID
                            left join MedicineCabinetInfo as c on c.ID=a.MedicineCabinetId
                            where  c.Code='"+SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode+"'"+
                            "order by a.CoordinateX,a.CoordinateY ";
            return DBHelper.ExecuteQuery<ParticlesPositionExcelModel>(sql);
        }

        /// <summary>
        /// 获取颗粒库存导出信息
        /// </summary>
        /// <returns></returns>
        public List<ParticlesStockExcelModel> GetParticlesStock()
        {
            string sql = @" select a.MedicineCabinetId,a.ParticlesID,b.Code,b.Name as ParName,a.Stock 
                            from MedicineCabinetDetail as a
                            left join ParticlesInfo as b on a.ParticlesID=b.ID
                            left join MedicineCabinetInfo as c on c.ID=a.MedicineCabinetId
                            where a.ParticlesID is not null and a.ParticlesID>0 and c.Code='"+SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode+"' ";
            return DBHelper.ExecuteQuery<ParticlesStockExcelModel>(sql);
        }

        /// <summary>
        /// 批量更新药柜详情信息
        /// </summary>
        /// <param name="medicineCabinetDetailList"></param>
        /// <returns></returns>
        public string UpdateRangeCabinetDetails(List<MedicineCabinetDetail> medicineCabinetDetailList)
        {
            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    _eFCoreContext.MedicineCabinetDetails.UpdateRange(medicineCabinetDetailList);
                    _eFCoreContext.SaveChanges();

                    dbContextTransaction.Commit();
                    return "";
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    return e.Message;
                }
            }
        }

        /// <summary>
        /// 添加颗粒库存
        /// </summary>
        /// <param name="par">颗粒</param>
        /// <param name="med">药柜</param>
        /// <param name="mcol">药柜颗粒操作记录</param>
        /// <returns></returns>
        public string AddParticleNum(ParticlesInfo par, MedicineCabinetDetail med, MedicineCabinetOperationLogInfo mcol)
        {
            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    if (med!=null)
                    {
                        _eFCoreContext.MedicineCabinetDetails.Update(med);
                    }
                    if (par!=null)
                    {
                        _eFCoreContext.ParticlesInfos.Update(par);
                    }
                    if (mcol!=null) 
                    {
                        _eFCoreContext.MedicineCabinetOperationLogInfos.Add(mcol);
                    }
                    
                    _eFCoreContext.SaveChanges();

                    dbContextTransaction.Commit();
                    return "";
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    return e.Message;
                }
            }
        }

        /// <summary>
        ///获取药柜详情信息
        /// </summary>
        /// <param name="id">id主键</param>
        /// <returns></returns>
        public MedicineCabinetDetail GetMedicineCabinetDetail(int id) 
        {
            var mcd= _eFCoreContext.MedicineCabinetDetails.FirstOrDefault(x => x.ID == id);
            return mcd;
        }

        /// <summary>
        /// 获取药柜颗粒操作日志分页列表
        /// </summary>
        public MedicineCabinetOperationLogByPage GetMedicineCabinetOperationLogByPage(MedicineCabinetOperationLogTypeEnum? type, string parName, DateTime? sdate, DateTime? edate, int pageIndex, int pageSize, out int count) 
        {
           
            string whereStr = " where 1=1 ";
            if (type.HasValue) 
            {
                whereStr += $" and MedicineCabinetOperationLogType={type} ";
            }
            if (!string.IsNullOrEmpty(parName)) 
            {
                whereStr += $" and ParticleName like '{parName}%' ";
            }
            if (sdate.HasValue) 
            {
                whereStr += $" and CreateTime >= '{sdate.Value.Date}' ";
            }
            if (edate.HasValue)
            {
                whereStr += $" and CreateTime < '{edate.Value.Date.AddDays(1)}' ";
            }

            string countSql = " select count(1) from  MedicineCabinetOperationLogInfo " + whereStr;
            count = Convert.ToInt32(DBHelper.ExecuteScalar(countSql));
            if (count <= 0)
            {
                return null;
            }

            string sumSql = $@" SELECT 
                                   sum([UsedQuantity]) as UsedQuantitySum
                                  ,sum([AddQuantity]) as AddQuantitySum
                                  ,sum([AdjustmentQuantity]) as AdjustmentQuantitySum
                             FROM [MedicineCabinetOperationLogInfo]   {whereStr}";

            MedicineCabinetOperationLogByPage model = DBHelper.ExecuteQueryOne<MedicineCabinetOperationLogByPage>(sumSql);

            string pageListSql = $@" SELECT 
                                   [ParticleCode]
                                  ,[ParticleName]
                                  ,[MedicineCabinetOperationLogType]
                                  ,[DeviceName]
                                  ,[OperationLogDecribe]
                                  ,[InitialQuantity]
                                  ,[CurrentWeightQuantity]
                                  ,[UsedQuantity]
                                  ,[AddQuantity]
                                  ,[AdjustmentQuantity]
                                  ,[CreateTime]
                                  ,[CreateName]
                                  ,[ParticleId]
                             FROM [AdjustmentSysDB].[dbo].[MedicineCabinetOperationLogInfo] where 1=1 {whereStr}
                             OFFSET {pageSize * (pageIndex - 1)} ROW FETCH NEXT {pageSize} ROWS ONLY " ;

  

            model.mcParticLogs = DBHelper.ExecuteQuery<McParticLog>(pageListSql);

            return model;

        }

        /// <summary>
        /// 获取药品使用统计数据
        /// </summary>
        public List<ParticleUsedStatistics> GetParticleUsedStatistics(string name,DateTime? stime,DateTime? etime)
        {
            string whereString = " where MedicineCabinetOperationLogType=2 and MedicineCabinetCode='"+SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode+"' ";
            if (!string.IsNullOrEmpty(name)) 
            {
                whereString += " and ParticleName like '" + name + "%'";
            }
            if (stime.HasValue)
            {
                whereString += $" and CreateTime >= '{stime.Value.Date}' ";
            }
            if (etime.HasValue)
            {
                whereString += $" and CreateTime < '{etime.Value.Date.AddDays(1)}' ";
            }
            string sql = $@" SELECT ParticleName,
                                    SUM(isnull(UsedQuantity,0)) as UseAmount,
                                    COUNT(ParticleName) as UseCount
                            FROM [dbo].[MedicineCabinetOperationLogInfo]
                            {whereString}
                            GROUP BY ParticleName
                            ";
            var datails = DBHelper.ExecuteQuery<ParticleUsedStatistics>(sql);
            return datails;
        }
    }
}
