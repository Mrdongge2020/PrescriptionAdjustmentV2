using AdjustmentSys.IService;
using AdjustmentSys.Models.User;
using AdjustmentSys.Service;
using AdjustmentSysUI.Forms;
using AdjustmentSysUI.Forms.UserForms;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AdjustmentSysUI
{
    public partial class FrmLogin : UILoginForm
    {
        private UserInfoBLL  _userInfoBLL=new UserInfoBLL();
        public FrmLogin()
        {
            InitializeComponent();

        }

 
        private void FrmLogin_ButtonLoginClick(object sender, System.EventArgs e)
        {
            string name = UserName;
            if (string.IsNullOrEmpty(name)) 
            {
                ShowWarningDialog("登录用户名不能为空");    
                return;
            }
            string pwd = Password;
            if (string.IsNullOrEmpty(pwd))
            {
                ShowWarningDialog("登录密码不能为空");
                return;
            }
            var user = _userInfoBLL.Login(name, pwd);
            
            if (user!=null)
            {
                ShowSuccessTip("登录成功");
                IsLogin = true;                
                SysLoginUser.currentUser.UserId = user.ID;
                SysLoginUser.currentUser.UserName = name;
                SysLoginUser.currentUser.UserLevelId = user.UserLevel;
                SysLoginUser.currentUser.UserLevelName = user.UserLevelName;
                SysLoginUser.currentUser.UserPhone = user.Phone;
                this.Hide();
                FrmMain frmMain = new FrmMain();
                frmMain.Show();

            }
            else
            {
                ShowErrorDialog("用户名或者密码错误。");
                return;
            }
        }
    }

    
}
