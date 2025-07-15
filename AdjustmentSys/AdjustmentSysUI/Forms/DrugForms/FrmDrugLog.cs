using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Drug;
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

namespace AdjustmentSysUI.Forms.DrugForms
{
    public partial class FrmDrugLog : UIPage
    {
        public FrmDrugLog()
        {

            InitializeComponent();
            initData();
            ControlOpterUI.SetTitleStyle(this);

        }

        private void initData()
        {
            this.dateTimeStart.Value = DateTime.Now.Date;
            this.dateTimeEnd.Value = DateTime.Now.Date.AddDays(1);

            //ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
            //List<ComboxModel> pDatas = _comboxDataBLL.GetParticlesInfoComboxData();
            //cbfp.ValueMember = "Id";
            //cbfp.DisplayMember = "Name";
            //cbfp.DataSource = pDatas;
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
            //dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ID", "主键", true, false, 0, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParticleCode", "药品编号", true, true, 15, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParticleName", "药品名称", true, true, 15, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "OperationLogDecribe", "操作类型", true, true, 15, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DeviceName", "设备名称", true, true, 15, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateName", "创建人", true, true, 15, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateTime", "创建时间", true, true, 24, "yyyy-MM-dd HH:mm:ss");

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            queryPage();
        }

        private void queryPage()
        {
            ParticleOperationLogTypeEnum? type = null;
            if (cbType.Text != "全部")
            {
                if (cbType.Text == "新增药品")
                {
                    type = ParticleOperationLogTypeEnum.新增药品;
                }
                if (cbType.Text == "编辑药品")
                {
                    type = ParticleOperationLogTypeEnum.编辑药品;
                }
                if (cbType.Text == "删除药品")
                {
                    type = ParticleOperationLogTypeEnum.删除药品;
                }
            }

            string pname = txtName.Text;
            //if (!string.IsNullOrEmpty(cbfp.Text))
            //{
            //    pname = cbfp.Text;
            //}
            DrugManagermentBLL drugManagermentBLL = new DrugManagermentBLL();
            int allCount = 0;//总条数
            var datas = drugManagermentBLL.GetDurgLogByPage(type, pname, dateTimeStart.Value, dateTimeEnd.Value, uiPage.ActivePage, uiPage.PageSize, out allCount);
            //设置分页控件总数
            uiPage.TotalCount = allCount;

            dgvList.DataSource = datas;
        }

        private void FrmDrugLog_Load(object sender, EventArgs e)
        {
            InitDgvFormat();
        }

        private void uiPage_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            queryPage();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbType.Text = "全部";
            txtName.Text = "";
            this.dateTimeStart.Value = DateTime.Now.Date;
            this.dateTimeEnd.Value = DateTime.Now.Date.AddDays(1);
            uiPage.ActivePage = 1;
            queryPage();
        }
    }
}
