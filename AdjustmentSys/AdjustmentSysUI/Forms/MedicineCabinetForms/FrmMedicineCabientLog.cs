using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Drug;
using AdjustmentSys.BLL.MedicineCabinet;
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
    public partial class FrmMedicineCabientLog : UIPage
    {
        public FrmMedicineCabientLog()
        {
            InitializeComponent();

            var names = Enum.GetNames(typeof(MedicineCabinetOperationLogTypeEnum));
            int index = 0;
            List<ComboxModel> preStatuslist = new List<ComboxModel>();
            foreach (var name in names)
            {
                preStatuslist.Add(new ComboxModel() { Id = index, Name = name });
                index++;
            }
            cbType.ValueMember = "Id";
            cbType.DisplayMember = "Name";
            cbType.DataSource = preStatuslist;
            cbType.SelectedIndex = -1;

            this.dateTimeStart.Value = DateTime.Now.Date;
            this.dateTimeEnd.Value = DateTime.Now.Date.AddDays(1);

            ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
            List<ComboxModel> pDatas = _comboxDataBLL.GetCabinetParticlesComboxData();
            cbfp.ValueMember = "Id";
            cbfp.DisplayMember = "Name";
            cbfp.DataSource = pDatas;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

        }

        private void queryPage()
        {
            MedicineCabinetOperationLogTypeEnum? type = null;
            if (cbType.SelectedValue != null && cbType.SelectedIndex != -1)
            {
                type = (MedicineCabinetOperationLogTypeEnum)cbType.SelectedValue;
            }

            string pname = "";
            if (!string.IsNullOrEmpty(cbfp.SelectedText))
            {
                pname = cbfp.SelectedText;
            }
            MedicineCabinetDrugManageBLL medicineCabinetDrugManageBLL = new MedicineCabinetDrugManageBLL();
            int allCount = 0;//总条数
            var datas = medicineCabinetDrugManageBLL.GetMedicineCabinetOperationLogByPage(type, pname, dateTimeStart.Value, dateTimeEnd.Value, uiPage.ActivePage, uiPage.PageSize, out allCount);
            //设置分页控件总数
            uiPage.TotalCount = allCount;

            dgvList.DataSource = datas.mcParticLogs;

            lblNum1.Text= datas.UsedQuantitySum.ToString();
            lblNum2.Text = datas.AddQuantitySum.ToString();
            lblNum3.Text = datas.AdjustmentQuantitySum.ToString();
        }
    }
}
