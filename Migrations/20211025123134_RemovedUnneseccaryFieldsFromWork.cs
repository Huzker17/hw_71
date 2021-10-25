using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hh.Migrations
{
    public partial class RemovedUnneseccaryFieldsFromWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "Working",
                table: "Works");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Works",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Works",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Working",
                table: "Works",
                type: "text",
                nullable: true);
        }
    }
}
