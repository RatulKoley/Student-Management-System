using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS_Data.Migrations
{
    /// <inheritdoc />
    public partial class All_Table_column_drop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "students");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "students");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "staffs");

            migrationBuilder.DropColumn(
                name: "last_login_date",
                table: "staffs");

            migrationBuilder.DropColumn(
                name: "last_password_change",
                table: "staffs");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "staffs");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "salaries");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "salaries");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "marks");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "marks");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "classes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "subjects",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "subjects",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "students",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "students",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "staffs",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_login_date",
                table: "staffs",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_password_change",
                table: "staffs",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "staffs",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "salaries",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "salaries",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "marks",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "marks",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "classes",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "classes",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
