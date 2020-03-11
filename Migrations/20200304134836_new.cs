using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Code360_Management.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Guarantors",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Guarantors",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Guarantors",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Guarantors",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Guarantors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Guarantors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Guarantors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "Guarantors",
                columns: new[] { "ID", "Address", "Email", "FirstName", "Gender", "LastName", "MaritalStatus", "Nationality", "Phone", "StudentID", "_student_id" },
                values: new object[] { 1, "20 wawe park", null, "Ekueme", 0, "Jonathan", 0, 0, 902345432L, null, 0 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "AddmissionType", "Address", "BVN", "DateOfBirth", "Email", "FirstName", "Gender", "ImagePath", "LastName", "MaritalStatus", "Nationality", "NextOfKinDocumentUrl", "NextOfKinEmail", "NextOfKinName", "NextOfKinPhone", "Phone" },
                values: new object[,]
                {
                    { 5, 1, null, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cokar@gmail.com", "Cokar", 0, null, "Segun", 0, 0, null, null, null, 0L, 9074778383L },
                    { 6, 0, null, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "georgeebisike@gmail.com", "Ebisike", 0, null, "George", 0, 0, null, null, null, 0L, 9074778383L },
                    { 7, 1, null, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pelumi@gmail.com", "Pelumi", 1, null, "Temi", 0, 0, null, null, null, 0L, 9074778383L }
                });
        }
    }
}
