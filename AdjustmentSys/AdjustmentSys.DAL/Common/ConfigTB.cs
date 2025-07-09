using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.DAL.Common
{
    public class ConfigTB
    {
        //private  readonly  EFCoreContext _eFCoreContext = new EFCoreContext();
        //public ConfigTB() 
        //{
        //    SetConfigData();
        //}
        public static List<ConfigInfo> ConfigInfos { get; set; }
        /// <summary>
        /// 是否初始化菜单
        /// </summary>
        [ConfigAttribute("是否初始化菜单", false,"bool",0,0)]
        public static bool IsInitMenu { get; set; }

        [ConfigAttribute("是否显示仪表温度", 0, "bool", 0, 0)]
        public static bool IsShowTemperature { get; set; }  //是否显示温度  0 不显示  1显示
        /// <summary>
        /// 药瓶容量
        /// </summary>
        [ConfigAttribute("药瓶容量", 940, "int", 100, 940)]
        public static int BottleCapacity { get; set; }// 药瓶容量
        /// <summary>
        /// 设置config参数
        /// </summary>
        public static void SetConfigData()
        {
            EFCoreContext _eFCoreContext = new EFCoreContext();
            //获取表里面的值
            ConfigInfos = _eFCoreContext.ConfigInfos.Where(x=>x.DeviceId==SysDeviceInfo.currentDeviceInfo.DeviceId)?.ToList();
            Type type = typeof(ConfigTB);
            var properties = type.GetProperties().Where(p => (ConfigAttribute)Attribute.GetCustomAttribute(p, typeof(ConfigAttribute)) != null);
            List<ConfigInfo> insertConfigInfos = new List<ConfigInfo>();
            List<string> propertyNames = new List<string>();
            foreach (var property in properties)
            {
                propertyNames.Add(property.Name);

                bool isExit = false;
                if (ConfigInfos != null && ConfigInfos.Count>0) 
                {
                    foreach (ConfigInfo r in ConfigInfos)
                    {
                        if (r.Name.Trim() == property.Name)
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

                    ConfigInfo configInfo = new ConfigInfo();
                    configInfo.Name = property.Name;
                    configInfo.ChineseName = description;
                    configInfo.DataValue = value;
                    configInfo.DataValueType = descriptiveAttribute.ValueType;
                    configInfo.DataValuMin = descriptiveAttribute.ValueMin;
                    configInfo.DataValuMax = descriptiveAttribute.ValueMax;
                    configInfo.DeviceId=SysDeviceInfo.currentDeviceInfo.DeviceId;
                    configInfo.DeviceType = SysDeviceInfo.currentDeviceInfo.DeviceType;
                    
                    //插入设备的config
                    insertConfigInfos.Add(configInfo);
                }
            }

            ConfigInfos = ConfigInfos.Where(x => propertyNames.Contains(x.Name))?.ToList();

            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    _eFCoreContext.ConfigInfos.AddRange(insertConfigInfos);
                    _eFCoreContext.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    OperateLog.WriteLog(LogTypeEnum.数据库, "初始化配置数据出现异常，原因："+e.Message);
                }
            }
           
        }
    }
}
