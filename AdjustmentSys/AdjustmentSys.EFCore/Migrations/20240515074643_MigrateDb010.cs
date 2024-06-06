using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineCabinet");

            migrationBuilder.CreateTable(
                name: "DeviceInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "设备编组"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "名称"),
                    DeviceType = table.Column<int>(type: "int", nullable: false, comment: "设备类型"),
                    IPAddress = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "IP地址"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    CreateBy = table.Column<int>(type: "int", nullable: false, comment: "创建人"),
                    CreateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "创建人名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceInfo", x => x.ID);
                },
                comment: "设备信息表");

            migrationBuilder.CreateTable(
                name: "DeviceMedicineCabinetRelation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineCabinetCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "药柜组code编号"),
                    MedicineCabinetId = table.Column<int>(type: "int", nullable: false, comment: "药柜id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceMedicineCabinetRelation", x => x.ID);
                },
                comment: "设备和药柜组关联信息表");

            migrationBuilder.CreateTable(
                name: "MedicineCabinetInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "名称"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "编号"),
                    Specifications = table.Column<int>(type: "int", nullable: true, comment: "规格，1=大药柜，2=小药柜"),
                    RowCount = table.Column<int>(type: "int", nullable: false, comment: "横向个数"),
                    ColCount = table.Column<int>(type: "int", nullable: false, comment: "纵向个数"),
                    Remark = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "备注")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineCabinetInfo", x => x.ID);
                },
                comment: "药柜信息主表");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceInfo");

            migrationBuilder.DropTable(
                name: "DeviceMedicineCabinetRelation");

            migrationBuilder.DropTable(
                name: "MedicineCabinetInfo");

            migrationBuilder.CreateTable(
                name: "MedicineCabinet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColCount = table.Column<int>(type: "int", nullable: false, comment: "纵向个数"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "名称"),
                    Remark = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "备注"),
                    RowCount = table.Column<int>(type: "int", nullable: false, comment: "横向个数")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineCabinet", x => x.ID);
                },
                comment: "药柜信息主表");
        }
    }
}