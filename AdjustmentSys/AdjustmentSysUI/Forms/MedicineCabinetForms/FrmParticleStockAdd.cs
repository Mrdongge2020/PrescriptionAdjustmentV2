using AdjustmentSys.BLL.Common;
using AdjustmentSys.Entity;
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

namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    public partial class FrmParticleStockAdd : UIForm
    {
        ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        MedicineCabinetDetail medicineCabinetDetail = new MedicineCabinetDetail();
        public FrmParticleStockAdd()
        {
            InitializeComponent();
            InitData();
        }
        private void InitData()
        {
            List<ComboxModel> mDatas = _comboxDataBLL.GetManufacturerComboxData();
            cbCJ.ValueMember = "Id";
            cbCJ.DisplayMember = "Name";
            cbCJ.DataSource = mDatas;
            cbCJ.SelectedIndex = -1;
        }

        private void timerParticleStockAdd_Tick(object sender, EventArgs e)
        {

        }

        private void FrmParticleStockAdd_Load(object sender, EventArgs e)
        {
            //medicineCabinetDetail.CabinetID = ConfigTB.CabinetID;
            medicineCabinetDetail.ParticlesID = 0;
            timerParticleStockAdd.Start();
            this.txtBZTM.Focus();
            lbErroe.Items.Insert(0, DateTime.Now + "|请将药品放入称重工位|");
        }
    }
}
