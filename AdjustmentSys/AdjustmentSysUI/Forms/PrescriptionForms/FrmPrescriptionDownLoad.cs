using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.BLL.User;
using AdjustmentSys.Tool.Enums;
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

namespace AdjustmentSysUI.Forms.PrescriptionForms
{
    public partial class FrmPrescriptionDownLoad : UIForm
    {
        PrescriptionBLL _prescriptionBLL = new PrescriptionBLL();
        string selectPreId = "";//处方编号
        string sortString = " CreateTime desc ";
        public List<string> loadPrescriptionIdList = new List<string>();
        public FrmPrescriptionDownLoad()
        {
            InitializeComponent();
        }
        private void FrmPrescriptionDownLoad_Load(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
            InitDgvFormat();
            InitPreDetail();
            QueryPrePageList();
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
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
            int datecolwidth = 160;
            //创建列
            dataGradeViewUi.InitDgvCheckBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "isCheck", "选择", false, true, 60);
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PrescriptionID", "处方编号", true, true, 130, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PatientName", "患者姓名", true, true, 90, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PatientSexText", "性别", true, true, 60, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PatientAgeText", "年龄", true, true, 70, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PatientTel", "联系电话", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Quantity", "付数", true, true, 60, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "TaskFrequency", "分服次数", true, true, 70, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DetailedCount", "明细条数", true, true, 70, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DoctorName", "医生", true, true, 90, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DepartmentName", "科室", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PrescriptionSourceText", "处方来源", true, true, 80, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "UnitPrice", "处方单价", true, true, 70, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "TotalPrice", "处方总价", true, true, 70, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateName", "创建人", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateTime", "创建时间", true, true, datecolwidth, "yyyy-MM-dd HH:mm:ss");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Remarks", "备注", true, true, 100, "");

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

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearQueryCondition();
        }
        private void ClearQueryCondition()
        {
            txtPrID.Text = string.Empty;
            txtPatentName.Text = string.Empty;
            cbSource.SelectedIndex = -1;
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
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
            var preDatas = _prescriptionBLL.GetPrescriptionPageList(txtPrID.Text, txtPatentName.Text, dtpStart.Value, dtpEnd.Value, source, ProcessStatusEnum.待下载, sortString, 1, 10000, out allCount);

            dgvList.DataSource = preDatas;

            this.dgvList.TopLeftHeaderCell.Value = "共" + allCount + "条";

            //清除默认选中的行
            dgvList.ClearSelection();
            selectPreId = "";
            foreach (DataGridViewRow row in dgvList.SelectedRows)
            {
                row.Selected = false;
            }
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头点击不处理
            if (e.RowIndex < 0) { return; }

            selectPreId = this.dgvList.Rows[e.RowIndex].Cells["PrescriptionID"].Value.ToString();
            QueryPreDetailList();
        }

        /// <summary>
        /// 查询处方详情
        /// </summary>
        private void QueryPreDetailList()
        {
            var preDetailsDatas = _prescriptionBLL.GetPrescriptionDetailList(selectPreId, ProcessStatusEnum.待下载, true);
            dgvPreDetail.DataSource = preDetailsDatas;
            dgvPreDetail.ClearSelection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            QueryPrePageList();
        }

        //获取选中待下载的处方编号
        private List<string> GetAllCheckPreId()
        {
            List<string> checkedList = new List<string>(); //选中待下载的处方编号
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                DataGridViewCheckBoxCell checkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                if (checkCell != null && (bool)checkCell.EditedFormattedValue == true)
                {
                    checkedList.Add(row.Cells["PrescriptionID"].Value.ToString());
                }
            }
            return checkedList;
        }

        private void btnZuoFei_Click(object sender, EventArgs e)
        {
            List<string> preIds = GetAllCheckPreId();
            if (preIds == null || preIds.Count <= 0)
            {
                ShowWarningDialog("异常提示", "请勾选要作废的处方");
                return;
            }
            if (!ShowAskDialog("作废提示", "确定要作废已勾选的处方吗，作废后将不可恢复，谨慎操作。", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
            {
                return;
            }
            var msg = _prescriptionBLL.UpdatePrescriptionStatus(preIds, ProcessStatusEnum.作废);
            if (msg == "")
            {
                ShowSuccessTip("作废成功");
                QueryPrePageList();
            }
            else
            {
                ShowErrorDialog("错误提示", msg);
            }
        }

        private void btnHis_Click(object sender, EventArgs e)
        {
            //if (selectPreId == "")
            //{
            //    ShowWarningDialog("异常提示", "请选中要匹配HIS码的处方");
            //    return;
            //}
            List<string> preIds = GetAllCheckPreId();
            if (preIds == null || preIds.Count <= 0)
            {
                ShowWarningDialog("异常提示", "请勾选要匹配HIS码的处方");
                return;
            }
            if (!ShowAskDialog("作废提示", $"确定要对已勾选的处方[{string.Join(",", preIds)}]匹配HIS码吗，操作不可逆，谨慎操作。", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
            {
                return;
            }
            int successCount = 0;
            var errorList = _prescriptionBLL.HisMate(new List<string> { selectPreId }, out successCount);
            if (successCount > 0)
            {
                errorList.Insert(0, $"成功匹配{successCount}条HIS码信息");
            }
            if (errorList != null && errorList.Count > 0)
            {

                ShowWarningDialog("结果提示", string.Join("\r\n", errorList));
                QueryPrePageList();
            }

        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            List<string> preIds = GetAllCheckPreId();
            if (preIds == null || preIds.Count <= 0)
            {
                ShowWarningDialog("异常提示", "请勾选要下载的处方");
                return;
            }
            List<string> errorList = null;
            loadPrescriptionIdList = _prescriptionBLL.DownLoadPrescriptions(preIds, out errorList);
            if (loadPrescriptionIdList != null && loadPrescriptionIdList.Count > 0)
            {
                if (errorList != null && errorList.Count > 0)
                {
                    ShowWarningDialog("错误提示", string.Join("\r\n", errorList));
                };
                this.Close();
            }
            else
            {
                if (errorList != null && errorList.Count > 0)
                {
                    ShowWarningDialog("错误提示", string.Join("\r\n", errorList));
                };
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

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头点击不处理
            if (e.RowIndex < 0) { return; }
            if (dgvList.Rows[e.RowIndex].Selected)
            {
                dgvList.Rows[e.RowIndex].Selected = false;
                selectPreId = "";
                QueryPreDetailList();
            }
        }

        private void btnUpdateHis_Click(object sender, EventArgs e)
        {
            if (dgvPreDetail.SelectedRows.Count<=0) 
            {
                ShowWarningDialog("异常提示", "请选择要更新HIS码的药品信息");
                return;
            }
          
            string code = dgvPreDetail.SelectedRows[0].Cells["ParticlesCodeHIS"].Value.ToString();
            string name = dgvPreDetail.SelectedRows[0].Cells["ParticlesNameHIS"].Value.ToString();
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
            dataGradeViewUi.FormClose("FrmUpdateHisCode");
            FrmUpdateHisCode frmUpdateHisCode = new FrmUpdateHisCode(code,name);
            frmUpdateHisCode.ShowDialog();
            string parName = frmUpdateHisCode.ParName;
            if (parName != "") 
            {
                ShowSuccessTip($"更新药品[{parName}]的HIS信息成功");
                QueryPreDetailList();
            }
        }
    }
}
