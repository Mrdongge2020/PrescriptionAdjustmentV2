using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb020 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEnable",
                table: "DeviceInfo",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "是否启用");

            migrationBuilder.AddColumn<string>(
                name: "MedicineCabinetCode",
                table: "DeviceInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "设备药柜编号");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnable",
                table: "DeviceInfo");

            migrationBuilder.DropColumn(
                name: "MedicineCabinetCode",
                table: "DeviceInfo");
        }
    }
}
