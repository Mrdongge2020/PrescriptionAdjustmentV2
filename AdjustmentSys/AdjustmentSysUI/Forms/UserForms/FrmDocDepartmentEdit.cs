using AdjustmentSys.BLL.User;
using AdjustmentSys.Entity;
using AdjustmentSys.IService;
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
    public partial class FrmDocDepartmentEdit : UIForm
    {
        DepartmentInfoBLL _departmentInfoBLL = new DepartmentInfoBLL();
        private int Id;
        public string resultMsg = "";
        public FrmDocDepartmentEdit(int id)
        {
            InitializeComponent();
            Id = id;
            InitData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitControlData();
            this.Close();
        }

        public void InitData() 
        {
            if (Id > 0)
            {
                var depModel = _departmentInfoBLL.GetDepartmentInfo(Id);
                if (depModel != null)
                {
                    txtName.Text = depModel.DepartmentName;
                    txtCname.Text = depModel.Contacts;
                    txtCPhone.Text = depModel.ContactsPhone;
                    txtAddress.Text = depModel.Address;
                    txtRemark.Text = depModel.Remark;
                }
            }
            else
            {
                InitControlData();
            }
        }
        public void InitControlData() 
        {
            txtName.Text = string.Empty;
            txtCname.Text = string.Empty;
            txtCPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtRemark.Text = string.Empty;
            
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckInfo())
            {
                return;
            };
            DepartmentInfo depInfo = new DepartmentInfo();
            depInfo.ID = Id;
            depInfo.DepartmentName = txtName.Text.Trim();
            depInfo.Address = txtAddress.Text.Trim();
            depInfo.Contacts = txtCname.Text.Trim();
            depInfo.ContactsPhone = txtCPhone.Text?.Trim();           
            depInfo.Remark = txtRemark.Text.Trim();

            string msg = _departmentInfoBLL.AddOrEditDepartmentInfo(depInfo);
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
        private bool CheckInfo() 
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                ShowWarningDialog("异常提示", "科室名称不能为空");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                ShowWarningDialog("异常提示", "科室地址不能为空");
                txtAddress.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCname.Text))
            {
                ShowWarningDialog("异常提示", "科室联系人不能为空");
                txtCname.Focus();
                return false;
            }

            return true;
        }
    }
}
