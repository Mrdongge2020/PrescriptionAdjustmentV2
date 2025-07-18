﻿using AdjustmentSys.DAL.Common;
using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Models.SystemSetting;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
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


        /// <summary>
        /// 修改配置config的值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="datavalue">值</param>
        /// <returns></returns>
        public string UpdateConfigValue(string name,string datavalue) 
        {
            string error = "";
            try
            {
                var config = _eFCoreContext.ConfigInfos.FirstOrDefault(x => x.ChineseName == name && x.DeviceId == SysDeviceInfo.currentDeviceInfo.DeviceId);
                if (config != null)
                {
                    config.DataValue = datavalue;
                    _eFCoreContext.ConfigInfos.Update(config);
                    _eFCoreContext.SaveChanges();
                    OperateLog.WriteLog(LogTypeEnum.用户操作, $"{SysLoginUser.currentUser.UserName}修改配置表的【{config.ChineseName}】值为【{datavalue}】");
                }
                else
                {
                    error = $"系统中未找到配置参数【{name}】";
                }

               
            }
            catch (Exception e)
            {
                OperateLog.WriteLog(LogTypeEnum.数据库, $"{SysLoginUser.currentUser.UserName}修改配置表的【{name}】值为【{datavalue}】出错，原因："+e.Message);
                error = e.Message;
            }
            return error;
            
        }

        /// <summary>
        /// 修改打印选项的值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="datavalue">值</param>
        /// <returns></returns>
        public string UpdatePrintConfigValue(string name, string datavalue)
        {
            string error = "";
            try
            {
                var config = _eFCoreContext.PrintConfigInfos.FirstOrDefault(x => x.ItemChineseName == name && x.DeviceId == SysDeviceInfo.currentDeviceInfo.DeviceId);
                if (config != null)
                {
                    config.DataValue = datavalue;
                    _eFCoreContext.PrintConfigInfos.Update(config);
                    _eFCoreContext.SaveChanges();
                    OperateLog.WriteLog(LogTypeEnum.用户操作, $"{SysLoginUser.currentUser.UserName}修改配置表的【{config.ItemChineseName}】值为【{datavalue}】");
                }
                else
                {
                    error = $"系统中未找到配置参数【{name}】";
                }


            }
            catch (Exception e)
            {
                OperateLog.WriteLog(LogTypeEnum.数据库, $"{SysLoginUser.currentUser.UserName}修改配置表的【{name}】值为【{datavalue}】出错，原因：" + e.Message);
                error = e.Message;
            }
            return error;

        }

        /// <summary>
        /// 修改打印配置config的值
        /// </summary>
        /// <returns></returns>
        public string UpdatePrintItemValue(string name,double?  sort,string title,int? checkvalue)
        {
            string error = "";
            string msg = "";
            try
            {
                var config = _eFCoreContext.PrintItemInfos.FirstOrDefault(x => x.ItemChineseName == name && x.DeviceId == SysDeviceInfo.currentDeviceInfo.DeviceId);
               
                if (config != null)
                {
                    if (sort.HasValue)
                    {
                        config.Sort = sort.Value;
                        msg += $"【sort】值为【{sort.Value}】";
                    }
                    if (title != null)
                    {
                        config.Title = title;
                        msg += $"【title】值为【{title}】";
                    }
                    if (checkvalue.HasValue)
                    {
                        config.CheckedValue = checkvalue.Value;
                        msg += $"【CheckedValue】值为【{checkvalue.Value}】";
                    }
                    _eFCoreContext.PrintItemInfos.Update(config);
                    _eFCoreContext.SaveChanges();
                    OperateLog.WriteLog(LogTypeEnum.用户操作, $"{SysLoginUser.currentUser.UserName}修改配置表的{name}-{msg}");
                    _eFCoreContext.SaveChanges();
                    return error;
                }
                else 
                {
                    error = $"系统中未找到打印项【{name}】";
                }
            }
            catch (Exception e)
            {
                OperateLog.WriteLog(LogTypeEnum.数据库, $"{SysLoginUser.currentUser.UserName}修改配置表的{name}-{msg}出错，原因：" + e.Message);
                error = e.Message;
            }
            return error;

        }


    }
}
