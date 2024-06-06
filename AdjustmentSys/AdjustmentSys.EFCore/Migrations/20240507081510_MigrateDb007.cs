using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdjustmentSys.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrateDb007 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullNamePinyin",
                table: "ParticlesInfo");

            migrationBuilder.DropColumn(
                name: "SimplifiedNamePinyin",
                table: "ParticlesInfo");

            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "ParticlesInfo",
                newName: "Remark");

            migrationBuilder.AlterTable(
                name: "ParticlesInfo",
                comment: "颗粒信息表",
                oldComment: "本地处方详情表");

            migrationBuilder.AddColumn<string>(
                name: "NameFullPinyin",
                table: "ParticlesInfo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                comment: "名称简称全拼");

            migrationBuilder.AddColumn<string>(
                name: "NameSimplifiedPinyin",
                table: "ParticlesInfo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                comment: "名称简称首字母拼音");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameFullPinyin",
                table: "ParticlesInfo");

            migrationBuilder.DropColumn(
                name: "NameSimplifiedPinyin",
                table: "ParticlesInfo");

            migrationBuilder.RenameColumn(
                name: "Remark",
                table: "ParticlesInfo",
                newName: "Remarks");

            migrationBuilder.AlterTable(
                name: "ParticlesInfo",
                comment: "本地处方详情表",
                oldComment: "颗粒信息表");

            migrationBuilder.AddColumn<string>(
                name: "FullNamePinyin",
                table: "ParticlesInfo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                comment: "名称全拼");

            migrationBuilder.AddColumn<string>(
                name: "SimplifiedNamePinyin",
                table: "ParticlesInfo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                comment: "名称简称");
        }
    }
}
