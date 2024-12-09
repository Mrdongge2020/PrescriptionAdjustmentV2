using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.MedicineCabinet;
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
    public partial class FrmDataStatistics : UIPage
    {
        MedicineCabinetDrugManageBLL medicineCabinetDrugManageBLL = new MedicineCabinetDrugManageBLL();
        public FrmDataStatistics()
        {
            InitializeComponent();
            dateTimeStart.Value = DateTime.Now.Date.AddDays(-7);
            dateTimeEnd.Value = DateTime.Now.Date;
            ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
            List<ComboxModel> pDatas = _comboxDataBLL.GetParticlesInfoComboxData();
            cbfp.ValueMember = "Id";
            cbfp.DisplayMember = "Name";
            cbfp.DataSource = pDatas;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryUsedDatas();
        }

        private void QueryUsedDatas()
        {
            string name = cbfp.Text;
            DateTime sdateTime = dateTimeStart.Value;
            DateTime edateTime = dateTimeEnd.Value;
            var datas = medicineCabinetDrugManageBLL.GetParticleUsedStatistics(name, sdateTime, edateTime);
            dgvUsedList.DataSource = datas;
            uiDataGridViewFooter1.Clear();
            uiDataGridViewFooter1["ParticleName"] = "合计："+ datas.Count;
            uiDataGridViewFooter1["UseAmount"] = datas.Sum(x => x.UseAmount).ToString();
            uiDataGridViewFooter1["UseCount"] = datas.Sum(x => x.UseCount).ToString();
        }

        private void dgvUsedList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            dgvUsedList.RowHeadersWidth - 4,
            e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dgvUsedList.RowHeadersDefaultCellStyle.Font,
            rectangle,
            dgvUsedList.RowHeadersDefaultCellStyle.ForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
            dgvUsedList.RowHeadersDefaultCellStyle.Padding = new Padding(dgvUsedList.RowHeadersWidth);// 去掉行头三角号
        }
    }
}
