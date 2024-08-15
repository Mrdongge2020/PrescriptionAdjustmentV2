using AdjustmentSys.BLL.MedicineCabinet;
using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.IService;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Tool.Enums;
using AdjustmentSysUI.Forms.MedicineCabinetForms;
using AdjustmentSysUI.Forms.UserForms;
using AdjustmentSysUI.UITool;
using Microsoft.Identity.Client.NativeInterop;
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
    public partial class FrmPrescriptionList : UIPage
    {
        PrescriptionBLL _prescriptionBLL = new PrescriptionBLL();
        string selectPreId = "";//处方编号
        public FrmPrescriptionList()
        {
            InitializeComponent();
        }
        private void FrmPrescriptionList_Load(object sender, EventArgs e)
        {
            var names = Enum.GetNames(typeof(ProcessStatusEnum));
            int index = 0;
            List<ComboxModel> preStatuslist = new List<ComboxModel>();
            foreach (var name in names)
            {
                preStatuslist.Add(new ComboxModel() { Id = index, Name = name });
                index++;
            }
            cbPreState.ValueMember = "Id";
            cbPreState.DisplayMember = "Name";
            cbPreState.DataSource = preStatuslist;

            ClearQueryCondition();
            //列表格式添加
            InitDgvFormat();
            //加载数据
            QueryPrePageList();
            //清除默认选中的行
            dgvList.ClearSelection();

            InitPreDetail();
            dgvPreDetail.ClearSelection();
        }

        /// <summary>
        /// 设置dgv格式
        /// </summary>
        private void InitDgvFormat()
        {
            if (dgvList.Columns.Count > 0)
            {
                // 清除旧的列
                dgvList.Columns.Clear();
            }
            //分页列表
            dgvList.AutoGenerateColumns = false;//不自动生成列
            dgvList.AllowUserToAddRows = false;//不自动产生最后的新行
            dgvList.AllowUserToResizeRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //初始化当前页
            uiPage.ActivePage = 1;
            //设置分页控件每页数量
            uiPage.PageSize = 20;
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
            int datecolwidth = 160;
            //创建列
            //dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ID", "主键", true, false, 0, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PrescriptionID", "处方编号", true, true, 130, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PatientName", "患者姓名", true, true, 90, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PatientSexText", "性别", true, true, 60, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PatientAgeText", "年龄", true, true, 70, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PatientTel", "联系电话", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Quantity", "付数", true, true, 60, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "TaskFrequency", "分服次数", true, true, 70, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DetailedCount", "明细条数", true, true, 70, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ProcessStatusText", "处方状态", true, true, 80, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DoctorName", "医生", true, true, 90, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DepartmentName", "科室", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PrescriptionSourceText", "处方来源", true, true, 80, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "UnitPrice", "处方单价", true, true, 70, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "TotalPrice", "处方总价", true, true, 70, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateName", "创建人", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateTime", "创建时间", true, true, datecolwidth, "yyyy-MM-dd HH:mm:ss");

            if (cbPreState.SelectedIndex > 0)
            {
                dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DownloadName", "下载人", true, true, 100, "");
                dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DownloadTime", "下载时间", true, true, datecolwidth, "yyyy-MM-dd HH:mm:ss");
            }
            if (cbPreState.Text == Enum.GetName(typeof(ProcessStatusEnum), ProcessStatusEnum.完成))
            {
                dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "BoxNumber", "盒数", true, true, 60, "");
                dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "AllocateName", "调剂员", true, true, 100, "");
                dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CompleteTime", "完成时间", true, true, datecolwidth, "yyyy-MM-dd HH:mm:ss");
                dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "TimeConsumingSecond", "调配耗时秒", true, true, 70, "");
                dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DeviceName", "设备名称", true, true, 100, "");
                dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "AnalysisResult", "处方分析结果", true, true, 100, "");
            }
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PatientLocation", "患者位置", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PrescriptionName", "协定处方名称", true, true, 110, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ValuerName", "划价员", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ValueSn", "划价单号", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ValuationTime", "划价时间", true, true, datecolwidth, "yyyy-MM-dd HH:mm:ss");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PaymentType", "缴费类型", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PaymentStatus", "缴费状态", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PrescriptionType", "处方类型", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ImportTime", "导入时间", true, true, datecolwidth, "yyyy-MM-dd HH:mm:ss");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Remarks", "备注", true, true, 100, "");

        }

        /// <summary>
        /// 查询处方信息
        /// </summary>
        public void QueryPrePageList()
        {
            int? source = null;
            if (cbSource.SelectedIndex != -1)
            {
                source = cbSource.SelectedIndex;
            }

            int allCount = 0;//总条数
            var preDatas = _prescriptionBLL.GetPrescriptionPageList(txtPrID.Text, txtPatentName.Text, dtpStart.Value, dtpEnd.Value, source, (ProcessStatusEnum)(cbPreState.SelectedIndex), uiPage.ActivePage, uiPage.PageSize, out allCount);
            //设置分页控件总数
            uiPage.TotalCount = allCount;

            dgvList.DataSource = preDatas;

            this.dgvList.TopLeftHeaderCell.Value = "序号";

            //清除默认选中的行
            dgvList.ClearSelection();
            selectPreId = "";
            foreach (DataGridViewRow row in dgvList.SelectedRows)
            {
                row.Selected = false;
            }
        }

        /// <summary>
        /// 初始化处方详情表格
        /// </summary>
        private void InitPreDetail()
        {
            dgvPreDetail.AutoGenerateColumns = false;//不自动生成列
            dgvPreDetail.AllowUserToAddRows = false;//不自动产生最后的新行
            dgvPreDetail.AllowUserToResizeRows = false;
            dgvPreDetail.AllowUserToResizeColumns = false;
            dgvPreDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "ID", "主键", true, false, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "ParticleOrder", "序号", true, true, 50, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "ParCode", "颗粒编号", true, true, 90, "");           
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "ParName", "颗粒名称", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "DoseHerb", "饮片剂量", true, true, 80, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "Equivalent", "当量", true, true, 80, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "Dose", "颗粒剂量", true, true, 80, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "Price", "单价", true, true, 80, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "ParticlesNameHIS", "HIS名称", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "ParticlesCodeHIS", "HIS码", true, true, 80, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "BatchNumber", "批号", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "Stock", "库存", true, false, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvPreDetail, DataGridViewContentAlignment.MiddleLeft, "DoseLimit", "剂量上限", true, false, 100, "");

        }
        /// <summary>
        /// 查询处方详情
        /// </summary>
        private void QueryPreDetailList()
        {
            var preDetailsDatas = _prescriptionBLL.GetPrescriptionDetailList(selectPreId, (ProcessStatusEnum)(cbPreState.SelectedIndex));
            dgvPreDetail.DataSource = preDetailsDatas;
            dgvPreDetail.ClearSelection();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearQueryCondition();
        }

        private void ClearQueryCondition()
        {
            txtPrID.Text = string.Empty;
            txtPatentName.Text = string.Empty;
            cbPreState.SelectedIndex = 0;
            cbSource.SelectedIndex = -1;
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头点击不处理
            if (e.RowIndex < 0) { return; }

            selectPreId = this.dgvList.Rows[e.RowIndex].Cells["PrescriptionID"].Value.ToString();
            QueryPreDetailList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            InitDgvFormat();
            QueryPrePageList();
        }

        private void uiPage_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            QueryPrePageList();
        }

        private void btnAddPre_Click(object sender, EventArgs e)
        {
            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmPrescriptionAdd).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmPrescriptionAdd frmPrescriptionAdd = new FrmPrescriptionAdd("", null,null);
            frmPrescriptionAdd.Text = "录入处方";
            frmPrescriptionAdd.ShowDialog();
            string msg = frmPrescriptionAdd.saveMessage;
            if (msg == "Successed")
            {
                ShowSuccessTip("提交处方成功");
                QueryPrePageList();
            }
            else if (msg != "")
            {
                ShowErrorDialog("错误提示", msg);
            }

        }

        private void btnCopyPre_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectPreId))
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

            FrmPrescriptionAdd frmPrescriptionAdd = new FrmPrescriptionAdd(selectPreId, cbPreState.SelectedIndex,null);
            frmPrescriptionAdd.Text = "复制处方";
            frmPrescriptionAdd.ShowDialog();

            string msg = frmPrescriptionAdd.saveMessage;
            if (msg == "Successed")
            {
                ShowSuccessTip("提交处方成功");
                QueryPrePageList();
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
