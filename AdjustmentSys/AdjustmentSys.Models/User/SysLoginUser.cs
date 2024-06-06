using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.User
{
    public class SysLoginUser
    {
        public  int UserId { get; set; }

        public  string UserName { get; set; }
                
        public  int UserLevelId { get; set; }
                
        public  string UserLevelName { get; set; }
                
        public  string UserPhone { get; set; }
        /// <summary>
        /// //应用单件模式，保存用户登录状态
        /// </summary>
        public static SysLoginUser _currentUser = null;
        public static SysLoginUser currentUser
        {
            get
            {
                if (_currentUser == null)
                    _currentUser = new SysLoginUser();
                return _currentUser;
            }
        }
    }
}
