using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class Identifiers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModuleCode",
                table: "Submissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentID",
                table: "Submissions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuleCode",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Submissions");
        }
    }
}
