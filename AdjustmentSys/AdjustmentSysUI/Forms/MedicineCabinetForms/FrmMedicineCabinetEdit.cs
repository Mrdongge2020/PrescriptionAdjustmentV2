using AdjustmentSys.BLL.Device;
using AdjustmentSys.BLL.MedicineCabinet;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Tool.Enums;
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

namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    public partial class FrmMedicineCabinetEdit : UIEditForm
    {
        private int _Id;
        MedicineCabinetInfoBLL _medicineCabinetInfoBLL = new MedicineCabinetInfoBLL();
        public FrmMedicineCabinetEdit(int id)
        {
            InitializeComponent();
            _Id = id;
            InitData();
        }

        private void InitData()
        {
            cbGG.Items.Insert(0, "请选择规格");
            cbGG.Items.Insert(1, "大药柜");
            cbGG.Items.Insert(2, "小药柜");
            cbGG.Items.Insert(3, "自定义");
            
            if (_Id == 0)
            {
                txtYGMC.Text = "";
                txtYGBZ.Text = "20000";
                txtBZ.Text = "";
                iupHXGS.Enabled = false;
                iudZXGS.Enabled = false;
                cbGG.SelectedIndex = 0;
                return;
            }
            var cabinet = _medicineCabinetInfoBLL.GetCabinetInfo(_Id);
            if (cabinet != null)
            {
                txtYGMC.Text = cabinet.Name;
                cbGG.Enabled = false;
                cbGG.SelectedIndex = cabinet.Specifications.HasValue?(int)cabinet.Specifications:0;
                txtYGBZ.Text = cabinet.Code;
                txtBZ.Text = cabinet.Remark;
                iupHXGS.Value = cabinet.RowCount;
                iudZXGS.Value = cabinet.ColCount;
            }
        }

        private void cbGG_SelectedValueChanged(object sender, EventArgs e)
        {
            int selectValue = cbGG.SelectedIndex;
            if (selectValue == 1)
            {
                iupHXGS.Value = 14;
                iupHXGS.Enabled = false;
                iudZXGS.Value = 16;
                iudZXGS.Enabled = false;

            }
            else if (selectValue == 2)
            {
                iupHXGS.Value = 14;
                iupHXGS.Enabled = false;
                iudZXGS.Value = 8;
                iudZXGS.Enabled = false;
            }
            else if (selectValue == 3)//自定义
            {
                iupHXGS.Value = 14;
                iupHXGS.Enabled = true;
                iudZXGS.Value = 16;
                iudZXGS.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckInfo())
            {
                return;
            };
            MedicineCabinetInfo medicineCabinetInfo = new MedicineCabinetInfo();
            medicineCabinetInfo.ID = _Id;
            medicineCabinetInfo.Name = txtYGMC.Text;
            medicineCabinetInfo.Code = txtYGBZ.Text;
            medicineCabinetInfo.Specifications = cbGG.SelectedIndex<=0?null: cbGG.SelectedIndex;
            medicineCabinetInfo.Remark = txtBZ.Text;
            medicineCabinetInfo.RowCount = iupHXGS.Value;
            medicineCabinetInfo.ColCount = iudZXGS.Value;

            string msg = _medicineCabinetInfoBLL.AddOrEditCabinetInfo(medicineCabinetInfo);
            if (msg == "")
            {
                ShowSuccessTip((_Id > 0 ? "编辑" : "新增") + "成功");
                this.Close();
            }
            else
            {
                ShowErrorDialog("错误提示", msg);
            }
        }

        private bool CheckInfo()
        {
            if (string.IsNullOrEmpty(txtYGMC.Text))
            {
                ShowWarningDialog("异常提示", "药柜名称不能为空");
                txtYGMC.Focus();
                return false;
            }
            if (cbGG.SelectedIndex <=0)
            {
                ShowWarningDialog("异常提示", "请选择药柜规格");
                return false;
            }
            if (string.IsNullOrEmpty(txtYGBZ.Text))
            {
                ShowWarningDialog("异常提示", "药柜编组不能为空");
                txtYGBZ.Focus();
                return false;
            }
            if (iudZXGS.Value == 0 || iupHXGS.Value == 0)
            {
                ShowWarningDialog("异常提示", "药柜层数和单层个数不能为0");
            }
            return true;
        }

        private void FrmMedicineCabinetEdit_Load(object sender, EventArgs e)
        {
            
        }
    }
}
