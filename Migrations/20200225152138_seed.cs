using Microsoft.EntityFrameworkCore.Migrations;

namespace Code360_Management.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Students",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Guarantors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _student_id = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<long>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    MaritalStatus = table.Column<int>(nullable: false),
                    Nationality = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guarantors", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Guarantors",
                columns: new[] { "ID", "Address", "Email", "FirstName", "Gender", "LastName", "MaritalStatus", "Nationality", "Phone", "_student_id" },
                values: new object[] { 1, "20 wawe park", null, "Ekueme", 0, "Jonathan", 0, 0, 902345432L, 0 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Cokar", "Segun" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Ebisike", "George" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Pelumi", "Temi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guarantors");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 5,
                column: "Name",
                value: "Cokar");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 6,
                column: "Name",
                value: "Ebisike George");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 7,
                column: "Name",
                value: "Pelumi Richard");
        }
    }
}
