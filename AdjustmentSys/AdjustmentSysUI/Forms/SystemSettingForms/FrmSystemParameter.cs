using AdjustmentSys.BLL.SystemSetting;
using AdjustmentSys.IService;
using AdjustmentSys.Models.CommModel;
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

namespace AdjustmentSysUI.Forms.SystemSettingForms
{
    public partial class FrmSystemParameter : UIPage
    {
        SystemParameterBLL systemParameterBLL = new SystemParameterBLL();
        DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
        private int selectId;
        public FrmSystemParameter()
        {
            InitializeComponent();
            //列表格式添加
            InitDgvFormat();
        }

        private void InitData()
        {
            var cbItemList = new List<ComboxModel> {
                new ComboxModel(){ Id=-1,Name="全部"},
                new ComboxModel(){ Id=0,Name="功能设置"},
                new ComboxModel(){ Id=1,Name="打印设置"},
            };

            cbType.ValueMember = "Id";
            cbType.DisplayMember = "Name";
            cbType.DataSource = cbItemList;
            cbType.SelectedValue = -1;

            
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

            //创建列
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ID", "主键", true, false, 1, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParameterName", "参数名称", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParameterDescribe", "参数描述", true, true, 6, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParameterValue", "参数值", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParameterTypeText", "参数类型", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateName", "创建人", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateTime", "创建时间", true, true, 10, "yyyy-MM-dd HH:mm:ss");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "UpdateName", "更新人", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "UpdateTime", "更新时间", true, true, 10, "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 查询分页信息
        /// </summary>
        public void QueryList()
        {
            string? decribe = txtDeciibe.Text?.Trim();
            ParameterTypeEnum? parameterType = null;
            if (cbType.SelectedValue != null && cbType.SelectedValue.ToString() == "-1")
            {
                parameterType = null;
            }

            int allCount = 0;//总条数
            var datas = systemParameterBLL.GetSystemParameterByPage(parameterType, decribe, uiPage.ActivePage, uiPage.PageSize, out allCount);
            //设置分页控件总数
            uiPage.TotalCount = allCount;

            dgvList.DataSource = datas;

            //清除默认选中的行
            dgvList.ClearSelection();
            selectId = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            uiPage.ActivePage = 1;
            QueryList();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbType.SelectedValue = -1;
            txtDeciibe.Text = string.Empty;
            uiPage.ActivePage = 1;
            QueryList();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头点击不处理
            if (e.RowIndex < 0) { return; }

            selectId = Convert.ToInt32(this.dgvList.Rows[e.RowIndex].Cells["ID"].Value);
        }

        private void FrmSystemParameter_Load(object sender, EventArgs e)
        {
            InitData();
            QueryList();
        }

        private void uiPage_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            QueryList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGradeViewUi.FormClose("FrmSystemParameterEdit");
            FrmSystemParameterEdit frmSystemParameterEdit = new FrmSystemParameterEdit(0);
            frmSystemParameterEdit.Text = "新增系统参数";
            frmSystemParameterEdit.ShowDialog();
            bool isok = frmSystemParameterEdit.isSuccess;
            if (isok)
            {
                ShowSuccessTip("新增系统参数成功");
                uiPage.ActivePage = 1;
                QueryList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectId<1) 
            {
                ShowWarningDialog("异常提示", "请选中一行要编辑的系统参数");
                return;
            }

            dataGradeViewUi.FormClose("FrmSystemParameterEdit");
            FrmSystemParameterEdit frmSystemParameterEdit = new FrmSystemParameterEdit(selectId);
            frmSystemParameterEdit.Text = "编辑系统参数";
            frmSystemParameterEdit.ShowDialog();
            bool isok = frmSystemParameterEdit.isSuccess;
            if (isok)
            {
                ShowSuccessTip("编辑系统参数");
                uiPage.ActivePage = 1;
                QueryList();
            }
        }
    }
}
