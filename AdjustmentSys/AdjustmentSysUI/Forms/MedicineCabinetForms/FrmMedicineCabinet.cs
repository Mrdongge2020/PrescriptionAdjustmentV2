using AdjustmentSys.BLL.Device;
using AdjustmentSys.BLL.MedicineCabinet;
using AdjustmentSysUI.Forms.DeviceForms;
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

namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    public partial class FrmMedicineCabinet : UIPage
    {
        private int _Id;
        MedicineCabinetInfoBLL _medicineCabinetInfoBLL = new MedicineCabinetInfoBLL();
        public FrmMedicineCabinet()
        {
            InitializeComponent();
            InitDgvFormat();
            QueryList();
        }

        /// <summary>
        /// 设置列表
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
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ID", "id", true, false, 1, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Code", "设备编组", true, true, 16, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Name", "设备名称", true, true, 16, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Specifications", "规格", true, true, 16, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "RowCount", "药柜层数", true, true, 16, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ColCount", "单层个数", true, true, 16, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Remark", "备注", true, true, 19, "");
        }

        /// <summary>
        /// 查询设备列表信息
        /// </summary>
        public void QueryList()
        {
            var datas = _medicineCabinetInfoBLL.GetCabinetInfoList();

            dgvList.DataSource = datas;

            //清除默认选中的行
            dgvList.ClearSelection();
            _Id = 0;
        }

        private void FrmMedicineCabinet_Load(object sender, EventArgs e)
        {
            //清除默认选中的行
            dgvList.ClearSelection();
            _Id = 0;
        }

        private void btnRefc_Click(object sender, EventArgs e)
        {
            QueryList();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头点击不处理
            if (e.RowIndex < 0) { return; }

            _Id = Convert.ToInt32(this.dgvList.Rows[e.RowIndex].Cells["ID"].Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmMedicineCabinetEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmMedicineCabinetEdit frmEdit = new FrmMedicineCabinetEdit(0);
            frmEdit.Text = "新增药柜";
            frmEdit.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_Id == 0)
            {
                ShowWarningDialog("异常提示", "请先选择要删除的药柜信息");
                return;
            }
            if (!ShowAskDialog("删除提示", "确定要删除选中的药柜信息吗？这将同时删除此药柜备相关配置信息，不可恢复！", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
            {
                return;
            }
            var msg = _medicineCabinetInfoBLL.DeleteCabinetInfo(_Id);
            if (msg == "")
            {
                ShowSuccessTip("删除成功");
                QueryList();
            }
            else
            {
                ShowErrorDialog("错误提示", msg);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_Id == 0)
            {
                ShowWarningDialog("异常提示", "请先选择要编辑的药柜信息");
                return;
            }
            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmMedicineCabinetEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmMedicineCabinetEdit frmEdit = new FrmMedicineCabinetEdit(_Id);
            frmEdit.Text = "编辑药柜";
            frmEdit.Show();
        }
    }
}
