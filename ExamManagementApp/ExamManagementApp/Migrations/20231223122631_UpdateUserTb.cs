using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamManagementApp.Migrations
{
    public partial class UpdateUserTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "passwordHash",
                table: "Users",
                newName: "JobTitle");

            migrationBuilder.RenameColumn(
                name: "roomId",
                table: "Schools",
                newName: "Code");

            migrationBuilder.AlterColumn<int>(
                name: "accessLevel",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "Users",
                newName: "passwordHash");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Schools",
                newName: "roomId");

            migrationBuilder.AlterColumn<int>(
                name: "accessLevel",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
