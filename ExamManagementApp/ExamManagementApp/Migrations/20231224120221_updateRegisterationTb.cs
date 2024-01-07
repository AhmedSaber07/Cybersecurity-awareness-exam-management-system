using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamManagementApp.Migrations
{
    public partial class updateRegisterationTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Registerations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Registerations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
