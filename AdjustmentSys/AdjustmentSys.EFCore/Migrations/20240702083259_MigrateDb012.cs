using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceID",
                table: "LocalDataPrescriptionInfoRecord");

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "调配设备名称");

            migrationBuilder.AddColumn<int>(
                name: "TimeConsumingSecond",
                table: "LocalDataPrescriptionInfoRecord",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "调配耗时秒");

            migrationBuilder.AlterColumn<int>(
                name: "ParticlesID",
                table: "LocalDataPrescriptionDetailRecord",
                type: "int",
                nullable: false,
                comment: "我库颗粒id，默认-1",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "我库颗粒编号，默认-1");

            migrationBuilder.AlterColumn<int>(
                name: "ParticlesID",
                table: "LocalDataPrescriptionDetail",
                type: "int",
                nullable: false,
                comment: "我库颗粒id，默认-1",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "我库颗粒编号，默认-1");

            migrationBuilder.AlterColumn<int>(
                name: "ParticlesID",
                table: "DataPrescriptionDetail",
                type: "int",
                nullable: false,
                comment: "我库颗粒id，默认-1",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "我库颗粒编号，默认-1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "LocalDataPrescriptionInfoRecord");

            migrationBuilder.DropColumn(
                name: "TimeConsumingSecond",
                table: "LocalDataPrescriptionInfoRecord");

            migrationBuilder.AddColumn<int>(
                name: "DeviceID",
                table: "LocalDataPrescriptionInfoRecord",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "调配设备");

            migrationBuilder.AlterColumn<int>(
                name: "ParticlesID",
                table: "LocalDataPrescriptionDetailRecord",
                type: "int",
                nullable: false,
                comment: "我库颗粒编号，默认-1",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "我库颗粒id，默认-1");

            migrationBuilder.AlterColumn<int>(
                name: "ParticlesID",
                table: "LocalDataPrescriptionDetail",
                type: "int",
                nullable: false,
                comment: "我库颗粒编号，默认-1",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "我库颗粒id，默认-1");

            migrationBuilder.AlterColumn<int>(
                name: "ParticlesID",
                table: "DataPrescriptionDetail",
                type: "int",
                nullable: false,
                comment: "我库颗粒编号，默认-1",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "我库颗粒id，默认-1");
        }
    }
}
