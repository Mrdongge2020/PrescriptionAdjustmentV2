using AdjustmentSys.Entity;
using AdjustmentSys.IService;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.User;
using AdjustmentSys.Service;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace AdjustmentSysUI.Forms.UserForms
{
    public partial class FrmUser : UIPage
    {
        private readonly UserInfoBLL _userInfoBLL = new UserInfoBLL();
        private int checkedUserId = 0;
        public FrmUser()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            //可用禁用下拉赋值
            var cbItemList = new List<ComboxModel> {
                new ComboxModel(){ Id=0,Name="启用"},
                new ComboxModel(){ Id=1,Name="禁用"},
            };

            cbUserState.ValueMember = "Id";
            cbUserState.DisplayMember = "Name";
            cbUserState.DataSource = cbItemList;
            cbUserState.SelectedIndex = -1;

            //列表格式添加
            InitDgvFormat();
        }
        /// <summary>
        /// 重置按钮点击事件
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserKey.Text = string.Empty;
            cbUserState.SelectedIndex = -1;
        }

        //添加用户点击事件
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmUserEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmUserEdit frmUserEdit = new FrmUserEdit(0);
            frmUserEdit.Text = "新增用户";
            frmUserEdit.Show();
        }

        //编辑用户点击事件
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (checkedUserId == 0)
            {
                ShowWarningDialog("异常提示", "请先选择要编辑的用户");
                return;
            }

            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmUserEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmUserEdit frmUserEdit = new FrmUserEdit(checkedUserId);
            frmUserEdit.Text = "编辑用户";

            frmUserEdit.Show();
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        public void QueryUserList()
        {
            string? keywordstr = txtUserKey.Text?.Trim();
            bool? state = null;
            if (cbUserState.SelectedValue != null && cbUserState.SelectedValue.ToString() == "0")
            {
                state = true;
            }
            else if (cbUserState.SelectedValue != null && cbUserState.SelectedValue.ToString() == "1")
            {
                state = false;
            }
            int allCount = 0;//总条数
            var userDatas = _userInfoBLL.GetUserInfoByPage(keywordstr, state, uiPage.ActivePage, uiPage.PageSize, out allCount);
            //设置分页控件总数
            uiPage.TotalCount = allCount;

            dgvUserList.DataSource = userDatas;

            //清除默认选中的行
            dgvUserList.ClearSelection();
            checkedUserId = 0;
        }

        /// <summary>
        /// 设置dgv格式
        /// </summary>
        private void InitDgvFormat()
        {
            //分页列表
            dgvUserList.AutoGenerateColumns = false;//不自动生成列
            dgvUserList.AllowUserToAddRows = false;//不自动产生最后的新行
            dgvUserList.AllowUserToResizeRows = false;
            dgvUserList.AllowUserToResizeColumns = false;
            dgvUserList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //初始化当前页
            uiPage.ActivePage = 1;
            //设置分页控件每页数量
            uiPage.PageSize = 20;
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
            //创建列
            //dataGradeViewUi.InitDgvCheckBoxColumn(this.dgvUserList, DataGridViewContentAlignment.MiddleLeft, "", "选择", false, true, 5);
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvUserList, DataGridViewContentAlignment.MiddleLeft, "ID", "编号", true, false, 1, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvUserList, DataGridViewContentAlignment.MiddleLeft, "UserName", "用户名称", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvUserList, DataGridViewContentAlignment.MiddleLeft, "StateText", "状态", true, true, 6, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvUserList, DataGridViewContentAlignment.MiddleLeft, "UserLevelName", "权限等级", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvUserList, DataGridViewContentAlignment.MiddleLeft, "Phone", "电话", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvUserList, DataGridViewContentAlignment.MiddleLeft, "Office", "办公室", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvUserList, DataGridViewContentAlignment.MiddleLeft, "Remark", "备注", true, true, 25, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvUserList, DataGridViewContentAlignment.MiddleLeft, "CreateName", "创建人", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvUserList, DataGridViewContentAlignment.MiddleLeft, "CreateTime", "创建时间", true, true, 10, "yyyy-MM-dd HH:mm:ss");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvUserList, DataGridViewContentAlignment.MiddleLeft, "UpdateName", "更新人", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvUserList, DataGridViewContentAlignment.MiddleLeft, "UpdateTime", "更新时间", true, true, 10, "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            QueryUserList();
        }

        private void uiPage_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            QueryUserList();
        }

        private void dgvUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头点击不处理
            if (e.RowIndex < 0) { return; }

            checkedUserId = Convert.ToInt32(this.dgvUserList.Rows[e.RowIndex].Cells["ID"].Value);
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            //清除默认选中的行
            dgvUserList.ClearSelection();
        }

        private void btnRefc_Click(object sender, EventArgs e)
        {
            QueryUserList();
            checkedUserId = 0;
        }
    }
}
