using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Drug;
using AdjustmentSys.Models.CommModel;
using AdjustmentSysUI.UITool;
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

namespace AdjustmentSysUI.Forms.DrugForms
{
    public partial class FrmDurgDensityCoefficientSet : UIForm
    {
        DrugManagermentBLL _drugManagermentBLL = new DrugManagermentBLL();
        ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        public FrmDurgDensityCoefficientSet()
        {
            InitializeComponent();
            BindInitData();
        }

        private void BindInitData()
        {
            //厂家
            List<ComboxModel> mDatas = _comboxDataBLL.GetManufacturerComboxData();
            cbCJ.ValueMember = "Id";
            cbCJ.DisplayMember = "Name";
            cbCJ.DataSource = mDatas;
            cbCJ.SelectedIndex = -1;

            //dgv列

            //列表
            dgvList.AutoGenerateColumns = false;//不自动生成列
            dgvList.AllowUserToAddRows = false;//不自动产生最后的新行
            dgvList.AllowUserToResizeRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.RowHeadersVisible = false;
        }

        private void QueryParticleDatas()
        {
            int? cjId = null;
            if (cbCJ.SelectedIndex != -1)
            {
                cjId = int.Parse(cbCJ.SelectedValue.ToString());
            }
            var datas = _drugManagermentBLL.GetParticlesByNameOrManufacturerId(txtName.Text, cjId);

            dgvList.DataSource = datas;
        }

        private void FrmDurgDensityCoefficientSet_Load(object sender, EventArgs e)
        {
            QueryParticleDatas();
        }
    }
}
