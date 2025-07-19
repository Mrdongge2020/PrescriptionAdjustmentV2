using AdjustmentSys.BLL.MedicineCabinet;
using AdjustmentSys.Models.Drug;
using AdjustmentSys.Models.MedicineCabinet;
using AdjustmentSysUI.UITool;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    public partial class FrmMedicineCabinetParticImport : UIForm
    {
        private int _IType;//1=库存，2=位置
        ExcelOpterUI excelOpterUI = new ExcelOpterUI();
        List<ParticlesPositionExcelModel> particlesPositionExcelModelList = new List<ParticlesPositionExcelModel>();
        List<ParticlesStockExcelModel> particlesStockExcelModelList = new List<ParticlesStockExcelModel>();

        MedicineCabinetDrugManageBLL _medicineCabinetDrugManageBLL = new MedicineCabinetDrugManageBLL();
        public FrmMedicineCabinetParticImport(int itype)
        {
            _IType = itype;
            InitializeComponent();
            InitDgvFormat();
        }

        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            LoadPositionData();
        }

        private void LoadPositionData()
        {
            if (_IType == 1)
            {
                this.Text = "颗粒库存信息导入";
                if (particlesStockExcelModelList != null && particlesStockExcelModelList.Count > 0)
                {
                    particlesStockExcelModelList.Clear();
                }
                particlesStockExcelModelList = excelOpterUI.GetExcelData<ParticlesStockExcelModel>();
                dgvList.DataSource = particlesStockExcelModelList;
                if (particlesStockExcelModelList != null && particlesStockExcelModelList.Count > 0)
                {
                    btnConfimImport.Enabled = true;
                }
                else
                {
                    btnConfimImport.Enabled = false;
                    this.ShowWarningDialog("导入提示", "未找到合规的颗粒库存信息。");
                }
                return;
            }
            if (_IType == 2)
            {
                this.Text = "颗粒位置信息导入";

                if (particlesPositionExcelModelList != null && particlesPositionExcelModelList.Count > 0)
                {
                    particlesPositionExcelModelList.Clear();
                }
                particlesPositionExcelModelList = excelOpterUI.GetExcelData<ParticlesPositionExcelModel>();
                dgvList.DataSource = particlesPositionExcelModelList;
                if (particlesPositionExcelModelList != null && particlesPositionExcelModelList.Count > 0)
                {
                    btnConfimImport.Enabled = true;
                }
                else
                {
                    btnConfimImport.Enabled = false;
                    this.ShowWarningDialog("导入提示", "未找到合规的颗粒位置信息。");
                }
                return;
            }
        }

        /// <summary>
        /// 设置dgv格式
        /// </summary>
        private void InitDgvFormat()
        {
            dgvList.AutoGenerateColumns = false;//不自动生成列
            dgvList.AllowUserToAddRows = false;//不自动产生最后的新行
            dgvList.AllowUserToResizeRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.Columns.Clear();
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
            //创建列
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "MedicineCabinetId", "药柜Id", true, true, 8, "");
            if (_IType == 1)
            {
                dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParticlesID", "颗粒Id", true, true, 8, "");
            }
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Code", "颗粒编号", true, true, 8, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParName", "颗粒名称", true, true, 8, "");
            if (_IType == 1)
            {
                dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Stock", "库存", true, true, 8, "");
            }
            if (_IType == 2)
            {
                dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CoordinateX", "X横坐标", true, true, 8, "");
                dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CoordinateY", "Y纵坐标", true, true, 8, "");
            }
        }

        private void btnConfimImport_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (dgvList.Rows.Count <= 0)
            {
                this.ShowWarningDialog("导入提示", "请先加载要导入的数据。");
                return;
            }
            if (!this.ShowAskDialog("导入提示", $"确定要列表中的数据吗？操作不可逆哦", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
            {
                return;
            }
            if (_IType == 1)
            {
                msg = _medicineCabinetDrugManageBLL.ImportParticlesStocks(particlesStockExcelModelList);
            }
            if (_IType == 2)
            {
                msg = _medicineCabinetDrugManageBLL.ImportParticlesPositions(particlesPositionExcelModelList);
            }

            if (msg == "")
            {
                this.ShowSuccessTip("导入数据成功");
                this.btnConfimImport.Enabled = false;
            }
            else
            {
                this.ShowErrorDialog("导入数据失败,原因:" + msg);
            }
        }

        private void lblRuler_Click(object sender, EventArgs e)
        {
            string remark = "1.导入前请在药柜颗粒管理<导出颗粒库存>导出一个数据模版，并填写正确数据。\r\n" +
                            "2.只需要参照颗粒名称修改模版里面的相应的库存列数据，其他列数据仅供参考，保留即可。\r\n" +
                            "3.药柜Id和颗粒ID列不要修改或删除，导入时会根据这2列数据，修改药柜颗粒库存数据。\r\n" +
                            "4.数字列请正确填写，否则数据会校验不通过不能导入。\r\n" +
                            "5.导入有风险，操作需谨慎。";
            if (_IType == 2) 
            {
                remark = "1.导入前请在药柜颗粒管理<导出颗粒位置>导出一个数据模版，并填写正确数据。\r\n" +
                         "2.只需要参照X横坐标和Y纵坐标修改模版里面的相应的颗粒编码，颗粒名称列数据，其他列数据仅供参考，保留即可。\r\n" +
                         "3.药柜Id,X横坐标,Y纵坐标3列不要修改或删除，导入时会根据这3列数据，修改药柜颗粒位置数据。\r\n" +
                         "4.要填入的颗粒编码位置已有颗粒编码信息，如需保留旧的颗粒信息，请先将旧的颗粒编码数据移除，再移入，否则旧数据会丢失。\r\n" +
                         "5.数字列请正确填写，否则数据会校验不通过不能导入。\r\n" +
                         "6.此导入功能最好仅限首次初始化药柜使用，操作需谨慎。";
            }
            this.ShowInfoDialog(remark);
        }
    }
}
