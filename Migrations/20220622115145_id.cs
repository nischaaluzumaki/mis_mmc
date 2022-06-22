using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mis_mmc.Migrations
{
    public partial class id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "uid",
                table: "TeacherModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "uid",
                table: "StudentModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "uid",
                table: "BookIssueModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "uid",
                table: "TeacherModels");

            migrationBuilder.DropColumn(
                name: "uid",
                table: "StudentModels");

            migrationBuilder.DropColumn(
                name: "uid",
                table: "BookIssueModels");
        }
    }
}
