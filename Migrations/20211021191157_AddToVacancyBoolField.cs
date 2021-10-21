using Microsoft.EntityFrameworkCore.Migrations;

namespace hh.Migrations
{
    public partial class AddToVacancyBoolField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Vision",
                table: "Vacancies",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vision",
                table: "Vacancies");
        }
    }
}
