using AdjustmentSys.BLL.Drug;
using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.Tool.Enums;
using AdjustmentSysUI.UITool;
using Microsoft.Identity.Client.NativeInterop;
using Microsoft.IdentityModel.Tokens;
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
    public partial class FrmAgreementPrescriptionManager : UIPage
    {
        PrescriptionBLL _prescriptionBLL = new PrescriptionBLL();
        private int selectId = 0;//选择的协定方
        public FrmAgreementPrescriptionManager()
        {
            InitializeComponent();
            InitControl();
        }
        private void InitControl()
        {
            //分页列表
            dgvList.AutoGenerateColumns = false;//不自动生成列
            dgvList.AllowUserToAddRows = false;//不自动产生最后的新行
            dgvList.AllowUserToResizeRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //初始化当前页
            uiPage.ActivePage = 1;
            //设置分页控件每页数量
            uiPage.PageSize = 20;
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ID", "主键", true, false, 1, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Name", "协定方名称", true, true, 0, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateName", "创建人", true, true, 0, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateTime", "创建时间", true, true, 0, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Description", "描述", true, true, 0, "");

            dgvPreDetail.AutoGenerateColumns = false;//不自动生成列
            dgvPreDetail.AllowUserToAddRows = false;//不自动产生最后的新行
            dgvPreDetail.AllowUserToResizeRows = false;
            dgvPreDetail.AllowUserToResizeColumns = false;
            dgvPreDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //初始化当前页
            uiPage.ActivePage = 1;
            //设置分页控件每页数量
            uiPage.PageSize = 20;
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "ParticlesId", "颗粒id", true, false, 1, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "Name", "颗粒名称", true, true, 0, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "DoseHerb", "饮片剂量", true, true, 0, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "Equivalent", "当量", true, true, 0, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "Dose", "颗粒剂量", true, true, 0, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "Price", "单价", true, true, 0, "");
        }

        private void QueryPageList()
        {
            string name = txtName.Text;
            int allCount = 0;//总条数
            var preDatas = _prescriptionBLL.GetAgreementPrescriptionByPage(name, uiPage.ActivePage, uiPage.PageSize, out allCount);
            //设置分页控件总数
            uiPage.TotalCount = allCount;

            dgvList.DataSource = preDatas;

            this.dgvList.TopLeftHeaderCell.Value = "序号";

            //清除默认选中的行
            dgvList.ClearSelection();
            selectId = 0;
            foreach (DataGridViewRow row in dgvList.SelectedRows)
            {
                row.Selected = false;
            }
        }

        private void QueryDetails()
        {
            if (selectId == 0) { return; }

            var preDetails = _prescriptionBLL.GetAgreementPrescriptionDetails(selectId);
            dgvPreDetail.DataSource = preDetails;

        }

        private void uiPage_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            QueryPageList();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryPageList();
        }

        private void FrmAgreementPrescriptionManager_Load(object sender, EventArgs e)
        {
            QueryPageList();

        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头点击不处理
            if (e.RowIndex < 0) { return; }

            selectId =int.Parse(this.dgvList.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            QueryDetails();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmAgreementPrescriptionAdd).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmAgreementPrescriptionAdd frmAgreementPrescriptionAdd = new FrmAgreementPrescriptionAdd(null);
            frmAgreementPrescriptionAdd.Text = "新建协定方";
            frmAgreementPrescriptionAdd.ShowDialog();
            string msg = frmAgreementPrescriptionAdd.saveMessage;
            if (msg == "Successed")
            {
                ShowSuccessTip("新建协定方成功");
                QueryPageList();
            }
            else if (msg != "")
            {
                ShowErrorDialog("错误提示", msg);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectId == 0)
            {
                ShowWarningDialog("异常提示", "请先选择要编辑的协定方");
                return;
            }
            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmAgreementPrescriptionAdd).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmAgreementPrescriptionAdd frmAgreementPrescriptionAdd = new FrmAgreementPrescriptionAdd(selectId);
            frmAgreementPrescriptionAdd.Text = "编辑协定方";
            frmAgreementPrescriptionAdd.ShowDialog();
            string msg = frmAgreementPrescriptionAdd.saveMessage;
            if (msg == "Successed")
            {
                ShowSuccessTip("编辑协定方成功");
                QueryPageList();
            }
            else if (msg != "")
            {
                ShowErrorDialog("错误提示", msg);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectId == 0)
            {
                ShowWarningDialog("异常提示", "请先选择要删除的协定方");
                return;
            }
            if (!ShowAskDialog("删除提示", "确定要删除选中的协定方吗", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
            {
                return;
            }
            var msg = _prescriptionBLL.DeleteAgreementPrescriptionInfo(selectId);
            if (msg == "")
            {
                ShowSuccessTip("删除成功");
                QueryPageList();
            }
            else
            {
                ShowErrorDialog("错误提示", msg);
            }
        }

        private void btnSetPre_Click(object sender, EventArgs e)
        {
            if (selectId == 0)
            {
                ShowWarningDialog("异常提示", "请先选择要复制的处方");
                return;
            }

            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmPrescriptionAdd).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }

            FrmPrescriptionAdd frmPrescriptionAdd = new FrmPrescriptionAdd("", null, selectId);
            frmPrescriptionAdd.Text = "协定方生成处方";
            frmPrescriptionAdd.ShowDialog();

            string msg = frmPrescriptionAdd.saveMessage;
            if (msg == "Successed")
            {
                ShowSuccessTip("提交处方成功");
            }
            else if (msg != "")
            {
                ShowErrorDialog("错误提示", msg);
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
        }
    }
}
