using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mis_mmc.Migrations
{
    public partial class book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookModels",
                columns: table => new
                {
                    s_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    author = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    publication = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    stock = table.Column<int>(type: "int", nullable: false),
                    is_issued = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    sem_year = table.Column<int>(type: "int", nullable: true),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    expiry_date = table.Column<DateOnly>(type: "date", nullable: true),
                    pid = table.Column<int>(type: "int", nullable: true),
                    sid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookModels", x => x.s_no);
                    table.ForeignKey(
                        name: "FK_BookModels_ProgramModels_pid",
                        column: x => x.pid,
                        principalTable: "ProgramModels",
                        principalColumn: "s_no");
                    table.ForeignKey(
                        name: "FK_BookModels_StudentModels_sid",
                        column: x => x.sid,
                        principalTable: "StudentModels",
                        principalColumn: "s_no");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BookModels_pid",
                table: "BookModels",
                column: "pid");

            migrationBuilder.CreateIndex(
                name: "IX_BookModels_sid",
                table: "BookModels",
                column: "sid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookModels");
        }
    }
}
