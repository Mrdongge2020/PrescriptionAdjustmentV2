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
                if (particlesStockExcelModelList!=null && particlesStockExcelModelList.Count>0) 
                {
                    particlesStockExcelModelList.Clear();
                }
                particlesStockExcelModelList = excelOpterUI.GetExcelData<ParticlesStockExcelModel>();
                dgvList.DataSource = particlesStockExcelModelList;
                if (particlesStockExcelModelList!=null && particlesStockExcelModelList.Count>0)
                {
                    btnConfimImport.Enabled = true;
                }
                else
                {
                    btnConfimImport.Enabled = false;
                    ShowWarningDialog("导入提示", "未找到合规的颗粒库存信息。");
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
                if (particlesPositionExcelModelList!=null && particlesPositionExcelModelList.Count>0)
                {
                    btnConfimImport.Enabled = true;
                }
                else
                {
                    btnConfimImport.Enabled = false;
                    ShowWarningDialog("导入提示", "未找到合规的颗粒位置信息。");
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
            if (dgvList.Rows.Count<=0) 
            {
                ShowWarningDialog("导入提示", "请先加载要导入的数据。");
                return;
            }
            if (!ShowAskDialog("导入提示", $"确定要列表中的数据吗？操作不可逆哦", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
            {
                return;
            }
            if (_IType==1) 
            {
                msg=_medicineCabinetDrugManageBLL.ImportParticlesStocks(particlesStockExcelModelList);
            }
            if (_IType == 2) 
            {
                msg = _medicineCabinetDrugManageBLL.ImportParticlesPositions(particlesPositionExcelModelList);
            }

            if (msg == "")
            {
                ShowSuccessTip("导入数据成功");
                this.btnConfimImport.Enabled = false;
            }
            else 
            {
                ShowErrorDialog("导入数据失败,原因:" + msg);
            }
        }
    }
}
