using AdjustmentSys.DAL.SystemSetting;
using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
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

        /// <summary>
        /// 获取用户的菜单信息
        /// </summary>
        /// <returns></returns>
        public  List<MenuInfo> GetUserAllMenuInfos() 
        {
            if (SysLoginUser.currentUser.UserLevelId==1) 
            {
                return null;
            }

            var usermenus= CacheHelper.GetFromCache("UserMenus");
            if (usermenus!=null) 
            { 
                return  (List<MenuInfo>)usermenus;
            }

            var permiss= _sysPermissionDAL.GetPermissionInfosByLevelID(SysLoginUser.currentUser.UserLevelId);
            if (permiss == null || permiss.Count <= 0) 
            {
                return null;
            }
            var allmenus= _sysPermissionDAL.GetAllMenuInfos();
            if (allmenus != null && allmenus.Count > 0) 
            {
                List<int> menuids = permiss.Select(x => x.MenuID).Distinct().ToList();
                allmenus = allmenus.Where(x=> menuids.Contains(x.ID)).ToList();
                if (allmenus!=null && allmenus.Count>0) 
                {
                    DateTimeOffset expirationTime = DateTimeOffset.Now.AddMinutes(180);
                    // 添加到缓存
                    CacheHelper.AddToCache("UserMenus", allmenus, expirationTime);
                }
            }
            return allmenus;
        }


        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="menuInfos"></param>
        /// <returns></returns>
        public string AddMenuinfos(List<MenuInfo> menuInfos)
        {
            //判断菜单是否已存在
            List<MenuInfo> menuInfos1 = new List<MenuInfo>();
            foreach (var item in menuInfos)
            {
                if (!_sysPermissionDAL.IsMenuExist(item.ParentName,item.ObjName))
                {
                    menuInfos1.Add(item);
                }
            }
            if (menuInfos1 != null && menuInfos1.Count > 0)
            {
                string resMsg = _sysPermissionDAL.AddMenuinfos(menuInfos1);
                return resMsg;
            }
            else 
            {
                return "";
            }
        }

        /// <summary>
        /// 操作菜单与权限关系
        /// </summary>
        /// <param name="parentName">权限等级id</param>
        /// <param name="objName">菜单id</param>
        /// <returns></returns>
        public string OpterPermission(int levelID, int menuID,bool isAdd) 
        {
            if (isAdd)
            {
                if (_sysPermissionDAL.IsPermissionExist(levelID, menuID))
                {
                    return "";
                }
                PermissionInfo permissionInfo = new PermissionInfo();
                permissionInfo.LevelID = levelID;
                permissionInfo.MenuID = menuID;

                return _sysPermissionDAL.AddPermission(permissionInfo);
            }
            else //删除
            {
                if (!_sysPermissionDAL.IsPermissionExist(levelID, menuID))
                {
                    return "";
                }
               return  _sysPermissionDAL.DeletePermission(levelID, menuID);
            }
        }
    }
}
