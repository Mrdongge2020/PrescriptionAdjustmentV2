using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb027 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BedNumber",
                table: "LocalDataPrescriptionInfoRecord",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "住院床号");

            migrationBuilder.AddColumn<string>(
                name: "BedNumber",
                table: "LocalDataPrescriptionInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "住院床号");

            migrationBuilder.AddColumn<string>(
                name: "BedNumber",
                table: "DataPrescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "住院床号");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BedNumber",
                table: "LocalDataPrescriptionInfoRecord");

            migrationBuilder.DropColumn(
                name: "BedNumber",
                table: "LocalDataPrescriptionInfo");

            migrationBuilder.DropColumn(
                name: "BedNumber",
                table: "DataPrescription");
        }
    }
}
