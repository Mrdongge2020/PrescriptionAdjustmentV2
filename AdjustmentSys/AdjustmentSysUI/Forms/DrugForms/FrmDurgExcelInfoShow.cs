using AdjustmentSys.BLL.Drug;
using AdjustmentSys.Common.Tool;
using AdjustmentSys.Models.Drug;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NPOI.POIFS.FileSystem;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.Streaming.Values;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdjustmentSysUI.Forms.DrugForms
{
    public partial class FrmDurgExcelInfoShow : UIForm
    {
        DrugManagermentBLL _drugManagermentBLL = new DrugManagermentBLL();
        List<ErrorParticlesExportModel> ErrorParticlesExportList = new List<ErrorParticlesExportModel>();
        public FrmDurgExcelInfoShow()
        {
            InitializeComponent();
            dgvList.AutoGenerateColumns = false;
        }
        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            ErrorParticlesExportList.Clear();
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
            //将excel数据读取到datatable
            List<DataTable> dataTables = ExcelOperationHelper.ToExcelDateTable(wb);
            if (dataTables != null && dataTables.Count > 0)
            {
                #region 转换excel数据

                foreach (DataRow row in dataTables[0].Rows)
                {
                    ErrorParticlesExportModel errorParticlesExportModel = new ErrorParticlesExportModel();
                    Type type = typeof(ErrorParticlesExportModel);
                    foreach (PropertyInfo propertyInfo in type.GetProperties())
                    {
                        // 获取属性上的特定特性
                        TitleAttribute titleAttribute = propertyInfo.GetCustomAttribute<TitleAttribute>();
                        string cellValue = "";
                        if (titleAttribute != null && dataTables[0].Columns.Contains(titleAttribute.Titile))
                        {
                            cellValue = row[titleAttribute.Titile].ToString();

                        }
                        if (propertyInfo != null)
                        {
                            if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(int?))
                            {
                                propertyInfo.SetValue(errorParticlesExportModel, string.IsNullOrEmpty(cellValue) || !int.TryParse(cellValue, out int number) ? 0 : Convert.ToInt32(cellValue));
                            }
                            else if (propertyInfo.PropertyType == typeof(decimal) || propertyInfo.PropertyType == typeof(decimal?))
                            {
                                propertyInfo.SetValue(errorParticlesExportModel, string.IsNullOrEmpty(cellValue) || !decimal.TryParse(cellValue, out decimal number) ? 0 : Convert.ToDecimal(cellValue));
                            }
                            else if (propertyInfo.PropertyType == typeof(float) || propertyInfo.PropertyType == typeof(float?))
                            {
                                propertyInfo.SetValue(errorParticlesExportModel, string.IsNullOrEmpty(cellValue) || !float.TryParse(cellValue, out float number) ? 0 : float.Parse(cellValue));
                            }
                            else if (propertyInfo.PropertyType == typeof(DateTime) || propertyInfo.PropertyType == typeof(DateTime?))
                            {
                                propertyInfo.SetValue(errorParticlesExportModel, string.IsNullOrEmpty(cellValue) || !DateTime.TryParse(cellValue, out DateTime dt) ? default(DateTime) : Convert.ToDateTime(cellValue));
                            }
                            else
                            {
                                propertyInfo.SetValue(errorParticlesExportModel, string.IsNullOrEmpty(cellValue) ? null : cellValue.ToString().Trim());
                            }
                        }
                    }
                    ErrorParticlesExportList.Add(errorParticlesExportModel);
                }
                #endregion

                dgvList.DataSource = ErrorParticlesExportList;
                if (ErrorParticlesExportList.Any())
                {
                    btnCheckData.Enabled = true;
                }
            }
            else
            {
                dgvList.DataSource = null;
                btnCheckData.Enabled = false;
            }

            btnConfimImport.Enabled = false;
            lblCheckResult.Text = $"校验结果：暂无。 ";
        }

        private void btnConfimImport_Click(object sender, EventArgs e)
        {
            var datas = ErrorParticlesExportList.Where(x => x.IsPassed == "通过").ToList();
            if (dgvList.Rows.Count <= 0 || datas == null || datas.Count == 0)
            {
                ShowWarningDialog("导入提示", "要导入的药品信息不存在");
                return;
            }
            string msg = _drugManagermentBLL.SaveAllParticlesImport(datas);
            if (msg == "")
            {
                ShowSuccessTip("导入数据成功");
                dgvList.DataSource = null;
                ErrorParticlesExportList.AddRange(datas);
                btnConfimImport.Enabled = false;
                btnCheckData.Enabled = false;
                lblCheckResult.Text = $"校验结果：暂无。 ";
            }
            else
            {
                ShowErrorDialog("导入数据失败,原因:" + msg);
            }
        }

        private void btnCheckData_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count <= 0)
            {
                ShowWarningDialog("校验提示", "要校验的药品信息不存在");
                return;
            }

            //List<ErrorParticlesExportModel> excelDatas = new List<ErrorParticlesExportModel>();
            //foreach (DataGridViewRow row in dgvList.Rows)
            //{
            //    ErrorParticlesExportModel errorParticlesExportModel = new ErrorParticlesExportModel();

            //    Type type = typeof(ErrorParticlesExportModel);
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        var cellValue = cell.Value.ToString();
            //        PropertyInfo propertyInfo = type.GetProperty(cell.OwningColumn.Name);
            //        if (propertyInfo != null) 
            //        {
            //            if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(int?))
            //            {
            //                propertyInfo.SetValue(errorParticlesExportModel, string.IsNullOrEmpty(cellValue) || !int.TryParse(cellValue, out int number)? 0 : Convert.ToInt32(cellValue));
            //            }
            //            else if (propertyInfo.PropertyType == typeof(decimal) || propertyInfo.PropertyType == typeof(decimal?))
            //            {
            //                propertyInfo.SetValue(errorParticlesExportModel, string.IsNullOrEmpty(cellValue) || !decimal.TryParse(cellValue, out decimal number) ? 0 : Convert.ToDecimal(cellValue));
            //            }
            //            else if (propertyInfo.PropertyType == typeof(float) || propertyInfo.PropertyType == typeof(float?))
            //            {
            //                propertyInfo.SetValue(errorParticlesExportModel, string.IsNullOrEmpty(cellValue) || !float.TryParse(cellValue, out float number) ? 0 :float.Parse(cellValue));
            //            }
            //            else if (propertyInfo.PropertyType == typeof(DateTime) || propertyInfo.PropertyType == typeof(DateTime?))
            //            {
            //                propertyInfo.SetValue(errorParticlesExportModel, string.IsNullOrEmpty(cellValue) || !DateTime.TryParse(cellValue, out DateTime dt) ? default(DateTime) : Convert.ToDateTime(cellValue));
            //            }
            //            else
            //            {
            //                propertyInfo.SetValue(errorParticlesExportModel, string.IsNullOrEmpty(cellValue) ? null : cellValue.ToString().Trim());
            //            }
            //        }
            //    }

            //    excelDatas.Add(errorParticlesExportModel);
            //}
            ErrorParticlesExportList = _drugManagermentBLL.CheckAllParticlesImport(ErrorParticlesExportList);

            if (ErrorParticlesExportList == null || ErrorParticlesExportList.Count == 0)
            {
                dgvList.DataSource = null;
                return;
            }

            dgvList.DataSource = ErrorParticlesExportList.Where(x => x.IsPassed == "通过").ToList();
            int passCount = ErrorParticlesExportList.Count(x => x.IsPassed == "通过");
            int unpassCount = ErrorParticlesExportList.Count(x => x.IsPassed != "通过");
            if (unpassCount > 0)
            {
                btnLoadErroeData.Enabled = true;
            }
            if (passCount > 0)
            {
                btnConfimImport.Enabled = true;
            }
            lblCheckResult.Text = $"校验结果：通过{passCount}条，未通过{unpassCount}条";
        }

        private void btnLoadErroeData_Click(object sender, EventArgs e)
        {
            var exportDatas= ErrorParticlesExportList.Where(x => x.IsPassed != "通过").ToList();
            if (!exportDatas.Any()) 
            {
                ShowWarningDialog("导出提示", "要导出的异常药品信息不存在");
                return;
            }
            //组装生成工作簿参数
            List<ExcelDataResource> excelDataResources = new List<ExcelDataResource>()
            {
                new ExcelDataResource ()
                {
                    SheetName="异常药品信息",
                    TitleIndex=1,
                    SheetDataResource=exportDatas.ToList<object>()
                }
            };

            //生成工作簿
            IWorkbook workbook1 = ExcelOperationHelper.DataToHSSFWorkbook(excelDataResources);

            //导出操作
            SaveFileDialog objSaveFileDialog = new SaveFileDialog();
            objSaveFileDialog.Filter = @"Excel (*.xls)|*.xls";//@"Excel2007文件(*.xlsx)|*.xlsx|Excel2003文件(*.xls)|*.xls";
            objSaveFileDialog.Title = "请选择保存位置";
            objSaveFileDialog.FileName = "异常药品信息" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (objSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //导出excel文件，提示文件地址
                    string exportMsg = ExcelOperationHelper.ExportWorkbookToLocal(workbook1, objSaveFileDialog.FileName);
                    MessageBox.Show(exportMsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出失败:<{ex.Message}>", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
