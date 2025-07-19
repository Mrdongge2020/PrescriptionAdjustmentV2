using AdjustmentSys.BLL.Drug;
using AdjustmentSys.Common.Tool;
using AdjustmentSys.Models.Drug;
using AdjustmentSysUI.UITool;
using NPOI.SS.UserModel;
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
    public partial class FrmParticleDataMate : UIForm
    {
        DrugManagermentBLL _drugManagermentBLL = new DrugManagermentBLL();
        List<ParticlesMateModel> particlesMateList = new List<ParticlesMateModel>();
        ExcelOpterUI excelOpterUI = new ExcelOpterUI();
        public FrmParticleDataMate()
        {
            InitializeComponent();
        }

        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            if (particlesMateList!=null && particlesMateList.Count>0)
            {
                particlesMateList.Clear();
            }
            particlesMateList = excelOpterUI.GetExcelData<ParticlesMateModel>();
            dgvList.DataSource = particlesMateList;
            if (particlesMateList!=null && particlesMateList.Count>0)
            {
                btnConfimImport.Enabled = true;
            }
            else
            {
                btnConfimImport.Enabled = false;
                this.ShowWarningDialog("导入提示", "未找到合规的药品匹配信息。");
            }
        }

        private void btnConfimImport_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count <= 0)
            {
                this.ShowWarningDialog("导入提示", "要匹配的药品信息不存在");
                return;
            }
            List<string> fieldstrings = new List<string>();
            if (cbHIS.Checked) 
            {
                fieldstrings.Add("HisCode");
            }
            if (cbCJ.Checked)
            {
                fieldstrings.Add("ManufacturerName");
            }
            if (cbDL.Checked)
            {
                fieldstrings.Add("Equivalent");
            }
            if (cbMD.Checked)
            {
                fieldstrings.Add("Density");
            }
            if (cbBZM.Checked)
            {
                fieldstrings.Add("PackageNumber");
            }
            if (fieldstrings==null || fieldstrings.Count<=0) 
            {
                this.ShowWarningDialog("导入提示", "请先选择要匹配的字段");
                return;
            }
            if (!this.ShowAskDialog("匹配提示", $"确定要根据药品简称匹配已选中的字段数据吗？操作不可逆哦", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
            {
                return;
            }
            
            var msg= _drugManagermentBLL.MateParticlesImport(particlesMateList, fieldstrings);
            if (msg=="") 
            {
                this.ShowSuccessTip("导入数据成功");
                btnConfimImport.Enabled = false;
                uiCheckBoxGroup1.UnSelectAll();
            }
            else
            {
                this.ShowErrorDialog("导入数据失败,原因:" + msg);
            }
        }
    }
}
