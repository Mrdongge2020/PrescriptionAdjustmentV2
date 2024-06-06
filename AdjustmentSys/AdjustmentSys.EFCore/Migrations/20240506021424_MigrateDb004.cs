using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "UserInfo",
                comment: "用户信息表");

            migrationBuilder.AlterTable(
                name: "ParticlesInfo",
                comment: "本地处方详情表");

            migrationBuilder.AlterTable(
                name: "LevelInfo",
                comment: "权限等级表");

            migrationBuilder.AlterTable(
                name: "DoctorInfo",
                comment: "医生信息表");

            migrationBuilder.AlterTable(
                name: "DepartmentInfo",
                comment: "科室信息表");

            migrationBuilder.AlterTable(
                name: "DataPrescriptionDetail",
                comment: "本地处方详情表");

            migrationBuilder.AlterTable(
                name: "DataPrescription",
                comment: "本地处方表");

            migrationBuilder.AlterColumn<string>(
                name: "UserPassword",
                table: "UserInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "用户密码",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "用户名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "UserLevelName",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "用户权限等级名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserLevel",
                table: "UserInfo",
                type: "int",
                nullable: false,
                comment: "用户权限等级",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "UserInfo",
                type: "datetime2",
                nullable: true,
                comment: "更新时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateName",
                table: "UserInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "更新人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdateBy",
                table: "UserInfo",
                type: "int",
                nullable: true,
                comment: "更新人",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "State",
                table: "UserInfo",
                type: "bit",
                nullable: false,
                comment: "账号状态：1：可用，0禁用",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "UserInfo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "备注",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "联系电话",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Office",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "办公室",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "UserInfo",
                type: "datetime2",
                nullable: false,
                comment: "创建时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreateName",
                table: "UserInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "创建人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreateBy",
                table: "UserInfo",
                type: "int",
                nullable: false,
                comment: "创建人",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "UserInfo",
                type: "int",
                nullable: false,
                comment: "ID主键",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "WholesalePrice",
                table: "ParticlesInfo",
                type: "decimal(18,2)",
                nullable: true,
                comment: "批发价",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "ParticlesInfo",
                type: "datetime2",
                nullable: true,
                comment: "更新时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateName",
                table: "ParticlesInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "更新人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdateBy",
                table: "ParticlesInfo",
                type: "int",
                nullable: true,
                comment: "更新人",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SimplifiedNamePinyin",
                table: "ParticlesInfo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "名称简称",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<decimal>(
                name: "RetailPrice",
                table: "ParticlesInfo",
                type: "decimal(18,2)",
                nullable: true,
                comment: "零售价",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "ParticlesInfo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "备注",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PackageNumber",
                table: "ParticlesInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "大包装码",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ParticlesInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "名称简称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "ParticlesInfo",
                type: "int",
                nullable: false,
                comment: "厂家id",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ListingNumber",
                table: "ParticlesInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "上市编号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HisCode",
                table: "ParticlesInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "His码",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FullNamePinyin",
                table: "ParticlesInfo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "名称全拼",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "ParticlesInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "名称全称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<float>(
                name: "Equivalent",
                table: "ParticlesInfo",
                type: "real",
                nullable: false,
                comment: "颗粒当量",
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "DoseLimit",
                table: "ParticlesInfo",
                type: "real",
                maxLength: 50,
                nullable: true,
                comment: "剂量上限",
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Density",
                table: "ParticlesInfo",
                type: "real",
                nullable: false,
                comment: "颗粒密度",
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "ParticlesInfo",
                type: "datetime2",
                nullable: false,
                comment: "创建时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreateName",
                table: "ParticlesInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "创建人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreateBy",
                table: "ParticlesInfo",
                type: "int",
                nullable: false,
                comment: "创建人",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ParticlesInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "编号",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ParticlesInfo",
                type: "int",
                nullable: false,
                comment: "ID主键",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "LevelName",
                table: "LevelInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "等级名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "LevelInfo",
                type: "int",
                nullable: false,
                comment: "ID主键",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "DoctorInfo",
                type: "datetime2",
                nullable: true,
                comment: "更新时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateName",
                table: "DoctorInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "更新人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdateBy",
                table: "DoctorInfo",
                type: "int",
                nullable: true,
                comment: "更新人",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "DoctorInfo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "备注",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "DoctorInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "医生电话",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Office",
                table: "DoctorInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "医生办公室",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "DoctorInfo",
                type: "bit",
                nullable: false,
                comment: "是否删除",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "InitialPinyin",
                table: "DoctorInfo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "医生名称首字母简称",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "EMail",
                table: "DoctorInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "医生Email",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorName",
                table: "DoctorInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "医生名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorDepartmentName",
                table: "DoctorInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "医生所属科室名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorDepartmentID",
                table: "DoctorInfo",
                type: "int",
                nullable: true,
                comment: "医生所属科室id",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteTime",
                table: "DoctorInfo",
                type: "datetime2",
                nullable: true,
                comment: "删除时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeleteName",
                table: "DoctorInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "删除人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeleteBy",
                table: "DoctorInfo",
                type: "int",
                nullable: true,
                comment: "删除人",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "DoctorInfo",
                type: "datetime2",
                nullable: false,
                comment: "创建时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreateName",
                table: "DoctorInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "创建人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreateBy",
                table: "DoctorInfo",
                type: "int",
                nullable: false,
                comment: "创建人",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "DoctorInfo",
                type: "int",
                nullable: false,
                comment: "ID主键",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "DepartmentInfo",
                type: "datetime2",
                nullable: true,
                comment: "更新时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateName",
                table: "DepartmentInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "更新人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdateBy",
                table: "DepartmentInfo",
                type: "int",
                nullable: true,
                comment: "更新人",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "DepartmentInfo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "备注",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "DepartmentInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "科室名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "DepartmentInfo",
                type: "datetime2",
                nullable: false,
                comment: "创建时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreateName",
                table: "DepartmentInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "创建人名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreateBy",
                table: "DepartmentInfo",
                type: "int",
                nullable: false,
                comment: "创建人",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ContactsPhone",
                table: "DepartmentInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "科室联系人电话",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contacts",
                table: "DepartmentInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "科室联系人",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "DepartmentInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "科室地址",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "DepartmentInfo",
                type: "int",
                nullable: false,
                comment: "ID主键",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "DataPrescriptionDetail",
                type: "decimal(18,2)",
                nullable: false,
                comment: "药品单价",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionID",
                table: "DataPrescriptionDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "处方唯一编号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ParticlesName",
                table: "DataPrescriptionDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "HIS颗粒名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ParticlesID",
                table: "DataPrescriptionDetail",
                type: "int",
                nullable: false,
                comment: "我库颗粒编号，默认-1",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ParticlesCodeHIS",
                table: "DataPrescriptionDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "颗粒HIS码",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ParticleOrder",
                table: "DataPrescriptionDetail",
                type: "int",
                nullable: false,
                comment: "颗粒序号",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "Equivalent",
                table: "DataPrescriptionDetail",
                type: "real",
                nullable: false,
                comment: "颗粒当量",
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "DoseHerb",
                table: "DataPrescriptionDetail",
                type: "real",
                nullable: false,
                comment: "颗粒饮片剂量",
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "Dose",
                table: "DataPrescriptionDetail",
                type: "real",
                nullable: false,
                comment: "颗粒剂量",
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "BatchNumber",
                table: "DataPrescriptionDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "颗粒批号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "DataPrescriptionDetail",
                type: "int",
                nullable: false,
                comment: "ID主键",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ValuerName",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "划价员",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ValueSn",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "划价单号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValuationTime",
                table: "DataPrescription",
                type: "datetime2",
                nullable: false,
                comment: "划价时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "UsageMethod",
                table: "DataPrescription",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "处方使用方式",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "DataPrescription",
                type: "decimal(18,2)",
                nullable: false,
                comment: "单付单价",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "DataPrescription",
                type: "decimal(18,2)",
                nullable: false,
                comment: "处方总价",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "TaskFrequency",
                table: "DataPrescription",
                type: "int",
                nullable: false,
                comment: "分服次数",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "DataPrescription",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "Remarks",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegisterID",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "挂单号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "DataPrescription",
                type: "int",
                nullable: false,
                comment: "处方付数",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessStatus",
                table: "DataPrescription",
                type: "int",
                nullable: false,
                comment: "处方状态",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionType",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "处方类型，住院或门诊",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "PrescriptionSource",
                table: "DataPrescription",
                type: "int",
                nullable: false,
                comment: "处方来源",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionName",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "协定处方名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionID",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "处方编号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentType",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "处方缴费类型",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "DataPrescription",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "缴费状态",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "PatientTel",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "患者联系方式",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientSex",
                table: "DataPrescription",
                type: "int",
                nullable: false,
                comment: "患者性别",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PatientName",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "患者姓名",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PatientLocation",
                table: "DataPrescription",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "患者的位置信息",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PatientEmail",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "患者邮件",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientBirthMonth",
                table: "DataPrescription",
                type: "int",
                nullable: true,
                comment: "出生月份",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientBirthDay",
                table: "DataPrescription",
                type: "int",
                nullable: true,
                comment: "出生日期",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientAge",
                table: "DataPrescription",
                type: "int",
                nullable: true,
                comment: "患者年龄",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportTime",
                table: "DataPrescription",
                type: "datetime2",
                nullable: false,
                comment: "导入时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorName",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "开方医生",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "DetailedCount",
                table: "DataPrescription",
                type: "int",
                nullable: false,
                comment: "处方明细条数",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "科室",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "DataPrescription",
                type: "datetime2",
                nullable: false,
                comment: "处方创建时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreateName",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "处方创建人",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BackupField3",
                table: "DataPrescription",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "BackupField2",
                table: "DataPrescription",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "BackupField1",
                table: "DataPrescription",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "DataPrescription",
                type: "int",
                nullable: false,
                comment: "ID主键",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "UserInfo",
                oldComment: "用户信息表");

            migrationBuilder.AlterTable(
                name: "ParticlesInfo",
                oldComment: "本地处方详情表");

            migrationBuilder.AlterTable(
                name: "LevelInfo",
                oldComment: "权限等级表");

            migrationBuilder.AlterTable(
                name: "DoctorInfo",
                oldComment: "医生信息表");

            migrationBuilder.AlterTable(
                name: "DepartmentInfo",
                oldComment: "科室信息表");

            migrationBuilder.AlterTable(
                name: "DataPrescriptionDetail",
                oldComment: "本地处方详情表");

            migrationBuilder.AlterTable(
                name: "DataPrescription",
                oldComment: "本地处方表");

            migrationBuilder.AlterColumn<string>(
                name: "UserPassword",
                table: "UserInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "用户密码");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "用户名称");

            migrationBuilder.AlterColumn<string>(
                name: "UserLevelName",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "用户权限等级名称");

            migrationBuilder.AlterColumn<int>(
                name: "UserLevel",
                table: "UserInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "用户权限等级");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "UserInfo",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "更新时间");

            migrationBuilder.AlterColumn<string>(
                name: "UpdateName",
                table: "UserInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "更新人名称");

            migrationBuilder.AlterColumn<int>(
                name: "UpdateBy",
                table: "UserInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "更新人");

            migrationBuilder.AlterColumn<bool>(
                name: "State",
                table: "UserInfo",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "账号状态：1：可用，0禁用");

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "UserInfo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "备注");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "联系电话");

            migrationBuilder.AlterColumn<string>(
                name: "Office",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "办公室");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "UserInfo",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "创建时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreateName",
                table: "UserInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "创建人名称");

            migrationBuilder.AlterColumn<int>(
                name: "CreateBy",
                table: "UserInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "创建人");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "UserInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "ID主键")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "WholesalePrice",
                table: "ParticlesInfo",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true,
                oldComment: "批发价");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "ParticlesInfo",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "更新时间");

            migrationBuilder.AlterColumn<string>(
                name: "UpdateName",
                table: "ParticlesInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "更新人名称");

            migrationBuilder.AlterColumn<int>(
                name: "UpdateBy",
                table: "ParticlesInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "更新人");

            migrationBuilder.AlterColumn<string>(
                name: "SimplifiedNamePinyin",
                table: "ParticlesInfo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "名称简称");

            migrationBuilder.AlterColumn<decimal>(
                name: "RetailPrice",
                table: "ParticlesInfo",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true,
                oldComment: "零售价");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "ParticlesInfo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "备注");

            migrationBuilder.AlterColumn<string>(
                name: "PackageNumber",
                table: "ParticlesInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "大包装码");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ParticlesInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "名称简称");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "ParticlesInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "厂家id");

            migrationBuilder.AlterColumn<string>(
                name: "ListingNumber",
                table: "ParticlesInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "上市编号");

            migrationBuilder.AlterColumn<string>(
                name: "HisCode",
                table: "ParticlesInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "His码");

            migrationBuilder.AlterColumn<string>(
                name: "FullNamePinyin",
                table: "ParticlesInfo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "名称全拼");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "ParticlesInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "名称全称");

            migrationBuilder.AlterColumn<float>(
                name: "Equivalent",
                table: "ParticlesInfo",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldComment: "颗粒当量");

            migrationBuilder.AlterColumn<float>(
                name: "DoseLimit",
                table: "ParticlesInfo",
                type: "real",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "剂量上限");

            migrationBuilder.AlterColumn<float>(
                name: "Density",
                table: "ParticlesInfo",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldComment: "颗粒密度");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "ParticlesInfo",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "创建时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreateName",
                table: "ParticlesInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "创建人名称");

            migrationBuilder.AlterColumn<int>(
                name: "CreateBy",
                table: "ParticlesInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "创建人");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ParticlesInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "编号");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ParticlesInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "ID主键")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "LevelName",
                table: "LevelInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "等级名称");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "LevelInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "ID主键")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "DoctorInfo",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "更新时间");

            migrationBuilder.AlterColumn<string>(
                name: "UpdateName",
                table: "DoctorInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "更新人名称");

            migrationBuilder.AlterColumn<int>(
                name: "UpdateBy",
                table: "DoctorInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "更新人");

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "DoctorInfo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "备注");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "DoctorInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "医生电话");

            migrationBuilder.AlterColumn<string>(
                name: "Office",
                table: "DoctorInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "医生办公室");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "DoctorInfo",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "是否删除");

            migrationBuilder.AlterColumn<string>(
                name: "InitialPinyin",
                table: "DoctorInfo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "医生名称首字母简称");

            migrationBuilder.AlterColumn<string>(
                name: "EMail",
                table: "DoctorInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "医生Email");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorName",
                table: "DoctorInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "医生名称");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorDepartmentName",
                table: "DoctorInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "医生所属科室名称");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorDepartmentID",
                table: "DoctorInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "医生所属科室id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteTime",
                table: "DoctorInfo",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "删除时间");

            migrationBuilder.AlterColumn<string>(
                name: "DeleteName",
                table: "DoctorInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "删除人名称");

            migrationBuilder.AlterColumn<int>(
                name: "DeleteBy",
                table: "DoctorInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "删除人");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "DoctorInfo",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "创建时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreateName",
                table: "DoctorInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "创建人名称");

            migrationBuilder.AlterColumn<int>(
                name: "CreateBy",
                table: "DoctorInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "创建人");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "DoctorInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "ID主键")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "DepartmentInfo",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "更新时间");

            migrationBuilder.AlterColumn<string>(
                name: "UpdateName",
                table: "DepartmentInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "更新人名称");

            migrationBuilder.AlterColumn<int>(
                name: "UpdateBy",
                table: "DepartmentInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "更新人");

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "DepartmentInfo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "备注");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "DepartmentInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "科室名称");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "DepartmentInfo",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "创建时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreateName",
                table: "DepartmentInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "创建人名称");

            migrationBuilder.AlterColumn<int>(
                name: "CreateBy",
                table: "DepartmentInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "创建人");

            migrationBuilder.AlterColumn<string>(
                name: "ContactsPhone",
                table: "DepartmentInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "科室联系人电话");

            migrationBuilder.AlterColumn<string>(
                name: "Contacts",
                table: "DepartmentInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "科室联系人");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "DepartmentInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "科室地址");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "DepartmentInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "ID主键")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "DataPrescriptionDetail",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "药品单价");

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionID",
                table: "DataPrescriptionDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "处方唯一编号");

            migrationBuilder.AlterColumn<string>(
                name: "ParticlesName",
                table: "DataPrescriptionDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "HIS颗粒名称");

            migrationBuilder.AlterColumn<int>(
                name: "ParticlesID",
                table: "DataPrescriptionDetail",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "我库颗粒编号，默认-1");

            migrationBuilder.AlterColumn<string>(
                name: "ParticlesCodeHIS",
                table: "DataPrescriptionDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "颗粒HIS码");

            migrationBuilder.AlterColumn<int>(
                name: "ParticleOrder",
                table: "DataPrescriptionDetail",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "颗粒序号");

            migrationBuilder.AlterColumn<float>(
                name: "Equivalent",
                table: "DataPrescriptionDetail",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldComment: "颗粒当量");

            migrationBuilder.AlterColumn<float>(
                name: "DoseHerb",
                table: "DataPrescriptionDetail",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldComment: "颗粒饮片剂量");

            migrationBuilder.AlterColumn<float>(
                name: "Dose",
                table: "DataPrescriptionDetail",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldComment: "颗粒剂量");

            migrationBuilder.AlterColumn<string>(
                name: "BatchNumber",
                table: "DataPrescriptionDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "颗粒批号");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "DataPrescriptionDetail",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "ID主键")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ValuerName",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "划价员");

            migrationBuilder.AlterColumn<string>(
                name: "ValueSn",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "划价单号");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValuationTime",
                table: "DataPrescription",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "划价时间");

            migrationBuilder.AlterColumn<string>(
                name: "UsageMethod",
                table: "DataPrescription",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "处方使用方式");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "DataPrescription",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "单付单价");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "DataPrescription",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "处方总价");

            migrationBuilder.AlterColumn<int>(
                name: "TaskFrequency",
                table: "DataPrescription",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "分服次数");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "DataPrescription",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true,
                oldComment: "Remarks");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterID",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "挂单号");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "DataPrescription",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "处方付数");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessStatus",
                table: "DataPrescription",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "处方状态");

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionType",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "处方类型，住院或门诊");

            migrationBuilder.AlterColumn<int>(
                name: "PrescriptionSource",
                table: "DataPrescription",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "处方来源");

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionName",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "协定处方名称");

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionID",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "处方编号");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentType",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "处方缴费类型");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "DataPrescription",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "缴费状态");

            migrationBuilder.AlterColumn<string>(
                name: "PatientTel",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "患者联系方式");

            migrationBuilder.AlterColumn<int>(
                name: "PatientSex",
                table: "DataPrescription",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "患者性别");

            migrationBuilder.AlterColumn<string>(
                name: "PatientName",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "患者姓名");

            migrationBuilder.AlterColumn<string>(
                name: "PatientLocation",
                table: "DataPrescription",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "患者的位置信息");

            migrationBuilder.AlterColumn<string>(
                name: "PatientEmail",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "患者邮件");

            migrationBuilder.AlterColumn<int>(
                name: "PatientBirthMonth",
                table: "DataPrescription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "出生月份");

            migrationBuilder.AlterColumn<int>(
                name: "PatientBirthDay",
                table: "DataPrescription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "出生日期");

            migrationBuilder.AlterColumn<int>(
                name: "PatientAge",
                table: "DataPrescription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "患者年龄");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportTime",
                table: "DataPrescription",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "导入时间");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorName",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "开方医生");

            migrationBuilder.AlterColumn<int>(
                name: "DetailedCount",
                table: "DataPrescription",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "处方明细条数");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "科室");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "DataPrescription",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "处方创建时间");

            migrationBuilder.AlterColumn<string>(
                name: "CreateName",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "处方创建人");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField3",
                table: "DataPrescription",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField2",
                table: "DataPrescription",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField1",
                table: "DataPrescription",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "DataPrescription",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "ID主键")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
