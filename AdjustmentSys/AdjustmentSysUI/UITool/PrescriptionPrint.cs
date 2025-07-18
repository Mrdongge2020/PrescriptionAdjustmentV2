using AdjustmentSys.Entity;
using AdjustmentSys.Tool.FileOpter;
using AdjustmentSys.Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.DAL.Common;
using Sunny.UI;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;


namespace AdjustmentSysUI.UITool
{
    public class PrescriptionPrint
    {
        public PrescriptionPrintModel PrintData { get; set; }     //打印数据
        UIPage uipage = new UIPage();
        /// <summary>
        /// [0:医院名称][1:患者姓名][2:性别][3:年龄][4:处方编号][5:处方明细]
        /// [6:处方价格][7:处方打印时间][8:页码标签][9:处方备注][10:饮片剂量]
        /// [11:颗粒剂量][12:使用方法][13:生成的使用方法][14:就诊卡号][15:颗粒明细]
        /// [16:住院部床号][17:打印就诊卡条码]
        /// </summary>
        public static long PrintMode { get; set; }   //处方打印模式  

        //public static int DeivceID;//设备ID             
        //public static int RowWordNumber = 16;       //每行字符数
        //public static int RowsCount = 25;       //每页行数
        //public static string HospitalName;    //医院名称
        //public static int BodyFontSize;
        //public static int BodyLocationX;
        //public static int BodyLocationY;
        //public static int BarcodeHeight;
        //public static int BarcodeWidth;
        //public static int BarcodeLocationX;
        //public static int BarcodeLocationY;
        //public static int TermValidityDayCount;
        public static string BOX = "袋";
        private string[] PrintStr = new string[12];     //打印数据数组
        private PrintDocument PrintDocumentObj = new PrintDocument(); //打印对象
        private List<string> StrList = new List<string>();
        private string PrintString;     //打印整体字符串
        /// <summary>
        /// 开始打印进程
        /// </summary>
        /// <param name="DoseType">=0:SoureDoseHerb;=1:DoseHerb</param>
        /// 

       List<PrintItemInfo> papercheckDatas = new List<PrintItemInfo>();

        static List<PrintItemInfo> allpapercheckDatas = new List<PrintItemInfo>();

        //判断是否有打印项可以打印
        public  bool IsOK(bool miancheck = false)
        {
            allpapercheckDatas = PrintConfigTB.PrintItemInfos.Where(x => x.CheckedValue > 0).ToList();
            if (allpapercheckDatas == null || allpapercheckDatas.Count <= 0)
            {
                return false;
            }
            else
            {
                if (!miancheck)
                {
                    //从打印
                    return allpapercheckDatas.Any(x => (x.CheckedValue == 1 || x.CheckedValue == 3));
                }
                else
                {
                    //主打印
                    return allpapercheckDatas.Any(x => (x.CheckedValue == 2 || x.CheckedValue == 3));
                }
            }
        }
        //查询打印选项
        //public static void SelectPaPercheck()
        //{
        //    try
        //    {
        //        allpapercheckDatas = PrintConfigTB.PrintItemInfos.Where(x=>x.CheckedValue>0).ToList();
        //        var cachepapercheckTBs = CacheHelper.GetFromCache("allpapercheckDatas");
        //        if (cachepapercheckTBs != null)
        //        {
        //            allpapercheckDatas = (List<PapercheckTB>)cachepapercheckTBs;
        //            return;
        //        }

        //        var datatable = DBHelper.ResultTable(string.Format(@"select
        //                                 [Ename],  
        //                                 [name],
        //                                 [check],
        //                                 [desc],
        //                                 DeviceID,
        //                                 Title
        //                                 from PapercheckTB where  DeviceID= '{0}' and [check]<>'0'   order by [desc] ", ConfigTB.DeviceID));

        //        foreach (DataRow row in datatable.Rows)
        //        {
        //            PapercheckTB papercheckTB = new PapercheckTB();
        //            papercheckTB.Ename = row["Ename"].ToString();
        //            papercheckTB.name = row["name"].ToString();
        //            papercheckTB.check = row["check"].ToString().Trim();
        //            papercheckTB.desc = Convert.ToDouble(row["desc"].ToString().Trim());
        //            papercheckTB.DeviceID = Convert.ToInt32(row["DeviceID"].ToString().Trim());
        //            papercheckTB.Title = row["Title"].ToString();
        //            allpapercheckDatas.Add(papercheckTB);
        //        }

