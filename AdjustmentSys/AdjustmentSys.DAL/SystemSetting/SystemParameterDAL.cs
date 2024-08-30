using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.SystemSetting;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.DAL.SystemSetting
{
    public class SystemParameterDAL
    {
        private readonly EFCoreContext _eFCoreContext = new EFCoreContext();

        /// <summary>
        /// 参数列表查询
        /// </summary>
        /// <returns></returns>
        public List<SystemParameterPageModel> GetSystemParameterByPage(ParameterTypeEnum? parameterType, string? parameterDescribe, int pageIndex, int pageSize, out int count)
        {
            var where = _eFCoreContext.SystemParameterInfos.AsNoTracking()
                .Where(user => 1 == 1);

            //参数描述条件
            if (!String.IsNullOrEmpty(parameterDescribe))
            {
                where = where.Where(x => x.ParameterDescribe.Contains(parameterDescribe));
            }

            //类型条件
            if (parameterType.HasValue)
            {
                where = where.Where(x => x.ParameterType == parameterType);
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
            var list = where.Skip(pageSize * (pageIndex - 1)).Take(pageSize)
                .Select(x => new SystemParameterPageModel()
                {
                    ID = x.ID,
                    ParameterName = x.ParameterName,
                    ParameterDescribe = x.ParameterDescribe,
                    ParameterValue = x.ParameterValue,
                    CreateName = x.CreateName,
                    CreateTime = x.CreateTime,
                    UpdateName = x.UpdateName,
                    UpdateTime = x.UpdateTime,
                    ParameterType = x.ParameterType
                }).ToList();
            return list;
        }

        /// <summary>
        /// 获取参数详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SystemParameterInfo GetSystemParameterInfo(int id) 
        { 
            return _eFCoreContext.SystemParameterInfos.AsNoTracking().FirstOrDefault(x=>x.ID == id);
        }

        /// <summary>
        /// 新增或编辑系统参数
        /// </summary>
        public string AddOrEditSystemParameterInfo(SystemParameterInfo systemParameterInfo) 
        {
            string error = "";
            try
            {
                if (systemParameterInfo.ID > 0)
                {
                    _eFCoreContext.SystemParameterInfos.Update(systemParameterInfo);
                }
                else 
                {
                    _eFCoreContext.SystemParameterInfos.Add(systemParameterInfo);
                }
                _eFCoreContext.SaveChanges();
                return error;
            }
            catch (Exception e)
            {
                error= e.Message;
            }
            return error;
        }
    }
}
