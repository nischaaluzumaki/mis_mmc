using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mis_mmc.Migrations
{
    public partial class supdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_admitted",
                table: "StudentModels",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "pid",
                table: "StudentModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "sem_year",
                table: "StudentModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentModels_pid",
                table: "StudentModels",
                column: "pid");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentModels_ProgramModels_pid",
                table: "StudentModels",
                column: "pid",
                principalTable: "ProgramModels",
                principalColumn: "s_no");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentModels_ProgramModels_pid",
                table: "StudentModels");

            migrationBuilder.DropIndex(
                name: "IX_StudentModels_pid",
                table: "StudentModels");

            migrationBuilder.DropColumn(
                name: "is_admitted",
                table: "StudentModels");

            migrationBuilder.DropColumn(
                name: "pid",
                table: "StudentModels");

            migrationBuilder.DropColumn(
                name: "sem_year",
                table: "StudentModels");
        }
    }
}
