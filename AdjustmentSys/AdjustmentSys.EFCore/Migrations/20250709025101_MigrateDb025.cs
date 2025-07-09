using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ParentName",
                table: "MenuInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "父级菜单控件名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "父级菜单控件名称");

            migrationBuilder.AlterColumn<string>(
                name: "ObjName",
                table: "MenuInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "控件名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "控件名称");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MenuInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "菜单名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "菜单名称");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ParentName",
                table: "MenuInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "父级菜单控件名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "父级菜单控件名称");

            migrationBuilder.AlterColumn<string>(
                name: "ObjName",
                table: "MenuInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "控件名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "控件名称");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MenuInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "菜单名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "菜单名称");
        }
    }
}
