using AdjustmentSys.Entity;
using AdjustmentSys.Models.User;
using AdjustmentSys.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.IService
{
    public class UserInfoBLL
    {
       private readonly UserInfoDAL userInfoDAL = new UserInfoDAL();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public UserInfo Login(string name, string pwd) 
        {
            return userInfoDAL.Login(name, pwd);
        }
        /// <summary>
        /// 新增或编辑用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public string AddOrEditUserinfo(UserInfo userInfo) 
        {
            if (userInfo.ID == 0)
            {//新增,加创建信息

                userInfo.CreateBy = SysLoginUser._currentUser.UserId;
                userInfo.CreateName = SysLoginUser._currentUser.UserName;
                userInfo.CreateTime = DateTime.Now;
            }

            userInfo.UpdateBy = SysLoginUser._currentUser.UserId;
            userInfo.UpdateName = SysLoginUser._currentUser.UserName;
            userInfo.UpdateTime = DateTime.Now;

            return userInfoDAL.AddOrEditUserinfo(userInfo);
        }

        /// <summary>
        /// 根据用户ID，获取用户信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        public UserInfo GetUserInfo(int id) 
        { 
            return userInfoDAL.GetUserInfo(id);
        }

        /// <summary>
        /// 用户列表查询
        /// </summary>
        /// <param name="keywords">名称/电话</param>
        /// <param name="state">账号状态</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        public List<UserPageListModel> GetUserInfoByPage(string? keywords, bool? state, int pageIndex, int pageSize, out int count) 
        {
            return userInfoDAL.GetUserInfoByPage(keywords, state, pageIndex, pageSize, out count);
        }
    }
}
