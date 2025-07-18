﻿using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Drug;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdjustmentSys.DAL.Drug
{
    /// <summary>
    /// 药品管理数据库操作
    /// </summary>
    public class DrugManagermentDAL
    {
        private readonly EFCoreContext _eFCoreContext = new EFCoreContext();

        /// <summary>
        /// 新增或编辑药品
        /// </summary>
        /// <returns></returns>
        public string AddOrEditDrugInfo(ParticlesInfoEditModel drugInfo)
        {
            string error = "";
            ParticlesInfo particlesInfo = new ParticlesInfo();
            particlesInfo.Code = drugInfo.Code;
            #region 逻辑校验
            if (drugInfo.ID != default(int))//编辑
            {
                bool isExitDrug = _eFCoreContext.ParticlesInfos.Any(x => (x.Name == drugInfo.Name || x.Code == drugInfo.Code) && x.ID != drugInfo.ID);
                if (isExitDrug)
                {
                    return "该药品名称或编号已存在";
                }

                particlesInfo = _eFCoreContext.ParticlesInfos.FirstOrDefault(x => x.ID == drugInfo.ID);
                if (particlesInfo == null)
                {
                    return "未找到要编辑的药品信息，请刷新后再试";
                }
            }
            else//新增
            {
                bool isExitDrug = _eFCoreContext.ParticlesInfos.AsNoTracking().Any(x => x.Name == drugInfo.Name || x.Code == drugInfo.Code);
                if (isExitDrug)
                {
                    return "该药品名称或编号已存在";
                }
                int maxCode= _eFCoreContext.ParticlesInfos.Max(x => x.Code);
                if (maxCode > 0)
                {
                    particlesInfo.Code = maxCode+1;
                }
                else
                {
                    particlesInfo.Code = 806001;
                }
               
            } 
            #endregion

            #region 字段赋值
            //赋值字典
            particlesInfo.Name = drugInfo.Name;
            particlesInfo.FullName = drugInfo.FullName;
            
            particlesInfo.NameFullPinyin = drugInfo.NameFullPinyin;
            particlesInfo.NameSimplifiedPinyin = drugInfo.NameSimplifiedPinyin;
            particlesInfo.ManufacturerId = drugInfo.ManufacturerId;
            particlesInfo.ListingNumber = drugInfo.ListingNumber;
            particlesInfo.Remark = drugInfo.Remark;
            particlesInfo.UpdateTime = DateTime.Now;
            particlesInfo.UpdateBy = SysLoginUser._currentUser.UserId;
            particlesInfo.UpdateName = SysLoginUser._currentUser.UserName;

            //赋值字典详情
            particlesInfo.HisCode = drugInfo.HisCode;
            particlesInfo.HisName = drugInfo.HisName;
            particlesInfo.Density = drugInfo.Density;
            var dc = _eFCoreContext.ManufacturerInfos.FirstOrDefault(x => x.ID == drugInfo.ManufacturerId)?.DensityCoefficient;
            particlesInfo.DensityCoefficient = dc.HasValue?dc.Value:1;
            particlesInfo.Equivalent = drugInfo.Equivalent;
            particlesInfo.DoseLimit = drugInfo.DoseLimit;
            particlesInfo.WholesalePrice = drugInfo.WholesalePrice;
            particlesInfo.RetailPrice = drugInfo.RetailPrice;
            particlesInfo.PackageNumber = drugInfo.PackageNumber;
            //particlesInfoExtend.BatchNumber = drugInfo.BatchNumber;
            //particlesInfoExtend.VaildUntil = drugInfo.VaildUntil;

            //日志
            ParticleOperationLogInfo particleOperationLogInfo = new ParticleOperationLogInfo();

            particleOperationLogInfo.ParticleOperationLogType = particlesInfo.ID != default(int)? ParticleOperationLogTypeEnum.编辑药品: ParticleOperationLogTypeEnum.新增药品;
            particleOperationLogInfo.OperationLogDecribe = particlesInfo.ID != default(int) ? "编辑药品": "新增药品";

            particleOperationLogInfo.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
            particleOperationLogInfo.ParticleName = particlesInfo.Name;

            particleOperationLogInfo.ParticleCode = particlesInfo.Code.ToString();
            particleOperationLogInfo.CreateBy = SysLoginUser._currentUser.UserId;
            particleOperationLogInfo.CreateName = SysLoginUser._currentUser.UserName;
            particleOperationLogInfo.CreateTime = DateTime.Now;
            #endregion

            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    if (drugInfo.ID != default(int))
                    {
                        _eFCoreContext.ParticlesInfos.Update(particlesInfo);
                    }
                    else 
                    {
                        //追加创建信息
                        
                        particlesInfo.CreateTime = DateTime.Now;
                        particlesInfo.CreateBy = SysLoginUser._currentUser.UserId;
                        particlesInfo.CreateName = SysLoginUser._currentUser.UserName;

                        _eFCoreContext.ParticlesInfos.Add(particlesInfo);
                    }
                    _eFCoreContext.ParticleOperationLogInfos.Add(particleOperationLogInfo);
                    _eFCoreContext.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    error =(drugInfo.ID>0?"编辑":"新增")+ "药品信息失败,请稍后再试";
                }
            }

            return error;
        }

        /// <summary>
        /// 删除药品
        /// </summary>
        public string DeleteDrugInfo(int id)
        {
            var drug = _eFCoreContext.ParticlesInfos.AsNoTracking().FirstOrDefault(x => x.ID == id);
            if (drug == null)
            {
                return "要删除的药品信息不存在，请刷新列表后再试";
            }
            var isUsed = _eFCoreContext.MedicineCabinetDetails.AsNoTracking().Any(x => x.ParticlesID == id);
            if (isUsed)
            {
                return "要删除的药品已在药柜上架，请下架后再删除";
            }
            string errorMsg = "";

            ParticleOperationLogInfo particleOperationLogInfo = new ParticleOperationLogInfo();

            particleOperationLogInfo.ParticleOperationLogType = ParticleOperationLogTypeEnum.删除药品;
            particleOperationLogInfo.OperationLogDecribe = "删除药品";

            particleOperationLogInfo.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
            particleOperationLogInfo.ParticleName = drug.Name;

            particleOperationLogInfo.ParticleCode = drug.Code.ToString();
            particleOperationLogInfo.CreateBy = SysLoginUser._currentUser.UserId;
            particleOperationLogInfo.CreateName = SysLoginUser._currentUser.UserName;
            particleOperationLogInfo.CreateTime = DateTime.Now;

            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    _eFCoreContext.ParticleProhibitionRules.Where(x => x.FirstParticlesID == id || x.SecondParticlesID == id).ExecuteDelete();
                    _eFCoreContext.ParticlesInfos.Where(x => x.ID == id).ExecuteDelete();
                    _eFCoreContext.DataPrescriptionDetails.Where(x => x.ParticlesID == id).ExecuteDelete();
                    _eFCoreContext.ParticleOperationLogInfos.Add(particleOperationLogInfo);
                    _eFCoreContext.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    errorMsg = "删除药品信息失败,请稍后再试";
                }
            }

            return errorMsg;
        }

        /// <summary>
        /// 根据药品ID，获取药品信息
        /// </summary>
        /// <param name="id">药品id</param>
        /// <returns></returns>
        public ParticlesInfoEditModel GetDrugInfo(int id)
        {
            var model = (from a in _eFCoreContext.ParticlesInfos
                         where a.ID == id
                         select new ParticlesInfoEditModel()
                         {
                             ID = a.ID,
                             Name = a.Name,
                             FullName = a.FullName,
                             Code = a.Code,
                             NameSimplifiedPinyin = a.NameSimplifiedPinyin,
                             NameFullPinyin = a.NameFullPinyin,
                             ListingNumber = a.ListingNumber,
                             ManufacturerId = a.ManufacturerId,
                             Remark = a.Remark,
                             HisCode=a.HisCode,
                             HisName=a.HisName,
                             Density=a.Density,
                             Equivalent=a.Equivalent,
                             DoseLimit=a.DoseLimit,
                             PackageNumber=a.PackageNumber,
                             //BatchNumber=b.BatchNumber,
                             //VaildUntil=b.VaildUntil,
                             RetailPrice=a.RetailPrice,
                             WholesalePrice=a.WholesalePrice
                         }).FirstOrDefault();
            return model;
        }

        /// <summary>
        /// 药品列表查询
        /// </summary>
        /// <param name="keywords">名称/拼音码</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        public  List<ParticlesPageListModel> GetDrugInfoByPage(string? keywords, int pageIndex, int pageSize, out int count)
        {
            var where = _eFCoreContext.ParticlesInfos.AsNoTracking()
                .Where(x => 1==1);

            //关键字条件
            if (!string.IsNullOrEmpty(keywords))
            {
                where = where.Where(x => (x.NameSimplifiedPinyin.Contains(keywords.ToUpper()) || x.Name.Contains(keywords) || x.FullName.Contains(keywords)));
            }

            //统计总记录数
            count = where.Count();
            if (count == 0)
            {
                return null;
            }
            
            //结果按照名称简称升序排序
            where = where.OrderBy(x => x.NameSimplifiedPinyin);

            //跳过翻页的数量
            var list = where.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();

            //获取结果，返回
            List<ParticlesPageListModel> resultList = new List<ParticlesPageListModel>();

            //获取厂家
            var manufacturers = _eFCoreContext.ManufacturerInfos.AsNoTracking().ToList();

            list.ForEach(item => {
                var model = new ParticlesPageListModel();
                model.ID = item.ID;
                model.Name = item.Name;
                model.FullName = item.FullName;
                model.Code = item.Code;
                model.NameFullPinyin = item.NameFullPinyin;
                model.NameSimplifiedPinyin = item.NameSimplifiedPinyin;
                model.ListingNumber = item.ListingNumber;
                model.Remark = item.Remark;
                model.UpdateName = item.UpdateName;
                model.UpdateTime = item.UpdateTime;
                if (manufacturers!=null && manufacturers.Count>0) 
                {
                    model.ManufacturerName = manufacturers.FirstOrDefault(x => x.ID == item.ManufacturerId)?.Name;
                }
                model.Density = item.Density;
                model.Equivalent = item.Equivalent;
                model.DoseLimit = item.DoseLimit;
                model.WholesalePrice = item.WholesalePrice;
                model.RetailPrice = item.RetailPrice;
                model.PackageNumber = item.PackageNumber;
                model.HisCode = item.HisCode;
                model.HisName = item.HisName;
                   
                resultList.Add(model);
            });

            return resultList;
        }

        /// <summary>
        /// 获取药品操作记录分页列表数据
        /// </summary>
        public List<ParticleOperationLogInfo> GetDurgLogByPage(ParticleOperationLogTypeEnum? type,string parName,DateTime? sdate,DateTime? edate, int pageIndex, int pageSize, out int count) 
        {
            var where = _eFCoreContext.ParticleOperationLogInfos.AsNoTracking()
                .Where(x => 1 == 1);

            if (type.HasValue) 
            {
                where = where.Where(x => (x.ParticleOperationLogType == type));
            }
            //药品名称条件
            if (!string.IsNullOrEmpty(parName))
            {
                where = where.Where(x => (x.ParticleName.Contains(parName.ToUpper())));
            }
            if (sdate.HasValue)
            {
                where = where.Where(x => (x.CreateTime>=sdate));
            }
            if (edate.HasValue)
            {
                where = where.Where(x => (x.CreateTime < edate));
            }
            //统计总记录数
            count = where.Count();
            if (count == 0)
            {
                return null;
            }

            //结果按照名称简称升序排序
            where = where.OrderByDescending(x => x.CreateTime);

            //跳过翻页的数量
            var list = where.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();

            return list;
        }
        /// <summary>
        /// 根据厂商id获取解码规则
        /// </summary>
        /// <param name="manufacturerId"></param>
        /// <returns></returns>
        public List<ManufacturerResolutionCode> GetManufacturerCodes(int manufacturerId) 
        {
           return _eFCoreContext.ManufacturerResolutionCodes.Where(x => x.ManufacturerId == manufacturerId).ToList();
        }

        /// <summary>
        /// 获取导出的excel数据
        /// </summary>
        /// <returns></returns>
        public List<ParticlesExportModel> ParticlesExports()
        {
            string sql = @" select  a.Name as ParName,
                                    a.FullName,
                                    a.Code,
                                    a.NameFullPinyin,
                                    a.NameSimplifiedPinyin,
                                    a.ManufacturerId,
                                    c.Name as ManufacturerName,
                                    a.ListingNumber,
                                    a.Remark,
                                    a.HisCode,
                                    a.HisName,
                                    a.Density,
                                    a.Equivalent,
                                    a.DoseLimit,
                                    a.PackageNumber,
                                    a.RetailPrice,
                                    a.WholesalePrice
                            from ParticlesInfo as a
                            left join ManufacturerInfo as c on a.ManufacturerId=c.ID
                            order by a.NameSimplifiedPinyin ";
            return DBHelper.ExecuteQuery<ParticlesExportModel>(sql);
        }

        /// <summary>
        /// 获取最大的颗粒ID
        /// </summary>
        /// <returns></returns>
        public int Maxid() 
        {
            return _eFCoreContext.ParticlesInfos.Max(x => x.ID);
        }

        public List<ParticlesInfo> GetAllParticlesInfos() 
        {
            return _eFCoreContext.ParticlesInfos.ToList();
        }
        /// <summary>
        /// 批量保存颗粒信息
        /// </summary>
        public string ImportPars(List<ParticlesInfo> particlesInfoList) 
        {
            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    _eFCoreContext.ParticlesInfos.AddRange(particlesInfoList);
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
        /// 批量更新药品信息
        /// </summary>
        /// <param name="particlesInfoList"></param>
        /// <returns></returns>
        public string UpdateImportPars(List<ParticlesInfo> particlesInfoList)
        {
            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    _eFCoreContext.ParticlesInfos.UpdateRange(particlesInfoList);
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
        /// 根据名称或厂家id获取颗粒信息
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="manId">厂家id</param>
        /// <returns></returns>
        public List<DensityCoefficientSetModel> GetParticlesByNameOrManufacturerId(string? name,int? manId) 
        {
            var query = _eFCoreContext.ParticlesInfos.AsQueryable();
                
            if (!string.IsNullOrEmpty(name)) 
            {
                query= query.Where(x => x.Name.StartsWith(name) || x.NameSimplifiedPinyin.StartsWith(name.ToUpper()));
            }
            if (manId.HasValue) 
            {
                query = query.Where(x=>x.ManufacturerId==manId.Value);
            }

            query= query.OrderBy(x=>x.NameSimplifiedPinyin);

            var dataList = query.Select(x=>new DensityCoefficientSetModel() 
            {
                ID = x.ID,
                ParName = x.Name,
                Code=x.Code,
                ManufacturerID = x.ManufacturerId,
                DensityCoefficient = x.DensityCoefficient,
                Density=x.Density,
            
            }).ToList();

            return dataList;
        }

        /// <summary>
        /// 批量修改颗粒密度系数
        /// </summary>
        /// <param name="particlesInfoList">颗粒对象</param>
        /// <param name="medicineCabinetDetails">药柜详情对象</param>
        /// <returns></returns>
        public string UpdateParticlesDensityCoefficient(List<ParticlesInfo> particlesInfoList, List<MedicineCabinetDetail> medicineCabinetDetails) 
        {
            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    //取消跟踪实体对象
                    _eFCoreContext.ChangeTracker.Clear();
                    _eFCoreContext.ParticlesInfos.UpdateRange(particlesInfoList);
                    if (medicineCabinetDetails!=null && medicineCabinetDetails.Count>0)
                    {
                        //foreach (var entity in medicineCabinetDetails)
                        //{
                            
                        //    _eFCoreContext.Update(entity);
                        //}
                        _eFCoreContext.MedicineCabinetDetails.UpdateRange(medicineCabinetDetails);
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
        /// 更新药品his信息
        /// </summary>
        /// <param name="parid">药品id</param>
        /// <param name="hiscode">his编号</param>
        /// <param name="hisname">his名称</param>
        /// <returns></returns>
        public string UpdateParticleHisCode(int parid, string hiscode, string hisname)
        {
            var par = _eFCoreContext.ParticlesInfos.FirstOrDefault(x => x.ID == parid);
            if (par == null) 
            {
                return "未查找到药品信息";
            }

            par.HisCode = hiscode;
            par.HisName = hisname;

            _eFCoreContext.ParticlesInfos.Update(par);
            return "";
        }
    }
}
