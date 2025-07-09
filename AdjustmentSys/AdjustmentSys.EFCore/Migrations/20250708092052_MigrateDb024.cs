using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DataValuMax",
                table: "ConfigInfo",
                type: "float",
                nullable: true,
                comment: "最大值");

            migrationBuilder.AddColumn<double>(
                name: "DataValuMin",
                table: "ConfigInfo",
                type: "float",
                nullable: true,
                comment: "最小值");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataValuMax",
                table: "ConfigInfo");

            migrationBuilder.DropColumn(
                name: "DataValuMin",
                table: "ConfigInfo");
        }
    }
}
