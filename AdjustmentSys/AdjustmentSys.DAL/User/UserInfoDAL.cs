using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.User;
using Microsoft.EntityFrameworkCore;
using System;

namespace AdjustmentSys.Service
{
    public class UserInfoDAL
    {
        private readonly EFCoreContext _eFCoreContext=new EFCoreContext();
        

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public UserInfo Login(string name,string pwd) 
        {
            return _eFCoreContext.UserInfos.AsNoTracking().FirstOrDefault(x=>x.UserName==name && x.UserPassword==pwd);
        }
        /// <summary>
        /// 新增或编辑用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public string AddOrEditUserinfo(UserInfo userInfo) 
        {
            string error = "";
            try
            {
                if (userInfo.ID != default(int))
                {
                    bool isExitUser = _eFCoreContext.UserInfos.AsNoTracking().Any(x => x.UserName == userInfo.UserName && x.ID!=userInfo.ID);
                    if (isExitUser)
                    {
                        return "该用户名称已存在";
                    }

                    var user = _eFCoreContext.UserInfos.AsNoTracking().FirstOrDefault(x => x.ID == userInfo.ID);
                    if (user==null) 
                    {
                        return "未找到要编辑的用户信息，请刷新后再试";
                    }
                    user.UserName = userInfo.UserName;
                    user.UserPassword = userInfo.UserPassword;
                    user.UserLevel= userInfo.UserLevel;
                    user.UserLevelName= userInfo.UserLevelName;
                    user.State= userInfo.State;
                    user.Phone= userInfo.Phone;
                    user.Office= userInfo.Office;
                    user.Remark= userInfo.Remark;
                    user.UpdateTime= userInfo.UpdateTime;
                    user.UpdateBy= userInfo.UpdateBy;
                    user.UpdateName= userInfo.UpdateName;
                    //可省略
                    _eFCoreContext.UserInfos.Update(user);
                }
                else
                {
                    bool isExitUser= _eFCoreContext.UserInfos.AsNoTracking().Any(x => x.UserName == userInfo.UserName);
                    if (isExitUser) 
                    {
                        return "该用户名称已存在";
                    }
                    _eFCoreContext.UserInfos.Add(userInfo);
                }

                var result = _eFCoreContext.SaveChanges();
                if (result <= 0) {
                    error = (userInfo.ID>0?"编辑":"新增")+"用户失败，请稍后再试。";
                }
            }
            catch (Exception e)
            {
                error=e.Message;
            }

            return error;
        }

        /// <summary>
        /// 根据用户ID，获取用户信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        public UserInfo GetUserInfo(int id)
        {
            return _eFCoreContext.UserInfos.AsNoTracking().FirstOrDefault(x => x.ID == id);
        }

        /// <summary>
        /// 用户列表查询
        /// </summary>
        /// <param name="keywords">名称/电话</param>
        /// <param name="state">账号状态</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        public List<UserPageListModel> GetUserInfoByPage(string? keywords,bool? state, int pageIndex,int pageSize,out int count) 
        {
            var where = _eFCoreContext.UserInfos.AsNoTracking()
                .Where(user=>1==1);

            //关键字条件
            if (!String.IsNullOrEmpty(keywords))
            {
                where = where.Where(user => (user.UserName.Contains(keywords) || user.Phone.Contains(keywords)));
            }

            //State条件
            if (state.HasValue)
            {
                where = where.Where(user => user.State == state);
            }
            
            //统计总记录数
            count = where.Count();
            if (count==0) {
                return null;
            }

            //结果按照创建时间倒序排序
            where = where.OrderByDescending(user => user.CreateTime);

            //跳过翻页的数量
            var list = where.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();

            //获取结果，返回
            var result = list.Select(x => new UserPageListModel() 
            {
                ID = x.ID,
                UserName= x.UserName,
                StateText=x.State?"启用":"禁用",
                Office=x.Office,
                Phone = x.Phone,
                UserLevelName=x.UserLevelName,
                Remark=x.Remark,
                CreateName=x.CreateName,
                CreateTime=x.CreateTime,
                UpdateName=x.UpdateName,
                UpdateTime=x.UpdateTime
            }).ToList();

            return result;
        }

    }
}
