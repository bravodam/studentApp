using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Code360_Management.Migrations
{
    public partial class EFCore_Relationship_PaymentSalaryCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "compnay",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compnay", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employmentHistories",
                columns: table => new
                {
                    CompID = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employmentHistories", x => new { x.StudentId, x.CompID });
                    table.ForeignKey(
                        name: "FK_employmentHistories_compnay_CompID",
                        column: x => x.CompID,
                        principalTable: "compnay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employmentHistories_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountPaid = table.Column<double>(nullable: false),
                    DatePaid = table.Column<DateTime>(nullable: false),
                    PaymentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payHistory_payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "salaries",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<int>(nullable: false),
                    salary = table.Column<double>(nullable: false),
                    ExpectedPayDay = table.Column<DateTime>(nullable: false),
                    EmploymentHistory_ID = table.Column<int>(nullable: false),
                    employmentHistoryStudentId = table.Column<int>(nullable: true),
                    employmentHistoryCompID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salaries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_salaries_employmentHistories_employmentHistoryStudentId_employmentHistoryCompID",
                        columns: x => new { x.employmentHistoryStudentId, x.employmentHistoryCompID },
                        principalTable: "employmentHistories",
                        principalColumns: new[] { "StudentId", "CompID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employmentHistories_CompID",
                table: "employmentHistories",
                column: "CompID");

            migrationBuilder.CreateIndex(
                name: "IX_payHistory_PaymentId",
                table: "payHistory",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_payments_StudentId",
                table: "payments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_salaries_employmentHistoryStudentId_employmentHistoryCompID",
                table: "salaries",
                columns: new[] { "employmentHistoryStudentId", "employmentHistoryCompID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payHistory");

            migrationBuilder.DropTable(
                name: "salaries");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "employmentHistories");

            migrationBuilder.DropTable(
                name: "compnay");
        }
    }
}
