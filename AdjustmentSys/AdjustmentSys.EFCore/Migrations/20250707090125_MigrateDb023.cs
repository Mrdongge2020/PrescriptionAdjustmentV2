using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "名称"),
                    ChineseName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "中文名称"),
                    DataValue = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "值"),
                    DataValueType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "值类型"),
                    DeviceId = table.Column<int>(type: "int", nullable: false, comment: "设备id"),
                    DeviceType = table.Column<int>(type: "int", nullable: false, comment: "设备类型")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigInfo", x => x.ID);
                },
                comment: "系统配置表");

            migrationBuilder.CreateTable(
                name: "MenuInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "菜单名称"),
                    ObjName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "控件名称"),
                    Level = table.Column<int>(type: "int", nullable: false, comment: "菜单等级,1,2"),
                    ParentName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "父级菜单控件名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuInfo", x => x.ID);
                },
                comment: "系统菜单表");

            migrationBuilder.CreateTable(
                name: "PermissionInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelID = table.Column<int>(type: "int", nullable: false, comment: "权限等级ID"),
                    MenuID = table.Column<int>(type: "int", nullable: false, comment: "菜单ID")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionInfo", x => x.ID);
                },
                comment: "角色菜单权限表");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigInfo");

            migrationBuilder.DropTable(
                name: "MenuInfo");

            migrationBuilder.DropTable(
                name: "PermissionInfo");
        }
    }
}
