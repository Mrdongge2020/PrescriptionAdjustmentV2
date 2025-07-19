using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Drug;
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

namespace AdjustmentSysUI.Forms.PrescriptionForms
{
    public partial class FrmUpdateHisCode : UIEditForm
    {
        ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        public string _HISCode;
        public string _HisName;
        public string ParName = "";
        public FrmUpdateHisCode(string hISCode, string hisName)
        {
            InitializeComponent();
            _HISCode = hISCode;
            _HisName = hisName;
            List<ComboxModel> pDatas = _comboxDataBLL.GetParticlesInfoComboxData();
            cblisDurg.ValueMember = "Id";
            cblisDurg.DisplayMember = "Name";
            cblisDurg.DataSource = pDatas;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cblisDurg.SelectedValue == null)
            {
                this.ShowWarningDialog("请选择要更新HIS码的药品信息");
                return;
            }
            DrugManagermentBLL drugManagermentBLL = new DrugManagermentBLL();
            int id = (int)cblisDurg.SelectedValue;
            string msg = drugManagermentBLL.UpdateParticleHisCode(id, _HISCode,_HisName);
            if (msg == "")
            {
                ParName = cblisDurg.SelectedText;
                this.Close();
            }
            else 
            { 
                this.ShowErrorDialog(msg);
            }
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
