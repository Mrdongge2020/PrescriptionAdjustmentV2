using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb009 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Density",
                table: "ParticlesInfo");

            migrationBuilder.DropColumn(
                name: "DoseLimit",
                table: "ParticlesInfo");

            migrationBuilder.DropColumn(
                name: "Equivalent",
                table: "ParticlesInfo");

            migrationBuilder.DropColumn(
                name: "HisCode",
                table: "ParticlesInfo");

            migrationBuilder.DropColumn(
                name: "PackageNumber",
                table: "ParticlesInfo");

            migrationBuilder.DropColumn(
                name: "RetailPrice",
                table: "ParticlesInfo");

            migrationBuilder.DropColumn(
                name: "WholesalePrice",
                table: "ParticlesInfo");

            migrationBuilder.CreateTable(
                name: "ParticlesInfoExtend",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticlesID = table.Column<int>(type: "int", nullable: false, comment: "颗粒id"),
                    HisCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "His码"),
                    HisName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "HIS名称"),
                    Density = table.Column<float>(type: "real", nullable: false, comment: "颗粒密度"),
                    Equivalent = table.Column<float>(type: "real", nullable: false, comment: "颗粒当量"),
                    DoseLimit = table.Column<float>(type: "real", maxLength: 50, nullable: true, comment: "剂量上限"),
                    PackageNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "大包装码"),
                    BatchNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "批号"),
                    VaildUntil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "有效期至"),
                    WholesalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "批发价"),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "零售价")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticlesInfoExtend", x => x.ID);
                },
                comment: "颗粒详情信息");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticlesInfoExtend");

            migrationBuilder.AddColumn<float>(
                name: "Density",
                table: "ParticlesInfo",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                comment: "颗粒密度");

            migrationBuilder.AddColumn<float>(
                name: "DoseLimit",
                table: "ParticlesInfo",
                type: "real",
                maxLength: 50,
                nullable: true,
                comment: "剂量上限");

            migrationBuilder.AddColumn<float>(
                name: "Equivalent",
                table: "ParticlesInfo",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                comment: "颗粒当量");

            migrationBuilder.AddColumn<string>(
                name: "HisCode",
                table: "ParticlesInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "His码");

            migrationBuilder.AddColumn<string>(
                name: "PackageNumber",
                table: "ParticlesInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "大包装码");

            migrationBuilder.AddColumn<decimal>(
                name: "RetailPrice",
                table: "ParticlesInfo",
                type: "decimal(18,2)",
                nullable: true,
                comment: "零售价");

            migrationBuilder.AddColumn<decimal>(
                name: "WholesalePrice",
                table: "ParticlesInfo",
                type: "decimal(18,2)",
                nullable: true,
                comment: "批发价");
        }
    }
}
