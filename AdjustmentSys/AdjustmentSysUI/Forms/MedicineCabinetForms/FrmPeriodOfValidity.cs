using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.MedicineCabinet;
using AdjustmentSysUI.UITool;
using Sunny.UI;
using Sunny.UI.Win32;
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
    public partial class FrmPeriodOfValidity : UIForm
    {
        ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        MedicineCabinetDrugManageBLL _medicineCabinetDrugManageBLL = new MedicineCabinetDrugManageBLL();
        public FrmPeriodOfValidity()
        {
            InitializeComponent();
            InitDgvFormat();
        }

       

        private void FrmPeriodOfValidity_Load(object sender, EventArgs e)
        {
            dateTimeStart.Value = DateTime.Now.Date;
            dateTimeEnd.Value = DateTime.Now.Date.AddMonths(1);
            var durgDLData = _comboxDataBLL.GetCabinetParticlesComboxData();
            cblisDurg.ValueMember = "Id";
            cblisDurg.DisplayMember = "Name";
            cblisDurg.DataSource = durgDLData;
            cblisDurg.SelectedIndex = -1;
            QueryData();
            dpSetDateEnd.Value=DateTime.Now;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryData();
        }

        /// <summary>
        /// 设置dgv格式
        /// </summary>
        private void InitDgvFormat()
        {
            //分页列表
            dgvList.AutoGenerateColumns = false;//不自动生成列
            dgvList.AllowUserToAddRows = false;//不自动产生最后的新行
            dgvList.AllowUserToResizeRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
            //创建列
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParticleCode", "颗粒编号", true, true, 20, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParticleName", "颗粒名称", true, true, 20, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ValidityTime", "效期至", true, true, 30, "yyyy-MM-dd HH:mm:ss");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "BatchNumber", "批号", true, true, 20, "");

        }

        private void QueryData()
        {
            DateTime sdateTime = dateTimeStart.Value;
            DateTime edateTime = dateTimeEnd.Value;
            var data = _medicineCabinetDrugManageBLL.GetMedicineCabinetValidity(sdateTime,edateTime);
            dgvList.DataSource = data;
            dgvList.TopLeftHeaderCell.Value = "序号("+ data.Count.ToString() + ")";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int? pid = null;
            if (cblisDurg.SelectedValue != null && (int)cblisDurg.SelectedValue > 0)
            {
                pid = (int)cblisDurg.SelectedValue;
            }
            else
            {
                if (!ShowAskDialog("重要提示", "您未选择药品，将执行修改药柜上所有药品效期到" + dpSetDateEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") + ",请慎重操作！确定要全部修改？", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
                {
                    return;
                }
            }

            bool isOk = _medicineCabinetDrugManageBLL.UpdateValidity(pid, dpSetDateEnd.Value);
            if (isOk)
            {
                ShowSuccessTip("操作成功");
                QueryData();
            }
            else
            {
                ShowErrorDialog("错误提示", "操作失败，请稍后再试");
            }
        }

        private void dgvList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            dgvList.RowHeadersWidth - 4,
            e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dgvList.RowHeadersDefaultCellStyle.Font,
            rectangle,
            dgvList.RowHeadersDefaultCellStyle.ForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

            dgvList.RowHeadersDefaultCellStyle.Padding = new Padding(dgvList.RowHeadersWidth);// 去掉行头三角号
        }
    }
}
