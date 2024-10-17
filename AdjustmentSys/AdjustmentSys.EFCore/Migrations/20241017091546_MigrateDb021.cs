using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb021 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeviceType",
                table: "SystemParameterInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "设备类型");

            migrationBuilder.AlterColumn<int>(
                name: "ParticleCode",
                table: "MedicineCabinetOperationLogInfo",
                type: "int",
                nullable: false,
                comment: "颗粒编号",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "颗粒编号");

            migrationBuilder.AddColumn<int>(
                name: "ParticleId",
                table: "MedicineCabinetOperationLogInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "颗粒Id");

            migrationBuilder.AddColumn<float>(
                name: "LastCoefficientErrorAmount",
                table: "MedicineCabinetDetail",
                type: "real",
                nullable: true,
                comment: "上次系数误差量");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceType",
                table: "SystemParameterInfo");

            migrationBuilder.DropColumn(
                name: "ParticleId",
                table: "MedicineCabinetOperationLogInfo");

            migrationBuilder.DropColumn(
                name: "LastCoefficientErrorAmount",
                table: "MedicineCabinetDetail");

            migrationBuilder.AlterColumn<string>(
                name: "ParticleCode",
                table: "MedicineCabinetOperationLogInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "颗粒编号",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "颗粒编号");
        }
    }
}