        //        DateTimeOffset expirationTime = DateTimeOffset.Now.AddMinutes(180);
        //        // 添加到缓存
        //        CacheHelper.AddToCache("allpapercheckDatas", allpapercheckDatas, expirationTime);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        bool isHaveDetail = false;
        /// <summary>
        /// 设置格式打印
        /// </summary>
        public void Print(bool check = false, bool miancheck = false)
        {
            StrList.Clear();
            allpapercheckDatas = PrintConfigTB.PrintItemInfos.Where(x => x.CheckedValue > 0).ToList();
            if (allpapercheckDatas == null || allpapercheckDatas.Count <= 0) { return; }
            if (!miancheck)
            {
                //从打印
                papercheckDatas = allpapercheckDatas.Where(x => (x.CheckedValue == 1 || x.CheckedValue == 3)).ToList();
            }
            else
            {
                //主打印
                papercheckDatas = allpapercheckDatas.Where(x => (x.CheckedValue == 2 || x.CheckedValue == 3)).ToList();

            }
            if (papercheckDatas == null || papercheckDatas.Count <= 0) { return; }

            int maxDesc = (int)(papercheckDatas.Max(x => x.Sort));

            isHaveDetail = false;
            List<string> lineStrings = new List<string>();
            for (int i = 0; i <= maxDesc; i++)
            {
                List<string> templineStrings = new List<string>();
                var currentItems = papercheckDatas.Where(x => (int)x.Sort == i).OrderBy(x => x.Sort).ToList();
                if (currentItems == null || currentItems.Count <= 0) { continue; }

                if (currentItems.Count == 1)
                {
                    templineStrings = GetLineString(currentItems[0], check);
                }
                else
                {
                    string currentStr = "";
                    for (int j = 0; j < currentItems.Count; j++)
                    {
                        var templineStrings1 = GetLineString(currentItems[j], check);
                        if (templineStrings1 == null)
                        {
                            continue;
                        }
                        if (templineStrings1.Count == 1)
                        {
                            currentStr += templineStrings1[0] + "  ";
                        }
                        else
                        {
                            if (currentItems.Any(x => x.ItemChineseName == "打印颗粒明细" || x.ItemChineseName == "打印饮片计量" || x.ItemChineseName == "打印颗粒计量"))
                            {
                                currentStr += string.Join("@", templineStrings1);
                            }
                            else
                            {
                                currentStr += string.Join("  ", templineStrings1);
                            }
                        }
                    }
                    if (currentStr != "")
                    {
                        if (currentItems.Any(x => x.ItemChineseName == "打印颗粒明细" || x.ItemChineseName == "打印饮片计量" || x.ItemChineseName == "打印颗粒计量"))
                        {
                            templineStrings.AddRange(currentStr.Split('@'));
                        }
                        else
                        {
                            templineStrings.AddRange(SplitStringByLength(currentStr, PrintConfigTB.RowWordNumber * 2));
                        }
                    }
                }
                if (templineStrings != null && templineStrings.Count > 0)
                {
                    lineStrings.AddRange(templineStrings);
                }
            }
            //计算页数
            int pages = (lineStrings.Count / PrintConfigTB.RowsCount) + (lineStrings.Count % PrintConfigTB.RowsCount > 0 ? 1 : 0);

            for (int i = 0; i < pages; i++)
            {

                List<string> pageStr = new List<string>();
                int count1 = i * PrintConfigTB.RowsCount + PrintConfigTB.RowsCount > lineStrings.Count ? lineStrings.Count : i * PrintConfigTB.RowsCount + PrintConfigTB.RowsCount;
                for (int j = i * PrintConfigTB.RowsCount; j < count1; j++)
                {
                    pageStr.Add(lineStrings[j]);
                }

                if (papercheckDatas.Any(x => x.ItemChineseName == "打印标签页码"))
                {
                    string pageindexStr = (i + 1) + "/" + pages + "页";
                    int index = PrintConfigTB.RowWordNumber * 2 - GetStringLen(pageindexStr);
                    index = index / 2;
                    string pageindexStr1 = "";
                    while (index > 0)
                    {
                        pageindexStr1 += "-";
                        index--;
                    }
                    pageindexStr = pageindexStr1 + pageindexStr + pageindexStr1;
                    pageStr.Add(pageindexStr);
                }
                this.PrintString = string.Join("\r\n", pageStr);

                this.PrintStart();
            }
        }

