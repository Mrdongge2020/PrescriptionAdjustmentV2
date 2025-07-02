using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Drug;
using AdjustmentSys.BLL.MedicineCabinet;
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

namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    public partial class FrmMedicineCabientLog : UIPage
    {
        public FrmMedicineCabientLog()
        {
          
            InitializeComponent();

            var names = Enum.GetNames(typeof(MedicineCabinetOperationLogTypeEnum));
            int index = 0;
            List<ComboxModel> preStatuslist = new List<ComboxModel>();
            foreach (var name in names)
            {
                preStatuslist.Add(new ComboxModel() { Id = index, Name = name });
                index++;
            }
            cbType.ValueMember = "Id";
            cbType.DisplayMember = "Name";
            cbType.DataSource = preStatuslist;
            cbType.SelectedIndex = -1;

            this.dateTimeStart.Value = DateTime.Now.Date;
            this.dateTimeEnd.Value = DateTime.Now.Date.AddDays(1);

            ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
            List<ComboxModel> pDatas = _comboxDataBLL.GetCabinetParticlesComboxData();
            cbfp.ValueMember = "Id";
            cbfp.DisplayMember = "Name";
            cbfp.DataSource = pDatas;
            ControlOpterUI.SetTitleStyle(this);
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
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ID", "主键", true, false, 0, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParticleCode", "药品编号", true, true, 15, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParticleName", "药品名称", true, true, 15, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "OperationLogDecribe", "操作类型", true, true, 15, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "InitialQuantity", "初始量", true, true, 15, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CurrentWeightQuantity", "当前称重量", true, true, 15, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "UsedQuantity", "使用量", true, true, 15, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "AddQuantity", "上药量", true, true, 15, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "AdjustmentQuantity", "调整量", true, true, 15, "");
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
            MedicineCabinetOperationLogTypeEnum? type = null;
            if (cbType.SelectedValue != null && cbType.SelectedIndex != -1)
            {
                type = (MedicineCabinetOperationLogTypeEnum)cbType.SelectedValue;
            }

            string pname = "";
            if (!string.IsNullOrEmpty(cbfp.SelectedText))
            {
                pname = cbfp.SelectedText;
            }
            MedicineCabinetDrugManageBLL medicineCabinetDrugManageBLL = new MedicineCabinetDrugManageBLL();
            int allCount = 0;//总条数
            var datas = medicineCabinetDrugManageBLL.GetMedicineCabinetOperationLogByPage(type, pname, dateTimeStart.Value, dateTimeEnd.Value, uiPage.ActivePage, uiPage.PageSize, out allCount);
            //设置分页控件总数
            uiPage.TotalCount = allCount;

            dgvList.DataSource = datas?.mcParticLogs;

            lblNum1.Text= datas?.UsedQuantitySum.ToString();
            lblNum2.Text = datas?.AddQuantitySum.ToString();
            lblNum3.Text = datas?.AdjustmentQuantitySum.ToString();

            uiDataGridViewFooter1.Clear();
            uiDataGridViewFooter1["ParticleCode"] = "合计：";
            uiDataGridViewFooter1["InitialQuantity"] = datas?.mcParticLogs.Sum(x=>x.InitialQuantity).ToString();
            uiDataGridViewFooter1["CurrentWeightQuantity"] = datas?.mcParticLogs.Sum(x => x.CurrentWeightQuantity).ToString();
            uiDataGridViewFooter1["UsedQuantity"] = datas?.mcParticLogs.Sum(x => x.UsedQuantity).ToString();
            uiDataGridViewFooter1["AddQuantity"] = datas?.mcParticLogs.Sum(x => x.AddQuantity).ToString();
            uiDataGridViewFooter1["AdjustmentQuantity"] = datas?.mcParticLogs?.Sum(x => x.AdjustmentQuantity).ToString();
        }
    }
}
