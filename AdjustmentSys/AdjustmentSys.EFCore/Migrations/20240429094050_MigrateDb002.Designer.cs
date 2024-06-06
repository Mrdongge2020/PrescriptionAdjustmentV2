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
    [Migration("20240429094050_MigrateDb002")]
    partial class MigrateDb002
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
