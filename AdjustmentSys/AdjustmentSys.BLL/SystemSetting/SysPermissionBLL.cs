using AdjustmentSys.DAL.SystemSetting;
using AdjustmentSys.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.SystemSetting
{
    public class SysPermissionBLL
    {
        SysPermissionDAL _sysPermissionDAL = new SysPermissionDAL();

        /// <summary>
        /// 查询所有菜单
        /// </summary>
        /// <returns></returns>
        public List<MenuInfo> GetAllMenuInfos() 
        {
            return _sysPermissionDAL.GetAllMenuInfos();
        }

        /// <summary>
        /// 根据角色查询角色菜单关系
        /// </summary>
        /// <returns></returns>
        public List<PermissionInfo> GetPermissionInfosByLevelID(int levelID) 
        {
            return _sysPermissionDAL.GetPermissionInfosByLevelID(levelID);
        }
    }
}
