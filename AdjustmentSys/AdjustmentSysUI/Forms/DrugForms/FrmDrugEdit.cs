using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Drug;
using AdjustmentSys.BLL.User;
using AdjustmentSys.DAL.Common;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.Drug;
using AdjustmentSys.Tool.Enums;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ZXing;

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
            particlesInfo.Code =string.IsNullOrEmpty(txtKLM.Text?.Trim())?0:int.Parse(txtKLM.Text?.Trim());
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
            //if (string.IsNullOrEmpty(txtKLM.Text))
            //{
            //    ShowWarningDialog("异常提示", "颗粒码不能为空");
            //    txtKLM.Focus();
            //    return false;
            //}
            //if (txtKLM.Text.Length != 6 || !int.TryParse(txtKLM.Text, out int w))
            //{
            //    ShowWarningDialog("异常提示", "颗粒码只能是6位正整数");
            //    txtKLM.Focus();
            //    return false;
            //}
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
            string code = txtBZTM.Text?.Trim();
            if (string.IsNullOrEmpty(code))
            {
                ShowWarningDialog("异常提示", "包装条码不能为空");
                txtBZTM.Focus();
                return;
            }
            
            int mid = cbCJ.SelectedValue == null ? 0 : (int)cbCJ.SelectedValue;
            CommonDataBLL commonDataBLL = new CommonDataBLL();
            //获取厂家信息
            var mcodes = commonDataBLL.GetManufacturerCodes(mid);
            if (mcodes == null || mcodes.Count <= 0)
            {
                ShowWarningDialog("异常提示", "无可用的厂家条码信息");
                return;
            }
            mcodes = mcodes.Where(x => x.ExampleCode.Length == code.Length).ToList();
            if (mcodes == null || mcodes.Count <= 0)
            {
                ShowWarningDialog("异常提示", "未找到相匹配的厂家条码信息");
                return;
            }

            for (int i = 0; i < mcodes.Count; i++)
            {
                //解析
                var ruler = GetAnalysisResult(mcodes[i], code);
                if (ruler != null)
                {
                    txtMD.Text = ruler.Density.ToString();
                    txtDL.Text = ruler.Equivalent.ToString();
                    txtDBZM.Text = ruler.PackageNumber;
                    ShowSuccessTip("解析完成");
                    break;
                }
                
            }
        }
        /// <summary>
        /// 获取解析结果
        /// </summary>
        /// <param name="code">编码规则</param>
        /// <returns></returns>
        private ManufacturerRuleResultModel GetAnalysisResult(ManufacturerResolutionCode code, string codeStr)
        {
            DrugManufacturerBLL drugManufacturerBLL = new DrugManufacturerBLL();
            ManufacturerRuleResultModel resultModel = new ManufacturerRuleResultModel();

            resultModel.PackageNumber = drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.Packaging, codeStr, code.LargePackagingCodeIndex, code.LargePackagingCodeLength);
            resultModel.PackageType = drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.PackagingType, codeStr, (int)code.PackagingTypeIndex, (int)code.PackagingTypeLength);
            resultModel.BatchNumber = drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.BatchNumber, codeStr, (int)code.BatchNumberIndex, (int)code.BatchNumberLength);
            resultModel.VaildUntil = drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.VaildUntil, codeStr, (int)code.ValidityPeriodIndex, (int)code.ValidityPeriodLength);
            resultModel.Density = float.Parse(drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.Density, codeStr, code.DensityIndex, code.DensityLength));
            resultModel.Equivalent = float.Parse(drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.Equivalent, codeStr, (int)code.EquivalentIndex, (int)code.EquivalentLength));
            resultModel.LoadCapacity = float.Parse(drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.LoadingCapacity, codeStr, (int)code.LoadingCapacityIndex, (int)code.LoadingCapacityLength));
            return resultModel;
        }
    }
}
