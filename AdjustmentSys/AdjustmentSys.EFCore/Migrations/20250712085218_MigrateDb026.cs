using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb026 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrintConfigInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "项名称"),
                    ItemChineseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "项中文名称"),
                    DataValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "值"),
                    DataValueType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "值类型"),
                    DataValuMin = table.Column<double>(type: "float", nullable: true, comment: "最小值"),
                    DataValuMax = table.Column<double>(type: "float", nullable: true, comment: "最大值"),
                    DeviceId = table.Column<int>(type: "int", nullable: false, comment: "设备id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintConfigInfo", x => x.ID);
                },
                comment: "打印配置表");

            migrationBuilder.CreateTable(
                name: "PrintItemInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "项名称"),
                    ItemChineseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "项中文名称"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "抬头"),
                    CheckedValue = table.Column<int>(type: "int", nullable: false, comment: "选中值"),
                    Sort = table.Column<double>(type: "float", nullable: false, comment: "排序"),
                    DeviceId = table.Column<int>(type: "int", nullable: false, comment: "设备id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintItemInfo", x => x.ID);
                },
                comment: "打印项表");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrintConfigInfo");

            migrationBuilder.DropTable(
                name: "PrintItemInfo");
        }
    }
}
