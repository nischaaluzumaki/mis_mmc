using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mis_mmc.Migrations
{
    public partial class yid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_returned",
                table: "BookIssueModels",
                type: "tinyint(1)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_returned",
                table: "BookIssueModels");
        }
    }
}
