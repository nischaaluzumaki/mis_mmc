using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mis_mmc.Migrations
{
    public partial class addmigrationns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignmentModels",
                columns: table => new
                {
                    s_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published_date = table.Column<DateOnly>(type: "date", nullable: false),
                    file = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    due_date = table.Column<DateOnly>(type: "date", nullable: false),
                    cid = table.Column<int>(type: "int", nullable: false),
                    tid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentModels", x => x.s_no);
                    table.ForeignKey(
                        name: "FK_AssignmentModels_CourseModels_cid",
                        column: x => x.cid,
                        principalTable: "CourseModels",
                        principalColumn: "s_no",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentModels_TeacherModels_tid",
                        column: x => x.tid,
                        principalTable: "TeacherModels",
                        principalColumn: "s_no",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LmsModels",
                columns: table => new
                {
                    s_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    file = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cid = table.Column<int>(type: "int", nullable: false),
                    tid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LmsModels", x => x.s_no);
                    table.ForeignKey(
                        name: "FK_LmsModels_CourseModels_cid",
                        column: x => x.cid,
                        principalTable: "CourseModels",
                        principalColumn: "s_no",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LmsModels_TeacherModels_tid",
                        column: x => x.tid,
                        principalTable: "TeacherModels",
                        principalColumn: "s_no",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentModels_cid",
                table: "AssignmentModels",
                column: "cid");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentModels_tid",
                table: "AssignmentModels",
                column: "tid");

            migrationBuilder.CreateIndex(
                name: "IX_LmsModels_cid",
                table: "LmsModels",
                column: "cid");

            migrationBuilder.CreateIndex(
                name: "IX_LmsModels_tid",
                table: "LmsModels",
                column: "tid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentModels");

            migrationBuilder.DropTable(
                name: "LmsModels");
        }
    }
}
