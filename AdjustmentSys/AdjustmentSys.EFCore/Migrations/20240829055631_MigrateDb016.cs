using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb016 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "DensityCoefficient",
                table: "ManufacturerInfo",
                type: "real",
                nullable: true,
                comment: "密度系数");

            migrationBuilder.CreateTable(
                name: "MedicineCabinetOperationLogInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticleCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "颗粒编号"),
                    ParticleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "颗粒名称"),
                    MedicineCabinetOperationLogType = table.Column<int>(type: "int", nullable: false, comment: "操作类型"),
                    DeviceName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "设备名称"),
                    OperationLogDecribe = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "操作描述"),
                    InitialQuantity = table.Column<float>(type: "real", nullable: false, comment: "初始量"),
                    CurrentWeightQuantity = table.Column<float>(type: "real", nullable: false, comment: "当前称重量"),
                    UsedQuantity = table.Column<float>(type: "real", nullable: false, comment: "使用量"),
                    AddQuantity = table.Column<float>(type: "real", nullable: false, comment: "上药量"),
                    AdjustmentQuantity = table.Column<float>(type: "real", nullable: false, comment: "调整量"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    CreateBy = table.Column<int>(type: "int", nullable: false, comment: "创建人"),
                    CreateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "创建人名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineCabinetOperationLogInfo", x => x.ID);
                },
                comment: "药柜颗粒操作日志表");

            migrationBuilder.CreateTable(
                name: "ParticleOperationLogInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticleCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "颗粒编号"),
                    ParticleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "颗粒名称"),
                    ParticleOperationLogType = table.Column<int>(type: "int", nullable: false, comment: "操作类型"),
                    DeviceName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "设备名称"),
                    OperationLogDecribe = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "操作描述"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    CreateBy = table.Column<int>(type: "int", nullable: false, comment: "创建人"),
                    CreateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "创建人名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticleOperationLogInfo", x => x.ID);
                },
                comment: "颗粒操作日志表");

            migrationBuilder.CreateTable(
                name: "SystemParameterInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterType = table.Column<int>(type: "int", nullable: false, comment: "系统参数类型"),
                    ParameterName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "参数名称"),
                    ParameterValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "参数值"),
                    ParameterDescribe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "参数描述"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    CreateBy = table.Column<int>(type: "int", nullable: false, comment: "创建人"),
                    CreateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "创建人名称"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    UpdateBy = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UpdateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "更新人名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemParameterInfo", x => x.ID);
                },
                comment: "系统参数表");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineCabinetOperationLogInfo");

            migrationBuilder.DropTable(
                name: "ParticleOperationLogInfo");

            migrationBuilder.DropTable(
                name: "SystemParameterInfo");

            migrationBuilder.DropColumn(
                name: "DensityCoefficient",
                table: "ManufacturerInfo");
        }
    }
}
