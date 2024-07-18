using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
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
    public class DrugManufacturerDAL
    {
        private readonly EFCoreContext _eFCoreContext = new EFCoreContext();

        /// <summary>
        /// 新增或编辑厂家
        /// </summary>
        /// <returns></returns>
        public string AddOrEditManufacturerInfo(ManufacturerInfo manInfo)
        {
            string error = "";
            try
            {
                if (manInfo.ID != default(int))
                {
                    bool isExitMan = _eFCoreContext.ManufacturerInfos.Any(x =>!x.IsDelete && x.Name == manInfo.Name && x.ID != manInfo.ID);
                    if (isExitMan)
                    {
                        return "该厂家名称已存在";
                    }

                    isExitMan = _eFCoreContext.ManufacturerInfos.Any(x => !x.IsDelete && x.Sort == manInfo.Sort && x.ID != manInfo.ID);
                    if (isExitMan)
                    {
                        return "序号不能与已有厂家序号重复";
                    }

                    var man = _eFCoreContext.ManufacturerInfos.FirstOrDefault(x => x.ID == manInfo.ID);
                    if (man == null)
                    {
                        return "未找到要编辑的厂家信息，请刷新后再试";
                    }
                    man.Name = manInfo.Name;
                    man.Sort = manInfo.Sort;
                    man.UpdateTime = manInfo.UpdateTime;
                    man.UpdateBy = manInfo.UpdateBy;
                    man.UpdateName = manInfo.UpdateName;
                    //可省略
                    //_eFCoreContext.ManufacturerInfos.Update(manInfo);
                }
                else
                {
                    bool isExitMan = _eFCoreContext.ManufacturerInfos.Any(x => !x.IsDelete && x.Name == manInfo.Name);
                    if (isExitMan)
                    {
                        return "该厂家名称已存在";
                    }
                    isExitMan = _eFCoreContext.ManufacturerInfos.Any(x => !x.IsDelete && x.Sort == manInfo.Sort);
                    if (isExitMan)
                    {
                        return "序号不能与已有厂家序号重复";
                    }
                    _eFCoreContext.ManufacturerInfos.Add(manInfo);
                }

                var result = _eFCoreContext.SaveChanges();
                if (result <= 0)
                {
                    error = (manInfo.ID > 0 ? "编辑" : "新增") + "厂家信息失败，请稍后再试。";
                }
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return error;
        }

        /// <summary>
        /// 启用厂家
        /// </summary>
        public string DeleteManufacturerInfo(int id,bool isdelete)
        {
            string typeStr = isdelete ? "启用" : "禁用";
            var manufacturerInfo = _eFCoreContext.ManufacturerInfos.FirstOrDefault(x => x.ID == id);
            if (manufacturerInfo == null)
            {
                return $"要{typeStr}的厂家信息不存在，请刷新列表后再试";
            }
            
            manufacturerInfo.IsDelete = isdelete;
            manufacturerInfo.DeleteTime = DateTime.Now;
            manufacturerInfo.DeleteBy = SysLoginUser._currentUser.UserId;
            manufacturerInfo.DeleteName = SysLoginUser._currentUser.UserName;

            _eFCoreContext.ManufacturerInfos.Update(manufacturerInfo);

            int index = _eFCoreContext.SaveChanges();

            return index > 0 ? "" : $"{typeStr}厂家信息失败,请稍后再试";
        }

        /// <summary>
        /// 厂家列表查询
        /// </summary>
        /// <param name="keywords">名称/拼音码</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        public List<ManufacturerPageListModel> GetManufacturerByPage(int pageIndex, int pageSize, out int count)
        {
            var where = _eFCoreContext.ManufacturerInfos.AsNoTracking();
                //.Where(x => !x.IsDelete);
            //统计总记录数
            count = where.Count();

            if (count == 0)
            {
                return null;
            }

            //结果按照序号升序排序
            where = where.OrderBy(x => x.Sort);

            //跳过翻页的数量
            var list = where.Skip(pageSize * (pageIndex - 1)).Take(pageSize)
                .Select(x=>new ManufacturerPageListModel() 
                {
                    ID = x.ID,
                    Name=x.Name,
                    Sort=x.Sort,
                    IsDelete=x.IsDelete,
                    CreateName=x.CreateName,
                    CreateTime=x.CreateTime,
                    UpdateName=x.UpdateName,
                    UpdateTime=x.UpdateTime
                }).ToList();

            return list;
        }

        /// <summary>
        /// 根据厂家id获取厂家解析码信息
        /// </summary>
        /// <param name="id">厂家id</param>
        /// <returns></returns>
        public List<ComboxModel> GetCodesByManufacturerId(int id) 
        {
           return _eFCoreContext.ManufacturerResolutionCodes.Where(x => x.ManufacturerId == id)
                .Select(x=>new ComboxModel() { Id=x.ID,Name=x.ExampleCode })
                .ToList();
        }

        /// <summary>
        /// 根据厂家解析码id获取解析码数据
        /// </summary>
        /// <param name="id">厂家解析码id</param>
        /// <returns></returns>
        public ManufacturerResolutionCode GetCodesById(int id)
        {
            return _eFCoreContext.ManufacturerResolutionCodes.FirstOrDefault(x => x.ID == id);
        }

        /// <summary>
        /// 新增或编辑解析码
        /// </summary>
        /// <param name="code">解析码规则</param>
        /// <returns></returns>
        public string AddOrEditManufacturerResolutionCode(ManufacturerResolutionCode code)
        {

            string error = "";
            try
            {
                if (code.ID != default(int))
                {
                    bool isExitCode = _eFCoreContext.ManufacturerResolutionCodes.Any(x => x.ManufacturerId==code.ManufacturerId && x.ExampleCode.Length==code.ExampleCode.Length && x.ID!=code.ID);
                    if (isExitCode)
                    {
                        return "该厂家已存在长度为"+code.ExampleCode.Length+"的解析规则码";
                    }
                    var model = _eFCoreContext.ManufacturerResolutionCodes.FirstOrDefault(x => x.ID == code.ID);
                    if (model == null)
                    {
                        return "未找到要编辑的厂家解析码规则信息，请刷新后再试";
                    }
                    model.ExampleCode = code.ExampleCode;
                    model.LargePackagingCodeIndex = code.LargePackagingCodeIndex;
                    model.LargePackagingCodeLength = code.LargePackagingCodeLength;

                    model.PackagingTypeIndex = code.PackagingTypeIndex;
                    model.PackagingTypeLength = code.PackagingTypeLength;

                    model.BatchNumberIndex = code.BatchNumberIndex;
                    model.BatchNumberLength = code.BatchNumberLength;

                    model.ValidityPeriodIndex = code.ValidityPeriodIndex;
                    model.ValidityPeriodLength = code.ValidityPeriodLength;

                    model.EquivalentIndex = code.EquivalentIndex;
                    model.EquivalentLength = code.EquivalentLength;

                    model.DensityIndex = code.DensityIndex;
                    model.DensityLength = code.DensityLength;

                    model.LoadingCapacityIndex = code.LoadingCapacityIndex;
                    model.LoadingCapacityLength = code.LoadingCapacityLength;
                    model.UpdateTime = code.UpdateTime;
                    model.UpdateBy = code.UpdateBy;
                    model.UpdateName = code.UpdateName;
                    //可省略
                    _eFCoreContext.ManufacturerResolutionCodes.Update(model);
                }
                else
                {
                    bool isExitCode = _eFCoreContext.ManufacturerResolutionCodes.AsNoTracking().Any(x => x.ManufacturerId == code.ManufacturerId && x.ExampleCode.Length == code.ExampleCode.Length);
                    if (isExitCode)
                    {
                        return "该厂家已存在长度为" + code.ExampleCode.Length + "的解析规则码";
                    }
                    
                    _eFCoreContext.ManufacturerResolutionCodes.Add(code);
                }

                var result = _eFCoreContext.SaveChanges();
                if (result <= 0)
                {
                    error = (code.ID > 0 ? "编辑" : "新增") + "厂家解析码规则信息失败，请稍后再试。";
                }
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return error;
        }


    }
}
