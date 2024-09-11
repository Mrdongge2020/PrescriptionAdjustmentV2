using AdjustmentSys.Common.Tool;
using AdjustmentSys.Models.Drug;
using NPOI.SS.UserModel;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSysUI.UITool
{
    /// <summary>
    /// excel操作UI
    /// </summary>
    public class ExcelOpterUI
    {
        /// <summary>
        /// 单工作簿导出
        /// </summary>
        /// <param name="list">数据集合</param>
        /// <param name="sheetName">工作簿名称</param>
        public void ExportSinglePage(List<object>? list,string sheetName)
        {
            //组装生成工作簿参数
            List<ExcelDataResource> excelDataResources = new List<ExcelDataResource>()
            {
                new ExcelDataResource ()
                {
                    SheetName=sheetName,
                    TitleIndex=1,
                    SheetDataResource=list
                }
            };

            //生成工作簿
            IWorkbook workbook1 = ExcelOperationHelper.DataToHSSFWorkbook(excelDataResources);

            //导出操作
            SaveFileDialog objSaveFileDialog = new SaveFileDialog();
            objSaveFileDialog.Filter = @"Excel (*.xls)|*.xls";//@"Excel2007文件(*.xlsx)|*.xlsx|Excel2003文件(*.xls)|*.xls";
            objSaveFileDialog.Title = "请选择保存位置";
            objSaveFileDialog.FileName = sheetName + DateTime.Now.ToString("yyyyMMddHHmmss");
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

        /// <summary>
        /// 获取excel的数据，转化成实体对象返回
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <returns></returns>
        public List<T> GetExcelData<T>() where T : class
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
                return null;
            }

            IWorkbook wb;
            using (FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                wb = WorkbookFactory.Create(file);
            }
            //将excel数据读取到datatable
            List<DataTable> dataTables = ExcelOperationHelper.ToExcelDateTable(wb);
            List<T> tlist = new List<T>();
            if (dataTables != null && dataTables.Count > 0)
            {
                #region 转换excel数据

                foreach (DataRow row in dataTables[0].Rows)
                {
                    Type type = typeof(T);
                    var excelModel = type.CreateInstance();
                    bool isTrue = false;
                    foreach (PropertyInfo propertyInfo in type.GetProperties())
                    {
                        // 获取属性上的特定特性
                        TitleAttribute titleAttribute = propertyInfo.GetCustomAttribute<TitleAttribute>();
                        string cellValue = "";
                        if (titleAttribute != null && dataTables[0].Columns.Contains(titleAttribute.Titile))
                        {
                            cellValue = row[titleAttribute.Titile].ToString();
                        }
                        else 
                        {
                            continue;
                        }

                        isTrue = true;

                        if (propertyInfo != null)
                        {
                            if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(int?))
                            {
                                propertyInfo.SetValue(excelModel, string.IsNullOrEmpty(cellValue) || !int.TryParse(cellValue, out int number) ? 0 : Convert.ToInt32(cellValue));
                            }
                            else if (propertyInfo.PropertyType == typeof(decimal) || propertyInfo.PropertyType == typeof(decimal?))
                            {
                                propertyInfo.SetValue(excelModel, string.IsNullOrEmpty(cellValue) || !decimal.TryParse(cellValue, out decimal number) ? 0 : Convert.ToDecimal(cellValue));
                            }
                            else if (propertyInfo.PropertyType == typeof(float) || propertyInfo.PropertyType == typeof(float?))
                            {
                                propertyInfo.SetValue(excelModel, string.IsNullOrEmpty(cellValue) || !float.TryParse(cellValue, out float number) ? 0 : float.Parse(cellValue));
                            }
                            else if (propertyInfo.PropertyType == typeof(DateTime) || propertyInfo.PropertyType == typeof(DateTime?))
                            {
                                propertyInfo.SetValue(excelModel, string.IsNullOrEmpty(cellValue) || !DateTime.TryParse(cellValue, out DateTime dt) ? default(DateTime) : Convert.ToDateTime(cellValue));
                            }
                            else
                            {
                                propertyInfo.SetValue(excelModel, string.IsNullOrEmpty(cellValue) ? null : cellValue.ToString().Trim());
                            }
                        }
                    }
                    if (isTrue) 
                    {
                        tlist.Add((T)excelModel);
                    }
                }
                #endregion
            }
            return tlist;
        }
    }
}
