﻿// <auto-generated />
using System;
using AdjustmentSys.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    [DbContext(typeof(EFCoreContext))]
    [Migration("20240430094548_MigrateDb003")]
    partial class MigrateDb003
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdjustmentSys.Entity.DataPrescription", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BackupField1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("BackupField1");

                    b.Property<string>("BackupField2")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("BackupField2");

                    b.Property<string>("BackupField3")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("BackupField3");

                    b.Property<string>("CreateName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CreateName");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateTime");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DepartmentName");

                    b.Property<int>("DetailedCount")
                        .HasColumnType("int")
                        .HasColumnName("DetailedCount");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DoctorName");

                    b.Property<DateTime>("ImportTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ImportTime");

                    b.Property<int?>("PatientAge")
                        .HasColumnType("int")
                        .HasColumnName("PatientAge");

                    b.Property<int?>("PatientBirthDay")
                        .HasColumnType("int")
                        .HasColumnName("PatientBirthDay");

                    b.Property<int?>("PatientBirthMonth")
                        .HasColumnType("int")
                        .HasColumnName("PatientBirthMonth");

                    b.Property<string>("PatientEmail")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PatientEmail");

                    b.Property<string>("PatientLocation")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("PatientLocation");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PatientName");

                    b.Property<int>("PatientSex")
                        .HasColumnType("int")
                        .HasColumnName("PatientSex");

                    b.Property<string>("PatientTel")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PatientTel");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("PaymentStatus");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PaymentType");

                    b.Property<string>("PrescriptionID")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PrescriptionID");

                    b.Property<string>("PrescriptionName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PrescriptionName");

                    b.Property<int>("PrescriptionSource")
                        .HasColumnType("int")
                        .HasColumnName("PrescriptionSource");

                    b.Property<string>("PrescriptionType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PrescriptionType");

                    b.Property<int>("ProcessStatus")
                        .HasColumnType("int")
                        .HasColumnName("ProcessStatus");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.Property<string>("RegisterID")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("RegisterID");

                    b.Property<string>("Remarks")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Remarks");

                    b.Property<int>("TaskFrequency")
                        .HasColumnType("int")
                        .HasColumnName("TaskFrequency");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TotalPrice");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("UnitPrice");

                    b.Property<string>("UsageMethod")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("UsageMethod");

                    b.Property<DateTime>("ValuationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ValuationTime");

                    b.Property<string>("ValueSn")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ValueSn");

                    b.Property<string>("ValuerName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ValuerName");

                    b.HasKey("ID");

                    b.ToTable("DataPrescription");
                });

            modelBuilder.Entity("AdjustmentSys.Entity.DataPrescriptionDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BatchNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("BatchNumber");

                    b.Property<float>("Dose")
                        .HasColumnType("real")
                        .HasColumnName("Dose");

                    b.Property<float>("DoseHerb")
                        .HasColumnType("real")
                        .HasColumnName("DoseHerb");

                    b.Property<float>("Equivalent")
                        .HasColumnType("real")
                        .HasColumnName("Equivalent");

                    b.Property<int>("ParticleOrder")
                        .HasColumnType("int")
                        .HasColumnName("ParticleOrder");

                    b.Property<string>("ParticlesCodeHIS")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ParticlesCodeHIS");

                    b.Property<int>("ParticlesID")
                        .HasColumnType("int")
                        .HasColumnName("ParticlesID");

                    b.Property<string>("ParticlesName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ParticlesName");

                    b.Property<string>("PrescriptionID")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PrescriptionID");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Price");

                    b.HasKey("ID");

                    b.ToTable("DataPrescriptionDetail");
                });

            modelBuilder.Entity("AdjustmentSys.Entity.DepartmentInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Address");

                    b.Property<string>("Contacts")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Contacts");

                    b.Property<string>("ContactsPhone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ContactsPhone");

                    b.Property<int>("CreateBy")
                        .HasColumnType("int")
                        .HasColumnName("CreateBy");

                    b.Property<string>("CreateName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CreateName");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateTime");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("DepartmentName");

                    b.Property<string>("Remark")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Remark");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int")
                        .HasColumnName("UpdateBy");

                    b.Property<string>("UpdateName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("UpdateName");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("DepartmentInfo");
                });

            modelBuilder.Entity("AdjustmentSys.Entity.DoctorInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CreateBy")
                        .HasColumnType("int")
                        .HasColumnName("CreateBy");

                    b.Property<string>("CreateName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CreateName");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateTime");

                    b.Property<int?>("DeleteBy")
                        .HasColumnType("int")
                        .HasColumnName("DeleteBy");

                    b.Property<string>("DeleteName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("DeleteName");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeleteTime");

                    b.Property<int?>("DoctorDepartmentID")
                        .HasColumnType("int")
                        .HasColumnName("DoctorDepartmentID");

                    b.Property<string>("DoctorDepartmentName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("DoctorDepartmentName");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("DoctorName");

                    b.Property<string>("EMail")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EMail");

                    b.Property<string>("InitialPinyin")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("InitialPinyin");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("IsDelete");

                    b.Property<string>("Office")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Office");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Phone");

                    b.Property<string>("Remark")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Remark");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int")
                        .HasColumnName("UpdateBy");

                    b.Property<string>("UpdateName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("UpdateName");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("DoctorInfo");
                });

            modelBuilder.Entity("AdjustmentSys.Entity.LevelInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("LevelName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("LevelName");

                    b.HasKey("ID");

                    b.ToTable("LevelInfo");
                });

            modelBuilder.Entity("AdjustmentSys.Entity.ParticlesInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Code");

                    b.Property<int>("CreateBy")
                        .HasColumnType("int")
                        .HasColumnName("CreateBy");

                    b.Property<string>("CreateName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CreateName");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateTime");

                    b.Property<float>("Density")
                        .HasColumnType("real")
                        .HasColumnName("Density");

                    b.Property<float?>("DoseLimit")
                        .HasMaxLength(50)
                        .HasColumnType("real")
                        .HasColumnName("DoseLimit");

                    b.Property<float>("Equivalent")
                        .HasColumnType("real")
                        .HasColumnName("Equivalent");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FullName");

                    b.Property<string>("FullNamePinyin")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("FullNamePinyin");

                    b.Property<string>("HisCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("HisCode");

                    b.Property<string>("ListingNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ListingNumber");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int")
                        .HasColumnName("ManufacturerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Name");

                    b.Property<string>("PackageNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("PackageNumber");

                    b.Property<string>("Remarks")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Remarks");

                    b.Property<decimal?>("RetailPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("RetailPrice");

                    b.Property<string>("SimplifiedNamePinyin")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("SimplifiedNamePinyin");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int")
                        .HasColumnName("UpdateBy");

                    b.Property<string>("UpdateName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("UpdateName");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdateTime");

                    b.Property<decimal?>("WholesalePrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("WholesalePrice");

                    b.HasKey("ID");

                    b.ToTable("ParticlesInfo");
                });

            modelBuilder.Entity("AdjustmentSys.Entity.UserInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CreateBy")
                        .HasColumnType("int")
                        .HasColumnName("CreateBy");

                    b.Property<string>("CreateName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CreateName");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateTime");

                    b.Property<string>("Office")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Office");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Phone");

                    b.Property<string>("Remark")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Remark");

                    b.Property<bool>("State")
                        .HasColumnType("bit")
                        .HasColumnName("State");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int")
                        .HasColumnName("UpdateBy");

                    b.Property<string>("UpdateName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("UpdateName");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdateTime");

                    b.Property<int>("UserLevel")
                        .HasColumnType("int")
                        .HasColumnName("UserLevel");

                    b.Property<string>("UserLevelName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UserLevelName");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("UserName");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("UserPassword");

                    b.HasKey("ID");

                    b.ToTable("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
