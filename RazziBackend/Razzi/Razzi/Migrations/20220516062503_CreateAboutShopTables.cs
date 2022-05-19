using Microsoft.EntityFrameworkCore.Migrations;

namespace Razzi.Migrations
{
    public partial class CreateAboutShopTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeftSideAboutShops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LongText = table.Column<string>(nullable: true),
                    ShortText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeftSideAboutShops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RightSideAboutShops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LongText = table.Column<string>(nullable: true),
                    ShortText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RightSideAboutShops", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeftSideAboutShops");

            migrationBuilder.DropTable(
                name: "RightSideAboutShops");
        }
    }
}
