using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.DAL.Common
{
    /// <summary>
    /// 打印设置
    /// </summary>
    public class PrintConfigTB
    {
        /// <summary>
        /// 打印配置
        /// </summary>
        public static List<PrintConfigInfo> PrintConfigs { get; set; }
        /// <summary>
        /// 打印项
        /// </summary>
        public static List<PrintItemInfo> PrintItemInfos { get; set; }

        [ConfigAttribute("医院名称", "XXX医院 ", "string", 0, 0)]
        public static    string     HospitalName                 { get; set; }//医院名称
        [ConfigAttribute("使用方法", "开水冲,温水服", "string", 0, 0)]
        public static string     GenerateUsageMethodPrefix    { get; set; }//使用方法
        [ConfigAttribute("分服次数", 2, "int", 0, 0)]
        public static int     GenerateUsageMiddle          { get; set; }//分服次数
        [ConfigAttribute("拆分次数", 0, "int", 0, 0)]
        public static int     GenerateUsageMethodSuffix    { get; set; }//拆分次数
        [ConfigAttribute("有效期天数", 3, "int", 0, 0)]
        public static int     TermValidityDayCount         { get; set; }//有效期天数
        [ConfigAttribute("正文起始位置X", 0, "int", 0, 0)]
        public static int     BodyLocationX                { get; set; }//正文起始位置X
        [ConfigAttribute("正文起始位置Y", 0, "int", 0, 0)]
        public static int     BodyLocationY                { get; set; }//正文起始位置Y
        [ConfigAttribute("字体大小", 12, "int", 0, 0)]
        public static int     BodyFontSize                 { get; set; }//字体大小
        [ConfigAttribute("每页行数", 20, "int", 0, 0)]
        public static int     RowsCount                    { get; set; }//每页行数
        [ConfigAttribute("条码位置X", 16, "int", 0, 0)]
        public static int     BarcodeLocationX             { get; set; }//条码位置X
        [ConfigAttribute("条码位置Y", 16, "int", 0, 0)]
        public static int     BarcodeLocationY             { get; set; }//条码位置Y
        [ConfigAttribute("条码高度", 16, "int", 0, 0)]
        public static int     BarcodeHeight                { get; set; }//条码高度
        [ConfigAttribute("条码宽度", 16, "int", 0, 0)]
        public static int     BarcodeWidth                 { get; set; }//条码宽度
        [ConfigAttribute("每行字符数", 10, "int", 0, 0)]
        public static int     RowWordNumber { get; set; }                    //每行字符数
        /// <summary>
        /// 是否自动打印处方主标签
        /// </summary>
        [ConfigAttribute("是否自动打印处方主标签", 0, "bool", 0, 1)]
        public static bool Automainpaper { get; set; }  //0 不自动打印  1自动打印
        /// <summary>
        /// 处方打印方式
        /// </summary>
        [ConfigAttribute("处方打印方式", 0, "int", 0, 2)]
        public static int Automodepapertype { get; set; }// 0一处方打印一次   1根据出筐打印   2根据袋数打印
        /// <summary>
        /// 设置config参数
        /// </summary>
        public static void SetConfigData()
        {
            EFCoreContext _eFCoreContext = new EFCoreContext();
            //获取表里面的值
            PrintConfigs = _eFCoreContext.PrintConfigInfos.Where(x => x.DeviceId == SysDeviceInfo.currentDeviceInfo.DeviceId)?.ToList();

            Type type = typeof(PrintConfigTB);
            var properties = type.GetProperties().Where(p => (ConfigAttribute)Attribute.GetCustomAttribute(p, typeof(ConfigAttribute)) != null);
            List<PrintConfigInfo> insertConfigInfos = new List<PrintConfigInfo>();
            List<string> propertyNames = new List<string>();
            foreach (var property in properties)
            {
                propertyNames.Add(property.Name);

                bool isExit = false;
                if (PrintConfigs != null && PrintConfigs.Count > 0)
                {
                    foreach (PrintConfigInfo r in PrintConfigs)
                    {
                        if (r.ItemName.Trim() == property.Name)
                        {
                            string value = r.DataValue.ToString().Trim();
                            //根据特性中的默认值给属性赋值
                            if (property.PropertyType == typeof(int))
                            {
                                property.SetValue(null, Convert.ToInt32(value), null);
                            }
                            else if (property.PropertyType == typeof(double))
                            {
                                property.SetValue(null, Convert.ToDouble(value), null);
                            }
                            else if (property.PropertyType == typeof(bool))
                            {
                                if (value == "1")
                                {
                                    property.SetValue(null, true);
                                }
                                else
                                {
                                    property.SetValue(null, false);
                                }
                            }
                            else if (property.PropertyType == typeof(float))
                            {
                                property.SetValue(null, float.Parse(value));
                            }
                            else if (property.PropertyType == typeof(DateTime))
                            {
                                property.SetValue(null, DateTime.Parse(value));
                            }
                            else //(property.PropertyType == typeof(string))
                            {
                                property.SetValue(null, value);
                            }
                            isExit = true;
                            break;
                        }
                    }
                }

                if (isExit)
                {
                    continue;
                }

                var descriptiveAttribute = (ConfigAttribute)Attribute.GetCustomAttribute(property, typeof(ConfigAttribute));
                if (descriptiveAttribute != null)
                {

                    string description = descriptiveAttribute.Description;
                    var value = descriptiveAttribute.DefaultValue.ToString().Trim();

                    //根据特性中的默认值给属性赋值
                    if (property.PropertyType == typeof(int))
                    {
                        property.SetValue(null, Convert.ToInt32(value), null);
                    }
                    else if (property.PropertyType == typeof(double))
                    {
                        property.SetValue(null, Convert.ToDouble(value), null);
                    }
                    else if (property.PropertyType == typeof(bool))
                    {
                        if (value == "1")
                        {
                            property.SetValue(null, true);
                        }
                        else
                        {
                            property.SetValue(null, false);
                        }
                    }
                    else if (property.PropertyType == typeof(float))
                    {
                        property.SetValue(null, float.Parse(value));
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        property.SetValue(null, DateTime.Parse(value));
                    }
                    else //(property.PropertyType == typeof(string))
                    {
                        property.SetValue(null, value);
                    }

                    PrintConfigInfo configInfo = new PrintConfigInfo();
                    configInfo.ItemName = property.Name;
                    configInfo.ItemChineseName = description;
                    configInfo.DataValue = value;
                    configInfo.DataValueType = descriptiveAttribute.ValueType;
                    configInfo.DataValuMin = descriptiveAttribute.ValueMin;
                    configInfo.DataValuMax = descriptiveAttribute.ValueMax;
                    configInfo.DeviceId = SysDeviceInfo.currentDeviceInfo.DeviceId;

                    //插入设备的config
                    insertConfigInfos.Add(configInfo);
                }
            }

            PrintConfigs = PrintConfigs.Where(x => propertyNames.Contains(x.ItemName))?.ToList();

            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    _eFCoreContext.PrintConfigInfos.AddRange(insertConfigInfos);
                    _eFCoreContext.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    OperateLog.WriteLog(LogTypeEnum.数据库, "初始化打印配置数据出现异常，原因：" + e.Message);
                }
            }
        }

        /// <summary>
        /// 设置config参数
        /// </summary>
        public static void SetPrintItemData()
        {
            EFCoreContext _eFCoreContext = new EFCoreContext();
            //获取表里面的值
            PrintItemInfos = _eFCoreContext.PrintItemInfos.Where(x => x.DeviceId == SysDeviceInfo.currentDeviceInfo.DeviceId)?.ToList();

            var allPrintItemInfos = _eFCoreContext.PrintItemInfos.Where(x => x.DeviceId == 0)?.ToList();

            if (PrintItemInfos == null || PrintItemInfos.Count <= 0)
            {


                PrintItemInfos = allPrintItemInfos.Select(x => new PrintItemInfo()
                {
                    ItemName = x.ItemName,
                    ItemChineseName = x.ItemChineseName,
                    Title = x.Title,
                    Sort = x.Sort,
                    CheckedValue = x.CheckedValue,
                    DeviceId = SysDeviceInfo.currentDeviceInfo.DeviceId
                }).ToList();
                using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
                {
                    try
                    {
                        _eFCoreContext.PrintItemInfos.AddRange(PrintItemInfos);
                        _eFCoreContext.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        OperateLog.WriteLog(LogTypeEnum.数据库, "初始化打印配项数据出现异常，原因：" + e.Message);
                    }
                }
            }
            else
            {
                var names = PrintItemInfos.Select(x => x.ItemName).ToList();
                if (names!=null && names.Count>0) 
                {
                   var list=  allPrintItemInfos.Where(x => !names.Contains(x.ItemName)).ToList();
                    if (list != null && list.Count > 0) 
                    {

                       var insertList= list.Select(x => new PrintItemInfo()
                        {
                            ItemName = x.ItemName,
                            ItemChineseName = x.ItemChineseName,
                            Title = x.Title,
                            Sort = x.Sort,
                            CheckedValue = x.CheckedValue,
                            DeviceId = SysDeviceInfo.currentDeviceInfo.DeviceId
                        }).ToList();

                        PrintItemInfos.AddRange(insertList);

                        using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
                        {
                            try
                            {
                                _eFCoreContext.PrintItemInfos.AddRange(insertList);
                                _eFCoreContext.SaveChanges();

                                dbContextTransaction.Commit();
                            }
                            catch (Exception e)
                            {
                                dbContextTransaction.Rollback();
                                OperateLog.WriteLog(LogTypeEnum.数据库, "初始化打印配项数据出现异常，原因：" + e.Message);
                            }
                        }
                    }

                }
            }
            
        }
    }
}
