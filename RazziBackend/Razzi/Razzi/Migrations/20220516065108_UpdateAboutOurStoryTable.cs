using Microsoft.EntityFrameworkCore.Migrations;

namespace Razzi.Migrations
{
    public partial class UpdateAboutOurStoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackImg",
                table: "AboutOurStories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontImg",
                table: "AboutOurStories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackImg",
                table: "AboutOurStories");

            migrationBuilder.DropColumn(
                name: "FrontImg",
                table: "AboutOurStories");
        }
    }
}
