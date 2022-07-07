using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mis_mmc.Migrations
{
    public partial class exam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamModels",
                columns: table => new
                {
                    s_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    sem_year = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamModels", x => x.s_no);
                    table.ForeignKey(
                        name: "FK_ExamModels_ProgramModels_pid",
                        column: x => x.pid,
                        principalTable: "ProgramModels",
                        principalColumn: "s_no",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExamDetailsModels",
                columns: table => new
                {
                    s_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    full_marks = table.Column<int>(type: "int", nullable: false),
                    pass_marks = table.Column<int>(type: "int", nullable: false),
                    exam_date = table.Column<DateOnly>(type: "date", nullable: false),
                    time = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    cid = table.Column<int>(type: "int", nullable: false),
                    eid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamDetailsModels", x => x.s_no);
                    table.ForeignKey(
                        name: "FK_ExamDetailsModels_CourseModels_cid",
                        column: x => x.cid,
                        principalTable: "CourseModels",
                        principalColumn: "s_no",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamDetailsModels_ExamModels_eid",
                        column: x => x.eid,
                        principalTable: "ExamModels",
                        principalColumn: "s_no",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ExamDetailsModels_cid",
                table: "ExamDetailsModels",
                column: "cid");

            migrationBuilder.CreateIndex(
                name: "IX_ExamDetailsModels_eid",
                table: "ExamDetailsModels",
                column: "eid");

            migrationBuilder.CreateIndex(
                name: "IX_ExamModels_pid",
                table: "ExamModels",
                column: "pid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamDetailsModels");

            migrationBuilder.DropTable(
                name: "ExamModels");
        }
    }
}
