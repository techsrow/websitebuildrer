using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteBuilder.Migrations
{
    public partial class servicurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceUrl",
                table: "Services",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceUrl",
                table: "Services");
        }
    }
}
