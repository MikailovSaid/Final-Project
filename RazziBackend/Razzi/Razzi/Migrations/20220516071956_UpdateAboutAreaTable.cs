using Microsoft.EntityFrameworkCore.Migrations;

namespace Razzi.Migrations
{
    public partial class UpdateAboutAreaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackImg",
                table: "AboutAreas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontImg",
                table: "AboutAreas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackImg",
                table: "AboutAreas");

            migrationBuilder.DropColumn(
                name: "FrontImg",
                table: "AboutAreas");
        }
    }
}
