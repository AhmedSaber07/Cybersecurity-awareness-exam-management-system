using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamManagementApp.Migrations
{
    public partial class updateResultTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Registerations");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Registerations");

            migrationBuilder.RenameColumn(
                name: "roomId",
                table: "Results",
                newName: "userAnswer");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Results",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "tokenExpireTime",
                table: "Registerations",
                newName: "EntryDate");

            migrationBuilder.RenameColumn(
                name: "roomId",
                table: "Registerations",
                newName: "Code");

            migrationBuilder.AddColumn<int>(
                name: "questionPoint",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "questionPoint",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "schoolId",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Results",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "userAnswer",
                table: "Results",
                newName: "roomId");

            migrationBuilder.RenameColumn(
                name: "EntryDate",
                table: "Registerations",
                newName: "tokenExpireTime");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Registerations",
                newName: "roomId");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Results",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Registerations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Registerations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
