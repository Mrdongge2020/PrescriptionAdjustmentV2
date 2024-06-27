using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Device;
using AdjustmentSys.BLL.MedicineCabinet;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    public partial class FrmListingParticles : UIEditForm
    {
        //public string TextBoxValue { get { return comboBoxSearh.Text; } set { comboBoxSearh.Text = value; } }
        ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        public int _Id;
        public string _Name;
        public FrmListingParticles()
        {
            InitializeComponent();
            List<ComboxModel> pDatas = _comboxDataBLL.GetParticlesInfoComboxData();
            cblisDurg.ValueMember = "Id";
            cblisDurg.DisplayMember = "Name";
            cblisDurg.DataSource = pDatas;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cblisDurg.SelectedValue==null)
            {
                ShowWarningDialog("请选择药上架的颗粒信息");
                return;
            }
            _Id= (int)cblisDurg.SelectedValue;
            _Name = cblisDurg.Text;
           
        }
    }
}
