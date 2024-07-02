using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb011 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "DataPrescriptionDetail",
                comment: "待下载处方详情表",
                oldComment: "本地处方详情表");

            migrationBuilder.AlterTable(
                name: "DataPrescription",
                comment: "待下载处方表",
                oldComment: "本地处方表");

            migrationBuilder.CreateTable(
                name: "AgreementPrescriptionDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgreementPrescriptionId = table.Column<int>(type: "int", nullable: false, comment: "协定处方id"),
                    Particles = table.Column<int>(type: "int", nullable: false, comment: "颗粒id"),
                    DoseHerb = table.Column<float>(type: "real", nullable: false, comment: "饮片剂量"),
                    Equivalent = table.Column<float>(type: "real", nullable: false, comment: "当量"),
                    Dose = table.Column<float>(type: "real", nullable: false, comment: "颗粒剂量"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "单价")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgreementPrescriptionDetail", x => x.ID);
                },
                comment: "协定处方详情表");

            migrationBuilder.CreateTable(
                name: "AgreementPrescriptionInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "处方名称"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "描述"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    CreateBy = table.Column<int>(type: "int", nullable: false, comment: "创建人"),
                    CreateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "创建人名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgreementPrescriptionInfo", x => x.ID);
                },
                comment: "协定处方表");

            migrationBuilder.CreateTable(
                name: "LocalDataPrescriptionDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "处方唯一编号"),
                    ParticleOrder = table.Column<int>(type: "int", nullable: false, comment: "颗粒序号"),
                    ParticlesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "HIS颗粒名称"),
                    ParticlesCodeHIS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "颗粒HIS码"),
                    ParticlesID = table.Column<int>(type: "int", nullable: false, comment: "我库颗粒编号，默认-1"),
                    BatchNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "颗粒批号"),
                    DoseHerb = table.Column<float>(type: "real", nullable: false, comment: "颗粒饮片剂量"),
                    Equivalent = table.Column<float>(type: "real", nullable: false, comment: "颗粒当量"),
                    Dose = table.Column<float>(type: "real", nullable: false, comment: "颗粒剂量"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "药品单价")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalDataPrescriptionDetail", x => x.ID);
                },
                comment: "本地处方详情表");

            migrationBuilder.CreateTable(
                name: "LocalDataPrescriptionDetailRecord",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "处方唯一编号"),
                    ParticleOrder = table.Column<int>(type: "int", nullable: false, comment: "颗粒序号"),
                    ParticlesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "HIS颗粒名称"),
                    ParticlesCodeHIS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "颗粒HIS码"),
                    ParticlesID = table.Column<int>(type: "int", nullable: false, comment: "我库颗粒编号，默认-1"),
                    BatchNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "颗粒批号"),
                    DoseHerb = table.Column<float>(type: "real", nullable: false, comment: "颗粒饮片剂量"),
                    Equivalent = table.Column<float>(type: "real", nullable: false, comment: "颗粒当量"),
                    Dose = table.Column<float>(type: "real", nullable: false, comment: "颗粒剂量"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "药品单价")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalDataPrescriptionDetailRecord", x => x.ID);
                },
                comment: "本地处方详情表记录");

            migrationBuilder.CreateTable(
                name: "LocalDataPrescriptionInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "处方编号"),
                    PatientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "患者姓名"),
                    PatientSex = table.Column<int>(type: "int", nullable: false, comment: "患者性别"),
                    PatientAge = table.Column<int>(type: "int", nullable: true, comment: "患者年龄"),
                    PatientBirthMonth = table.Column<int>(type: "int", nullable: true, comment: "出生月份"),
                    PatientBirthDay = table.Column<int>(type: "int", nullable: true, comment: "出生日期"),
                    PatientTel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "患者联系方式"),
                    PatientEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "患者邮件"),
                    PatientLocation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "患者的位置信息"),
                    DoctorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "开方医生"),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "科室"),
                    PrescriptionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "协定处方名称"),
                    CreateName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "处方创建人"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "处方创建时间"),
                    ValuerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "划价员"),
                    ValueSn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "划价单号"),
                    ValuationTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "划价时间"),
                    RegisterID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "挂单号"),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "处方缴费类型"),
                    PaymentStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "缴费状态"),
                    PrescriptionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "处方类型，住院或门诊"),
                    ImportTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "导入时间"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "处方付数"),
                    TaskFrequency = table.Column<int>(type: "int", nullable: false, comment: "分服次数"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "单付单价"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "处方总价"),
                    DetailedCount = table.Column<int>(type: "int", nullable: false, comment: "处方明细条数"),
                    ProcessStatus = table.Column<int>(type: "int", nullable: false, comment: "处方状态"),
                    PrescriptionSource = table.Column<int>(type: "int", nullable: false, comment: "处方来源"),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Remarks"),
                    UsageMethod = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "处方使用方式"),
                    DownloadName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "下载人名称"),
                    DownloadBy = table.Column<int>(type: "int", nullable: false, comment: "下载人"),
                    DownloadTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "下载时间"),
                    BackupField1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "预留字段1"),
                    BackupField2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "预留字段1"),
                    BackupField3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "预留字段1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalDataPrescriptionInfo", x => x.ID);
                },
                comment: "本地处方表");

            migrationBuilder.CreateTable(
                name: "LocalDataPrescriptionInfoRecord",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "处方编号"),
                    PatientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "患者姓名"),
                    PatientSex = table.Column<int>(type: "int", nullable: false, comment: "患者性别"),
                    PatientAge = table.Column<int>(type: "int", nullable: true, comment: "患者年龄"),
                    PatientBirthMonth = table.Column<int>(type: "int", nullable: true, comment: "出生月份"),
                    PatientBirthDay = table.Column<int>(type: "int", nullable: true, comment: "出生日期"),
                    PatientTel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "患者联系方式"),
                    PatientEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "患者邮件"),
                    PatientLocation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "患者的位置信息"),
                    DoctorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "开方医生"),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "科室"),
                    PrescriptionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "协定处方名称"),
                    CreateName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "处方创建人"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "处方创建时间"),
                    ValuerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "划价员"),
                    ValueSn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "划价单号"),
                    ValuationTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "划价时间"),
                    RegisterID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "挂单号"),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "处方缴费类型"),
                    PaymentStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "缴费状态"),
                    PrescriptionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "处方类型，住院或门诊"),
                    ImportTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "导入时间"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "处方付数"),
                    TaskFrequency = table.Column<int>(type: "int", nullable: false, comment: "分服次数"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "单付单价"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "处方总价"),
                    DetailedCount = table.Column<int>(type: "int", nullable: false, comment: "处方明细条数"),
                    ProcessStatus = table.Column<int>(type: "int", nullable: false, comment: "处方状态"),
                    PrescriptionSource = table.Column<int>(type: "int", nullable: false, comment: "处方来源"),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Remarks"),
                    UsageMethod = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "处方使用方式"),
                    DownloadName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "下载人名称"),
                    DownloadBy = table.Column<int>(type: "int", nullable: false, comment: "下载人"),
                    DownloadTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "下载时间"),
                    BackupField1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "预留字段1"),
                    BackupField2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "预留字段1"),
                    BackupField3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "预留字段1"),
                    AllocateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "调配员姓名"),
                    DeviceID = table.Column<int>(type: "int", nullable: false, comment: "调配设备"),
                    BoxNumber = table.Column<int>(type: "int", nullable: false, comment: "调配盒数"),
                    TimeConsuming = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "调配耗时"),
                    AnalysisResult = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "处方分析结果"),
                    CompleteTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "完成时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalDataPrescriptionInfoRecord", x => x.ID);
                },
                comment: "本地处方表记录");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgreementPrescriptionDetail");

            migrationBuilder.DropTable(
                name: "AgreementPrescriptionInfo");

            migrationBuilder.DropTable(
                name: "LocalDataPrescriptionDetail");

            migrationBuilder.DropTable(
                name: "LocalDataPrescriptionDetailRecord");

            migrationBuilder.DropTable(
                name: "LocalDataPrescriptionInfo");

            migrationBuilder.DropTable(
                name: "LocalDataPrescriptionInfoRecord");

            migrationBuilder.AlterTable(
                name: "DataPrescriptionDetail",
                comment: "本地处方详情表",
                oldComment: "待下载处方详情表");

            migrationBuilder.AlterTable(
                name: "DataPrescription",
                comment: "本地处方表",
                oldComment: "待下载处方表");
        }
    }
}
