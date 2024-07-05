using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb013 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParticlesName",
                table: "LocalDataPrescriptionDetailRecord",
                newName: "ParticlesNameHIS");

            migrationBuilder.RenameColumn(
                name: "ParticlesName",
                table: "LocalDataPrescriptionDetail",
                newName: "ParticlesNameHIS");

            migrationBuilder.RenameColumn(
                name: "ParticlesName",
                table: "DataPrescriptionDetail",
                newName: "ParticlesNameHIS");

            migrationBuilder.AlterColumn<string>(
                name: "UsageMethod",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "处方使用方式",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "处方使用方式");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterID",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "挂单号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "挂单号");

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionType",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "处方类型，住院或门诊",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "处方类型，住院或门诊");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentType",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "处方缴费类型",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "处方缴费类型");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "缴费状态",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "缴费状态");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField3",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField2",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "UsageMethod",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "处方使用方式",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "处方使用方式");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterID",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "挂单号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "挂单号");

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionType",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "处方类型，住院或门诊",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "处方类型，住院或门诊");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentType",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "处方缴费类型",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "处方缴费类型");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "缴费状态",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "缴费状态");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField3",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField2",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField1",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "BatchNumber",
                table: "LocalDataPrescriptionDetailRecord",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "颗粒批号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "颗粒批号");

            migrationBuilder.AlterColumn<string>(
                name: "BatchNumber",
                table: "LocalDataPrescriptionDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "颗粒批号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "颗粒批号");

            migrationBuilder.AlterColumn<string>(
                name: "BatchNumber",
                table: "DataPrescriptionDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "颗粒批号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "颗粒批号");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterID",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "挂单号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "挂单号");

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionType",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "处方类型，住院或门诊",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "处方类型，住院或门诊");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentType",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "处方缴费类型",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "处方缴费类型");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "DataPrescription",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "缴费状态",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "缴费状态");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField3",
                table: "DataPrescription",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField2",
                table: "DataPrescription",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField1",
                table: "DataPrescription",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "预留字段1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParticlesNameHIS",
                table: "LocalDataPrescriptionDetailRecord",
                newName: "ParticlesName");

            migrationBuilder.RenameColumn(
                name: "ParticlesNameHIS",
                table: "LocalDataPrescriptionDetail",
                newName: "ParticlesName");

            migrationBuilder.RenameColumn(
                name: "ParticlesNameHIS",
                table: "DataPrescriptionDetail",
                newName: "ParticlesName");

            migrationBuilder.AlterColumn<string>(
                name: "UsageMethod",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "处方使用方式",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "处方使用方式");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterID",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "挂单号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "挂单号");

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionType",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "处方类型，住院或门诊",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "处方类型，住院或门诊");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentType",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "处方缴费类型",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "处方缴费类型");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "缴费状态",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "缴费状态");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField3",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField2",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "UsageMethod",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "处方使用方式",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "处方使用方式");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterID",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "挂单号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "挂单号");

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionType",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "处方类型，住院或门诊",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "处方类型，住院或门诊");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentType",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "处方缴费类型",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "处方缴费类型");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "缴费状态",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "缴费状态");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField3",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField2",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField1",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "BatchNumber",
                table: "LocalDataPrescriptionDetailRecord",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "颗粒批号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "颗粒批号");

            migrationBuilder.AlterColumn<string>(
                name: "BatchNumber",
                table: "LocalDataPrescriptionDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "颗粒批号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "颗粒批号");

            migrationBuilder.AlterColumn<string>(
                name: "BatchNumber",
                table: "DataPrescriptionDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "颗粒批号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "颗粒批号");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterID",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "挂单号",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "挂单号");

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionType",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "处方类型，住院或门诊",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "处方类型，住院或门诊");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentType",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "处方缴费类型",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "处方缴费类型");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "DataPrescription",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "缴费状态",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "缴费状态");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField3",
                table: "DataPrescription",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField2",
                table: "DataPrescription",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "预留字段1");

            migrationBuilder.AlterColumn<string>(
                name: "BackupField1",
                table: "DataPrescription",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "预留字段1",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "预留字段1");
        }
    }
}
