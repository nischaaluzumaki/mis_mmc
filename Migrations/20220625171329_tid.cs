using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mis_mmc.Migrations
{
    public partial class tid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tid",
                table: "CourseModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseModels_tid",
                table: "CourseModels",
                column: "tid");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseModels_TeacherModels_tid",
                table: "CourseModels",
                column: "tid",
                principalTable: "TeacherModels",
                principalColumn: "s_no");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseModels_TeacherModels_tid",
                table: "CourseModels");

            migrationBuilder.DropIndex(
                name: "IX_CourseModels_tid",
                table: "CourseModels");

            migrationBuilder.DropColumn(
                name: "tid",
                table: "CourseModels");
        }
    }
}
