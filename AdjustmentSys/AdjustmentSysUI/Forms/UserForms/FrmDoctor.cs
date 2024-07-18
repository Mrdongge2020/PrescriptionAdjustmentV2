using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.User;
using AdjustmentSys.IService;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Service;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace AdjustmentSysUI.Forms.UserForms
{
    public partial class FrmDoctor : UIPage
    {
        private readonly DoctorInfoBLL _doctorInfoBLL = new DoctorInfoBLL();
        private readonly ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        private int checkDocId = 0;
        public FrmDoctor()
        {
            InitializeComponent();

            //科室下拉框
            List<ComboxModel> levelDatas = _comboxDataBLL.GetDoctorDepartmentComboxData();
            cbDepartment.ValueMember = "Id";
            cbDepartment.DisplayMember = "Name";
            cbDepartment.DataSource = levelDatas;
            cbDepartment.SelectedIndex = -1;

            //设置DataGridView
            InitDgvFormat();

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
            //初始化当前页
            uiPage.ActivePage = 1;
            //设置分页控件每页数量
            uiPage.PageSize = 20;
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();

            //创建列
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ID", "编号", true, false, 1, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DoctorName", "医生名称", true, true, 11, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "InitialPinyin", "拼音简称", true, true, 6, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DoctorDepartmentName", "所属科室", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Phone", "电话", true, true, 10, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Office", "办公室", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "EMail", "EMail地址", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Remark", "备注", true, true, 12, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateName", "创建人", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateTime", "创建时间", true, true, 10, "yyyy-MM-dd HH:mm:ss");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "UpdateName", "更新人", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "UpdateTime", "更新时间", true, true, 10, "yyyy-MM-dd HH:mm:ss");

        }

        //重置
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtDocKey.Text = "";
            cbDepartment.SelectedIndex = -1;
        }

        /// <summary>
        /// 查询医生信息
        /// </summary>
        public void QueryPageList()
        {
            string? keywordstr = txtDocKey.Text?.Trim();
            int? depId = cbDepartment.SelectedIndex != -1 ? Convert.ToInt32(cbDepartment.SelectedValue) : null;

            int allCount = 0;//总条数
            var datas = _doctorInfoBLL.GetDoctorInfoByPage(keywordstr, depId, uiPage.ActivePage, uiPage.PageSize, out allCount);
            //设置分页控件总数
            uiPage.TotalCount = allCount;

            dgvList.DataSource = datas;

            //清除默认选中的行
            dgvList.ClearSelection();
            checkDocId = 0;

        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            QueryPageList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkDocId == 0)
            {
                ShowWarningDialog("异常提示", "请先选择要删除的医生");
                return;
            }
            if (!ShowAskDialog("删除提示", "确定要删除选中的医生吗", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
            {
                return;
            }
            var msg = _doctorInfoBLL.DeleteDoctorInfo(checkDocId);
            if (msg == "")
            {
                ShowErrorTip("删除成功");
                QueryPageList();
            }
            else
            {
                ShowErrorDialog("错误提示", msg);
            }
        }

        private void btnEditDoctor_Click(object sender, EventArgs e)
        {
            if (checkDocId == 0)
            {
                ShowWarningDialog("异常提示", "请先选择要编辑的医生");
                return;
            }

            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmDoctorEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmDoctorEdit frmEdit = new FrmDoctorEdit(checkDocId);
            frmEdit.Text = "编辑医生";
            frmEdit.ShowDialog();
            string msg = frmEdit.resultMsg;
            if (msg == "Successed")
            {
                ShowSuccessTip("编辑医生成功");
                QueryPageList();
            }
            else if (msg != "")
            {
                ShowErrorDialog("错误提示", msg);
            }
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmDoctorEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmDoctorEdit frmEdit = new FrmDoctorEdit(0);
            frmEdit.Text = "新增医生";
            frmEdit.ShowDialog();
            string msg = frmEdit.resultMsg;
            if (msg == "Successed")
            {
                ShowSuccessTip("新增医生成功");
                QueryPageList();
            }
            else if (msg != "")
            {
                ShowErrorDialog("错误提示", msg);
            }
        }

       
        private void uiPage_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            QueryPageList();
        }

        private void btnRefc_Click(object sender, EventArgs e)
        {
            QueryPageList();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头点击不处理
            if (e.RowIndex < 0) { return; }

            checkDocId = Convert.ToInt32(this.dgvList.Rows[e.RowIndex].Cells["ID"].Value);
        }

        private void FrmDoctor_Load(object sender, EventArgs e)
        {
            //清除默认选中的行
            dgvList.ClearSelection();
            checkDocId = 0;
        }
    }
}
