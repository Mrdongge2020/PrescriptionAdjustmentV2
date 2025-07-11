using AdjustmentSys.BLL.Common;
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
    public partial class FrmEditHisCode : UIForm
    {
        ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        public string ParName = "";
        List<ComboxStringModel> _comboxStringModels;
        public FrmEditHisCode(List<ComboxStringModel> comboxStringModels)
        {
            InitializeComponent();
            _comboxStringModels=comboxStringModels;
        }

        private void FrmEditHisCode_Load(object sender, EventArgs e)
        {
            List<ComboxModel> pDatas = _comboxDataBLL.GetParticlesInfoComboxData();
            cblisDurg.ValueMember = "Id";
            cblisDurg.DisplayMember = "Name";
            cblisDurg.DataSource = pDatas;


            cbOldDurg.ValueMember = "Id";
            cbOldDurg.DisplayMember = "Name";

            //var tempdatas = new List<ComboxStringModel> ();
            //_comboxStringModels.ForEach(p => {
            //    if (pDatas.Any(x=>x.)) { }
            //});
            cbOldDurg.DataSource = _comboxStringModels; 


        }
    }
}
