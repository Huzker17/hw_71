using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace hh.Migrations
{
    public partial class CreateNewItemNamedVacancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Graduation_Summary_SummaryId",
                table: "Graduation");

            migrationBuilder.DropForeignKey(
                name: "FK_Summary_AspNetUsers_UserId",
                table: "Summary");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExp_Summary_SummaryId",
                table: "WorkExp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkExp",
                table: "WorkExp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Summary",
                table: "Summary");

            migrationBuilder.RenameTable(
                name: "WorkExp",
                newName: "Works");

            migrationBuilder.RenameTable(
                name: "Summary",
                newName: "Summaries");

            migrationBuilder.RenameIndex(
                name: "IX_WorkExp_SummaryId",
                table: "Works",
                newName: "IX_Works_SummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Summary_UserId",
                table: "Summaries",
                newName: "IX_Summaries_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Works",
                table: "Works",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Summaries",
                table: "Summaries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Salary = table.Column<int>(type: "integer", nullable: false),
                    Requirments = table.Column<string>(type: "text", nullable: true),
                    From = table.Column<int>(type: "integer", nullable: false),
                    To = table.Column<int>(type: "integer", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacancies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    VacancyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_VacancyId",
                table: "Category",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_UserId",
                table: "Vacancies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Graduation_Summaries_SummaryId",
                table: "Graduation",
                column: "SummaryId",
                principalTable: "Summaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Summaries_AspNetUsers_UserId",
                table: "Summaries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Summaries_SummaryId",
                table: "Works",
                column: "SummaryId",
                principalTable: "Summaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Graduation_Summaries_SummaryId",
                table: "Graduation");

            migrationBuilder.DropForeignKey(
                name: "FK_Summaries_AspNetUsers_UserId",
                table: "Summaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Summaries_SummaryId",
                table: "Works");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Works",
                table: "Works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Summaries",
                table: "Summaries");

            migrationBuilder.RenameTable(
                name: "Works",
                newName: "WorkExp");

            migrationBuilder.RenameTable(
                name: "Summaries",
                newName: "Summary");

            migrationBuilder.RenameIndex(
                name: "IX_Works_SummaryId",
                table: "WorkExp",
                newName: "IX_WorkExp_SummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Summaries_UserId",
                table: "Summary",
                newName: "IX_Summary_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkExp",
                table: "WorkExp",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Summary",
                table: "Summary",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Graduation_Summary_SummaryId",
                table: "Graduation",
                column: "SummaryId",
                principalTable: "Summary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Summary_AspNetUsers_UserId",
                table: "Summary",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExp_Summary_SummaryId",
                table: "WorkExp",
                column: "SummaryId",
                principalTable: "Summary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
