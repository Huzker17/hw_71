using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace hh.Migrations
{
    public partial class ModeratedSummaryClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Summaries_SummaryId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Graduation_Summaries_SummaryId",
                table: "Graduation");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SummaryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Summaries");

            migrationBuilder.DropColumn(
                name: "SummaryId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Summaries",
                newName: "TgName");

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Summaries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedInUrl",
                table: "Summaries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Salary",
                table: "Summaries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SummaryId",
                table: "Graduation",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Graduation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Graduation",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Specialization = table.Column<string>(type: "text", nullable: true),
                    SummaryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificate_Summaries_SummaryId",
                        column: x => x.SummaryId,
                        principalTable: "Summaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_SummaryId",
                table: "Certificate",
                column: "SummaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Graduation_Summaries_SummaryId",
                table: "Graduation",
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

            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Summaries");

            migrationBuilder.DropColumn(
                name: "LinkedInUrl",
                table: "Summaries");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Summaries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Graduation");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Graduation");

            migrationBuilder.RenameColumn(
                name: "TgName",
                table: "Summaries",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "Summaries",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "SummaryId",
                table: "Graduation",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "SummaryId",
                table: "Categories",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SummaryId",
                table: "Categories",
                column: "SummaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Summaries_SummaryId",
                table: "Categories",
                column: "SummaryId",
                principalTable: "Summaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Graduation_Summaries_SummaryId",
                table: "Graduation",
                column: "SummaryId",
                principalTable: "Summaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
