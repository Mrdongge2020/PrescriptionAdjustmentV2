using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.User;
using AdjustmentSys.Entity;
using AdjustmentSys.IService;
using AdjustmentSys.Models.CommModel;
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
    public partial class FrmDoctorEdit : UIForm
    {
        DoctorInfoBLL _doctorInfoBLL = new DoctorInfoBLL();
        private readonly ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        private int docId;
        public string resultMsg = "";
        public FrmDoctorEdit(int docId)
        {
            InitializeComponent();
            this.docId = docId;
            InitData();
        }

        private void InitData()
        {
            List<ComboxModel> depDatas = _comboxDataBLL.GetDoctorDepartmentComboxData();
            cbDepartment.ValueMember = "Id";
            cbDepartment.DisplayMember = "Name";
            cbDepartment.DataSource = depDatas;
            cbDepartment.SelectedIndex = -1;
            if (docId > 0)
            {
                var model = _doctorInfoBLL.GetDoctorInfo(docId);
                if (model != null)
                {
                    txtName.Text = model.DoctorName;
                    txtEmail.Text = model.EMail;
                    txtOffic.Text = model.Office;
                    txtPhone.Text = model.Phone;
                    txtRemark.Text = model.Remark;
                    cbDepartment.SelectedValue = model.DoctorDepartmentID;
                }
            }
            else
            {
                InitControlData();
            }
        }

        private void InitControlData()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtOffic.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtRemark.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitControlData();
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckInfo())
            {
                return;
            };

            DoctorInfo doctorInfo = new DoctorInfo();
            doctorInfo.ID = docId;
            doctorInfo.DoctorName= txtName.Text;
            doctorInfo.EMail= txtEmail.Text;
            doctorInfo.Phone= txtPhone.Text;
            doctorInfo.Office=txtOffic.Text;
            doctorInfo.Remark= txtRemark.Text;
            doctorInfo.DoctorDepartmentID= Convert.ToInt32(cbDepartment.SelectedValue);
            doctorInfo.DoctorDepartmentName = cbDepartment.SelectedText;
            doctorInfo.IsDelete = false;
            string msg = _doctorInfoBLL.AddOrEditDoctorInfo(doctorInfo);
            if (msg == "")
            {
                resultMsg = "Successed";
                this.Close();
            }
            else
            {
                resultMsg = msg ;
            }
        }

        /// <summary>
        /// 数据检查
        /// </summary>
        /// <returns></returns>
        private bool CheckInfo()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                ShowWarningDialog("异常提示", "医生名称不能为空");
                txtName.Focus();
                return false;
            }

            if (cbDepartment.SelectedIndex == -1)
            {
                ShowWarningDialog("异常提示", "请选择医生所属科室");
                return false;
            }
            return true;
        }

    }
}
