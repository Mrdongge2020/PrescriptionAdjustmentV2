using AdjustmentSys.BLL.Drug;
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

namespace AdjustmentSysUI.Forms.Drug
{
    public partial class FrmDrugCompatibilityRuler : UIPage
    {
        private int selectId = 0;
        ParticleProhibitionRuleBLL _particleProhibitionRuleBLL = new ParticleProhibitionRuleBLL();
        public FrmDrugCompatibilityRuler()
        {
            InitializeComponent();
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
            uiPage.PageSize = 15;
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();

            //创建列
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ID", "id", true, false, 1, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Name", "规则名称", true, true, 15, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "FirstParticlesName", "第一味颗粒", true, true, 10, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "SecondParticlesName", "第二味颗粒", true, true, 10, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Remark", "备注", true, true, 25, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateName", "创建人", true, true, 10, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateTime", "创建时间", true, true, 10, "yyyy-MM-dd HH:mm:ss");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "UpdateName", "更新人", true, true, 10, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "UpdateTime", "更新时间", true, true, 10, "yyyy-MM-dd HH:mm:ss");
        }


        /// <summary>
        /// 查询规则信息
        /// </summary>
        public void QueryPageList()
        {
            int allCount = 0;//总条数
            var datas = _particleProhibitionRuleBLL.GetRuleInfoByPage(uiPage.ActivePage, uiPage.PageSize, out allCount);
            //设置分页控件总数
            uiPage.TotalCount = allCount;

            dgvList.DataSource = datas;

            //清除默认选中的行
            dgvList.ClearSelection();
            selectId = 0;
        }

        private void uiPage_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            QueryPageList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectId == 0)
            {
                ShowWarningDialog("异常提示", "请先选择要删除的规则信息");
                return;
            }
            if (!ShowAskDialog("删除提示", "确定要删除选中的规则信息吗", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
            {
                return;
            }
            var msg = _particleProhibitionRuleBLL.DeleteRuleInfo(selectId);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmDrugCompatibilityRulerEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmDrugCompatibilityRulerEdit frmEdit = new FrmDrugCompatibilityRulerEdit(0);
            frmEdit.Text = "新增药品相容规则";
            frmEdit.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectId == 0)
            {
                ShowWarningDialog("异常提示", "请先选择要编辑的规则信息");
                return;
            }
            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmDrugCompatibilityRulerEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmDrugCompatibilityRulerEdit frmEdit = new FrmDrugCompatibilityRulerEdit(selectId);
            frmEdit.Text = "编辑药品相容规则";
            frmEdit.Show();
        }

        private void btnRefc_Click(object sender, EventArgs e)
        {
            QueryPageList();
           
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头点击不处理
            if (e.RowIndex < 0) { return; }

            selectId = Convert.ToInt32(this.dgvList.Rows[e.RowIndex].Cells["ID"].Value);
        }

        private void FrmDrugCompatibilityRuler_Load(object sender, EventArgs e)
        {
            //清除默认选中的行
            dgvList.ClearSelection();
            selectId = 0;
        }
    }
}
