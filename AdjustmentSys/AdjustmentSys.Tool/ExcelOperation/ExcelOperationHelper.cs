using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdjustmentSys.Common.Tool
{
    public class ExcelOperationHelper
    {
        /// <summary>
        /// 创建一个ExcelWorkbook
        /// </summary>
        /// <returns></returns>
        public static IWorkbook CreateExcelWorkbook()
        {
            HSSFWorkbook _Workbook = new HSSFWorkbook(); 
            ISheet sheet = _Workbook.CreateSheet("Sheet1"); 
            IRow titleRow = sheet.CreateRow(0); 
            ICell cell= titleRow.CreateCell(1);
            cell.SetCellValue("你好"); 
            return _Workbook;
        }


        /// <summary>
        /// 导出
        /// </summary>
        public static IWorkbook DataToHSSFWorkbook(List<ExcelDataResource> dataResources)
        {
            HSSFWorkbook _Workbook = new HSSFWorkbook();
            if (dataResources == null && dataResources.Count == 0)
            {
                return _Workbook;
            }
            foreach (var sheetResource in dataResources)
            {
                if (sheetResource.SheetDataResource != null && sheetResource.SheetDataResource.Count == 0)
                {
                    break;
                }
                ISheet sheet = _Workbook.CreateSheet(sheetResource.SheetName);
                object obj = sheetResource.SheetDataResource[0];

                Type type = obj.GetType();
                List<PropertyInfo> propList = type.GetProperties().Where(c => c.IsDefined(typeof(TitleAttribute), true)).ToList();

                IRow titleRow = sheet.CreateRow(0);

                ICellStyle style = _Workbook.CreateCellStyle();
                style.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
                style.FillPattern = FillPattern.SolidForeground;
                style.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Automatic.Index;

                style.Alignment = HorizontalAlignment.CenterSelection;
                style.VerticalAlignment = VerticalAlignment.Center;
                titleRow.Height = 100 * 4;

                for (int i = 0; i < propList.Count(); i++)
                {
                    TitleAttribute propertyAttribute = propList[i].GetCustomAttribute<TitleAttribute>();
                    ICell cell = titleRow.CreateCell(i);
                    cell.SetCellValue(propertyAttribute.Titile);
                    cell.CellStyle = style;
                }

                for (int i = 0; i < sheetResource.SheetDataResource.Count(); i++)
                {
                    IRow row = sheet.CreateRow(i + 1);
                    object objInstance = sheetResource.SheetDataResource[i];
                    for (int j = 0; j < propList.Count; j++)
                    {
                        ICell cell = row.CreateCell(j);
                        //string value = propList[j].GetValue(objInstance)==null ?"": propList[j].GetValue(objInstance).ToString();
                        cell.SetCellValue(propList[j].GetValue(objInstance) == null ? "" : propList[j].GetValue(objInstance).ToString());
                    }
                }
            }
            return _Workbook;
        }

        /// <summary>
        /// 生成Excel的内存流-MemoryStream
        /// </summary>
        /// <param name="dataResources"></param>
        /// <returns></returns>
        public static MemoryStream ToExcelMemoryStream(List<ExcelDataResource> dataResources)
        {
            IWorkbook _Workbook = DataToHSSFWorkbook(dataResources);
            using (MemoryStream stream = new MemoryStream())
            {
                _Workbook.Write(stream);
                return stream;
            }

        }

        /// <summary>
        ///通过数据生成Excel  然后转换成byte[]
        /// </summary>
        /// <param name="dataResources"></param>
        /// <returns></returns>
        public static byte[] ToExcelByteArray(List<ExcelDataResource> dataResources)
        {
            IWorkbook _Workbook = DataToHSSFWorkbook(dataResources);
            using (MemoryStream stream = new MemoryStream())
            {
                _Workbook.Write(stream);
                byte[] bt = stream.ToArray();
                stream.Write(bt, 0, (int)stream.Length);
                return bt;
            }
        }

        /// <summary>
        ///Excel转换成DataTable 
        /// </summary>
        /// <param name="hSSFWorkbook"></param>
        /// <returns></returns>
        public static List<DataTable> ToExcelDateTable(IWorkbook hSSFWorkbook)
        {
            List<DataTable> datatableList = new List<DataTable>();
            try
            {
                for (int sheetIndex = 0; sheetIndex < hSSFWorkbook.NumberOfSheets; sheetIndex++)
                {
                    ISheet sheet = hSSFWorkbook.GetSheetAt(sheetIndex);
                    //获取表头 FirstRowNum 第一行索引 0
                    IRow header = sheet.GetRow(sheet.FirstRowNum);//获取第一行
                    if (header == null)
                    {
                        break;
                    }
                    int startRow = 0;//数据的第一行索引

                    DataTable dtNpoi = new DataTable();
                    startRow = sheet.FirstRowNum + 1;
                    for (int i = header.FirstCellNum; i < header.LastCellNum; i++)
                    {
                        ICell cell = header.GetCell(i);
                        if (cell != null)
                        {
                            string cellValue = $"{cell.ToString()}";
                            if (cellValue != null)
                            {
                                DataColumn col = new DataColumn(cellValue);
                                dtNpoi.Columns.Add(col);
                            }
                            else
                            {
                                DataColumn col = new DataColumn();
                                dtNpoi.Columns.Add(col);
                            }
                        }

                    }
                    //数据    LastRowNum 最后一行的索引 如第九行---索引 8
                    for (int i = startRow; i <= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);//获取第i行
                        if (row == null)
                        {
                            continue;
                        }
                        DataRow dr = dtNpoi.NewRow();
                        //遍历每行的单元格
                        for (int j = row.FirstCellNum; j < row.LastCellNum; j++)
                        {
                            if (row.GetCell(j) != null)
                                dr[j] = row.GetCell(j).ToString();
                        }
                        dtNpoi.Rows.Add(dr);
                    }

                    datatableList.Add(dtNpoi);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return datatableList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static List<DataTable> ExcelStreamToDateTable(Stream stream)
        {
            IWorkbook hSSFWorkbook = WorkbookFactory.Create(stream);
            return ToExcelDateTable(hSSFWorkbook);
        }

        public static string ExportWorkbookToLocal(IWorkbook workbook, string filePath)
        {
            using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                if (workbook is XSSFWorkbook)
                {
                    ((XSSFWorkbook)workbook).Write(file);
                }
                else if (workbook is HSSFWorkbook)
                {
                    ((HSSFWorkbook)workbook).Write(file);
                }
                else
                {
                    return "导出失败，不支持该工作簿类型";
                }
            }
            return "数据导出完成,文件位置:<" + filePath + ">";
        }

    }
}
