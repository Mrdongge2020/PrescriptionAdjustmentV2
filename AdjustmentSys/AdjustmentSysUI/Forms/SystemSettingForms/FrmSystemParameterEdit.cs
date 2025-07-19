using AdjustmentSys.BLL.SystemSetting;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Tool.Enums;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdjustmentSysUI.Forms.SystemSettingForms
{
    public partial class FrmSystemParameterEdit : UIForm
    {
        SystemParameterBLL systemParameterBLL = new SystemParameterBLL();
        private int _selectId;
        public bool isSuccess=false;
        public FrmSystemParameterEdit(int selectId)
        {
            InitializeComponent();
            _selectId = selectId;
        }

        private void InitData()
        {
            string[] types = Enum.GetNames(typeof(ParameterTypeEnum));
            List<ComboxModel> typelist = new List<ComboxModel>() { new ComboxModel() { Id = -1, Name = "全部" } };
            for (int i = 0; i < types.Length; i++)
            {
                ComboxModel comboxModel = new ComboxModel();
                comboxModel.Id = i;
                comboxModel.Name = types[i];
                typelist.Add(comboxModel);
            }
            cbType.ValueMember = "Id";
            cbType.DisplayMember = "Name";
            cbType.DataSource = typelist;
            cbType.SelectedValue = -1;

            if (_selectId > 0)
            {
                var info = systemParameterBLL.GetSystemParameterInfo(_selectId);
                if (info != null)
                {
                    txtName.Text = info.ParameterName;
                    txtDecribe.Text = info.ParameterDescribe;
                    txtName.ReadOnly = true;
                    txtDecribe.ReadOnly = true;
                    txtParaValue.Text = info.ParameterValue;
                    cbType.SelectedValue = (int)info.ParameterType;
                }
            }
        }

        private void FrmSystemParameterEdit_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckData())
            {
                return;
            };
            SystemParameterInfo systemParameterInfo = new SystemParameterInfo();
            systemParameterInfo.ID=_selectId;
            systemParameterInfo.ParameterName = txtName.Text;
            systemParameterInfo.ParameterDescribe = txtDecribe.Text;
            systemParameterInfo.ParameterValue = txtParaValue.Text;
            systemParameterInfo.ParameterType=(ParameterTypeEnum)cbType.SelectedValue;
            string error= systemParameterBLL.AddOrEditSystemParameterInfo(systemParameterInfo);
            if (error == "")
            {
                isSuccess = true;
                this.Close();
            }
            else 
            {
                this.ShowErrorDialog("错误提示", error);
            }
        }

        private bool CheckData() 
        {
            if (string.IsNullOrEmpty(txtName.Text)) 
            {
                this.ShowWarningDialog("异常提示", "参数名称不能为空");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDecribe.Text))
            {
                this.ShowWarningDialog("异常提示", "参数描述不能为空");
                txtDecribe.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtParaValue.Text))
            {
                this.ShowWarningDialog("异常提示", "参数值不能为空");
                txtParaValue.Focus();
                return false;
            }
            if (cbType.SelectedIndex==-1 ||(int)cbType.SelectedValue==-1 )
            {
                this.ShowWarningDialog("异常提示", "参数类型不能为空");
                cbType.Focus();
                return false;
            }

            return true;
        }
    }
}
