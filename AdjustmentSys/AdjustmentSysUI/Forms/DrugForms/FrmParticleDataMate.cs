using AdjustmentSys.BLL.Drug;
using AdjustmentSys.Common.Tool;
using AdjustmentSys.Models.Drug;
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
        public FrmParticleDataMate()
        {
            InitializeComponent();
        }

        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Title = "选择要打开的Excel源文件.";
            string FilePath = "";
            OpenFile.Filter = @"Excel Files (*.xls, *.xlsx, *.xlsm)|*.xls;*.xlsx;*.xlsm";
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                FilePath = OpenFile.FileName;
            }
            else
            {
                return;
            }

            IWorkbook wb;
            using (FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                wb = WorkbookFactory.Create(file);
            }

            List<DataTable> dataTables = ExcelOperationHelper.ToExcelDateTable(wb);
            if (dataTables != null && dataTables.Count > 0)
            {
                List<ParticlesMateModel> particlesMateList = new List<ParticlesMateModel>();
                foreach (DataRow row in dataTables[0].Rows) 
                {
                    ParticlesMateModel particlesMateModel = new ParticlesMateModel();
                    particlesMateModel.ParName = row["药品简称"].ToString();
                    particlesMateModel.HisCode = row["HIS编码"].ToString(); 
                    particlesMateModel.ManufacturerName = row["厂家名称"].ToString();
                    particlesMateModel.Density = float.TryParse(row["密度"].ToString(), out float i) ? i : 0;
                    particlesMateModel.Equivalent = float.TryParse(row["当量"].ToString(), out float j) ? j : 0; 
                    particlesMateModel.PackageNumber = row["包装码"].ToString();
                    particlesMateList.Add(particlesMateModel);
                }
               
                dgvList.DataSource = particlesMateList;
                if (particlesMateList!=null && particlesMateList.Count>0) 
                { 
                    btnConfimImport.Enabled = true;
                }
            }
            else
            {
                dgvList.DataSource = null;
                btnConfimImport.Enabled = false;
            }
        }

        private void btnConfimImport_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count <= 0)
            {
                ShowWarningDialog("导入提示", "要匹配的药品信息不存在");
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
                ShowWarningDialog("导入提示", "请先选择要匹配的字段");
                return;
            }
            if (!ShowAskDialog("匹配提示", $"确定要根据药品简称匹配[{string.Join(",", fieldstrings)}]数据吗？操作不可逆哦", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
            {
                return;
            }
            List<ParticlesMateModel> particlesMateList = new List<ParticlesMateModel>();
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                ParticlesMateModel particlesMateModel = new ParticlesMateModel();
                particlesMateModel.ParName=row.Cells["ParName"].Value.ToString();
                particlesMateModel.HisCode = row.Cells["HisCode"].Value.ToString();
                particlesMateModel.ManufacturerName = row.Cells["ManufacturerName"].Value.ToString();
                particlesMateModel.Density =float.TryParse(row.Cells["Density"].Value.ToString(),out float i)?i:0;
                particlesMateModel.Equivalent = float.TryParse(row.Cells["Equivalent"].Value.ToString(), out float j) ? j : 0;
                particlesMateModel.PackageNumber = row.Cells["PackageNumber"].Value.ToString();
                particlesMateList.Add(particlesMateModel);
            }
            var msg= _drugManagermentBLL.MateParticlesImport(particlesMateList, fieldstrings);
            if (msg=="") 
            {
                ShowSuccessTip("导入数据成功");
                //dgvList.DataSource = null;
                btnConfimImport.Enabled = false;
                uiCheckBoxGroup1.UnSelectAll();
            }
            else
            {
                ShowErrorDialog("导入数据失败,原因:" + msg);
            }
        }

       
    }
}
