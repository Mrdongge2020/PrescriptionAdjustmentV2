using AdjustmentSys.BLL.Drug;
using AdjustmentSys.BLL.User;
using AdjustmentSys.Common.Tool;
using AdjustmentSys.Models.Drug;
using AdjustmentSysUI.Forms.Drug;
using AdjustmentSysUI.Forms.DrugForms;
using AdjustmentSysUI.Forms.UserForms;
using AdjustmentSysUI.UITool;
using NPOI.SS.UserModel;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdjustmentSysUI.Forms.Pharmacopoeia
{
    public partial class FrmDrugManagement : UIPage
    {
        DrugManagermentBLL _drugManagermentBLL = new DrugManagermentBLL();
        private int _drugId;
        public FrmDrugManagement()
        {
            InitializeComponent();
            //设置DataGridView
            InitDgvFormat();
            QueryPageList();
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
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.RowHeadersVisible = false;
            //初始化当前页
            //uiPage.ActivePage = 1;
            //设置分页控件每页数量
            uiPage.PageSize = 20;
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();

            //创建列
            int width = 125;
            int width1 = 165;
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ID", "id", true, false, width, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Code", "颗粒编号", true, true, width, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Name", "名称简称", true, true, width, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "FullName", "名称全称", true, true, width, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "NameFullPinyin", "名称全拼", true, true, width, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "NameSimplifiedPinyin", "名称简拼", true, true, width, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "HisCode", "His码", true, true, width, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Density", "颗粒密度", true, true, width, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Equivalent", "颗粒当量", true, true, width, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DoseLimit", "剂量上限", true, true, width, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "PackageNumber", "大包装码", true, true, width, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "WholesalePrice", "批发价", true, true, width, "N3");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "RetailPrice", "零售价", true, true, width, "N3");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ManufacturerName", "厂家名称", true, true, width, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ListingNumber", "上市编号", true, true, width, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Remark", "备注", true, true, width, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "UpdateName", "更新人", true, true, width, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "UpdateTime", "更新时间", true, true, width1, "yyyy-MM-dd HH:mm:ss");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtKeywords.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            QueryPageList();
        }

        /// <summary>
        /// 查询颗粒信息
        /// </summary>
        public void QueryPageList()
        {
            string? keywordstr = txtKeywords.Text?.Trim();
            int allCount = 0;//总条数
            var datas = _drugManagermentBLL.GetDrugInfoByPage(keywordstr, uiPage.ActivePage, uiPage.PageSize, out allCount);
            //设置分页控件总数
            uiPage.TotalCount = allCount;

            dgvList.DataSource = datas;

            //清除默认选中的行
            dgvList.ClearSelection();
            _drugId = 0;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmDrugEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmDrugEdit frmEdit = new FrmDrugEdit(0);
            frmEdit.Text = "新增药品";
            frmEdit.ShowDialog();
            bool isOK = frmEdit.isSuccess;
            if (isOK)
            {
                ShowSuccessTip("新增成功");
                QueryPageList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_drugId == 0)
            {
                ShowWarningDialog("异常提示", "请先选择要编辑的药品");
                return;
            }

            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmDrugEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmDrugEdit frmEdit = new FrmDrugEdit(_drugId);
            frmEdit.Text = "编辑药品";
            frmEdit.ShowDialog();
            bool isOK = frmEdit.isSuccess;
            if (isOK)
            {
                ShowSuccessTip("编辑成功");
                QueryPageList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_drugId == 0)
            {
                ShowWarningDialog("异常提示", "请先选择要删除的药品");
                return;
            }
            if (!ShowAskDialog("删除提示", "确定要删除选中的药品吗", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
            {
                return;
            }
            var msg = _drugManagermentBLL.DeleteDrugInfo(_drugId);
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

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头点击不处理
            if (e.RowIndex < 0) { return; }

            _drugId = Convert.ToInt32(this.dgvList.Rows[e.RowIndex].Cells["ID"].Value);
        }

        private void FrmDrugManagement_Load(object sender, EventArgs e)
        {
            //清除默认选中的行
            dgvList.ClearSelection();
            _drugId = 0;
        }

        private void btnRefc_Click(object sender, EventArgs e)
        {
            QueryPageList();
        }

        private void uiPage_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            QueryPageList();
        }

        private void 药品数据导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var exportDatas = _drugManagermentBLL.ParticlesExports();
            if (exportDatas == null || exportDatas.Count <= 0)
            {
                ShowWarningDialog("导出提示", "要导出的药品信息不存在");
                return;
            }
            ExportParticles(exportDatas.ToList<object>());
        }

        private void ExportParticles(List<object>? list)
        {
            //组装生成工作簿参数
            List<ExcelDataResource> excelDataResources = new List<ExcelDataResource>()
            {
                new ExcelDataResource ()
                {
                    SheetName="药品信息",
                    TitleIndex=1,
                    SheetDataResource=list
                }
            };

            //生成工作簿
            IWorkbook workbook1 = ExcelOperationHelper.DataToHSSFWorkbook(excelDataResources);

            //导出操作
            SaveFileDialog objSaveFileDialog = new SaveFileDialog();
            objSaveFileDialog.Filter = @"Excel (*.xls)|*.xls";//@"Excel2007文件(*.xlsx)|*.xlsx|Excel2003文件(*.xls)|*.xls";
            objSaveFileDialog.Title = "请选择保存位置";
            objSaveFileDialog.FileName = "药品信息" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (objSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //导出excel文件，提示文件地址
                    string exportMsg = ExcelOperationHelper.ExportWorkbookToLocal(workbook1, objSaveFileDialog.FileName);
                    MessageBox.Show(exportMsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出失败:<{ex.Message}>", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnOpterDropDown_Click(object sender, EventArgs e)
        {
            btnOpterDropDown.ShowContextMenuStrip(cmsOpterDurgData, 0, btnOpterDropDown.Height);
        }

        private void brnDrugExport_Click(object sender, EventArgs e)
        {
            brnDrugExport.ShowContextMenuStrip(cmsDurgExcelOpter, 0, brnDrugExport.Height);
        }

        private void 药品数据导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDurgExcelInfoShow frmDurgExcelInfoShow = new FrmDurgExcelInfoShow();
            frmDurgExcelInfoShow.ShowDialog();
        }

        private void 匹配数据导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParticleDataMate frmParticleDataMate = new FrmParticleDataMate();
            frmParticleDataMate.ShowDialog();
        }
    }
}
