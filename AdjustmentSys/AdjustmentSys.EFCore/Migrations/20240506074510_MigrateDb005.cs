using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManufacturerInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "厂家名称"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    CreateBy = table.Column<int>(type: "int", nullable: false, comment: "创建人"),
                    CreateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "创建人名称"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    UpdateBy = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UpdateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "更新人名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturerInfo", x => x.ID);
                },
                comment: "厂家信息表");

            migrationBuilder.CreateTable(
                name: "ManufacturerResolutionCode",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false, comment: "厂家id"),
                    ExampleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "示例code"),
                    LargePackagingCodeIndex = table.Column<int>(type: "int", nullable: false, comment: "大包装码开始位置"),
                    LargePackagingCodeLength = table.Column<int>(type: "int", nullable: false, comment: "大包装码长度"),
                    PackagingTypeIndex = table.Column<int>(type: "int", nullable: true, comment: "包装类型开始位置"),
                    PackagingTypeLength = table.Column<int>(type: "int", nullable: true, comment: "包装类型长度"),
                    BatchNumberIndex = table.Column<int>(type: "int", nullable: true, comment: "批号开始位置"),
                    BatchNumberLength = table.Column<int>(type: "int", nullable: true, comment: "批号长度"),
                    ValidityPeriodIndex = table.Column<int>(type: "int", nullable: true, comment: "有效期开始位置"),
                    ValidityPeriodLength = table.Column<int>(type: "int", nullable: true, comment: "有效期长度"),
                    EquivalentIndex = table.Column<int>(type: "int", nullable: true, comment: "当量开始位置"),
                    EquivalentLength = table.Column<int>(type: "int", nullable: true, comment: "当量长度"),
                    DensityIndex = table.Column<int>(type: "int", nullable: false, comment: "密度开始位置"),
                    DensityLength = table.Column<int>(type: "int", nullable: false, comment: "密度长度"),
                    LoadingCapacityIndex = table.Column<int>(type: "int", nullable: false, comment: "装量开始位置"),
                    LoadingCapacityLength = table.Column<int>(type: "int", nullable: false, comment: "装量长度")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturerResolutionCode", x => x.ID);
                },
                comment: "厂家解析码表");

            migrationBuilder.CreateTable(
                name: "MedicineCabinet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "名称"),
                    RowCount = table.Column<int>(type: "int", nullable: false, comment: "横向个数"),
                    ColCount = table.Column<int>(type: "int", nullable: false, comment: "纵向个数"),
                    Remark = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "备注")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineCabinet", x => x.ID);
                },
                comment: "药柜信息主表");

            migrationBuilder.CreateTable(
                name: "ParticleProhibitionRule",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "规则名称"),
                    FirstParticlesID = table.Column<int>(type: "int", nullable: false, comment: "第一味颗粒"),
                    SecondParticlesID = table.Column<int>(type: "int", nullable: false, comment: "第二味颗粒"),
                    Remark = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    CreateBy = table.Column<int>(type: "int", nullable: false, comment: "创建人"),
                    CreateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "创建人名称"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    UpdateBy = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UpdateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "更新人名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticleProhibitionRule", x => x.ID);
                },
                comment: "颗粒相融规则");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManufacturerInfo");

            migrationBuilder.DropTable(
                name: "ManufacturerResolutionCode");

            migrationBuilder.DropTable(
                name: "MedicineCabinet");

            migrationBuilder.DropTable(
                name: "ParticleProhibitionRule");
        }
    }
}
