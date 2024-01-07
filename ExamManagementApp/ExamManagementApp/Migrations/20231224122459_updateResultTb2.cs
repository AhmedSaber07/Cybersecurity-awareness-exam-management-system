using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamManagementApp.Migrations
{
    public partial class updateResultTb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "questionPoint",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "registerationId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "schoolId",
                table: "Results");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "questionPoint",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "registerationId",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "schoolId",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
