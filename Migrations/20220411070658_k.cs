using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mis_mmc.Migrations
{
    public partial class k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProgramModels_fid",
                table: "ProgramModels",
                column: "fid");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramModels_FacultyModels_fid",
                table: "ProgramModels",
                column: "fid",
                principalTable: "FacultyModels",
                principalColumn: "s_no",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramModels_FacultyModels_fid",
                table: "ProgramModels");

            migrationBuilder.DropIndex(
                name: "IX_ProgramModels_fid",
                table: "ProgramModels");
        }
    }
}
