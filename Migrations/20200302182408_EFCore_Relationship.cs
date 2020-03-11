using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Code360_Management.Migrations
{
    public partial class EFCore_Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Guarantors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false),
                    Program_Id = table.Column<int>(nullable: false),
                    Supervisor = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    studentForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Name = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Program_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Project_Status = table.Column<int>(nullable: false),
                    ProjectUrl = table.Column<string>(nullable: true),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentGuarantors",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    GuarantorId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentGuarantors", x => new { x.GuarantorId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_studentGuarantors_Guarantors_GuarantorId",
                        column: x => x.GuarantorId,
                        principalTable: "Guarantors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentGuarantors_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Program_Name = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Course_Id = table.Column<int>(nullable: false),
                    BatchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programs_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_in_batch",
                columns: table => new
                {
                    Student_Id = table.Column<int>(nullable: false),
                    Batch_Id = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Student_Status = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_in_batch", x => new { x.Batch_Id, x.Student_Id });
                    table.ForeignKey(
                        name: "FK_student_in_batch_Batches_Batch_Id",
                        column: x => x.Batch_Id,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_in_batch_Students_Student_Id",
                        column: x => x.Student_Id,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentCourses", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_studentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "programCourses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    ProgramID = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programCourses", x => new { x.CourseId, x.ProgramID });
                    table.ForeignKey(
                        name: "FK_programCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_programCourses_Programs_ProgramID",
                        column: x => x.ProgramID,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guarantors_StudentID",
                table: "Guarantors",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_programCourses_ProgramID",
                table: "programCourses",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_BatchId",
                table: "Programs",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StudentId",
                table: "Projects",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_student_in_batch_Student_Id",
                table: "student_in_batch",
                column: "Student_Id");

            migrationBuilder.CreateIndex(
                name: "IX_studentCourses_StudentId",
                table: "studentCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_studentGuarantors_StudentId",
                table: "studentGuarantors",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guarantors_Students_StudentID",
                table: "Guarantors",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guarantors_Students_StudentID",
                table: "Guarantors");

            migrationBuilder.DropTable(
                name: "programCourses");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "student_in_batch");

            migrationBuilder.DropTable(
                name: "studentCourses");

            migrationBuilder.DropTable(
                name: "studentGuarantors");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_Guarantors_StudentID",
                table: "Guarantors");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Guarantors");
        }
    }
}
