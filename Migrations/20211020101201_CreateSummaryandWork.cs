using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace hh.Migrations
{
    public partial class CreateSummaryandWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Summary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Gender = table.Column<bool>(type: "boolean", nullable: false),
                    Citizen = table.Column<string>(type: "text", nullable: true),
                    HaveExperinece = table.Column<bool>(type: "boolean", nullable: false),
                    GraduationLvl = table.Column<List<string>>(type: "text[]", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Summary_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Graduation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SummaryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graduation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Graduation_Summary_SummaryId",
                        column: x => x.SummaryId,
                        principalTable: "Summary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkExp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Specialization = table.Column<string>(type: "text", nullable: true),
                    Working = table.Column<string>(type: "text", nullable: true),
                    SummaryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExp_Summary_SummaryId",
                        column: x => x.SummaryId,
                        principalTable: "Summary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Graduation_SummaryId",
                table: "Graduation",
                column: "SummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Summary_UserId",
                table: "Summary",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExp_SummaryId",
                table: "WorkExp",
                column: "SummaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Graduation");

            migrationBuilder.DropTable(
                name: "WorkExp");

            migrationBuilder.DropTable(
                name: "Summary");
        }
    }
}
