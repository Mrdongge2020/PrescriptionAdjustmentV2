using AdjustmentSys.Entity;
using AdjustmentSys.Tool;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Metadata;
using System.Xml;

namespace AdjustmentSys.EFCore
{
    public class EFCoreContext : DbContext
    {
        private string strConn = "Server=47.109.107.251,1433;database=AdjustmentSysDB;uid=sa;pwd=LDSsql20231106;TrustServerCertificate=true";

        public EFCoreContext()
        {

        }
        public EFCoreContext(string strConn)
        {
            this.strConn = strConn;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(strConn);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entity.Name, builder =>
                {

                    //#if DEBUG
                    //设置表的备注
                    builder.ToTable(t => t.HasComment(GetEntityComment(entity.Name)));

                    List<string> baseTypeNames = new();
                    var baseType = entity.ClrType.BaseType;
                    while (baseType != null)
                    {
                        baseTypeNames.Add(baseType.FullName!);
                        baseType = baseType.BaseType;
                    }
                    //#endif

                    foreach (var property in entity.GetProperties())
                    {

                        //#if DEBUG
                        //设置字段的备注
                        property.SetComment(GetEntityComment(entity.Name, property.Name, baseTypeNames));
                        //#endif

                        //设置字段的默认值 
                        var defaultValueAttribute = property.PropertyInfo?.GetCustomAttribute<DefaultValueAttribute>();
                        if (defaultValueAttribute != null)
                        {
                            property.SetDefaultValue(defaultValueAttribute.Value);
                        }
                    }
                });
            }
            //base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        public DbSet<UserInfo> UserInfos { get; set; }
        /// <summary>
        /// 权限等级
        /// </summary>
        public DbSet<LevelInfo> LevelInfos { get; set; }
        /// <summary>
        /// 医生信息
        /// </summary>
        public DbSet<DoctorInfo> DoctorInfos { get; set; }
        /// <summary>
        /// 科室信息
        /// </summary>
        public DbSet<DepartmentInfo> DepartmentInfos { get; set; }
        /// <summary>
        /// 本地处方信息
        /// </summary>
        public DbSet<LocalDataPrescriptionInfo> LocalDataPrescriptionInfos { get; set; }
        /// <summary>
        /// 本地处方详情信息
        /// </summary>
        public DbSet<LocalDataPrescriptionDetail> LocalDataPrescriptionDetails { get; set; }
        /// <summary>
        /// 待下载处方信息
        /// </summary>
        public DbSet<DataPrescription> DataPrescriptions { get; set; }
        /// <summary>
        /// 待下载处方详情信息
        /// </summary>
        public DbSet<DataPrescriptionDetail> DataPrescriptionDetails { get; set; }
        /// <summary>
        /// 颗粒字典信息
        /// </summary>
        public DbSet<ParticlesInfo> ParticlesInfos { get; set; }
        /// <summary>
        /// 颗粒字典详情信息
        /// </summary>
        public DbSet<ParticlesInfoExtend> ParticlesInfoExtends { get; set; }
        

        /// <summary>
        /// 颗粒相融规则
        /// </summary>
        public DbSet<ParticleProhibitionRule> ParticleProhibitionRules { get; set; }

        /// <summary>
        /// 厂家信息表
        /// </summary>
        public DbSet<ManufacturerInfo> ManufacturerInfos { get; set; }

        /// <summary>
        /// 厂家解析码表
        /// </summary>
        public DbSet<ManufacturerResolutionCode> ManufacturerResolutionCodes { get; set; }

        /// <summary>
        /// 药柜信息主表
        /// </summary>
        public DbSet<MedicineCabinetInfo> MedicineCabinetInfos { get; set; }

        /// <summary>
        /// 药柜详情信息表
        /// </summary>
        public DbSet<MedicineCabinetDetail> MedicineCabinetDetails { get; set; }
        /// <summary>
        /// 设备信息表
        /// </summary>
        public DbSet<DeviceInfo> DeviceInfos { get; set; }
        /// <summary>
        /// 药柜组与设备关联信息表
        /// </summary>
        public DbSet<DeviceMedicineCabinetCodeRelation> DeviceMedicineCabinetCodeRelations { get; set; }


        public static string GetEntityComment(string typeName, string? fieldName = null, List<string>? baseTypeNames = null)
        {
            var path = Path.Combine(AppContext.BaseDirectory, "AdjustmentSys.Entity.xml");
            XmlDocument xml = new();
            xml.Load(path);
            XmlNodeList memebers = xml.SelectNodes("/doc/members/member")!;

            Dictionary<string, string> fieldList = new();

            if (fieldName == null)
            {
                var matchKey = "T:" + typeName;

                foreach (object m in memebers)
                {
                    if (m is XmlNode node)
                    {
                        var name = node.Attributes!["name"]!.Value;

                        var summary = node.InnerText.Trim();

                        if (name == matchKey)
                        {
                            fieldList.Add(name, summary);
                        }
                    }
                }

                return fieldList.FirstOrDefault(t => t.Key.ToLower() == matchKey.ToLower()).Value ?? typeName.ToString().Split(".").ToList().LastOrDefault()!;
            }
            else
            {

                foreach (object m in memebers)
                {
                    if (m is XmlNode node)
                    {
                        string name = node.Attributes!["name"]!.Value;

                        var summary = node.InnerText.Trim();

                        var matchKey = "P:" + typeName + ".";
                        if (name.StartsWith(matchKey))
                        {
                            name = name.Replace(matchKey, "");

                            fieldList.Remove(name);

                            fieldList.Add(name, summary);
                        }

                        if (baseTypeNames != null)
                        {
                            foreach (var baseTypeName in baseTypeNames)
                            {
                                if (baseTypeName != null)
                                {
                                    matchKey = "P:" + baseTypeName + ".";
                                    if (name.StartsWith(matchKey))
                                    {
                                        name = name.Replace(matchKey, "");
                                        fieldList.Add(name, summary);
                                    }
                                }
                            }
                        }
                    }
                }

                return fieldList.FirstOrDefault(t => t.Key.ToLower() == fieldName.ToLower()).Value ?? fieldName;
            }
        }
    }
}
