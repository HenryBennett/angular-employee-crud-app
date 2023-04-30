using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAPI.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Employees");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
