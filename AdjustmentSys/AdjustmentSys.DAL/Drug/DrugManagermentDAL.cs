using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Drug;
using AdjustmentSys.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ParticlesInfoExtend particlesInfoExtend = new ParticlesInfoExtend();

            #region 逻辑校验
            if (drugInfo.ID != default(int))//编辑
            {
                bool isExitDrug = _eFCoreContext.ParticlesInfos.Any(x => (x.Name == drugInfo.Name || x.Code == drugInfo.Code) && x.ID != drugInfo.ID);
                if (isExitDrug)
                {
                    return "该药品名称或编号已存在";
                }

                particlesInfo = _eFCoreContext.ParticlesInfos.FirstOrDefault(x => x.ID == drugInfo.ID);
                particlesInfoExtend = _eFCoreContext.ParticlesInfoExtends.FirstOrDefault(x => x.ParticlesID == drugInfo.ID);
                if (particlesInfo == null || particlesInfoExtend == null)
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
            } 
            #endregion

            #region 字段赋值
            //赋值字典
            particlesInfo.Name = drugInfo.Name;
            particlesInfo.FullName = drugInfo.FullName;
            particlesInfo.Code = drugInfo.Code;
            particlesInfo.NameFullPinyin = drugInfo.NameFullPinyin;
            particlesInfo.NameSimplifiedPinyin = drugInfo.NameSimplifiedPinyin;
            particlesInfo.ManufacturerId = drugInfo.ManufacturerId;
            particlesInfo.ListingNumber = drugInfo.ListingNumber;
            particlesInfo.Remark = drugInfo.Remark;
            particlesInfo.UpdateTime = DateTime.Now;
            particlesInfo.UpdateBy = SysLoginUser._currentUser.UserId;
            particlesInfo.UpdateName = SysLoginUser._currentUser.UserName;

            //赋值字典详情
            particlesInfoExtend.HisCode = drugInfo.HisCode;
            particlesInfoExtend.HisName = drugInfo.HisName;
            particlesInfoExtend.Density = drugInfo.Density;
            particlesInfoExtend.Equivalent = drugInfo.Equivalent;
            particlesInfoExtend.DoseLimit = drugInfo.DoseLimit;
            particlesInfoExtend.WholesalePrice = drugInfo.WholesalePrice;
            particlesInfoExtend.RetailPrice = drugInfo.RetailPrice;
            particlesInfoExtend.PackageNumber = drugInfo.PackageNumber;
            //particlesInfoExtend.BatchNumber = drugInfo.BatchNumber;
            //particlesInfoExtend.VaildUntil = drugInfo.VaildUntil;
           
            #endregion

            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    if (drugInfo.ID != default(int))
                    {
                        _eFCoreContext.ParticlesInfos.Update(particlesInfo);
                        _eFCoreContext.ParticlesInfoExtends.Update(particlesInfoExtend);
                    }
                    else 
                    {
                        //追加创建信息
                        
                        particlesInfo.CreateTime = DateTime.Now;
                        particlesInfo.CreateBy = SysLoginUser._currentUser.UserId;
                        particlesInfo.CreateName = SysLoginUser._currentUser.UserName;

                        _eFCoreContext.ParticlesInfos.Add(particlesInfo);
                        _eFCoreContext.SaveChanges();
                        particlesInfoExtend.ParticlesID = particlesInfo.ID;
                        _eFCoreContext.ParticlesInfoExtends.Add(particlesInfoExtend);
                    }

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
            
            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    _eFCoreContext.ParticleProhibitionRules.Where(x => x.FirstParticlesID == id || x.SecondParticlesID == id).ExecuteDelete();
                    _eFCoreContext.ParticlesInfos.Where(x => x.ID == id).ExecuteDelete();
                    _eFCoreContext.DataPrescriptionDetails.Where(x => x.ParticlesID == id).ExecuteDelete();
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
                         join b in _eFCoreContext.ParticlesInfoExtends on a.ID equals b.ParticlesID
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
                             HisCode=b.HisCode,
                             HisName=b.HisName,
                             Density=b.Density,
                             Equivalent=b.Equivalent,
                             DoseLimit=b.DoseLimit,
                             PackageNumber=b.PackageNumber,
                             //BatchNumber=b.BatchNumber,
                             //VaildUntil=b.VaildUntil,
                             RetailPrice=b.RetailPrice,
                             WholesalePrice=b.WholesalePrice
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
            if (!String.IsNullOrEmpty(keywords))
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
            List<int> ids = list.Select(x => x.ID).ToList();

            var extend= _eFCoreContext.ParticlesInfoExtends.AsNoTracking().Where(x=>ids.Contains(x.ParticlesID)).ToList();

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

                //扩展信息赋值
                var currentExtend = extend.FirstOrDefault(x => x.ParticlesID == item.ID);
                if (currentExtend!=null) 
                {
                    model.Density = currentExtend.Density;
                    model.Equivalent = currentExtend.Equivalent;
                    model.DoseLimit = currentExtend.DoseLimit;
                    model.WholesalePrice = currentExtend.WholesalePrice;
                    model.RetailPrice = currentExtend.RetailPrice;
                    model.PackageNumber = currentExtend.PackageNumber;
                    model.HisCode = currentExtend.HisCode;
                    model.HisName = currentExtend.HisName;
                    //model.BatchNumber = currentExtend.BatchNumber;
                    //model.VaildUntil = currentExtend.VaildUntil;
                }
                
              
                
                resultList.Add(model);
            });

            return resultList;
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
    }
}
