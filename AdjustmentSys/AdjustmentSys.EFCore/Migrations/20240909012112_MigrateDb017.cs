using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb017 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "DensityCoefficient",
                table: "ParticlesInfoExtend",
                type: "real",
                nullable: true,
                comment: "密度系数");

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "ParticlesInfo",
                type: "int",
                maxLength: 20,
                nullable: false,
                comment: "编号",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "编号");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DensityCoefficient",
                table: "ParticlesInfoExtend");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ParticlesInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "编号",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20,
                oldComment: "编号");
        }
    }
}
