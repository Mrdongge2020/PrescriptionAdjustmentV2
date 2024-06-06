using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb008 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "ManufacturerResolutionCode",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "创建人");

            migrationBuilder.AddColumn<string>(
                name: "CreateName",
                table: "ManufacturerResolutionCode",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "创建人名称");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "ManufacturerResolutionCode",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "创建时间");

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "ManufacturerResolutionCode",
                type: "int",
                nullable: true,
                comment: "更新人");

            migrationBuilder.AddColumn<string>(
                name: "UpdateName",
                table: "ManufacturerResolutionCode",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "更新人名称");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "ManufacturerResolutionCode",
                type: "datetime2",
                nullable: true,
                comment: "更新时间");

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "ManufacturerInfo",
                type: "int",
                nullable: true,
                comment: "删除人");

            migrationBuilder.AddColumn<string>(
                name: "DeleteName",
                table: "ManufacturerInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "删除人名称");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "ManufacturerInfo",
                type: "datetime2",
                nullable: true,
                comment: "删除时间");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "ManufacturerInfo",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "是否删除");

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "ManufacturerInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "序号");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "ManufacturerResolutionCode");

            migrationBuilder.DropColumn(
                name: "CreateName",
                table: "ManufacturerResolutionCode");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "ManufacturerResolutionCode");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "ManufacturerResolutionCode");

            migrationBuilder.DropColumn(
                name: "UpdateName",
                table: "ManufacturerResolutionCode");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "ManufacturerResolutionCode");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "ManufacturerInfo");

            migrationBuilder.DropColumn(
                name: "DeleteName",
                table: "ManufacturerInfo");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "ManufacturerInfo");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "ManufacturerInfo");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "ManufacturerInfo");
        }
    }
}
