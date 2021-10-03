using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initialContracter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publisher_Book",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "Publisher_Rank",
                table: "Publisher");

            migrationBuilder.AddColumn<string>(
                name: "Contracter_ContactNumber",
                table: "Contracters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contracter_EmailAddress",
                table: "Contracters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contracter_ContactNumber",
                table: "Contracters");

            migrationBuilder.DropColumn(
                name: "Contracter_EmailAddress",
                table: "Contracters");

            migrationBuilder.AddColumn<string>(
                name: "Publisher_Book",
                table: "Publisher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Publisher_Rank",
                table: "Publisher",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
