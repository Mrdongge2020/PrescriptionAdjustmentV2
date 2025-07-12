using AdjustmentSys.DAL.SystemSetting;
using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Models.SystemSetting;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.SystemSetting
{
    public class SystemParameterBLL
    {
        SystemParameterDAL systemParameterDAL = new SystemParameterDAL();
        /// <summary>
        /// 参数列表查询
        /// </summary>
        /// <returns></returns>
        public List<SystemParameterPageModel> GetSystemParameterByPage(ParameterTypeEnum? parameterType, string? parameterDescribe, int pageIndex, int pageSize, out int count)
        {
            return systemParameterDAL.GetSystemParameterByPage(parameterType,parameterDescribe,pageIndex,pageSize,out count);
        }

        /// <summary>
        /// 获取参数详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SystemParameterInfo GetSystemParameterInfo(int id)
        {
            return systemParameterDAL.GetSystemParameterInfo(id);
        }

        /// <summary>
        /// 新增或编辑系统参数
        /// </summary>
        public string AddOrEditSystemParameterInfo(SystemParameterInfo systemParameterInfo) 
        {
            if (systemParameterInfo.ID <1)
            {
                systemParameterInfo.CreateBy = SysLoginUser._currentUser.UserId;
                systemParameterInfo.CreateName = SysLoginUser._currentUser.UserName;
                systemParameterInfo.CreateTime = DateTime.Now;
            }
            systemParameterInfo.UpdateBy = SysLoginUser._currentUser.UserId;
            systemParameterInfo.UpdateName = SysLoginUser._currentUser.UserName;
            systemParameterInfo.UpdateTime = DateTime.Now;
            return systemParameterDAL.AddOrEditSystemParameterInfo(systemParameterInfo);
        }

        /// <summary>
        /// 修改配置config的值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="datavalue">值</param>
        /// <returns></returns>
        public string UpdateConfigValue(string name, string datavalue)
        { 
            return systemParameterDAL.UpdateConfigValue(name, datavalue);
        }

        /// <summary>
        /// 修改打印选项的值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="datavalue">值</param>
        /// <returns></returns>
        public string UpdatePrintConfigValue(string name, string datavalue)
        {
            
            return systemParameterDAL.UpdatePrintConfigValue(name,datavalue);

        }

        /// <summary>
        /// 修改打印配置config的值
        /// </summary>
        /// <returns></returns>
        public string UpdatePrintItemValue(string name, double? sort, string title, int? checkvalue) 
        {
            return systemParameterDAL.UpdatePrintItemValue(name, sort,title,checkvalue);
        }
    }
}
