using AdjustmentSys.BLL.User;
using AdjustmentSys.IService;
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

namespace AdjustmentSysUI.Forms.UserForms
{
    public partial class FrmDocDepartment : UIPage
    {
        DepartmentInfoBLL departmentInfoBLL = new DepartmentInfoBLL();
        private int checkedDepId = 0;
        public FrmDocDepartment()
        {
            InitializeComponent();
            InitDgvFormat();
        }

        /// <summary>
        /// 查询部门信息
        /// </summary>
        public void QueryPageList()
        {
            string? keywordstr = txtKey.Text?.Trim();

            int allCount = 0;//总条数
            var datas = departmentInfoBLL.GetDepartmentInfoByPage(keywordstr, uiPage.ActivePage, uiPage.PageSize, out allCount);
            //设置分页控件总数
            uiPage.TotalCount = allCount;

            dgvList.DataSource = datas;

            //清除默认选中的行
            dgvList.ClearSelection();
            checkedDepId = 0;
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
            //初始化当前页
            uiPage.ActivePage = 1;
            //设置分页控件每页数量
            uiPage.PageSize = 20;
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
            //创建列
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ID", "编号", true, false, 1, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DepartmentName", "科室名称", true, true, 10, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Contacts", "联系人", true, true, 10, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ContactsPhone", "联系人电话", true, true, 10, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Address", "地址", true, true, 10, ""); ;
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Remark", "备注", true, true, 20, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateName", "创建人", true, true, 10, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateTime", "创建时间", true, true, 10, "yyyy-MM-dd HH:mm:ss");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "UpdateName", "更新人", true, true, 9, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "UpdateTime", "更新时间", true, true, 10, "yyyy-MM-dd HH:mm:ss");
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            QueryPageList();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKey.Text = "";
        }

        private void uiPage_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            QueryPageList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmDocDepartmentEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmDocDepartmentEdit frmEdit = new FrmDocDepartmentEdit(0);
            frmEdit.Text = "新增科室";
            frmEdit.ShowDialog();
            string msg = frmEdit.resultMsg;
            if (msg == "Successed")
            {
                ShowSuccessTip("新增医生科室成功");
                QueryPageList();
            }
            else if (msg != "")
            {
                ShowErrorDialog("错误提示", msg);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (checkedDepId == 0)
            {
                ShowWarningDialog("异常提示", "请先选择要编辑的科室");
                return;
            }

            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmDocDepartmentEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmDocDepartmentEdit frmEdit = new FrmDocDepartmentEdit(checkedDepId);
            frmEdit.Text = "编辑科室";
            frmEdit.ShowDialog();
            string msg = frmEdit.resultMsg;
            if (msg == "Successed")
            {
                ShowSuccessTip("编辑医生科室成功");
                QueryPageList();
            }
            else if (msg != "")
            {
                ShowErrorDialog("错误提示", msg);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkedDepId == 0)
            {
                ShowWarningDialog("异常提示", "请先选择要删除的科室");
                return;
            }
            if (!ShowAskDialog("删除提示", "确定要删除选中的科室吗", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
            {
                return;
            }
            var msg = departmentInfoBLL.DeleteDepartmentInfo(checkedDepId);
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

        private void FrmDocDepartment_Load(object sender, EventArgs e)
        {
            //清除默认选中的行
            dgvList.ClearSelection();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头点击不处理
            if (e.RowIndex < 0) { return; }

            checkedDepId = Convert.ToInt32(this.dgvList.Rows[e.RowIndex].Cells["ID"].Value);
        }

        private void btnRefc_Click(object sender, EventArgs e)
        {
            QueryPageList();
            checkedDepId = 0;
        }
    }
}
