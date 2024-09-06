using AdjustmentSys.Common.Tool;
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
    public partial class FrmDurgExcelInfoShow : UIForm
    {
        public FrmDurgExcelInfoShow()
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
            using (FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                wb = WorkbookFactory.Create(file);
            }

            List<DataTable> dataTables = ExcelOperationHelper.ToExcelDateTable(wb);
            if (dataTables != null && dataTables.Count > 0)
            {
                dgvList.DataSource = dataTables[0];
            }
            else
            {
                dgvList.DataSource = null;
            }

        }

        private void btnImportType_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>() { "请选择", "全部字段", "HIS编码", "密度", "当量", "厂家名称", "密度系数", "包装码" };
            int index = 0;
            if (this.ShowSelectDialog(ref index, items))
            {
                ShowInfoDialog(index.ToString());
            }
        }

        private void btnConfimImport_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count <= 0)
            {
                ShowWarningDialog("导入提示", "要导入的药品信息不存在");
                return;
            }



        }

        private void btnCheckData_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count <= 0)
            {
                ShowWarningDialog("校验提示", "要校验的药品信息不存在");
                return;
            }


        }
    }
}
