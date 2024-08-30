using AdjustmentSys.DAL.SystemSetting;
using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.SystemSetting;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool.Enums;
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
    }
}