        /// <summary>
        /// 打印内容获取
        /// </summary>
        private List<string> GetLineString(PrintItemInfo tb, bool check = false)
        {
            List<string> rstrings = new List<string>();
            string str = "";
            int index = 0;

            List<string> particstrings = new List<string>();
            switch (tb.ItemChineseName)
            {
                case "打印医院名称":
                    if (!StringIsNULL(PrintConfigTB.HospitalName))
                    {
                        str = PrintConfigTB.HospitalName;
                    }
                    break;
                case "打印患者姓名":
                    if (!StringIsNULL(PrintData.PatientName))
                    {
                        str = PrintData.PatientName;
                    }
                    break;
                case "打印患者性别":
                    str = PrintData.PatientSex.ToString();
                    break;
                case "打印患者年龄":
                    str = PrintData.PatientAge + "岁";
                    break;
                case "打印处方编号":
                    if (!StringIsNULL(PrintData.PrescriptionID))
                    {
                        str = PrintData.PrescriptionID;
                    }
                    break;
                case "打印颗粒明细":
                case "打印饮片计量":
                case "打印颗粒计量":
                    if (this.PrintData.Details != null && this.PrintData.Details.Count > 0 && !isHaveDetail)
                    {
                        index = 1;
                        int maxLength = 0;
                        foreach (PrintDetailModel Node in this.PrintData.Details)
                        {
                            string parInfo = "";
                            parInfo += Node.ParName;
                            if (papercheckDatas.Any(x => x.ItemChineseName == "打印饮片计量") && papercheckDatas.Any(x => x.ItemChineseName == "打印颗粒计量"))
                            {
                                parInfo += "(" + Node.DoseHerb + "/" + Node.Dose + ")g";
                            }
                            else if (papercheckDatas.Any(x => x.ItemChineseName == "打印饮片计量"))
                            {
                                parInfo += "(" + Node.DoseHerb + ")g";
                            }
                            else if (papercheckDatas.Any(x => x.ItemChineseName == "打印颗粒计量"))
                            {
                                parInfo += "(" + Node.Dose + ")g";
                            }
                            particstrings.Add(parInfo);
                            if (GetStringLen(parInfo) > maxLength)
                            {
                                maxLength = GetStringLen(parInfo);
                            }
                        }
                        //计算一行显示颗粒数
                        int num = PrintConfigTB.RowWordNumber * 2 / (maxLength + 2);
                        if (num <= 0) { num = 1; }
                        //拼接颗粒string
                        for (int i = 0; i < particstrings.Count; i++)
                        {
                            str += particstrings[i];
                            if (GetStringLen(particstrings[i]) != maxLength)
                            {
                                int cl = maxLength - GetStringLen(particstrings[i]);
                                while (cl > 0)
                                {
                                    str += " ";
                                    cl--;
                                }
                            }
                            if ((i + 1) % num == 0)
                            {
                                str += "\r";
                            }
                            else
                            {
                                str += "  ";
                            }
                        }
                        isHaveDetail = true;
                    }
                    break;
                case "打印处方价格":
                    str = "￥" + Math.Round(Convert.ToSingle(this.PrintData.TotalPrice), 2).ToString();
                    break;
                case "打印处方时间":
                    str = PrintData.PreDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    break;
                case "打印标签页码":

                    break;
                case "打印处方备注":
                    if (!StringIsNULL(PrintData.Remarks))
                    {
                        str = PrintData.Remarks;
                    }
                    break;
                case "打印使用方法":
                    if (!StringIsNULL(PrintData.UsageMethod))
                    {
                        str = PrintData.UsageMethod;
                    }
                    break;
                case "打印生成的使用方法":
                    if (!StringIsNULL(PrintData.GenerateUseWay))
                    {
                        if (!check)
                        {
                            str = PrintData.GenerateUseWay;
                        }
                        else
                        {
                            str = PrintData.GenerateUseWay1;
                        }
                    }
                    break;
                case "打印协定处方":
                    if (!StringIsNULL(PrintData.PrescriptionName))
                    {
                        str = PrintData.PrescriptionName;
                    }
                    break;
                case "打印住院部床号":
                    if (!StringIsNULL(PrintData.BedNumber))
                    {
                        str = PrintData.BedNumber;
                    }
                    break;
                case "打印医生":
                    if (!StringIsNULL(PrintData.DoctorName))
                    {
                        str = PrintData.DoctorName;
                    }
                    break;
                case "打印科室":
                    if (!StringIsNULL(PrintData.DepartmentName))
                    {
                        str = PrintData.DepartmentName;
                    }
                    break;
                case "打印有效期":
                    str = DateTime.Now.AddDays(this.PrintData.Quantity + PrintConfigTB.TermValidityDayCount).ToString("yyyy/MM/dd") + "";
                    break;
                case "打印付数/(袋|盒)数":
                    str = this.PrintData.Quantity + "付/" + this.PrintData.BoxNumber * 2 + BOX;
                    break;
            }
            if (str != "")
            {
                if (index > 0)
                {
                    int alllength = PrintConfigTB.RowWordNumber * 2;
                    string fengexian = "";
                    while (alllength > 0)
                    {
                        fengexian += "-";
                        alllength--;
                    }
                    rstrings.Add(fengexian);
                    var parcheck = papercheckDatas.FirstOrDefault(x => x.ItemChineseName == "打印颗粒明细");
                    if (parcheck != null && !StringIsNULL(tb.Title))
                    {
                        rstrings.Add(parcheck.Title);
                    }
                    var particStrs = str.Split('\r');
                    for (int i = 0; i < particStrs.Length; i++)
                    {
                        if (particStrs[i] != "")
                        {
                            rstrings.Add(particStrs[i]);
                        }
                    }
                }
                else
                {
                    str = StringIsNULL(tb.Title) ? str : tb.Title + ":" + str;
                    if (tb.ItemChineseName == "打印有效期" || tb.ItemChineseName == "打印处方时间" || tb.ItemChineseName == "打印处方编号")
                    {
                        rstrings.Add(str);
                    }
                    else
                    {
                        rstrings.AddRange(SplitStringByLength(str, PrintConfigTB.RowWordNumber * 2));
                    }
                }
                if (check && tb.ItemChineseName == "打印生成的使用方法")
                {
                    rstrings.Add("注意：");
                    string str1 = "本次调剂中，此两袋为半袋，请将这两袋半袋的颗粒混合后一次性使用";
                    rstrings.AddRange(SplitStringByLength(str1, PrintConfigTB.RowWordNumber * 2));
                }
                return rstrings;
            }
            else
            {
                return null;
            }
        }



