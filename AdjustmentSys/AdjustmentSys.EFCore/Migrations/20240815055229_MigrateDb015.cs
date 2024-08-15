using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb015 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "ParticlesInfoExtend");

            migrationBuilder.DropColumn(
                name: "VaildUntil",
                table: "ParticlesInfoExtend");

            migrationBuilder.AddColumn<string>(
                name: "ValidityTime",
                table: "LocalDataPrescriptionDetailRecord",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "有效期至");

            migrationBuilder.AddColumn<string>(
                name: "ValidityTime",
                table: "LocalDataPrescriptionDetail",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "有效期至");

            migrationBuilder.CreateTable(
                name: "PrescriptionLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "处方编号"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "处方创建时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionLog", x => x.ID);
                },
                comment: "处方日志表，主要用于创建处方判断处方编号是否存在");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescriptionLog");

            migrationBuilder.DropColumn(
                name: "ValidityTime",
                table: "LocalDataPrescriptionDetailRecord");

            migrationBuilder.DropColumn(
                name: "ValidityTime",
                table: "LocalDataPrescriptionDetail");

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "ParticlesInfoExtend",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "批号");

            migrationBuilder.AddColumn<string>(
                name: "VaildUntil",
                table: "ParticlesInfoExtend",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "有效期至");
        }
    }
}
