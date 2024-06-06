using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataPrescription",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PatientSex = table.Column<int>(type: "int", nullable: false),
                    PatientAge = table.Column<int>(type: "int", nullable: true),
                    PatientBirthMonth = table.Column<int>(type: "int", nullable: true),
                    PatientBirthDay = table.Column<int>(type: "int", nullable: true),
                    PatientTel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PatientEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PatientLocation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DoctorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrescriptionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValuerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ValueSn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ValuationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PrescriptionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImportTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TaskFrequency = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DetailedCount = table.Column<int>(type: "int", nullable: false),
                    ProcessStatus = table.Column<int>(type: "int", nullable: false),
                    PrescriptionSource = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UsageMethod = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BackupField1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BackupField2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BackupField3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPrescription", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DataPrescriptionDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParticleOrder = table.Column<int>(type: "int", nullable: false),
                    ParticlesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParticlesCodeHIS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParticlesID = table.Column<int>(type: "int", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DoseHerb = table.Column<float>(type: "real", nullable: false),
                    Equivalent = table.Column<float>(type: "real", nullable: false),
                    Dose = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPrescriptionDetail", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ParticlesInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FullNamePinyin = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SimplifiedNamePinyin = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    HisCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Density = table.Column<float>(type: "real", nullable: false),
                    Equivalent = table.Column<float>(type: "real", nullable: false),
                    DoseLimit = table.Column<float>(type: "real", maxLength: 50, nullable: true),
                    WholesalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PackageNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    ListingNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticlesInfo", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataPrescription");

            migrationBuilder.DropTable(
                name: "DataPrescriptionDetail");

            migrationBuilder.DropTable(
                name: "ParticlesInfo");
        }
    }
}