        #region 字符串操作
        /// <summary>
        /// 字符串判空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool StringIsNULL(string str)
        {
            if (string.IsNullOrEmpty(str) || str == "无" || str == "<无>" || str == "null" || str == "<null>" || str == "<NULL>")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取字符串字节长度,判断char>127的字符占2个字节，包括汉字，全角字符。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private int GetStringLen(string str)
        {
            int i = 0;//字节数
            foreach (char newChar in str)
            {
                if (IsChineseChar(newChar))
                {
                    //汉字
                    i += 2;
                }
                else
                {
                    i++;
                }
            }
            return i;
        }
        /// <summary>
        /// 按长度分割字符串
        /// </summary>
        /// <param name="input"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public string[] SplitStringByLength(string input, int len)
        {
            List<string> result = new List<string>();
            StringBuilder currentSegment = new StringBuilder();
            int lengthSoFar = 0;

            foreach (char c in input)
            {
                // 检查字符是否为中文字符
                bool isChinese = IsChineseChar(c);
                int charLength = isChinese ? 2 : 1;

                // 如果当前段加上这个字符后长度不超过固定长度，则加入当前段
                if (lengthSoFar + charLength <= len) // 假设固定长度为4，可以根据需要调整
                {
                    currentSegment.Append(c);
                    lengthSoFar += charLength;
                }
                else // 否则，开始新的段
                {
                    result.Add(currentSegment.ToString());
                    currentSegment.Clear();
                    currentSegment.Append(c);
                    lengthSoFar = charLength; // 重置长度计数器
                }
            }

            // 添加最后一个段（如果有的话）
            if (currentSegment.Length > 0)
            {
                result.Add(currentSegment.ToString());
            }

            return result.ToArray();
        }

        /// <summary>
        /// 判断是否是中文字符
        /// </summary>
        private bool IsChineseChar(char c)
        {
            // 中文字符的Unicode范围大致是：0x4e00-0x9fa5，这里简化处理，更精确的可以包含扩展A等其他区域。
            return (c >= 0x4e00 && c <= 0x9fa5);
        }
        #endregion

        private void InitializeParam()
        {
            // Application.DoEvents();


        }
        private void PrintStart()
        {
            if (this.PrintData != null)
            {
                PrintDocumentObj.PrintPage += new PrintPageEventHandler(Page_PrintPage); //打印页面需指定相应的PrintDocument_PrintPrintPage事件委托                               
                PrintDocumentObj.Print();
            }
            else
            {
                uipage.ShowErrorDialog("无打印数据!");
            }
        }
        bool isPrintBarcode = true;
        private void Page_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                //"宋体", 9F, System.Drawing.FontStyle.Regular,
                e.Graphics.DrawString(PrintString, new Font("宋体", PrintConfigTB.BodyFontSize, FontStyle.Regular), new SolidBrush(Color.Black), new Point(PrintConfigTB.BodyLocationX, PrintConfigTB.BodyLocationY));
                //DrawString方式进行打印。      
                //if ((PaperPrint.PrintMode & (Int32)Math.Pow(2, 17)) == Math.Pow(2, 17))
                //{
                //      Barcode objBarcode = new Barcode();
                //      DAL.TYPE type = DAL.TYPE.UNSPECIFIED;
                //      type = DAL.TYPE.CODE128;
                //  //if (type != DAL.TYPE.UNSPECIFIED)
                //  //{
                //  //, Color.Black, Color.White, PaperPrint.BarcodeWidth, PaperPrint.BarcodeHeight
                //            System.Drawing.Image Dm = objBarcode.Encode(type, this.PrintData.PrescriptionID, PaperPrint.BarcodeWidth, PaperPrint.BarcodeHeight);
                //           e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                //           e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //           e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
                //         // System.Drawing.Image Dm = CreateBarCode(this.PrintData.PrescriptionID, PaperPrint.BarcodeWidth, PaperPrint.BarcodeHeight);
                //          e.Graphics.DrawImage(Dm, PaperPrint.BodyLocationX, PaperPrint.BarcodeLocationY);
                //      //}
                ////  }
                if (papercheckDatas.Any(x => x.ItemChineseName == "打印处方条码") && isPrintBarcode)
                {
                    var writer = new BarcodeWriter<Bitmap>
                    {
                        Format = BarcodeFormat.CODE_128,
                        Options = new EncodingOptions
                        {
                            Height = PrintConfigTB.BarcodeHeight,
                            Width = PrintConfigTB.BarcodeWidth,
                            PureBarcode = true,  // 如果不需要空白边缘，设置为true
                        }
                    };
                    Bitmap barcodeBitmap = writer.Write(this.PrintData.PrescriptionID);
                    //Size size = new Size(300, 1000);
                    //Bitmap b = ResizeImage(barcodeBitmap, size);
                    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    e.Graphics.DrawImage(barcodeBitmap, PrintConfigTB.BodyLocationX, PrintConfigTB.BarcodeLocationY);
                    isPrintBarcode = false;
                }
            }
            catch (Exception ex)
            {
                uipage.ShowErrorDialog("打印出错！", "" + ex.Message);
            }
        }
    }
}
