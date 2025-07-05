using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.DAL.SystemSetting
{
    public class SysPermissionDAL
    {
        private readonly EFCoreContext _eFCoreContext = new EFCoreContext();
        /// <summary>
        /// 查询所有菜单
        /// </summary>
        /// <returns></returns>
        public List<MenuInfo> GetAllMenuInfos() 
        {
            try
            {
                var menuInfos = _eFCoreContext.MenuInfos.ToList();
                return menuInfos;
            }
            catch (Exception e)
            {
                OperateLog.WriteLog(LogTypeEnum.数据库,"查询所有菜单时出现异常，原因"+e.Message);
                return null;
            }
        }

        /// <summary>
        /// 根据角色查询角色菜单关系
        /// </summary>
        /// <returns></returns>
        public List<PermissionInfo> GetPermissionInfosByLevelID(int levelID)
        {
            try
            {
                var permissionInfos = _eFCoreContext.PermissionInfos.Where(x=>levelID==levelID).ToList();
                return permissionInfos;
            }
            catch (Exception e)
            {
               
                OperateLog.WriteLog(LogTypeEnum.数据库, "根据角色查询角色菜单关系出现异常，原因" + e.Message);
                return null;
            }
        }

        /// <summary>
        /// 查看菜单是否存在
        /// </summary>
        /// <param name="parentName">父级菜单名称</param>
        /// <param name="objName">菜单名称</param>
        /// <returns></returns>
        public bool IsMenuExist(string parentName,string objName) 
        {
            return _eFCoreContext.MenuInfos.Any(x => x.ParentName == parentName && x.ObjName == objName);
        }

        /// <summary>
        /// 查看菜单是否存在
        /// </summary>
        /// <param name="parentName">权限等级id</param>
        /// <param name="objName">菜单id</param>
        /// <returns></returns>
        public bool IsPermissionExist(int levelID, int menuID)
        {
            return _eFCoreContext.PermissionInfos.Any(x => x.LevelID == levelID && x.MenuID == menuID);
        }
    }
}
