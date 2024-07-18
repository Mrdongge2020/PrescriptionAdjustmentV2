using AdjustmentSys.BLL.Common;
using AdjustmentSys.Entity;
using AdjustmentSys.IService;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.User;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdjustmentSysUI.Forms.UserForms
{
    public partial class FrmUserEdit : UIForm
    {
        private int userId;
        private readonly ComboxDataBLL _comboxDataBLL=new ComboxDataBLL();
        private readonly UserInfoBLL _userInfoBLL = new UserInfoBLL();
        public string resultMsg = ""; 
        public FrmUserEdit(int id)
        {
            userId = id;
            InitializeComponent();
            InitData();
           
        }
        private void InitData()
        {
            List<ComboxModel> levelDatas = _comboxDataBLL.GetUserLevelComboxData();
            cbLevel.ValueMember = "Id";
            cbLevel.DisplayMember = "Name";
            cbLevel.DataSource = levelDatas;
            cbLevel.SelectedIndex = -1;
            if (userId > 0)
            {
                var userModel = _userInfoBLL.GetUserInfo(userId);
                if (userModel != null)
                {
                    txtName.Text = userModel.UserName;
                    txtPassword.Text = userModel.UserPassword;
                    txtConfimPassword.Text = userModel.UserPassword;
                    cbLevel.SelectedValue = userModel.UserLevel;
                    rbTrue.Checked = userModel.State ? true : false;
                    rbFalse.Checked = !userModel.State ? true : false;
                    txtOffic.Text = userModel.Office;
                    txtPhone.Text = userModel.Phone;
                    txtRemark.Text = userModel.Remark;
                }
            }
            else
            {
                InitControlValue();
            }
        }

        /// <summary>
        /// 确定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckInfo())
            {
                return;
            };
            UserInfo userInfo = new UserInfo();          
            userInfo.ID = userId;
            userInfo.UserName = txtName.Text.Trim();
            userInfo.UserPassword = txtPassword.Text.Trim();
            userInfo.UserLevel = Convert.ToInt32(cbLevel.SelectedValue);
            userInfo.UserLevelName = cbLevel.SelectedText;
            userInfo.State = rbTrue.Checked ? true : false;
            userInfo.Office = txtOffic.Text.Trim();
            userInfo.Phone = txtPhone.Text.Trim();
            userInfo.Remark = txtRemark.Text.Trim();

            string msg = _userInfoBLL.AddOrEditUserinfo(userInfo);
            if (msg == "")
            {
                resultMsg = "Successed";
                this.Close();
            }
            else
            {
                resultMsg = msg;
            }

        }

        /// <summary>
        /// 初始化控件值
        /// </summary>
        public void InitControlValue() 
        {
            txtName.Text = "";
            txtPassword.Text = "";
            txtConfimPassword.Text = "";    
            rbTrue.Checked = true;
            rbTrue.Checked =  false;
            txtOffic.Text = "";
            txtPhone.Text = "";
            txtRemark.Text = "";
        }
        /// <summary>
        /// 数据检查
        /// </summary>
        /// <returns></returns>
        private bool CheckInfo()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                ShowWarningDialog("异常提示","用户名不能为空");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                ShowWarningDialog("异常提示", "密码不能为空");
                txtPassword.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtConfimPassword.Text))
            {
                ShowWarningDialog("异常提示", "确认密码不能为空");
                txtConfimPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Trim() != txtConfimPassword.Text.Trim())
            {
                ShowWarningDialog("异常提示", "两次输入密码不一致,请重新输入密码");
                txtPassword.Focus();
                txtPassword.Text = "";
                txtConfimPassword.Text = "";
                return false;
            }

            if (cbLevel.SelectedIndex == -1)
            {
                ShowWarningDialog("异常提示", "请选择权限等级");
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitControlValue();
            this.Close();
        }
    }
}
