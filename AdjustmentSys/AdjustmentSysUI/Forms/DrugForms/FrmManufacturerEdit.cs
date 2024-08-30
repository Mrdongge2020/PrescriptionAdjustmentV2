using AdjustmentSys.BLL.Drug;
using AdjustmentSys.Entity;
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

namespace AdjustmentSysUI.Forms.Drug
{
    public partial class FrmManufacturerEdit : UIEditForm
    {
        private ManufacturerInfo _manufacturerInfo;
        public bool IsSuccess = false;
        public FrmManufacturerEdit(ManufacturerInfo manufacturerInfo)
        {
            InitializeComponent();
            _manufacturerInfo = manufacturerInfo;
            InitData();
        }

        private void InitData()
        {
            if (_manufacturerInfo == null)
            {
                _manufacturerInfo = new ManufacturerInfo();
                txtMC.Text = string.Empty;
                iudSort.Value = 0;
            }
            else
            {
                txtMC.Text = _manufacturerInfo.Name;
                iudSort.Value = _manufacturerInfo.Sort;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtMC.Text = string.Empty;
            iudSort.Value = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (iudSort.Value<=0) 
            {
                ShowWarningDialog("异常提示", "序号必须大于0");
                iudSort.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMC.Text))
            {
                ShowWarningDialog("异常提示", "厂家名称不能为空");
                txtMC.Focus();
                return;
            }

            DrugManufacturerBLL drugManufacturerBLL = new DrugManufacturerBLL();
            _manufacturerInfo.Name = txtMC.Text.Trim();
            _manufacturerInfo.Sort = iudSort.Value;
            string msg = drugManufacturerBLL.AddOrEditManufacturerInfo(_manufacturerInfo);
            if (msg == "")
            {
                IsSuccess = true;
                //ShowSuccessTip((_manufacturerInfo.ID > 0 ? "编辑" : "新增") + "成功");
                this.Close();
            }
            else
            {
                ShowErrorDialog("错误提示", msg);
            }
        }
    }
}
