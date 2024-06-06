using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicineCabinetDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineCabinetId = table.Column<int>(type: "int", nullable: false, comment: "药柜id"),
                    CoordinateX = table.Column<int>(type: "int", nullable: false, comment: "横坐标"),
                    CoordinateY = table.Column<int>(type: "int", nullable: false, comment: "纵坐标"),
                    ParticlesID = table.Column<int>(type: "int", nullable: true, comment: "颗粒id"),
                    ValidityTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "效期至"),
                    BatchNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "批号"),
                    Stock = table.Column<float>(type: "real", nullable: true, comment: "库存"),
                    BottleHeadAdjustAmount = table.Column<float>(type: "real", nullable: true, comment: "瓶头累计调整量"),
                    TotalErrorAmount = table.Column<float>(type: "real", nullable: true, comment: "累计的误差量"),
                    TotalUsedAmount = table.Column<float>(type: "real", nullable: true, comment: "总共使用数量"),
                    CurentAdjustAmount = table.Column<float>(type: "real", nullable: true, comment: "本次调整量"),
                    LastWeightAmount = table.Column<float>(type: "real", nullable: true, comment: "上次称重的重量"),
                    EmptyBottleWeight = table.Column<float>(type: "real", nullable: true, comment: "空瓶重量"),
                    Density = table.Column<float>(type: "real", nullable: true, comment: "密度"),
                    DensityCoefficient = table.Column<float>(type: "real", nullable: true, comment: "密度系数"),
                    RFID = table.Column<int>(type: "int", nullable: true, comment: "rfd"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    CreateBy = table.Column<int>(type: "int", nullable: false, comment: "创建人"),
                    CreateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "创建人名称"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    UpdateBy = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UpdateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "更新人名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineCabinetDetail", x => x.ID);
                },
                comment: "药柜详情表");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineCabinetDetail");
        }
    }
}
