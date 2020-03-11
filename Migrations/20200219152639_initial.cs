using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Code360_Management.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Nationality = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<long>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<int>(nullable: false),
                    AddmissionType = table.Column<int>(nullable: false),
                    NextOfKinName = table.Column<string>(nullable: true),
                    NextOfKinEmail = table.Column<string>(nullable: true),
                    NextOfKinPhone = table.Column<long>(nullable: false),
                    NextOfKinDocumentUrl = table.Column<string>(nullable: true),
                    BVN = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "AddmissionType", "Address", "BVN", "DateOfBirth", "Email", "Gender", "Image", "MaritalStatus", "Name", "Nationality", "NextOfKinDocumentUrl", "NextOfKinEmail", "NextOfKinName", "NextOfKinPhone", "Phone" },
                values: new object[] { 5, 1, null, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cokar@gmail.com", 0, null, 0, "Cokar", 0, null, null, null, 0L, 9074778383L });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "AddmissionType", "Address", "BVN", "DateOfBirth", "Email", "Gender", "Image", "MaritalStatus", "Name", "Nationality", "NextOfKinDocumentUrl", "NextOfKinEmail", "NextOfKinName", "NextOfKinPhone", "Phone" },
                values: new object[] { 6, 0, null, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "georgeebisike@gmail.com", 0, null, 0, "Ebisike George", 0, null, null, null, 0L, 9074778383L });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "AddmissionType", "Address", "BVN", "DateOfBirth", "Email", "Gender", "Image", "MaritalStatus", "Name", "Nationality", "NextOfKinDocumentUrl", "NextOfKinEmail", "NextOfKinName", "NextOfKinPhone", "Phone" },
                values: new object[] { 7, 1, null, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pelumi@gmail.com", 1, null, 0, "Pelumi Richard", 0, null, null, null, 0L, 9074778383L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
