using Microsoft.EntityFrameworkCore.Migrations;

namespace Code360_Management.Migrations
{
    public partial class editedEF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programs_Batches_BatchId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_BatchId",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "Program_Id",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "studentForeignKey",
                table: "Batches");

            migrationBuilder.AddColumn<int>(
                name: "BatchName",
                table: "Programs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "programmeId",
                table: "Batches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Batches_programmeId",
                table: "Batches",
                column: "programmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Programs_programmeId",
                table: "Batches",
                column: "programmeId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Programs_programmeId",
                table: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_Batches_programmeId",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "BatchName",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "programmeId",
                table: "Batches");

            migrationBuilder.AddColumn<int>(
                name: "Program_Id",
                table: "Batches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "studentForeignKey",
                table: "Batches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Programs_BatchId",
                table: "Programs",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_Batches_BatchId",
                table: "Programs",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
