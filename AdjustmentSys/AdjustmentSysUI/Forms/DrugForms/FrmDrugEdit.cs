using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Drug;
using AdjustmentSys.BLL.User;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.Drug;
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
using System.Xml.Linq;

namespace AdjustmentSysUI.Forms.Drug
{
    public partial class FrmDrugEdit : UIForm
    {
        DrugManagermentBLL _drugManagermentBLL = new DrugManagermentBLL();
        ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        private int _drugId;
        public bool isSuccess = false;
        public FrmDrugEdit(int drugId)
        {
            InitializeComponent();
            _drugId = drugId;
            InitData();
        }

        public void InitData()
        {
            List<ComboxModel> mDatas = _comboxDataBLL.GetManufacturerComboxData();
            cbCJ.ValueMember = "Id";
            cbCJ.DisplayMember = "Name";
            cbCJ.DataSource = mDatas;
            cbCJ.SelectedIndex = -1;

            if (_drugId > 0)
            {
                var drugModel = _drugManagermentBLL.GetDrugInfo(_drugId);
                if (drugModel != null)
                {
                    cbCJ.SelectedValue = drugModel.ManufacturerId;
                    txtJC.Text = drugModel.Name;
                    txtQC.Text = drugModel.FullName;
                    txtKLM.Text = drugModel.Code.ToString();
                    txtMD.Text = drugModel.Density.ToString();
                    txtDL.Text = drugModel.Equivalent.ToString();
                    txtMCJP.Text = drugModel.NameSimplifiedPinyin;
                    txtMCQP.Text = drugModel.NameFullPinyin;
                    txtHISM.Text = drugModel.HisCode;
                    txtLSJ.Text = drugModel.RetailPrice.ToString();
                    txtGHJ.Text = drugModel.WholesalePrice.ToString();
                    txtJLSX.Text = drugModel.DoseLimit.ToString();
                    txtDBZM.Text = drugModel.PackageNumber;
                    txtSSBH.Text = drugModel.ListingNumber;
                    txtBZ.Text = drugModel.Remark;
                    txtHISMC.Text = drugModel.HisName;
                    //txtPH.Text = drugModel.BatchNumber;
                    //txtXQZ.Text = drugModel.VaildUntil;

                    lblTM.Enabled = true;
                    txtBZTM.Enabled = true;
                    btnSB.Enabled = true;
                }
            }
            else
            {
                InitControlData();
            }
        }

        private void InitControlData()
        {
            txtJC.Text = string.Empty;
            txtQC.Text = string.Empty;
            txtKLM.Text = string.Empty;
            txtMD.Text = string.Empty;
            txtDL.Text = string.Empty;
            txtMCJP.Text = string.Empty;
            txtMCQP.Text = string.Empty;
            txtHISM.Text = string.Empty;
            txtLSJ.Text = string.Empty;
            txtGHJ.Text = string.Empty;
            txtJLSX.Text = string.Empty;
            txtDBZM.Text = string.Empty;
            txtSSBH.Text = string.Empty;
            txtBZ.Text = string.Empty;

            txtHISMC.Text = string.Empty;

            lblTM.Enabled = false;
            txtBZTM.Enabled = false;
            btnSB.Enabled = false;
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
            ParticlesInfoEditModel particlesInfo = new ParticlesInfoEditModel();
            particlesInfo.ID = _drugId;
            particlesInfo.ManufacturerId = int.Parse(cbCJ.SelectedValue.ToString());
            particlesInfo.Name = txtJC.Text?.Trim();
            particlesInfo.FullName = txtQC.Text?.Trim();
            particlesInfo.Code = int.Parse(txtKLM.Text?.Trim());
            particlesInfo.Density = float.Parse(txtMD.Text?.Trim());
            particlesInfo.Equivalent = float.Parse(txtDL.Text?.Trim());
            particlesInfo.NameSimplifiedPinyin = txtMCJP.Text?.Trim();
            particlesInfo.NameFullPinyin = txtMCQP.Text?.Trim();
            particlesInfo.HisCode = txtHISM.Text?.Trim();
            particlesInfo.RetailPrice = string.IsNullOrEmpty(txtLSJ.Text) ? null : decimal.Parse(txtLSJ.Text);
            particlesInfo.WholesalePrice = string.IsNullOrEmpty(txtGHJ.Text) ? null : decimal.Parse(txtGHJ.Text); ;
            particlesInfo.DoseLimit = string.IsNullOrEmpty(txtJLSX.Text) ? 9 : float.Parse(txtJLSX.Text);
            particlesInfo.PackageNumber = txtDBZM.Text?.Trim();
            particlesInfo.ListingNumber = txtSSBH.Text?.Trim();
            particlesInfo.Remark = txtBZ.Text.Trim();
            particlesInfo.HisName = txtHISMC.Text?.Trim();
            //particlesInfo.BatchNumber = txtPH.Text?.Trim();
            //particlesInfo.VaildUntil = txtXQZ.Text?.Trim();

            string msg = _drugManagermentBLL.AddOrEditDrugInfo(particlesInfo);
            if (msg == "")
            {
                isSuccess = true;
                //ShowSuccessTip((_drugId > 0 ? "编辑" : "新增") + "成功");
                this.Close();
            }
            else
            {
                ShowErrorDialog("错误提示", msg);
            }
        }

        private bool CheckInfo()
        {
            if (string.IsNullOrEmpty(txtJC.Text))
            {
                ShowWarningDialog("异常提示", "名称简称不能为空");
                txtJC.Focus();
                return false;
            }
            if (cbCJ.SelectedIndex == -1)
            {
                ShowWarningDialog("异常提示", "请选择颗粒厂家");
                return false;
            }
            if (string.IsNullOrEmpty(txtKLM.Text))
            {
                ShowWarningDialog("异常提示", "颗粒码不能为空");
                txtKLM.Focus();
                return false;
            }
            if (txtKLM.Text.Length!=6 || !int.TryParse(txtKLM.Text,out int w))
            {
                ShowWarningDialog("异常提示", "颗粒码只能是6位正整数");
                txtKLM.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMD.Text))
            {
                ShowWarningDialog("异常提示", "密度不能为空");
                txtMD.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDL.Text))
            {
                ShowWarningDialog("异常提示", "当量不能为空");
                txtDL.Focus();
                return false;
            }

            return true;
        }

        private void btnSB_Click(object sender, EventArgs e)
        {
            if (cbCJ.SelectedIndex == -1)
            {
                ShowWarningDialog("异常提示", "请选择颗粒厂家");
                return ;
            }
            if (string.IsNullOrEmpty(txtKLM.Text))
            {
                ShowWarningDialog("异常提示", "颗粒码不能为空");
                txtKLM.Focus();
                return;
            }
            var result= _drugManagermentBLL.GetManufacturerRuleResult(txtKLM.Text.Trim(),(int)cbCJ.SelectedValue);
            if (result!=null) 
            {
                txtMD.Text = result.Density.ToString();
                txtDL.Text = result.Equivalent.ToString();
                txtDBZM.Text = result.PackageNumber;
            }
            ShowSuccessTip("解析完成");
        }
    }
}
